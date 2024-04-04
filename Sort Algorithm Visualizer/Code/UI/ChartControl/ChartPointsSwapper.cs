using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartPointsSwapper
    {
        private readonly DataPointCollection _points;

        public ChartPointsSwapper(DataPointCollection points) => 
            _points = points;

        public void Swap(int firstIndex, int secondIndex)
        {
            double firstX = _points[firstIndex].XValue;
            double firstY = _points[firstIndex].YValues[0];
            Color firstColor = _points[firstIndex].Color;
            
            double secondX = _points[secondIndex].XValue;
            double secondY = _points[secondIndex].YValues[0];
            Color secondColor = _points[secondIndex].Color;

            _points[firstIndex].SetValueXY(secondX, secondY);
            _points[firstIndex].Color = secondColor;

            _points[secondIndex].SetValueXY(firstX, firstY);
            _points[secondIndex].Color = firstColor;
        }
    }
}