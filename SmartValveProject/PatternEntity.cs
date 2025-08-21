using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace SmartValve
{
    public class PatternEntity
    {
        public string Type { get; set; }
        public Point3d Start { get; set; }
        public Point3d End { get; set; }
        public Point3d Center { get; set; }
        public double Radius { get; set; }
        public double Angle { get; set; }

        public static PatternEntity FromEntity(Entity ent)
        {
            if (ent is Line line)
            {
                return new PatternEntity
                {
                    Type = "Line",
                    Start = line.StartPoint,
                    End = line.EndPoint
                };
            }

            if (ent is Circle circle)
            {
                return new PatternEntity
                {
                    Type = "Circle",
                    Center = circle.Center,
                    Radius = circle.Radius
                };
            }

            if (ent is Arc arc)
            {
                return new PatternEntity
                {
                    Type = "Arc",
                    Center = arc.Center,
                    Radius = arc.Radius,
                    Angle = arc.TotalAngle
                };
            }

            return new PatternEntity
            {
                Type = ent.GetType().Name
            };
        }
    }
}
