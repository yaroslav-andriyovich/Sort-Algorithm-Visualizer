using Sort_Algorithm_Visualizer.Algorithms;
using Sort_Algorithm_Visualizer.Data;
using Sort_Algorithm_Visualizer.UI.ChartControl;

namespace Sort_Algorithm_Visualizer.Common
{
    public class ChartAlgorithmConnector
    {
        private const int MinDataValue = 1;
        
        private readonly ChartView _chartView;
        private readonly SortingController _sortingController;
        private readonly NumericDataGenerator _dataGenerator;

        private NumericData _numericData;

        public ChartAlgorithmConnector(ChartView chartView, SortingController sortingController, NumericDataGenerator dataGenerator)
        {
            _chartView = chartView;
            _sortingController = sortingController;
            _dataGenerator = dataGenerator;

            _sortingController.Mark += _chartView.MarkPointsInMainThread;
            _sortingController.Finish += _chartView.HandleStopSortingInMainThread;
        }

        public void InitializeNewData(int size)
        {
            if (_numericData != null)
                _numericData.Change -= _chartView.HandleDataChange;

            _numericData = _dataGenerator.Generate(size, MinDataValue, _chartView.MaxElementValue);
            _sortingController.SetData(_numericData);
            _chartView.Initialize(new ReadonlyNumericData(_numericData));
            _numericData.Change += _chartView.HandleDataChange;
        }
    }
}