using System;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            InitializeApplication();
        }

        private static void InitializeApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}