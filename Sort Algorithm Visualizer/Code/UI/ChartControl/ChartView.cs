using System;
using System.Drawing;
using System.Linq;
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
        private readonly ColorPicker _colorPicker;
        private readonly ChartPointsMarker _pointsMarker;
        private readonly ChartPointsSwapper _pointsSwapper;
        private readonly MarkCallback _markCallback;
        private readonly SwapCallback _swapCallback;
        private readonly Action _finishSortingCallback;
        
        private int _pointsMaxValue;

        public ChartView(Chart chart, Button toggle3DButton, PictureBox colorPickBox)
        {
            _chart = chart;
            _points = _chart.Series[0].Points;
            _colorPicker = new ColorPicker(colorPickBox);

            _styleSwitcher = new ChartStyleSwitcher(chart, toggle3DButton);
            _pointsMarker = new ChartPointsMarker(_points);
            _pointsSwapper = new ChartPointsSwapper(_points);
            
            _markCallback = _pointsMarker.MarkPoints;
            _swapCallback = SwapPoints;
            _finishSortingCallback = OnFinishSorting;

            _colorPicker.Pick += Repaint;
        }

        public void InitializeGraph(int[] data)
        {
            Clear();

            _pointsMaxValue = data.Max();

            for (int i = 0; i < data.Length; i++)
            {
                int dataValue = data[i];
                DataPoint dataPoint = new DataPoint(i, dataValue);
                Color pointColor = _colorPicker.GetPointColor(dataValue, _pointsMaxValue);

                dataPoint.Color = pointColor;

                _points.Add(dataPoint);
            }
        }
        
        public void SelectPointsInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_markCallback, firstIndex, secondIndex);

        public void SwapPointsInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_swapCallback, firstIndex, secondIndex);
        
        public void HandleStopSortingInMainThread() => 
            _chart.Invoke(_finishSortingCallback);

        private void Repaint(Color color)
        {
            foreach (DataPoint dataPoint in _points)
            {
                int dataValue = Convert.ToInt32(dataPoint.YValues[0]);
                Color pointColor = _colorPicker.GetPointColor(dataValue, _pointsMaxValue);

                dataPoint.Color = pointColor;
            }
        }

        private void Clear()
        {
            _pointsMarker.Unmark();
            _points.Clear();
        }
        
        private void SwapPoints(int firstIndex, int secondIndex)
        {
            _pointsSwapper.Swap(firstIndex, secondIndex);
            _pointsMarker.SwapOriginalColor();
        }

        private void OnFinishSorting() => 
            _pointsMarker.Unmark();
    }
}