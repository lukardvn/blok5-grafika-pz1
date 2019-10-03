using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1.Model
{
    public class XMLPictures
    {
        private string path;
        private string title;
        private string description;
        private DateTime time;
        private string owner;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
