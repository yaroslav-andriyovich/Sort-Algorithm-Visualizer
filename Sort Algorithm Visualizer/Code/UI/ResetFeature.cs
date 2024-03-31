using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Code.Algorithms;
using Sort_Algorithm_Visualizer.Code.Data;

namespace Sort_Algorithm_Visualizer.Code.UI
{
    public class ResetFeature
    {
        private readonly Button _resetButton;
        private readonly Button _startButton;
        private readonly ChartView _chartView;
        private readonly NumericDataGenerator _dataGenerator;
        private readonly AlgorithmController _algorithmController;

        public ResetFeature(
            Button resetButton, 
            Button startButton, 
            ChartView chartView, 
            NumericDataGenerator dataGenerator,
            AlgorithmController algorithmController
            )
        {
            _resetButton = resetButton;
            _startButton = startButton;
            _chartView = chartView;
            _dataGenerator = dataGenerator;
            _algorithmController = algorithmController;

            _resetButton.Click += OnResetButtonClick;
        }
        
        private void OnResetButtonClick(object sender, EventArgs e)
        {
            if (_algorithmController.IsRunning)
                return;
            
            int elementsCount = 20;
            int maxElementValue = _chartView.MaxElementValue;
            int[] data = _dataGenerator.Generate(elementsCount, maxElementValue);

            _chartView.InitializeGraph(elementsCount, maxElementValue, data);
            _algorithmController.SetData(data);

            _startButton.Enabled = true;
        }
    }
}