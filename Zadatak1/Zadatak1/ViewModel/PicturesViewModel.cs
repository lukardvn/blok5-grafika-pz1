using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zadatak1.Model;
using System.Drawing;

namespace Zadatak1.ViewModel
{
    public class PicturesViewModel : BindableBase
    {
        public ObservableCollection<Picture> Pictures { get; set; }
        public List<XMLPictures> PicturesList { get; set; }

        public PicturesViewModel()
        {
            LoadPictures();
        }

        public void LoadPictures()
        {
            ObservableCollection<Picture> tempPictures = new ObservableCollection<Picture>();

            try
            {
                XmlSerializer serPictures = new XmlSerializer(typeof(List<XMLPictures>));
                StreamReader srPictures = new StreamReader(@"../../../pictures.xml");
                PicturesList = (List<XMLPictures>)serPictures.Deserialize(srPictures);
                srPictures.Close();
            }
            catch
            {
                PicturesList = new List<XMLPictures>();
            }

            foreach (var item in PicturesList)
            {
                if (item.Owner == Global.UserInSystem.Username)
                {
                    Picture temp = new Picture();
                    temp.Description = item.Description;
                    temp.Owner = item.Owner;
                    temp.Path = item.Path;
                    temp.Time = item.Time;
                    temp.Title = item.Title;
                    
                    tempPictures.Add(temp);
                }
            }

            Pictures = tempPictures;
        }
    }
}
