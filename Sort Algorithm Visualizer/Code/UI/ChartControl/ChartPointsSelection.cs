using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartPointsSelection
    {
        private static readonly Color SelectedColor = Color.FromArgb(255, 50, 50);
        private static readonly Color SwappedColor = Color.DarkOrange;
        
        private readonly DataPointCollection _points;
        
        private bool _somePointsSelected;
        private SelectedPoint _firstSelectedPoint;
        private SelectedPoint _secondSelectedPoint;

        public ChartPointsSelection(DataPointCollection points) => 
            _points = points;

        public void SelectPoints(int firstIndex, int secondIndex)
        {
            Deselect();
            CachePointsData(firstIndex, secondIndex);
            ApplyColor(SelectedColor);

            _somePointsSelected = true;
        }

        public void Deselect()
        {
            if (_somePointsSelected)
                ApplyOriginalColor();

            _somePointsSelected = false;
        }

        public void SwapOriginalColor()
        {
            if (_somePointsSelected)
            {
                Color tempColor = _firstSelectedPoint.originalColor;

                _firstSelectedPoint.originalColor = _secondSelectedPoint.originalColor;
                _secondSelectedPoint.originalColor = tempColor;
                
                ApplyColor(SwappedColor);
            }
        }

        private void CachePointsData(int firstIndex, int secondIndex)
        {
            _firstSelectedPoint = new SelectedPoint(firstIndex, _points[firstIndex].Color);
            _secondSelectedPoint = new SelectedPoint(secondIndex, _points[secondIndex].Color);
        }

        private void ApplyOriginalColor()
        {
            _points[_firstSelectedPoint.index].Color = _firstSelectedPoint.originalColor;
            _points[_secondSelectedPoint.index].Color = _secondSelectedPoint.originalColor;
        }

        private void ApplyColor(Color color)
        {
            _points[_firstSelectedPoint.index].Color = color;
            _points[_secondSelectedPoint.index].Color = color;
        }
    }
}