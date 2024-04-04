using System;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer.UI.SortControls
{
    public class ArraySizeChanger
    {
        public int Size => Convert.ToInt32(_numericUpDown.Value);
        
        private readonly NumericUpDown _numericUpDown;

        public ArraySizeChanger(NumericUpDown numericUpDown) => 
            _numericUpDown = numericUpDown;
    }
}