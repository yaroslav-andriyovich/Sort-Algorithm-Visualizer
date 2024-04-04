using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Algorithms;

namespace Sort_Algorithm_Visualizer.UI.SortControls
{
    public class SortTypeSelector
    {
        public bool Enabled
        {
            get => _dropdownMenu.Enabled;
            set => _dropdownMenu.Enabled = value;
        }

        private readonly ComboBox _dropdownMenu;

        public SortTypeSelector(ComboBox dropdownMenu)
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
            foreach (SortAlgorithmType type in Enum.GetValues(typeof(SortAlgorithmType)))
                _dropdownMenu.Items.Add(type);
        }
    }
}