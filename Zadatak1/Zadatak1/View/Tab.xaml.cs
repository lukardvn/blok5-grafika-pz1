using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zadatak1.ViewModel;

namespace Zadatak1.View
{
    /// <summary>
    /// Interaction logic for Tav.xaml
    /// </summary>
    public partial class Tab : Window
    {
        public Tab()
        {
            InitializeComponent();
            this.DataContext = new TabViewModel(this);
        }
    }
}
