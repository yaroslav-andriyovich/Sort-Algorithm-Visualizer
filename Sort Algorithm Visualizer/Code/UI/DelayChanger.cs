using System;
using System.Windows.Forms;
using Sort_Algorithm_Visualizer.Data;

namespace Sort_Algorithm_Visualizer.UI
{
    public class DelayChanger
    {
        private readonly NumericUpDown _numericUpDown;
        private readonly Delay _delay;

        public DelayChanger(NumericUpDown numericUpDown, Delay delay)
        {
            _numericUpDown = numericUpDown;
            _delay = delay;

            _numericUpDown.ValueChanged += OnNumericUpDownChange;

            ChangeDelay();
        }

        private void OnNumericUpDownChange(object sender, EventArgs e) => 
            ChangeDelay();

        private void ChangeDelay() => 
            _delay.Value = Convert.ToInt32(_numericUpDown.Value);
    }
}