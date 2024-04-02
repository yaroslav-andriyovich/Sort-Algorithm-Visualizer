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
                int dataValue = data[i];
                DataPoint dataPoint = new DataPoint(i, dataValue);
                Color color = GetPointColor(maxElementValue, dataValue);

                dataPoint.Color = color;
                
                _points.Add(dataPoint);
            }
        }

        public void HandleSwapInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_swapCallback, firstIndex, secondIndex);

        private void Clear() => 
            _points.Clear();
        
        private Color GetPointColor(int maxElementValue, int dataValue)
        {
            /*int red = 125;
            int green = 0;
            int blue = 255;*/
            
            int red = 255;
            int green = 255;
            int blue = 255;
            
            float colorIntensity = dataValue / (float)maxElementValue;
            
            red = (int)(red * colorIntensity);
            green = (int)(green * colorIntensity);
            blue = (int)(blue * colorIntensity);
            
            Color color = Color.FromArgb(red, green, blue);
            
            return color;
        }

        private void SwapPoints(int firstIndex, int secondIndex)
        {
            double firstX = _points[firstIndex].XValue;
            double firstY = _points[firstIndex].YValues[0];
            Color firstColor = _points[firstIndex].Color;

            _points[firstIndex].SetValueXY(_points[secondIndex].XValue, _points[secondIndex].YValues[0]);
            _points[firstIndex].Color = _points[secondIndex].Color;

            _points[secondIndex].SetValueXY(firstX, firstY);
            _points[secondIndex].Color = firstColor;
        }
    }
}