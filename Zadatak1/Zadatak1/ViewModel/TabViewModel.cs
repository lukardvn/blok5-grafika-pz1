using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Zadatak1.View;

namespace Zadatak1.ViewModel
{
    public class TabViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private PicturesViewModel myimagesViewModel = new PicturesViewModel();
        private AddPicViewModel addimagesViewModel = new AddPicViewModel();
        private ProfilViewModel accdetailViewModel = new ProfilViewModel();
        private BindableBase currentViewModel;
        private Tab view;


        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public TabViewModel(Tab param)
        {
            this.view = param;

            NavCommand = new MyICommand<string>(OnNav);

            if (Global.Setter == 1)
            {
                CurrentViewModel = addimagesViewModel;

                view.new1.Background = new SolidColorBrush(Colors.LightSkyBlue);
                view.new1.Foreground = new SolidColorBrush(Colors.Black);
                view.new2.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                view.new2.Foreground = new SolidColorBrush(Colors.White);
                view.new3.Background = new SolidColorBrush(Colors.LightSkyBlue);
                view.new3.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                CurrentViewModel = myimagesViewModel;

                view.new1.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                view.new1.Foreground = new SolidColorBrush(Colors.White);
                view.new2.Background = new SolidColorBrush(Colors.LightSkyBlue);
                view.new2.Foreground = new SolidColorBrush(Colors.Black);
                view.new3.Background = new SolidColorBrush(Colors.LightSkyBlue);
                view.new3.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

       

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "images":
                    CurrentViewModel = myimagesViewModel;

                    view.new1.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                    view.new1.Foreground = new SolidColorBrush(Colors.White);
                    view.new2.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    view.new2.Foreground = new SolidColorBrush(Colors.Black);
                    view.new3.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    view.new3.Foreground = new SolidColorBrush(Colors.Black);

                    break;
                case "add":
                    CurrentViewModel = addimagesViewModel;

                    view.new1.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    view.new1.Foreground = new SolidColorBrush(Colors.Black);
                    view.new2.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                    view.new2.Foreground = new SolidColorBrush(Colors.White);
                    view.new3.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    view.new3.Foreground = new SolidColorBrush(Colors.Black);

                    break;
                case "details":
                    CurrentViewModel = accdetailViewModel;

                    view.new1.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    view.new1.Foreground = new SolidColorBrush(Colors.Black);
                    view.new2.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    view.new2.Foreground = new SolidColorBrush(Colors.Black);
                    view.new3.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                    view.new3.Foreground = new SolidColorBrush(Colors.White);

                    break;
            }
        }
    }
}
