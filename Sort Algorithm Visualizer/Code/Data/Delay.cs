namespace Sort_Algorithm_Visualizer.Data
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
                    _value = value;
                }
            }
        }
        
        private readonly object _lock = new object();

        private int _value;
    }
}