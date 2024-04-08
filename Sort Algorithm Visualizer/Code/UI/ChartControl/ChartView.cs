using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sort_Algorithm_Visualizer.Algorithms.Base;
using Sort_Algorithm_Visualizer.Data;
using Sort_Algorithm_Visualizer.UI.ChartControl.Points;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartView
    {
        public int MaxElementValue => _chart.Height;

        private readonly Chart _chart;
        private readonly DataPointCollection _points;
        private readonly ChartStyleSwitcher _styleSwitcher;
        private readonly ColorPicker _colorPicker;
        private readonly PointPainter _pointPainter;
        private readonly PointMarker _pointMarker;
        private readonly PointSwapper _pointSwapper;
        private readonly NumericDataChange _dataChangeCallback;
        private readonly MarkCallback _markCallback;
        private readonly SwapCallback _swapCallback;
        private readonly Action _finishSortingCallback;

        public ChartView(Chart chart, Button toggle3DButton, PictureBox colorPickBox)
        {
            _chart = chart;
            _points = _chart.Series[0].Points;
            _colorPicker = new ColorPicker(colorPickBox);

            _styleSwitcher = new ChartStyleSwitcher(chart, toggle3DButton);
            _pointPainter = new PointPainter();
            _pointMarker = new PointMarker(_points, _pointPainter);
            _pointSwapper = new PointSwapper(_points, _pointMarker);

            _dataChangeCallback = OnDataChange;
            _markCallback = _pointMarker.MarkPoints;
            _swapCallback = SwapPoints;
            _finishSortingCallback = OnFinishSorting;

            _colorPicker.Pick += Repaint;
            
            _pointPainter.ChangeDefaultColor(_colorPicker.Color);
        }

        public void InitializeGraph(ReadonlyNumericData numericData)
        {
            Clear();
            
            _pointPainter.ChangeMaxPointValue(numericData.GetMaxValue());

            for (int i = 0; i < numericData.Length; i++)
            {
                int xValue = i;
                int yValue = numericData[i];
                DataPoint dataPoint = new DataPoint(xValue, yValue);
                
                _pointPainter.Paint(dataPoint);
                _points.Add(dataPoint);
            }
        }

        public void HandleDataChange(int index, int value) => 
            _chart.Invoke(_dataChangeCallback, index, value);

        public void MarkPointsInMainThread(MarkType type, params int[] indexes) => 
            _chart.Invoke(_markCallback, type, indexes);

        public void SwapPointsInMainThread(int firstIndex, int secondIndex) => 
            _chart.Invoke(_swapCallback, firstIndex, secondIndex);

        public void HandleStopSortingInMainThread() => 
            _chart.Invoke(_finishSortingCallback);

        private void OnDataChange(int index, int value)
        {
            _points[index].SetValueXY(index, value);

            if (!_pointMarker.IsPointMarkedAt(index))
                _pointPainter.Paint(_points[index]);
        }

        private void SwapPoints(int firstIndex, int secondIndex)
        {
            //_pointSwapper.Swap(firstIndex, secondIndex);
            _chart.Invalidate();
        }

        private void Clear()
        {
            _pointMarker.UnmarkAll();
            _points.Clear();
        }

        private void OnFinishSorting() => 
            _pointMarker.UnmarkAll();

        private void Repaint(Color color)
        {
            _pointPainter.ChangeDefaultColor(color);
            _pointPainter.Paint(_points);
        }
    }
}