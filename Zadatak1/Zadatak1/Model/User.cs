using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1.Model
{
    public class User : ValidationBase
    {
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Enter username.";
            }
            if (string.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Enter password.";
            }
        }
    }
}
