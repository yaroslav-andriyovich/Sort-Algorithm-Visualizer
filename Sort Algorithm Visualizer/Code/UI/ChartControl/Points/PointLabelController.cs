using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl.Points
{
    public class PointLabelController
    {
        private static readonly Color LabelColor = Color.White;
        
        private const string ShowText = "Show Value";
        private const string HideText = "Hide Value";

        private readonly DataPointCollection _points;
        private readonly Button _toggleButton;

        private bool _isShowed;

        public PointLabelController(DataPointCollection points, Button toggleButton)
        {
            _points = points;
            _toggleButton = toggleButton;
            
            _toggleButton.Click += OnToggleButtonClick;
        }

        public void Initialize(DataPoint point)
        {
            point.LabelForeColor = LabelColor;
            Update(point);   
        }

        public void Update(DataPoint point) => 
            point.Label = _isShowed ? point.YValues[0].ToString() : string.Empty;

        private void OnToggleButtonClick(object sender, EventArgs e)
        {
            _isShowed = !_isShowed;
            _toggleButton.Text = (_isShowed) ? HideText : ShowText;
            
            foreach (DataPoint point in _points)
                Update(point);
        }
    }
}