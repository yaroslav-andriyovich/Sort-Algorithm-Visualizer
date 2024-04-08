using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ColorPicker
    {
        public event Action<Color> Pick;
        public Color Color => _pickBox.BackColor;

        private readonly PictureBox _pickBox;

        public ColorPicker(PictureBox pickBox)
        {
            _pickBox = pickBox;
            
            _pickBox.Click += OnPickBoxClick;
        }

        private void OnPickBoxClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _pickBox.BackColor = colorDialog.Color;
                Pick?.Invoke(Color);
            }
        }
    }
}