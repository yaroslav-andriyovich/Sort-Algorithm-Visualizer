using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sort_Algorithm_Visualizer.Algorithms;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartView
    {
        public int MaxElementValue => _chart.Height;

        private readonly Chart _chart;
        private readonly ChartStyleSwitcher _styleSwitcher;
        private readonly ChartColorPicker _colorPicker;
        private readonly DataPointCollection _points;
        private readonly SelectedCallback _selectedCallback;
        private readonly SwapCallback _swapCallback;
        
        private bool _somePointsSelected;
        private SelectedPoint _firstSelectedPoint;
        private SelectedPoint _secondSelectedPoint;

        public ChartView(Chart chart, Button toggle3DButton, PictureBox colorPickBox)
        {
            _chart = chart;
            _styleSwitcher = new ChartStyleSwitcher(chart, toggle3DButton);
            _colorPicker = new ChartColorPicker(colorPickBox);
            _points = _chart.Series[0].Points;
            _selectedCallback = SelectPoints;
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
        
        public void HandleSelectInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_selectedCallback, firstIndex, secondIndex);

        public void HandleSwapInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_swapCallback, firstIndex, secondIndex);

        private void Clear()
        {
            _somePointsSelected = false;
            _points.Clear();
        }

        private Color GetPointColor(int maxElementValue, int dataValue)
        {
            int red = _colorPicker.Color.R;
            int green = _colorPicker.Color.G;
            int blue = _colorPicker.Color.B;
            
            float colorIntensity = dataValue / (float)maxElementValue;
            
            red = (int)(red * colorIntensity);
            green = (int)(green * colorIntensity);
            blue = (int)(blue * colorIntensity);
            
            Color color = Color.FromArgb(red, green, blue);
            
            return color;
        }

        private void SelectPoints(int firstIndex, int secondIndex)
        {
            if (_somePointsSelected)
            {
                _points[_firstSelectedPoint.index].Color = _firstSelectedPoint.color;
                _points[_secondSelectedPoint.index].Color = _secondSelectedPoint.color;
            }

            _firstSelectedPoint = new SelectedPoint(firstIndex, _points[firstIndex].Color);
            _secondSelectedPoint = new SelectedPoint(secondIndex, _points[secondIndex].Color);
            
            _points[_firstSelectedPoint.index].Color = Color.Red;
            _points[_secondSelectedPoint.index].Color = Color.Red;

            _somePointsSelected = true;
        }
        
        private void SwapPoints(int firstIndex, int secondIndex)
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
            
            if (_somePointsSelected)
            {
                Color temp = _firstSelectedPoint.color;
                
                _firstSelectedPoint.color = _secondSelectedPoint.color;
                _secondSelectedPoint.color = temp;
            }
        }
    }
}