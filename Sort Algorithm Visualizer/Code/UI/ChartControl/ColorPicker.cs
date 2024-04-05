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

        public Color GetPointColor(int dataValue, int maxElementValue)
        {
            int red = Color.R;
            int green = Color.G;
            int blue = Color.B;
            
            float colorIntensity = dataValue / (float)maxElementValue;
            
            red = (int)(red * colorIntensity);
            green = (int)(green * colorIntensity);
            blue = (int)(blue * colorIntensity);
            
            Color color = Color.FromArgb(red, green, blue);
            
            return color;
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