using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace MVVM.Model
{

    public class RestaurentList
    {
        private ObservableCollection<Restaurent> _List = new ObservableCollection<Restaurent>();

        public ObservableCollection<Restaurent> List
        {
            get { return _List; }
        }

        public async Task PopulateList()
        {
            if (this._List.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///Model/SampleData.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            // Json
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Restaurent"].GetArray();

            foreach (JsonValue restaurentValue in jsonArray)
            {
                JsonObject restaurentObject = restaurentValue.GetObject();
                Restaurent restaurent = new Restaurent(restaurentObject["UniqueId"].GetString(),
                    restaurentObject["Title"].GetString(),
                    restaurentObject["RestaurantImage"].GetString(),
                    restaurentObject["Logo"].GetString(),
                    restaurentObject["Description"].GetString(),
                    restaurentObject["OpenTimes"].GetString(),
                    restaurentObject["Adress"].GetString(),
                    restaurentObject["MapImage"].GetString(),
                    restaurentObject["MapDirection"].GetString(),
                    restaurentObject["LargeImage"].GetString());

                foreach (JsonValue menuValue in restaurentObject["Menu"].GetArray())
                {
                    JsonObject menuObject = menuValue.GetObject();
                    restaurent.Menu.Add(new Menu(menuObject["UniqueId"].GetString(),
                        menuObject["RestaurentId"].GetString(),
                        menuObject["Title"].GetString(),
                        menuObject["ImagePath"].GetString(),
                        menuObject["Description"].GetString(),
                        menuObject["Price"].GetString(),
                        menuObject["Sale"].GetString()));
                }
                this._List.Add(restaurent);
            }
        }

        public override string ToString()
        {
            return _List[0].ToString();
        }
    }

}
