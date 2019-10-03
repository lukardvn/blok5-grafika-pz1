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
    public class PrijavaViewModel : BindableBase
    {
        public List<string> numberList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public List<XMLUsers> Users { get; set; }
        public MyICommand LogInCommand { get; set; }
        public MyICommand RegisterCommand { get; set; }
        private User currentUser = new User();
        private Prijava view;

        public PrijavaViewModel(Prijava param)
        {
            this.view = param;
            LoadUsers();
            RegisterCommand = new MyICommand(Register);
            LogInCommand = new MyICommand(LogIn);
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
        public void LogIn()
        {
            CurrentUser.Validate();
            if (CurrentUser.IsValid)
            {
                foreach (var item in Users)
                {
                    if (item.Username == CurrentUser.Username && item.Password == CurrentUser.Password)
                    {
                        Global.UserInSystem = CurrentUser;
                        Global.Setter = 0;
                        Tab viewStart = new Tab();

                        viewStart.ShowDialog();

                        return;
                    }
                }

                view.userBlock.Text = "User " + CurrentUser.Username + " doesnt exist in db. :(";
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

      
        public void Register()
        {
            CurrentUser.Validate();
            if (CurrentUser.IsValid)
            {
                foreach (var item in Users)
                {
                    if (item.Username == CurrentUser.Username)
                    {
                        view.userBlock.Text = "User: " + CurrentUser.Username + " already exists!";

                        return;
                    }
                }

                foreach (var item in numberList)
                {
                    if (CurrentUser.Username[0].ToString() == item)
                    {
                        view.userBlock.Text = "Username cannot start with a number.";

                        return;
                    }
                }

                if (CurrentUser.Password.Length <= 6)
                {
                    view.passBlock.Text = "Password must be at least 6 characters long.";

                    return;
                }

                Users.Add(new XMLUsers { Username = CurrentUser.Username, Password = CurrentUser.Password });
                WriteUsers();

                Global.UserInSystem = CurrentUser;
                Global.Setter = 1;
                Tab viewStart = new Tab();

                viewStart.ShowDialog();
            }
        }
        public void WriteUsers()
        {
            XmlSerializer serUsers = new XmlSerializer(typeof(List<XMLUsers>));
            StreamWriter swUsers = new StreamWriter(@"../../../users.xml");
            serUsers.Serialize(swUsers, Users);
            swUsers.Close();
        }

    
    }
}