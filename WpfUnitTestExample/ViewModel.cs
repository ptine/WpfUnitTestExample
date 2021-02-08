using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUnitTestExample
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region private fields
        private bool[] _positions;
        private int _positionsCount;
        private int freePlace;
        private int _positionsNeeded;
        private ObservableCollection<int> _listItemSource;
        private object _selectedPosition;
        private bool _isCircular;
        private string _resultMessage;
        #endregion

        #region constructors
        public ViewModel()
        {
            ListItemSource = new ObservableCollection<int>();
            //lets start with a 12 items magazine
            PositionsCount = 8;
            PositionsNeeded = 4;
        }
        #endregion

        #region public properties        
        public ObservableCollection<int> ListItemSource
        {
            get => _listItemSource;
            set
            {
                _listItemSource = value;
                OnPropertyChanged("ListItemSource");
            }
        }

        public int PositionsCount
        {
            get => _positionsCount; set
            {
                _positionsCount = value;
                LoadPlaces();
                CheckResult();
                OnPropertyChanged("PositionsCount");
            }
        }

        public int PositionsNeeded
        {
            get => _positionsNeeded; set
            {
                _positionsNeeded = value;
                CheckResult();
                OnPropertyChanged("PositionsNeeded");
            }
        }

        public object SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                _selectedPosition = value;
                OnPropertyChanged("SelectedPosition");
            }
        }

        public bool IsCircular
        {
            get => _isCircular;
            set
            {
                _isCircular = value;
                CheckResult();
                OnPropertyChanged("IsCircular");
            }
        }

        public string ResultMessage
        {
            get => _resultMessage; set
            {
                _resultMessage = value;
                OnPropertyChanged("ResultMessage");
            }
        }

        public int FreePlace
        {
            get => freePlace;
            set
            {
                freePlace = value;
                OnPropertyChanged("FreePlace");
            }
        }

        public bool[] Positions { get => _positions; set => _positions = value; }
        #endregion

        #region private methods
        /// <summary>
        /// Load listview itemsource and initialize places array
        /// </summary>
        private void LoadPlaces()
        {
            ListItemSource.Clear();
            for (int i = 0; i < PositionsCount; i++)
            {
                ListItemSource.Add(i);
            }

            _positions = new bool[PositionsCount];
        }

        /// <summary>
        /// Check if free position is found
        /// </summary>
        public int CheckResult()
        {
            var result = Utils.FindFreePosition(Positions, PositionsNeeded, IsCircular);

            ResultMessage = $"is circular = {IsCircular} , needed Places = {PositionsNeeded} , returns {result}";

            return result;
        }
        #endregion

        #region interface implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string strPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(strPropertyName));
            }
        }
        #endregion
    }
}
