// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using System;
using System.ServiceModel.Channels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MVVM.Model;
using MVVM.ViewModel;
using System.Collections.ObjectModel;

namespace MVVM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int currentListNumber { get; set; }
        private int prevListNumber { get; set; }
        private int nextListNumber { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            RestaurantItemsControl.ItemsSource = ViewModelDefault.List;
            nextListNumber = 9;
        }

        private void paginationList(int fromValue = 1)
        {
            ObservableCollection<Restaurent> tempList = new ObservableCollection<Restaurent>();
            int itemsToShow = 8;
            int collectionAmount = ViewModelDefault.List.Count;

            fromValue = (fromValue > collectionAmount || fromValue < 1 ? 1 : fromValue);
            currentListNumber = fromValue;
            prevListNumber = ((currentListNumber - itemsToShow) < 1 ? 1 : (currentListNumber - itemsToShow));

            foreach (Restaurent currentRestaurent in ViewModelDefault.List)
            {
                int currentId = Convert.ToInt32(currentRestaurent.UniqueId);
                if (currentId == fromValue || (currentId > fromValue && currentId <= (fromValue + itemsToShow) - 1))
                {
                    tempList.Add(currentRestaurent);
                    nextListNumber = (currentId + 1);
                }
            }
            RestaurantItemsControl.ItemsSource = tempList;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            paginationList(prevListNumber);
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            paginationList(nextListNumber);
        }

        private void RestaurantButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Restaurent) ((Button) sender).Content).Description != "")
            {
                ViewModelDefault.Restaurent = (Restaurent)((Button)sender).Content;
                this.Frame.Navigate(typeof (Restaurant));
            }
        }

    }
}
