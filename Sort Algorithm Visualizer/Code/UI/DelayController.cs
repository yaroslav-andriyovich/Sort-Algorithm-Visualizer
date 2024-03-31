using System;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer.Code.UI
{
    public class DelayController
    {
        private readonly TextBox _delayInput;

        public DelayController(TextBox delayInput)
        {
            _delayInput = delayInput;
            _delayInput.KeyPress += DelayInputOnKeyPress;

            UpdateText();
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
            Settings.Instance.Delay = Int32.Parse(_delayInput.Text);

        private void UpdateText() => 
            _delayInput.Text = Settings.Instance.Delay.ToString();
    }
}