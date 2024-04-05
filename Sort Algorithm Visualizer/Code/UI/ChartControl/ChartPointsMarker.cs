using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartPointsMarker
    {
        private static readonly Color MarkedColor = Color.FromArgb(255, 50, 50);
        private static readonly Color SwappedColor = Color.DarkOrange;
        
        private readonly DataPointCollection _points;
        
        private bool _somePointsMarked;
        private MarkedPoint _firstPoint;
        private MarkedPoint _secondPoint;

        public ChartPointsMarker(DataPointCollection points) => 
            _points = points;

        public void MarkPoints(int firstIndex, int secondIndex)
        {
            Unmark();
            CachePointsData(firstIndex, secondIndex);
            ApplyColor(MarkedColor);

            _somePointsMarked = true;
        }

        public void Unmark()
        {
            if (_somePointsMarked)
                ApplyOriginalColor();

            _somePointsMarked = false;
        }

        public void SwapOriginalColor()
        {
            if (_somePointsMarked)
            {
                (_firstPoint.originalColor, _secondPoint.originalColor) = (_secondPoint.originalColor, _firstPoint.originalColor);

                ApplyColor(SwappedColor);
            }
        }

        private void CachePointsData(int firstIndex, int secondIndex)
        {
            _firstPoint = new MarkedPoint(firstIndex, _points[firstIndex].Color);
            _secondPoint = new MarkedPoint(secondIndex, _points[secondIndex].Color);
        }

        private void ApplyOriginalColor()
        {
            _points[_firstPoint.index].Color = _firstPoint.originalColor;
            _points[_secondPoint.index].Color = _secondPoint.originalColor;
        }

        private void ApplyColor(Color color)
        {
            _points[_firstPoint.index].Color = color;
            _points[_secondPoint.index].Color = color;
        }
    }
}