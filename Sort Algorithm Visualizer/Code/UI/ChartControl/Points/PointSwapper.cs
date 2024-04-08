using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl.Points
{
    public class PointSwapper
    {
        private readonly DataPointCollection _points;
        private readonly PointMarker _pointMarker;

        public PointSwapper(DataPointCollection points, PointMarker pointMarker)
        {
            _points = points;
            _pointMarker = pointMarker;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            double firstX = _points[firstIndex].XValue;
            double firstY = _points[firstIndex].YValues[0];
            
            double secondX = _points[secondIndex].XValue;
            double secondY = _points[secondIndex].YValues[0];

            //_points[firstIndex].SetValueXY(secondX, secondY);
            //_points[secondIndex].SetValueXY(firstX, firstY);
            
            //_pointMarker.Swap(firstIndex, secondIndex);
        }
    }
}