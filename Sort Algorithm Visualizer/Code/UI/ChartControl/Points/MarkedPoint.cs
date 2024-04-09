using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl.Points
{
    public class MarkedPoint
    {
        public readonly DataPoint point;
        public int index;

        public MarkedPoint(DataPoint point, int index)
        {
            this.point = point;
            this.index = index;
        }
    }
}