using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Code.Algorithms;

namespace Sort_Algorithm_Visualizer.Code.UI
{
    public class StartFeature
    {
        private readonly Button _startButton;
        private readonly AlgorithmController _algorithmController;
        private readonly AlgorithmSelection _algorithmSelection;
        private readonly ChartView _chartView;
        private readonly Button _resetButton;

        public StartFeature(
            Button startButton, 
            AlgorithmController algorithmController, 
            AlgorithmSelection algorithmSelection,
            ChartView chartView,
            Button resetButton
            )
        {
            _startButton = startButton;
            _algorithmController = algorithmController;
            _algorithmSelection = algorithmSelection;
            _chartView = chartView;
            _resetButton = resetButton;

            _startButton.Enabled = false;
            _startButton.Click += OnStartButtonClick;
        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            if (_algorithmController.IsRunning)
                return;
            
            SortAlgorithmType sortingType = _algorithmSelection.GetSelected();
            SwapCallback swapCallback = _chartView.HandleSwapInMainThread;

            _algorithmController.StartSort(sortingType, swapCallback);
            DisableButtons();
        }
        
        private void DisableButtons()
        {
            _algorithmSelection.Enabled = false;
            _resetButton.Enabled = false;
            _startButton.Enabled = false;
        }
    }
}