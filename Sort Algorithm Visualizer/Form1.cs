using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Code;

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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => 
            Close();

        private void btnReset_Click(object sender, EventArgs e) => 
            _panelController.Reset();
    }
}