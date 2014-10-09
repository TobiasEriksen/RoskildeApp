using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Menu
    {
        public string UniqueId { get; private set; }
        public string RestaurentId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Price { get; private set; }
        public string Sale { get; private set; }
        public Menu(String uniqueId, String restaurentId, String title, String imagePath, String description, String price, String sale)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.RestaurentId = restaurentId;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Price = price;
            this.Sale = sale;
        }

        public override string ToString()
        {
            return null;
        }
    }
}
