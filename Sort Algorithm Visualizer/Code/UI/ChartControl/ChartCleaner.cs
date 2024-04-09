using System.Windows.Forms.DataVisualization.Charting;
using Sort_Algorithm_Visualizer.UI.ChartControl.Points;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartCleaner
    {
        private readonly DataPointCollection _points;
        private readonly PointMarker _pointMarker;

        public ChartCleaner(DataPointCollection points, PointMarker pointMarker)
        {
            _points = points;
            _pointMarker = pointMarker;
        }

        public void Clean()
        {
            _pointMarker.UnmarkAll();
            _points.Clear();
        }
    }
}