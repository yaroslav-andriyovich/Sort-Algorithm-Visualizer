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
        private Delay _delay;
        private DelayChanger _delayChanger;
        private ArraySizeChanger _arraySizeChanger;
        private SortingController _sortingController;
        private ChartView _chartView;
        private ChartAlgorithmConnector _chartAlgorithmConnector;
        private SortTypeSelector _sortTypeSelector;
        private ResetFeature _resetFeature;
        private StartFeature _startFeature;
        private StopFeature _stopFeature;

        public MainForm()
        {
            InitializeComponent();
            Compose();
        }

        private void Compose()
        {
            RegisterDelay();
            RegisterArraySizeChanger();
            RegisterSortController();
            RegisterChart();
            RegisterChartAlgorithmConnection();
            RegisterSortTypeSelector();
            RegisterUserFeatures();
        }

        private void RegisterDelay()
        {
            _delay = new Delay();
            _delayChanger = new DelayChanger(delayChanger, _delay);
        }

        private void RegisterArraySizeChanger() => 
            _arraySizeChanger = new ArraySizeChanger(arraySizeChanger);

        private void RegisterSortController() => 
            _sortingController = new SortingController(_delay, new AlgorithmFactory(), new SortingThread());

        private void RegisterChart() => 
            _chartView = new ChartView(chart, new ColorPicker(colorPickBox), toggle3DButton, togglePointLabelsButton);

        private void RegisterChartAlgorithmConnection() => 
            _chartAlgorithmConnector = new ChartAlgorithmConnector(_chartView, _sortingController, new NumericDataGenerator());

        private void RegisterSortTypeSelector() => 
            _sortTypeSelector = new SortTypeSelector(comboBox);

        private void RegisterUserFeatures()
        {
            _resetFeature = new ResetFeature(resetButton, startButton, _chartAlgorithmConnector, _sortingController, _arraySizeChanger);
            _startFeature = new StartFeature(startButton, _sortingController, _sortTypeSelector, resetButton, arraySizeChanger, colorPickBox);
            _stopFeature = new StopFeature(stopButton, _sortingController, _sortTypeSelector, resetButton, startButton, arraySizeChanger, colorPickBox);
        }
    }
}