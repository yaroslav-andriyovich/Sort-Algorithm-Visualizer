using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Code.Algorithms;
using Sort_Algorithm_Visualizer.Code.Data;
using Sort_Algorithm_Visualizer.Code.UI;

namespace Sort_Algorithm_Visualizer
{
    public partial class MainForm : Form
    {
        private readonly ChartView _chartView;
        private readonly ResetFeature _resetFeature;
        private readonly StartFeature _startFeature;
        private readonly StopFeature _stopFeature;
        private readonly Delay _delay;
        private readonly AlgorithmController _algorithmController;
        private readonly AlgorithmSelection _algorithmSelection;

        public MainForm()
        {
            InitializeComponent();

            _delay = new Delay(delayInput);
            _algorithmController = new AlgorithmController(new AlgorithmFactory(), _delay);
            _chartView = new ChartView(chart);
            _resetFeature = new ResetFeature(resetButton, startButton, _chartView, new NumericDataGenerator(), _algorithmController);
            _algorithmSelection = new AlgorithmSelection(comboBox);
            _startFeature = new StartFeature(startButton, _algorithmController, _algorithmSelection, _chartView, resetButton);
            _stopFeature = new StopFeature(stopButton, _algorithmController, _algorithmSelection, resetButton, startButton);
        }
    }
}