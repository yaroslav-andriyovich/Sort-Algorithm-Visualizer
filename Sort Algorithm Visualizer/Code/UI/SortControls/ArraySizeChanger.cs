using System;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer.UI.SortControls
{
    public class ArraySizeChanger
    {
        public event Action<int> Changed;
        public int Size => Convert.ToInt32(_numericUpDown.Value);
        
        private readonly NumericUpDown _numericUpDown;

        public ArraySizeChanger(NumericUpDown numericUpDown)
        {
            _numericUpDown = numericUpDown;
            _numericUpDown.ValueChanged += NumericUpDownOnValueChanged;
        }

        private void NumericUpDownOnValueChanged(object sender, EventArgs e) => 
            Changed?.Invoke(Size);
    }
}