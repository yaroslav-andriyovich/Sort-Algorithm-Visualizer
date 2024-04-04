using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sort_Algorithm_Visualizer.Algorithms.Base;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartView
    {
        public int MaxElementValue => _chart.Height;

        private readonly Chart _chart;
        private readonly DataPointCollection _points;
        private readonly ChartStyleSwitcher _styleSwitcher;
        private readonly ChartColorPicker _colorPicker;
        private readonly ChartPointsSelection _pointsSelection;
        private readonly ChartPointsSwapper _pointsSwapper;
        private readonly SelectCallback _selectCallback;
        private readonly SwapCallback _swapCallback;
        private readonly Action _finishSortingCallback;

        public ChartView(Chart chart, Button toggle3DButton, PictureBox colorPickBox)
        {
            _chart = chart;
            _points = _chart.Series[0].Points;
            
            _styleSwitcher = new ChartStyleSwitcher(chart, toggle3DButton);
            _colorPicker = new ChartColorPicker(colorPickBox);
            _pointsSelection = new ChartPointsSelection(_points);
            _pointsSwapper = new ChartPointsSwapper(_points);
            
            _selectCallback = _pointsSelection.SelectPoints;
            _swapCallback = SwapPoints;
            _finishSortingCallback = OnFinishSorting;
        }

        public void InitializeGraph(int[] data, int maxElementValue)
        {
            Clear();

            for (int i = 0; i < data.Length; i++)
            {
                int dataValue = data[i];
                DataPoint dataPoint = new DataPoint(i, dataValue);
                Color color = _colorPicker.GetPointColor(dataValue, maxElementValue);

                dataPoint.Color = color;
                
                _points.Add(dataPoint);
            }
        }
        
        public void SelectPointsInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_selectCallback, firstIndex, secondIndex);

        public void SwapPointsInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_swapCallback, firstIndex, secondIndex);
        
        public void HandleStopSortingInMainThread() => 
            _chart.Invoke(_finishSortingCallback);
        
        private void Clear()
        {
            _pointsSelection.Deselect();
            _points.Clear();
        }
        
        private void SwapPoints(int firstIndex, int secondIndex)
        {
            _pointsSwapper.Swap(firstIndex, secondIndex);
            _pointsSelection.SwapOriginalColor();
        }

        private void OnFinishSorting() => 
            _pointsSelection.Deselect();
    }
}