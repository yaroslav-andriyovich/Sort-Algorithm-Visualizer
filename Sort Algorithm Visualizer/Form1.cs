using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Code;
using Sort_Algorithm_Visualizer.Code.HUD;

namespace Sort_Algorithm_Visualizer
{
    public partial class Form1 : Form
    {
        private readonly PanelController _panelController;

        public Form1()
        {
            InitializeComponent();

            _panelController = new PanelController(panel);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => 
            Close();

        private void btnReset_Click(object sender, EventArgs e) => 
            _panelController.Reset();

        private void btnStart_Click(object sender, EventArgs e) => 
            _panelController.Start();
    }
}