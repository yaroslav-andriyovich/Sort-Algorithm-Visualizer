using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Sort_Algorithm_Visualizer.Data;
using Sort_Algorithm_Visualizer.UI.ChartControl.Points;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartInitializer
    {
        private readonly DataPointCollection _points;
        private readonly ChartCleaner _cleaner;
        private readonly PointPainter _pointPainter;
        private readonly PointLabelController _labelController;

        public ChartInitializer(DataPointCollection points, ChartCleaner cleaner, PointPainter pointPainter, PointLabelController labelController)
        {
            _points = points;
            _cleaner = cleaner;
            _pointPainter = pointPainter;
            _labelController = labelController;
        }

        public void Initialize(ReadonlyNumericData numericData)
        {
            _cleaner.Clean();
            _pointPainter.ChangeMaxPointValue(numericData.GetMaxValue());

            for (int i = 0; i < numericData.Length; i++)
            {
                int xValue = i;
                int yValue = numericData[i];
                DataPoint dataPoint = new DataPoint(xValue, yValue);

                _pointPainter.Paint(dataPoint);
                _labelController.Initialize(dataPoint);
                
                _points.Add(dataPoint);
            }
        }
    }
}