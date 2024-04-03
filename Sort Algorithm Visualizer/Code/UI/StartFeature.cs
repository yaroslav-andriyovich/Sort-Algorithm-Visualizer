using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;
using Sort_Algorithm_Visualizer.UI.ChartControl;

namespace Sort_Algorithm_Visualizer.UI
{
    public class StartFeature
    {
        private readonly Button _startButton;
        private readonly AlgorithmController _algorithmController;
        private readonly SortingTypeSelector _sortingTypeSelector;
        private readonly ChartView _chartView;
        private readonly Button _resetButton;
        private readonly NumericUpDown _arraySizeChanger;

        public StartFeature(
            Button startButton, 
            AlgorithmController algorithmController, 
            SortingTypeSelector sortingTypeSelector,
            ChartView chartView,
            Button resetButton,
            NumericUpDown arraySizeChanger
            )
        {
            _startButton = startButton;
            _algorithmController = algorithmController;
            _sortingTypeSelector = sortingTypeSelector;
            _chartView = chartView;
            _resetButton = resetButton;
            _arraySizeChanger = arraySizeChanger;

            _startButton.Click += OnStartButtonClick;
        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            if (_algorithmController.IsRunning)
                return;
            
            SortAlgorithmType sortingType = _sortingTypeSelector.GetSelected();
            SelectedCallback selectedCallback = _chartView.HandleSelectInMainThread;
            SwapCallback swapCallback = _chartView.HandleSwapInMainThread;

            _algorithmController.StartSort(sortingType, selectedCallback, swapCallback);
            DisableButtons();
        }
        
        private void DisableButtons()
        {
            _sortingTypeSelector.Enabled = false;
            _resetButton.Enabled = false;
            _startButton.Enabled = false;
            _arraySizeChanger.Enabled = false;
        }
    }
}