using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;



[assembly: CommandClass(typeof(SmartValve.PatternFileCommands))]

namespace SmartValve
{
    public class PatternFileCommands
    {
        [CommandMethod("SMARTVALVE_SAVE_PATTERNS")]
        public void SavePatterns()
        {
            ValvePatternLibrary.SaveToFile();
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("\n Valve patterns saved to 'C:\\SmartValve\\valve_patterns.json'");
        }

        [CommandMethod("SMARTVALVE_LOAD_PATTERNS")]
        public void LoadPatterns()
        {
            ValvePatternLibrary.LoadFromFile();
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("\n Valve patterns loaded from 'C:\\SmartValve\\valve_patterns.json'");
        }
    }
}
