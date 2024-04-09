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

        public ChartInitializer(DataPointCollection points, ChartCleaner cleaner, PointPainter pointPainter)
        {
            _points = points;
            _cleaner = cleaner;
            _pointPainter = pointPainter;
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
                _points.Add(dataPoint);
            }
        }
    }
}