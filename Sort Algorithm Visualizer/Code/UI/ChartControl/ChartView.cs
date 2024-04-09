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
        private readonly ColorPicker _colorPicker;
        private readonly ChartStyleSwitcher _styleSwitcher;
        private readonly PointPainter _pointPainter;
        private readonly PointMarker _pointMarker;
        private readonly DataChangeHandler _dataChangeHandler;
        private readonly ChartCleaner _cleaner;
        private readonly ChartInitializer _initializer;
        
        private readonly NumericDataChange _dataChangeCallback;
        private readonly MarkCallback _markCallback;
        private readonly Action _finishSortingCallback;

        public ChartView(Chart chart, Button toggle3DButton, PictureBox colorPickBox)
        {
            _chart = chart;
            _points = _chart.Series[0].Points;
            
            _colorPicker = new ColorPicker(colorPickBox);
            _styleSwitcher = new ChartStyleSwitcher(chart, toggle3DButton);
            _pointPainter = new PointPainter();
            _pointMarker = new PointMarker(_points, _pointPainter);
            _dataChangeHandler = new DataChangeHandler(_points, _pointMarker, _pointPainter);
            _cleaner = new ChartCleaner(_points, _pointMarker);
            _initializer = new ChartInitializer(_points, _cleaner, _pointPainter);

            _dataChangeCallback = _dataChangeHandler.Handle;
            _markCallback = _pointMarker.Mark;
            _finishSortingCallback = _pointMarker.UnmarkAll;

            _colorPicker.Pick += Repaint;
            
            _pointPainter.ChangeDefaultColor(_colorPicker.Color);
        }

        public void Initialize(ReadonlyNumericData numericData) => 
            _initializer.Initialize(numericData);

        public void HandleDataChange(int index, int value) => 
            _chart.Invoke(_dataChangeCallback, index, value);

        public void MarkPointsInMainThread(MarkType type, params int[] indexes) => 
            _chart.Invoke(_markCallback, type, indexes);

        public void HandleStopSortingInMainThread() => 
            _chart.Invoke(_finishSortingCallback);

        private void Repaint(Color color)
        {
            _pointPainter.ChangeDefaultColor(color);
            _pointPainter.Paint(_points);
        }
    }
}