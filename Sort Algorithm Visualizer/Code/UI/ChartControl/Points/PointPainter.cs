using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl.Points
{
    public class PointPainter
    {
        private int _maxPointValue;
        private Color _defaultColor;

        public void ChangeMaxPointValue(int value) => 
            _maxPointValue = value;

        public void ChangeDefaultColor(Color color) => 
            _defaultColor = color;

        public void Paint(DataPoint point)
        {
            int dataValue = Convert.ToInt32(point.YValues[0]);
            Color color = GetColor(dataValue);

            point.Color = color;
        }

        public void Paint(DataPoint point, Color color) => 
            point.Color = color;

        public void Paint(DataPointCollection points)
        {
            foreach (DataPoint dataPoint in points)
                Paint(dataPoint);
        }

        public Color GetColor(int dataValue) => 
            GetColor(dataValue, _maxPointValue);

        public Color GetColor(int dataValue, int maxElementValue)
        {
            int red = _defaultColor.R;
            int green = _defaultColor.G;
            int blue = _defaultColor.B;
            
            float colorIntensity = dataValue / (float)maxElementValue;
            
            red = (int)(red * colorIntensity);
            green = (int)(green * colorIntensity);
            blue = (int)(blue * colorIntensity);
            
            Color color = Color.FromArgb(red, green, blue);
            
            return color;
        }
    }
}