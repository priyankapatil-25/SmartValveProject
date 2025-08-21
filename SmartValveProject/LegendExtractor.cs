using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;

[assembly: CommandClass(typeof(SmartValve.LegendExtractor))]

namespace SmartValve
{
    public class LegendExtractor
    {
        [CommandMethod("SMARTVALVE_LEGEND_EXTRACT")]
        public void ExtractValvePattern()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;


            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                PromptEntityOptions peo = new PromptEntityOptions("\nSelect valve geometry (block or loose): ");
                peo.SetRejectMessage("\nOnly graphical entities are allowed.");
                peo.AllowNone = false;
                PromptEntityResult per = ed.GetEntity(peo);
                if (per.Status != PromptStatus.OK) return;

                Entity selectedEnt = tr.GetObject(per.ObjectId, OpenMode.ForRead) as Entity;
                if (selectedEnt == null) return;

                PromptResult pr = ed.GetString(new PromptStringOptions("\nEnter valve name: ") { AllowSpaces = true });
                if (pr.Status != PromptStatus.OK || string.IsNullOrWhiteSpace(pr.StringResult)) return;
                string valveName = pr.StringResult.Trim();

                List<Entity> seedEntities = new List<Entity>();

                if (selectedEnt is BlockReference blkRef)
                {
                    DBObjectCollection exploded = new DBObjectCollection();
                    blkRef.Explode(exploded);
                    foreach (DBObject obj in exploded)
                    {
                        if (obj is Entity ent)
                        {
                            ent.TransformBy(blkRef.BlockTransform);
                            seedEntities.Add(ent);
                        }
                    }
                }
                else
                {
                    seedEntities.Add(selectedEnt);
                }

                List<PatternEntity> patternEntities = ExtractPatternFromEntities(seedEntities);
                ValvePatternLibrary.Add(valveName, patternEntities);
                ed.WriteMessage($"\nValve pattern '{valveName}' extracted with {patternEntities.Count} entities.");

                tr.Commit();
            }
        }

        public static List<PatternEntity> ExtractPatternFromEntities(List<Entity> seedEntities)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            List<PatternEntity> patternEntities = new List<PatternEntity>();

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTableRecord modelSpace = (BlockTableRecord)tr.GetObject(
                    SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForRead);

                List<Entity> allEntities = new List<Entity>();
                foreach (ObjectId id in modelSpace)
                {
                    Entity ent = tr.GetObject(id, OpenMode.ForRead) as Entity;
                    if (ent != null) allEntities.Add(ent);
                }

                double tolerance = 1.0;
                HashSet<ObjectId> visited = new HashSet<ObjectId>();
                Queue<Entity> queue = new Queue<Entity>(seedEntities);

                while (queue.Count > 0)
                {
                    Entity current = queue.Dequeue();
                    PatternEntity pattern = PatternEntity.FromEntity(current);
                    if (pattern != null) patternEntities.Add(pattern);

                    foreach (Entity candidate in allEntities)
                    {
                        if (visited.Contains(candidate.ObjectId)) continue;
                        if (IsConnected(current, candidate, tolerance))
                        {
                            visited.Add(candidate.ObjectId);
                            queue.Enqueue(candidate);
                        }
                    }
                }

                tr.Commit();
            }

            return patternEntities;
        }

        private static bool IsConnected(Entity a, Entity b, double tolerance)
        {
            try
            {
                Extents3d extA = a.GeometricExtents;
                Extents3d extB = b.GeometricExtents;

                bool xClose = Math.Abs(extA.MinPoint.X - extB.MaxPoint.X) < tolerance ||
                              Math.Abs(extB.MinPoint.X - extA.MaxPoint.X) < tolerance;

                bool yClose = Math.Abs(extA.MinPoint.Y - extB.MaxPoint.Y) < tolerance ||
                              Math.Abs(extB.MinPoint.Y - extA.MaxPoint.Y) < tolerance;

                return xClose && yClose;
            }
            catch
            {
                return false;
            }
        }
    }
}