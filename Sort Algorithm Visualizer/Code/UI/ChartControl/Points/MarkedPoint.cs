using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl.Points
{
    public class MarkedPoint
    {
        public readonly DataPoint point;
        public int index;
        public Color originalColor;

        public MarkedPoint(DataPoint point, int index)
        {
            this.point = point;
            this.index = index;
            originalColor = point.Color;
        }

        public void RestoreOriginalColor() => 
            point.Color = originalColor;
    }
}