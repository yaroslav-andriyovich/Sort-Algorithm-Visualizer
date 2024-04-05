using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;
using Sort_Algorithm_Visualizer.Common;

namespace Sort_Algorithm_Visualizer.UI.SortControls
{
    public class ResetFeature
    {
        private readonly Button _resetButton;
        private readonly Button _startButton;
        private readonly ChartAlgorithmConnector _chartAlgorithmConnector;
        private readonly SortingController _sortingController;
        private readonly ArraySizeChanger _arraySizeChanger;

        public ResetFeature(
            Button resetButton, 
            Button startButton,  
            ChartAlgorithmConnector chartAlgorithmConnector,
            SortingController sortingController,
            ArraySizeChanger arraySizeChanger
            )
        {
            _resetButton = resetButton;
            _startButton = startButton;
            _chartAlgorithmConnector = chartAlgorithmConnector;
            _sortingController = sortingController;
            _arraySizeChanger = arraySizeChanger;

            _resetButton.Click += OnResetButtonClick;
            _arraySizeChanger.Changed += OnArraySizeChanged;

            Reset();
        }

        private void OnResetButtonClick(object sender, EventArgs e) => 
            Reset();

        private void OnArraySizeChanged(int size) => 
            Reset();

        private void Reset()
        {
            if (_sortingController.IsRunning)
                return;

            _chartAlgorithmConnector.InitializeNewData(_arraySizeChanger.Size);
            _startButton.Enabled = true;
        }
    }
}