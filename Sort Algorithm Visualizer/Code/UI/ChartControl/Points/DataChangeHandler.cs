using System.Windows.Forms.DataVisualization.Charting;

namespace Sort_Algorithm_Visualizer.UI.ChartControl.Points
{
    public class DataChangeHandler
    {
        private readonly DataPointCollection _points;
        private readonly PointMarker _pointMarker;
        private readonly PointPainter _pointPainter;
        private readonly PointLabelController _labelController;

        public DataChangeHandler(DataPointCollection points, PointMarker pointMarker, PointPainter pointPainter, PointLabelController labelController)
        {
            _points = points;
            _pointMarker = pointMarker;
            _pointPainter = pointPainter;
            _labelController = labelController;
        }

        public void Handle(int index, int value)
        {
            DataPoint changedPoint = _points[index]; 
            
            changedPoint.SetValueXY(index, value);

            if (!_pointMarker.IsPointMarked(index))
                _pointPainter.Paint(changedPoint);
            
            _labelController.Update(changedPoint);
        }
    }
}