using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;
using Sort_Algorithm_Visualizer.Data;
using Sort_Algorithm_Visualizer.UI.ChartControl;

namespace Sort_Algorithm_Visualizer.UI
{
    public class ResetFeature
    {
        private readonly Button _resetButton;
        private readonly Button _startButton;
        private readonly ChartView _chartView;
        private readonly NumericDataGenerator _dataGenerator;
        private readonly AlgorithmController _algorithmController;
        private readonly ArraySizeChanger _arraySizeChanger;

        public ResetFeature(
            Button resetButton, 
            Button startButton, 
            ChartView chartView, 
            NumericDataGenerator dataGenerator,
            AlgorithmController algorithmController,
            ArraySizeChanger arraySizeChanger
            )
        {
            _resetButton = resetButton;
            _startButton = startButton;
            _chartView = chartView;
            _dataGenerator = dataGenerator;
            _algorithmController = algorithmController;
            _arraySizeChanger = arraySizeChanger;

            _resetButton.Click += OnResetButtonClick;

            OnResetButtonClick(null, null);
        }

        private void OnResetButtonClick(object sender, EventArgs e)
        {
            if (_algorithmController.IsRunning)
                return;
            
            int elementsCount = _arraySizeChanger.Size;
            int maxElementValue = _chartView.MaxElementValue;
            int[] data = _dataGenerator.Generate(elementsCount, maxElementValue);

            _chartView.InitializeGraph(elementsCount, maxElementValue, data);
            _algorithmController.SetData(data);

            _startButton.Enabled = true;
        }
    }
}