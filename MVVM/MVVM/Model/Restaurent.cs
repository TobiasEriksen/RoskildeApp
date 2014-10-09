using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Restaurent
    {
        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string RestaurantImage { get; private set; }
        public string Description { get; private set; }
        public string Logo { get; private set; }
        public string OpenTimes { get; private set; }
        public string Adress { get; private set; }
        public string MapImage { get; private set; }
        public string MapDirection { get; private set; }
        public string LargeImage { get; private set; }
        public ObservableCollection<Menu> Menu { get; private set; }
        public Restaurent(String uniqueId, String title, String restaurantImage, String logo, String description, String openTimes, String adress, String mapImage, String mapDirection, String largeImage)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.RestaurantImage = restaurantImage;
            this.Description = description;
            this.Logo = logo;
            this.OpenTimes = openTimes;
            this.Adress = adress;
            this.MapImage = mapImage;
            this.MapDirection = mapDirection;
            this.LargeImage = largeImage;
            this.Menu = new ObservableCollection<Menu>();
        }

        public override string ToString()
        {
            return null;
        }
    }
}
