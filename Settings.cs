namespace BlazorApp2.Shared
{
    public class Settings
    {
        private int _maxRowsToDisplay;
        public int maxRowsToDisplay {

            get { return _maxRowsToDisplay; } 

            set { if (value < 10) _maxRowsToDisplay = 10;
                else if (value > 200) _maxRowsToDisplay = 200;
                else _maxRowsToDisplay = value;
            }
        }

        public Settings()
        {
            maxRowsToDisplay = 10;
        }
    }
}
