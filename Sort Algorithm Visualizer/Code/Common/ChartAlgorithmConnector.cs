using Sort_Algorithm_Visualizer.Algorithms;
using Sort_Algorithm_Visualizer.Data;
using Sort_Algorithm_Visualizer.UI.ChartControl;

namespace Sort_Algorithm_Visualizer.Common
{
    public class ChartAlgorithmConnector
    {
        private readonly ChartView _chartView;
        private readonly SortingController _sortingController;
        private readonly NumericDataGenerator _dataGenerator;

        public ChartAlgorithmConnector(ChartView chartView, SortingController sortingController, NumericDataGenerator dataGenerator)
        {
            _chartView = chartView;
            _sortingController = sortingController;
            _dataGenerator = dataGenerator;

            _sortingController.Select += _chartView.SelectPointsInMainThread;
            _sortingController.Swap += _chartView.SwapPointsInMainThread;
            _sortingController.Finish += _chartView.HandleStopSortingInMainThread;
        }

        public void InitializeNewData(int elementsNumber)
        {
            int maxElementValue = _chartView.MaxElementValue;
            int[] data = _dataGenerator.Generate(elementsNumber, maxElementValue);

            _sortingController.SetData(data);
            _chartView.InitializeGraph(data);
        }
    }
}