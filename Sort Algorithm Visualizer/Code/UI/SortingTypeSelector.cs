using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;

namespace Sort_Algorithm_Visualizer.UI
{
    public class SortingTypeSelector
    {
        public bool Enabled
        {
            get => _dropdownMenu.Enabled;
            set => _dropdownMenu.Enabled = value;
        }

        private readonly ComboBox _dropdownMenu;

        public SortingTypeSelector(ComboBox dropdownMenu)
        {
            _dropdownMenu = dropdownMenu;
            
            AddMenuItems();
            SelectDefault();
        }

        public SortAlgorithmType GetSelected() => 
            (SortAlgorithmType)_dropdownMenu.SelectedItem;

        private void SelectDefault() => 
            _dropdownMenu.SelectedIndex = 0;

        private void AddMenuItems()
        {
            _dropdownMenu.Items.Add(SortAlgorithmType.Bubble);
            _dropdownMenu.Items.Add(SortAlgorithmType.Insertion);
        }
    }
}