using System;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer.Code.UI
{
    public class Delay
    {
        public int Value
        {
            get
            {
                lock (_lock)
                    return _value;
            }
            set
            {
                lock (_lock)
                {
                    if (value < Min)
                        _value = Min;
                    else if (value > Max)
                        _value = Max;
                    else
                        _value = value;
                }
            }
        }

        private const int Min = 0;
        private const int Max = 2000;
        private const int Default = 250;
        
        private readonly object _lock = new object();
        private readonly TextBox _delayInput;

        private int _value;

        public Delay(TextBox delayInput)
        {
            _delayInput = delayInput;
            _delayInput.KeyPress += DelayInputOnKeyPress;

            SetDefault();
        }

        private void DelayInputOnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ChangeDelay();
                UpdateText();
            }
        }

        private void ChangeDelay() => 
            Value = Int32.Parse(_delayInput.Text);

        private void UpdateText() => 
            _delayInput.Text = Value.ToString();

        private void SetDefault()
        {
            Value = Default;
            UpdateText();
        }
    }
}