using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sort_Algorithm_Visualizer.UI.ChartControl
{
    public class ChartColorPicker
    {
        public Color Color => _pickBox.BackColor;
        
        private readonly PictureBox _pickBox;

        public ChartColorPicker(PictureBox pickBox)
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
            }
        }
    }
}