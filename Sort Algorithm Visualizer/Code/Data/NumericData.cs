namespace Sort_Algorithm_Visualizer.Data
{
    public class NumericData
    {
        public readonly int[] array;

        public event NumericDataChange Change;
        public int Length => array.Length;

        public NumericData(int[] array) =>
            this.array = array;

        public int this[int key]
        {
            get => array[key];
            set
            {
                array[key] = value;
                Change?.Invoke(key, value);
            }
        }

        public override string ToString()
            => string.Join(",", array);
    }

    public delegate void NumericDataChange(int index, int value);
}