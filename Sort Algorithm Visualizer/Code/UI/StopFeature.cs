using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Code.Algorithms;

namespace Sort_Algorithm_Visualizer.Code.UI
{
    public class StopFeature
    {
        private readonly Button _stopButton;
        private readonly AlgorithmController _algorithmController;
        private readonly AlgorithmSelection _algorithmSelection;
        private readonly Button _resetButton;
        private readonly Button _startButton;

        public StopFeature(Button stopButton, 
            AlgorithmController algorithmController,
            AlgorithmSelection algorithmSelection, 
            Button resetButton, 
            Button startButton)
        {
            _stopButton = stopButton;
            _algorithmController = algorithmController;
            _algorithmSelection = algorithmSelection;
            _resetButton = resetButton;
            _startButton = startButton;

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
            _algorithmSelection.Enabled = true;
            _resetButton.Enabled = true;
            _startButton.Enabled = true;
        }
    }
}