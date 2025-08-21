using Autodesk.AutoCAD.Runtime;
using System.Windows.Forms;

[assembly: CommandClass(typeof(SmartValve.FormLauncher))]

namespace SmartValve
{
    public class FormLauncher
    {
        [CommandMethod("SMARTVALVE_UI")]
        public void LaunchValveForm()
        {
            ValveForm form = new ValveForm();
            form.ShowDialog();  //  Modal keeps focus inside AutoCAD
        }
    }
}