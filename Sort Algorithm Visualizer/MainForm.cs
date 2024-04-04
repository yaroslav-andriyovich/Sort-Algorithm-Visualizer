using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;
using Sort_Algorithm_Visualizer.Common;
using Sort_Algorithm_Visualizer.Data;
using Sort_Algorithm_Visualizer.UI.ChartControl;
using Sort_Algorithm_Visualizer.UI.SortControls;

namespace Sort_Algorithm_Visualizer
{
    public partial class MainForm : Form
    {
        private readonly Delay _delay;
        private readonly SortDelayChanger _sortDelayChanger;
        private readonly ArraySizeChanger _arraySizeChanger;
        private readonly SortingController _sortingController;
        private readonly ChartView _chartView;
        private readonly ChartAlgorithmConnector _chartAlgorithmConnector;
        private readonly ResetFeature _resetFeature;
        private readonly SortTypeSelector _sortTypeSelector;
        private readonly StartFeature _startFeature;
        private readonly StopFeature _stopFeature;

        public MainForm()
        {
            InitializeComponent();

            _delay = new Delay();
            _sortDelayChanger = new SortDelayChanger(delayChanger, _delay);
            _arraySizeChanger = new ArraySizeChanger(arraySizeChanger);
            _sortingController = new SortingController(_delay);
            _chartView = new ChartView(chart, toggle3DButton, colorPickBox);
            _chartAlgorithmConnector = new ChartAlgorithmConnector(_chartView, _sortingController, new NumericDataGenerator());
            _resetFeature = new ResetFeature(resetButton, startButton, _chartAlgorithmConnector, _sortingController, _arraySizeChanger);
            _sortTypeSelector = new SortTypeSelector(comboBox);
            _startFeature = new StartFeature(startButton, _sortingController, _sortTypeSelector, resetButton, arraySizeChanger);
            _stopFeature = new StopFeature(stopButton, _sortingController, _sortTypeSelector, resetButton, startButton, arraySizeChanger);
        }
    }
}