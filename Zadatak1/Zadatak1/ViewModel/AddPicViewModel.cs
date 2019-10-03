using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using Zadatak1.Model;

namespace Zadatak1.ViewModel
{
    public class AddPicViewModel : BindableBase
    {
        private Picture currentPicture = new Picture();
        public List<XMLPictures> Pictures { get; set; }
        public MyICommand AddImageCommand { get; set; }

        public MyICommand SetPictureCommand { get; set; }
        public string path = "";

        public AddPicViewModel()
        {
            LoadPictures();
            AddImageCommand = new MyICommand(Change);
            SetPictureCommand = new MyICommand(AddPicture);
        }

        private BitmapImage _bitmapImage;
        public BitmapImage BitmapImage
        {
            get { return _bitmapImage; }
            set
            {
                _bitmapImage = value;
                OnPropertyChanged("BitmapImage");
            }
        }

        public void AddPicture()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                FileName = "Image",
                DefaultExt = ".jpg",
                Filter = "Image Files (.jpg)|*.jpg"
            };
            if (!ofd.ShowDialog().Equals(true))
                return;

            path = ofd.FileName;
            CurrentPicture.Path = path;

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ofd.OpenFile();
            bitmapImage.EndInit();

            BitmapImage = bitmapImage;
        }

        public void Change()
        {
            CurrentPicture.Validate();
            if (CurrentPicture.IsValid)
            {
                Pictures.Add(new XMLPictures { Title = CurrentPicture.Title, Owner = Global.UserInSystem.Username, Path = CurrentPicture.Path, Time = DateTime.Now, Description = CurrentPicture.Description });
                WritePictures();

                CurrentPicture.Path = "";
                CurrentPicture.Title = "";
                CurrentPicture.Description = "";
                BitmapImage = null;
            }
        }

        public void LoadPictures()
        {
            try
            {
                XmlSerializer serPictures = new XmlSerializer(typeof(List<XMLPictures>));
                StreamReader srPictures = new StreamReader(@"../../../pictures.xml");
                Pictures = (List<XMLPictures>)serPictures.Deserialize(srPictures);
                srPictures.Close();
            }
            catch
            {
                Pictures = new List<XMLPictures>();
            }
        }

        public Picture CurrentPicture
        {
            get { return currentPicture; }
            set
            {
                currentPicture = value;
                OnPropertyChanged("CurrentPicture");
            }
        }

        public void WritePictures()
        {
            XmlSerializer serPictures = new XmlSerializer(typeof(List<XMLPictures>));
            StreamWriter swPictures = new StreamWriter(@"../../../pictures.xml");
            serPictures.Serialize(swPictures, Pictures);
            swPictures.Close();
        }

       

      
    }
}
