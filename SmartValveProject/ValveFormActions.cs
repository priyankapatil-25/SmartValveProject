using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;


namespace SmartValve
{
    public static class ValveFormActions
    {
        private static List<Entity> selectedEntities = new List<Entity>();
        private static string currentValveName = "";

        public static void SelectValve()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            PromptEntityOptions peo = new PromptEntityOptions("\nSelect valve geometry: ");
            peo.SetRejectMessage("\nOnly graphical entities are allowed.");
            peo.AllowNone = false;
            PromptEntityResult per = ed.GetEntity(peo);
            if (per.Status != PromptStatus.OK) return;

            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                Entity ent = tr.GetObject(per.ObjectId, OpenMode.ForRead) as Entity;
                if (ent != null)
                {
                    selectedEntities.Clear();
                    selectedEntities.Add(ent);
                }
                tr.Commit();
            }

            ed.WriteMessage("\nValve geometry selected.");
        }

        public static void SetValveName(string name)
        {
            currentValveName = name;
            List<PatternEntity> patternEntities = LegendExtractor.ExtractPatternFromEntities(selectedEntities);
            ValvePatternLibrary.Add(name, patternEntities);
        }

        public static void ResetSelection()
        {
            selectedEntities.Clear();
            currentValveName = "";
        }

        public static void RemoveValve(string name)
        {
            if (ValvePatternLibrary.Patterns.ContainsKey(name))
                ValvePatternLibrary.Patterns.Remove(name);
        }

        public static void ExportToJson()
        {
            ValvePatternLibrary.SaveToFile();
            MessageBox.Show("Valve patterns exported to JSON.");
        }
        public static void CloseForm(Form form)
        {
            form.Close();
        }

    }
}
