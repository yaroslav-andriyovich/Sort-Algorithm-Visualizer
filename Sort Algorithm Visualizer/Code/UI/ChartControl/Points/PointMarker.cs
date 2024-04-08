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
        private static readonly Color SwapColor = Color.DarkOrange;
        private static readonly Color PivotColor = Color.LawnGreen;
        
        private readonly DataPointCollection _points;
        private readonly PointPainter _pointPainter;
        private readonly Dictionary<int, MarkedPoint> _markedPoints;
        
        private MarkedPoint _pivotPoint;

        public PointMarker(DataPointCollection points, PointPainter pointPainter)
        {
            _points = points;
            _pointPainter = pointPainter;
            _markedPoints = new Dictionary<int, MarkedPoint>();
        }

        public bool IsPointMarkedAt(int index) => 
            _markedPoints.ContainsKey(index);

        public void MarkPoints(MarkType type, params int[] indexes)
        {
            MarkAction markAction;
            
            switch (type)
            {
                case MarkType.None:
                    markAction = UnmarkPoint;
                    break;
                case MarkType.Select:
                    markAction = MarkAsSelect;
                    break;
                case MarkType.Swap:
                    markAction = MarkAsSwap;
                    break;
                case MarkType.Pivot:
                    markAction = MarkAsPivot;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            foreach (int index in indexes)
            {
                DataPoint point = _points[index];
                MarkedPoint markedPoint;

                if (!_markedPoints.ContainsKey(index))
                {
                    markedPoint = new MarkedPoint(point, index);
                    _markedPoints.Add(index, markedPoint);
                }
                else
                    markedPoint = _markedPoints[index];

                markAction(markedPoint);
            }
        }

        public void UnmarkAll()
        {
            foreach (MarkedPoint markedPoint in _markedPoints.Values) 
                //markedPoint.RestoreOriginalColor();
                _pointPainter.Paint(markedPoint.point);
            
            _pivotPoint = null;
            _markedPoints.Clear();
        }

        /*public void Swap(int firstIndex, int secondIndex)
        {
            if (_markedPoints.ContainsKey(firstIndex) && _markedPoints.ContainsKey(secondIndex))
            {
                MarkedPoint first = _markedPoints[firstIndex];
                MarkedPoint second = _markedPoints[secondIndex];

                (_markedPoints[firstIndex], _markedPoints[secondIndex]) = (_markedPoints[secondIndex], _markedPoints[firstIndex]);
                (first.index, second.index) = (second.index, first.index);
                (first.originalColor, second.originalColor) = (second.originalColor, first.originalColor);
            }
        }*/
        
        private void UnmarkPoint(MarkedPoint markedPoint)
        {
            _pointPainter.Paint(markedPoint.point);

            if (markedPoint == _pivotPoint)
                _pivotPoint = null;
            
            _markedPoints.Remove(markedPoint.index);
        }

        private void MarkAsSelect(MarkedPoint markedPoint) => 
            _pointPainter.Paint(markedPoint.point, SelectColor);

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