namespace Sort_Algorithm_Visualizer.Code
{
    public class Settings
    {
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Settings();
                
                return _instance;
            }
        }

        public int Delay
        {
            get => _delay;
            set
            {
                if (value < 0 )
                    _delay = 0;
                else if (value > 2000)
                    _delay = 2000;
                else
                    _delay = value;
            }
        }
        
        private static Settings _instance;
        private int _delay;

        public Settings()
        {
            Delay = 250;
        }
    }
}