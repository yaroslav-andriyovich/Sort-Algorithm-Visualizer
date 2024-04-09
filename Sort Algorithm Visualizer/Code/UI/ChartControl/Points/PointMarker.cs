using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Sort_Algorithm_Visualizer.Algorithms.Base;

namespace Sort_Algorithm_Visualizer.UI.ChartControl.Points
{
    public class PointMarker
    {
        private static readonly Color SelectColor = Color.FromArgb(255, 50, 50);
        private static readonly Color Select2Color = Color.Aqua;
        private static readonly Color SwapColor = Color.DarkOrange;
        private static readonly Color PivotColor = Color.LawnGreen;

        private readonly DataPointCollection _chartPoints;
        private readonly PointPainter _pointPainter;
        private readonly Dictionary<int, MarkedPoint> _markedPoints;
        
        private MarkedPoint _pivotPoint;

        public PointMarker(DataPointCollection chartPoints, PointPainter pointPainter)
        {
            _chartPoints = chartPoints;
            _pointPainter = pointPainter;
            _markedPoints = new Dictionary<int, MarkedPoint>();
        }

        public bool IsPointMarked(int index) => 
            _markedPoints.ContainsKey(index);

        public void Mark(MarkType type, params int[] indexes)
        {
            MarkAction markAction = GetMarkAction(type);
            
            foreach (int index in indexes)
            {
                MarkedPoint markedPoint;

                if (!IsPointMarked(index))
                    markedPoint = RegisterPoint(_chartPoints[index], index);
                else
                    markedPoint = _markedPoints[index];

                markAction(markedPoint);
            }
        }

        public void UnmarkAll()
        {
            foreach (MarkedPoint markedPoint in _markedPoints.Values) 
                _pointPainter.Paint(markedPoint.point);
            
            _pivotPoint = null;
            _markedPoints.Clear();
        }

        private MarkAction GetMarkAction(MarkType type)
        {
            switch (type)
            {
                case MarkType.None:
                    return UnmarkPoint;
                case MarkType.Select:
                    return MarkAsSelect;
                case MarkType.Select2:
                    return MarkAsSelect2;
                case MarkType.Swap:
                    return MarkAsSwap;
                case MarkType.Pivot:
                    return MarkAsPivot;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private MarkedPoint RegisterPoint(DataPoint point, int index)
        {
            MarkedPoint markedPoint = new MarkedPoint(point, index);
            _markedPoints.Add(index, markedPoint);
            return markedPoint;
        }

        private void UnmarkPoint(MarkedPoint markedPoint)
        {
            _pointPainter.Paint(markedPoint.point);

            if (markedPoint == _pivotPoint)
                _pivotPoint = null;
            
            _markedPoints.Remove(markedPoint.index);
        }

        private void MarkAsSelect(MarkedPoint markedPoint) => 
            _pointPainter.Paint(markedPoint.point, SelectColor);

        private void MarkAsSelect2(MarkedPoint markedPoint) => 
            _pointPainter.Paint(markedPoint.point, Select2Color);

        private void MarkAsSwap(MarkedPoint markedPoint) => 
            _pointPainter.Paint(markedPoint.point, SwapColor);

        private void MarkAsPivot(MarkedPoint markedPoint)
        {
            if (_pivotPoint == markedPoint)
                return;
            
            if (_pivotPoint != null)
                UnmarkPoint(_pivotPoint);

            _pointPainter.Paint(markedPoint.point, PivotColor);
            _pivotPoint = markedPoint;
        }
    }

    public delegate void MarkAction(MarkedPoint markedPoint);
}