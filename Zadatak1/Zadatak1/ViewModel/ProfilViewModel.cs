using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zadatak1.Model;
using Zadatak1.View;

namespace Zadatak1.ViewModel
{
    public class ProfilViewModel : BindableBase
    {
        public List<string> numberList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public List<XMLUsers> Users { get; set; }
        public MyICommand ChangeCommand { get; set; }
        private User currentUser = new User();
        private Profil view;

        public ProfilViewModel()
        {
            ChangeCommand = new MyICommand(Change);
            LoadUsers();

            CurrentUser.Username = Global.UserInSystem.Username;
            CurrentUser.Password = Global.UserInSystem.Password;
        }
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }


        public void WriteUsers()
        {
            XmlSerializer serUsers = new XmlSerializer(typeof(List<XMLUsers>));
            StreamWriter swUsers = new StreamWriter(@"../../../users.xml");
            serUsers.Serialize(swUsers, Users);
            swUsers.Close();
        }

        public ProfilViewModel(Profil param)
        {
            this.view = param;
            ChangeCommand = new MyICommand(Change);
            LoadUsers();
            
            CurrentUser.Username = Global.UserInSystem.Username;
            CurrentUser.Password = Global.UserInSystem.Password;
        }

        

       

        public void Change()
        {
            CurrentUser.Validate();
            if (CurrentUser.IsValid)
            {
                foreach (var item in Users)
                {
                    if (item.Username == CurrentUser.Username)
                    {
                        if (item.Username == Global.UserInSystem.Username)
                        {
                            continue;
                        }
                        view.userBlock.Text = "Korisnik: " + CurrentUser.Username + " vec postoji!";

                        return;
                    }
                }

                foreach (var item in numberList)
                {
                    if (CurrentUser.Username[0].ToString() == item)
                    {
                        view.userBlock.Text = "Pocetno slovo ne moze biti broj";

                        return;
                    }
                }

                if (CurrentUser.Password.Length <= 6)
                {
                    view.passBlock.Text = "Sifra mora da bude duza od 6 karaktera";

                    return;
                }

                foreach (var item in Users)
                {
                    if (item.Username == Global.UserInSystem.Username && item.Password == Global.UserInSystem.Password)
                    {
                        item.Password = CurrentUser.Password;
                        item.Username = CurrentUser.Username;

                        Global.UserInSystem = CurrentUser;

                        view.passBlock.Text = "";
                        view.userBlock.Text = "";

                        break;
                    }
                }
                
                WriteUsers();
            }
        }

        public void LoadUsers()
        {
            try
            {
                XmlSerializer serUsers = new XmlSerializer(typeof(List<XMLUsers>));
                StreamReader srUsers = new StreamReader(@"../../../users.xml");
                Users = (List<XMLUsers>)serUsers.Deserialize(srUsers);
                srUsers.Close();
            }
            catch
            {
                Users = new List<XMLUsers>();
            }
        }

    }
}
