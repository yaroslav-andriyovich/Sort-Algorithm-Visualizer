using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartStyleSwitcher
    {
        private const string Enable3DText = "Enable 3D";
        private const string Disable3DText = "Disable 3D";
        
        private readonly Chart _chart;
        private readonly Button _toggleButton;
        
        private ChartArea3DStyle Area3DStyle => _chart.ChartAreas[0].Area3DStyle;

        public ChartStyleSwitcher(Chart chart, Button toggleButton)
        {
            _chart = chart;
            _toggleButton = toggleButton;
            
            _toggleButton.Click += OnToggleButtonClick;
        }
        
        private void OnToggleButtonClick(object sender, EventArgs e)
        {
            if (Area3DStyle.Enable3D)
            {
                Area3DStyle.Enable3D = false;
                _toggleButton.Text = Enable3DText;
                return;
            }
            
            Area3DStyle.Enable3D = true;
            _toggleButton.Text = Disable3DText;
        }
    }
}