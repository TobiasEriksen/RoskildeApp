using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MVVM.Model;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel
{
    class ViewModelDefault : INotifyPropertyChanged
    {


        public static RestaurentList _List;

        public static Restaurent _Restaurent;

        public static Menu _Menu;

        public static ObservableCollection<Restaurent> List
        {
            get { return _List.List; }
        }

        public static Restaurent Restaurent
        {
            get { return _Restaurent; }
            set { _Restaurent = value; }
        }

        public static Menu Menu
        {
            get { return _Menu; }
            set { _Menu = value; }
        }


        public ViewModelDefault()
        {  
            _List = new RestaurentList();
            _List.PopulateList();
        }

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
