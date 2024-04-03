using System;

namespace Sort_Algorithm_Visualizer.Data
{
    public class NumericDataGenerator
    {
        private readonly Random _random;
        
        private int[] _data;

        public NumericDataGenerator() => 
            _random = new Random();

        public int[] Generate(int elementsCount, int maxElementValue)
        {
            CreateArray(elementsCount);
            FillData(elementsCount, maxElementValue);
            
            return _data;
        }

        private void CreateArray(int elementsCount) => 
            _data = new int[elementsCount];

        private void FillData(int elementsCount, int maxElementValue)
        {
            for (int i = 0; i < elementsCount; i++)
            {
                _data[i] = GetRandomNumber(maxElementValue);
            }
        }

        private int GetRandomNumber(int maxElementValue) => 
            _random.Next(0, maxElementValue);
    }
}