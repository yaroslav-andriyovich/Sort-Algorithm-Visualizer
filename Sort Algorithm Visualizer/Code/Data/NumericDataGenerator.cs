using System;

namespace Sort_Algorithm_Visualizer.Data
{
    public class NumericDataGenerator
    {
        private readonly Random _random;
        
        private int[] _data;

        public NumericDataGenerator() => 
            _random = new Random();

        public int[] Generate(int elementsNumber, int maxElementValue)
        {
            CreateArray(elementsNumber);
            FillData(elementsNumber, maxElementValue);
            
            return _data;
        }

        private void CreateArray(int elementsNumber) => 
            _data = new int[elementsNumber];

        private void FillData(int elementsNumber, int maxElementValue)
        {
            for (int i = 0; i < elementsNumber; i++)
            {
                _data[i] = GetRandomNumber(maxElementValue);
            }
        }

        private int GetRandomNumber(int maxElementValue) => 
            _random.Next(0, maxElementValue);
    }
}