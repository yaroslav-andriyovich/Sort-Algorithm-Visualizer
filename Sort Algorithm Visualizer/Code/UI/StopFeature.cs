using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;

namespace Sort_Algorithm_Visualizer.UI
{
    public class StopFeature
    {
        private readonly Button _stopButton;
        private readonly AlgorithmController _algorithmController;
        private readonly SortingTypeSelector _sortingTypeSelector;
        private readonly Button _resetButton;
        private readonly Button _startButton;
        private readonly NumericUpDown _arraySizeChanger;

        public StopFeature(Button stopButton, 
            AlgorithmController algorithmController,
            SortingTypeSelector sortingTypeSelector, 
            Button resetButton, 
            Button startButton,
            NumericUpDown arraySizeChanger
            )
        {
            _stopButton = stopButton;
            _algorithmController = algorithmController;
            _sortingTypeSelector = sortingTypeSelector;
            _resetButton = resetButton;
            _startButton = startButton;
            _arraySizeChanger = arraySizeChanger;

            _stopButton.Click += OnStopButtonClick;
            _algorithmController.Finished += HandleSortingFinishInMainThread;
        }

        private void OnStopButtonClick(object sender, EventArgs e)
        {
            if (!_algorithmController.IsRunning)
                return;
            
            _algorithmController.StopSort();
        }

        private void HandleSortingFinishInMainThread() => 
            _resetButton.Invoke(new Action(EnableButtons));

        private void EnableButtons()
        {
            _sortingTypeSelector.Enabled = true;
            _resetButton.Enabled = true;
            _startButton.Enabled = true;
            _arraySizeChanger.Enabled = true;
        }
    }
}