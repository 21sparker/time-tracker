using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackerV2
{
    public class WBSViewModel : ObservableObject
    {
        private int wbsId;
        public int WBSId
        {
            get { return wbsId; }
            set
            {
                if (wbsId != value)
                {
                    wbsId = value;
                    OnPropertyChanged("WBSId");
                }
            }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                if (code != value)
                {
                    code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name;  }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string description;
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

        private string taxArea;
        public string TaxArea
        {
            get { return taxArea; }
            set
            {
                if (taxArea != value)
                {
                    taxArea = value;
                    OnPropertyChanged("TaxArea");
                }
            }
        }

        //public List<Project> Projects { get; set; }
    }
}
