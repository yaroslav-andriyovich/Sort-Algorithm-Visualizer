using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;

namespace Sort_Algorithm_Visualizer.UI.SortControls
{
    public class StartFeature
    {
        private readonly Button _startButton;
        private readonly SortingController _sortingController;
        private readonly SortTypeSelector _sortTypeSelector;
        private readonly Button _resetButton;
        private readonly NumericUpDown _arraySizeChanger;

        public StartFeature(
            Button startButton, 
            SortingController sortingController, 
            SortTypeSelector sortTypeSelector,
            Button resetButton,
            NumericUpDown arraySizeChanger
            )
        {
            _startButton = startButton;
            _sortingController = sortingController;
            _sortTypeSelector = sortTypeSelector;
            _resetButton = resetButton;
            _arraySizeChanger = arraySizeChanger;

            _startButton.Click += OnStartButtonClick;
        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            if (_sortingController.IsRunning)
                return;
            
            SortAlgorithmType sortingType = _sortTypeSelector.GetSelected();

            _sortingController.StartSorting(sortingType);
            
            DisableButtons();
        }
        
        private void DisableButtons()
        {
            _sortTypeSelector.Enabled = false;
            _resetButton.Enabled = false;
            _startButton.Enabled = false;
            _arraySizeChanger.Enabled = false;
        }
    }
}