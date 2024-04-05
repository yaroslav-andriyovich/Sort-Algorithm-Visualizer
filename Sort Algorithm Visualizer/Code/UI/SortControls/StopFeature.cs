using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;

namespace Sort_Algorithm_Visualizer.UI.SortControls
{
    public class StopFeature
    {
        private readonly Button _stopButton;
        private readonly SortingController _sortingController;
        private readonly SortTypeSelector _sortTypeSelector;
        private readonly Button _resetButton;
        private readonly Button _startButton;
        private readonly NumericUpDown _arraySizeChanger;
        private readonly PictureBox _chartColorPickBox;

        public StopFeature(Button stopButton, 
            SortingController sortingController,
            SortTypeSelector sortTypeSelector, 
            Button resetButton, 
            Button startButton,
            NumericUpDown arraySizeChanger,
            PictureBox chartColorPickBox
        )
        {
            _stopButton = stopButton;
            _sortingController = sortingController;
            _sortTypeSelector = sortTypeSelector;
            _resetButton = resetButton;
            _startButton = startButton;
            _arraySizeChanger = arraySizeChanger;
            _chartColorPickBox = chartColorPickBox;

            _stopButton.Click += OnStopButtonClick;
            _sortingController.Finish += HandleSortingFinishInMainThread;
        }

        private void OnStopButtonClick(object sender, EventArgs e)
        {
            if (!_sortingController.IsRunning)
                return;
            
            _sortingController.StopSort();
        }

        private void HandleSortingFinishInMainThread() => 
            _resetButton.Invoke(new Action(EnableButtons));

        private void EnableButtons()
        {
            _sortTypeSelector.Enabled = true;
            _resetButton.Enabled = true;
            _startButton.Enabled = true;
            _arraySizeChanger.Enabled = true;
            _chartColorPickBox.Enabled = true;
        }
    }
}