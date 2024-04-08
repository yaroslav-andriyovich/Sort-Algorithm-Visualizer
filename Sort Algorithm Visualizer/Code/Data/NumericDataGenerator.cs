using System;

namespace Sort_Algorithm_Visualizer.Data
{
    public class NumericDataGenerator
    {
        private readonly Random _random;
        
        private int[] _data;

        public NumericDataGenerator() => 
            _random = new Random();

        public NumericData Generate(int size, int minValue, int maxValue)
        {
            CreateArray(size);
            FillData(size, minValue, maxValue);
            
            return new NumericData(_data);
        }

        private void CreateArray(int size) => 
            _data = new int[size];

        private void FillData(int size, int minValue, int maxValue)
        {
            for (int i = 0; i < size; i++)
                _data[i] = GetRandomNumber(minValue, maxValue);
        }

        private int GetRandomNumber(int min, int max) => 
            _random.Next(min, max);
    }
}