using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;
using Sort_Algorithm_Visualizer.Data;
using Sort_Algorithm_Visualizer.UI;
using Sort_Algorithm_Visualizer.UI.ChartControl;

namespace Sort_Algorithm_Visualizer
{
    public partial class MainForm : Form
    {
        private readonly Delay _delay;
        private readonly DelayChanger _delayChanger;
        private readonly ArraySizeChanger _arraySizeChanger;
        private readonly AlgorithmController _algorithmController;
        private readonly ChartView _chartView;
        private readonly ResetFeature _resetFeature;
        private readonly SortingTypeSelector _sortingTypeSelector;
        private readonly StartFeature _startFeature;
        private readonly StopFeature _stopFeature;

        public MainForm()
        {
            InitializeComponent();

            _delay = new Delay();
            _delayChanger = new DelayChanger(delayChanger, _delay);
            _arraySizeChanger = new ArraySizeChanger(arraySizeChanger);
            _algorithmController = new AlgorithmController(new AlgorithmFactory(), _delay);
            _chartView = new ChartView(chart, toggle3DButton, colorPickBox);
            _resetFeature = new ResetFeature(resetButton, startButton, _chartView, new NumericDataGenerator(), _algorithmController, _arraySizeChanger);
            _sortingTypeSelector = new SortingTypeSelector(comboBox);
            _startFeature = new StartFeature(startButton, _algorithmController, _sortingTypeSelector, _chartView, resetButton, arraySizeChanger);
            _stopFeature = new StopFeature(stopButton, _algorithmController, _sortingTypeSelector, resetButton, startButton, arraySizeChanger);
        }
    }
}