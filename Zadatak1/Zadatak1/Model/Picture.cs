using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1.Model
{
    public class Picture : ValidationBase
    {
        private string path;
        private string title;
        private string description;
        private DateTime time;
        private string owner;

        public string Path
        {
            get { return path; }
            set
            {
                if (path != value)
                {
                    path = value;
                    OnPropertyChanged("Path");
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public DateTime Time
        {
            get { return time; }
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        public string Owner
        {
            get { return owner; }
            set
            {
                if (owner != value)
                {
                    owner = value;
                    OnPropertyChanged("Owner");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.path))
            {
                this.ValidationErrors["Path"] = "Choose an image";
            }
            if (string.IsNullOrWhiteSpace(this.title))
            {
                this.ValidationErrors["Title"] = "Enter title";
            }
        }
    }
}
