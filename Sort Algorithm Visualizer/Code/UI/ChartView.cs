using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Sort_Algorithm_Visualizer.Code.Algorithms;

namespace Sort_Algorithm_Visualizer.Code.UI
{
    public class ChartView
    {
        public int MaxElementValue => _chart.Height;

        private readonly Chart _chart;
        private readonly DataPointCollection _points;
        private readonly SwapCallback _swapCallback;

        public ChartView(Chart chart)
        {
            _chart = chart;
            _points = _chart.Series[0].Points;
            _swapCallback = SwapPoints;
        }

        public void InitializeGraph(int elementsCount, int maxElementValue, int[] data)
        {
            Clear();

            for (int i = 0; i < elementsCount; i++)
            {
                DataPoint dataPoint = new DataPoint(i, data[i]);
                float colorIntensity = data[i] / (float)maxElementValue;
                int brightness = (int)(255f * colorIntensity);
                Color color = Color.FromArgb(brightness, brightness, brightness);

                dataPoint.Color = color;

                _points.Add(dataPoint);
            }
        }

        public void HandleSwapInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_swapCallback, firstIndex, secondIndex);

        private void Clear() => 
            _points.Clear();

        private void SwapPoints(int firstIndex, int secondIndex)
        {
            Series series = _chart.Series[0];

            double firstX = series.Points[firstIndex].XValue;
            double firstY = series.Points[firstIndex].YValues[0];
            Color firstColor = series.Points[firstIndex].Color;

            series.Points[firstIndex].SetValueXY(series.Points[secondIndex].XValue, series.Points[secondIndex].YValues[0]);
            series.Points[firstIndex].Color = series.Points[secondIndex].Color;

            series.Points[secondIndex].SetValueXY(firstX, firstY);
            series.Points[secondIndex].Color = firstColor;
        }
    }
}