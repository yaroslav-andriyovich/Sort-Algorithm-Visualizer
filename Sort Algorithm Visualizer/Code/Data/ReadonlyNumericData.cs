using System.Linq;

namespace Sort_Algorithm_Visualizer.Data
{
    public class ReadonlyNumericData
    {
        public int Length => _data.Length;

        private readonly NumericData _data;

        public ReadonlyNumericData(NumericData data) => 
            _data = data;

        public int this[int key]
            => _data.array[key];

        public override string ToString()
            => string.Join(",", _data.array);

        public int GetMaxValue() =>
            _data.array.Max();
    }
}