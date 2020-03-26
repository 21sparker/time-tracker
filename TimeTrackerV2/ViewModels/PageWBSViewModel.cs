using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TimeTrackerV2.Data;

namespace TimeTrackerV2
{
    public class PageWBSViewModel : ObservableObject, IPageViewModel
    {

        private DatabaseContext _DBcontext;
        public ObservableCollection<WBS> WBSs { get; set; }
        //public ObservableCollection<WBS> WBSModels { get; set; }

        /// <summary>
        /// Name of View Model
        /// </summary>
        public string Name
        {
            get { return "WBS"; }
        }


        /// <summary>
        /// WBS selected in listView
        /// </summary>
        private WBS selectedWBS;
        public WBS SelectedWBS
        {
            get { return selectedWBS; }
            set
            {
                selectedWBS = value;
                OnPropertyChanged("SelectedWBS");
            }
        }

        private string newWBSName;
        public string NewWBSName
        {
            get { return newWBSName; }
            set
            {
                if (newWBSName != value)
                {
                    newWBSName = value;
                    OnPropertyChanged("NewWBSName");
                }
            }
        }

        private string newWBSCode;
        public string NewWBSCode
        {
            get { return newWBSCode; }
            set
            {
                if (newWBSCode != value)
                {
                    newWBSCode = value;
                    OnPropertyChanged("NewWBSCode");
                }
            }
        }

        private string newWBSDescription;
        public string NewWBSDescription
        {
            get { return newWBSDescription; }
            set
            {
                if (newWBSDescription != value)
                {
                    newWBSDescription = value;
                    OnPropertyChanged("NewWBSDescription");
                }
            }
        }

        private string newWBSTaxArea;
        public string NewWBSTaxArea
        {
            get { return newWBSTaxArea; }
            set
            {
                if (newWBSTaxArea != value)
                {
                    newWBSTaxArea = value;
                    OnPropertyChanged("NewWBSTaxArea");
                }
            }
        }

        private string statusMessage;
        public string StatusMessage
        {
            get { return statusMessage; }
            set
            {
                statusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        public PageWBSViewModel(DatabaseContext _context, ObservableCollection<WBS> wbss)
        {
            _DBcontext = _context;
            WBSs = wbss;
        }


        private ICommand _addWBSCommand;
        public ICommand AddWBSCommand
        {
            get
            {
                if (_addWBSCommand == null)
                {
                    _addWBSCommand = new RelayCommand(
                        param => AddWBS());
                }

                return _addWBSCommand;
            }
        }

        private void AddWBS()
        {
            WBS wbs = CreateNewProjectFromFields();

            string tempStatusMessage;
            if (!WBSisValid(wbs, out tempStatusMessage))
            {
                StatusMessage = tempStatusMessage;
                return;
            }

            _DBcontext.InsertIntoDatabase(wbs);
            StatusMessage = "WBS successfully added.";

            // Update wbs observable collection to include new item
            WBSs.Add(wbs);

            ResetNewWBSFields();

        }

        private WBS CreateNewProjectFromFields()
        {
            WBS wbs = new WBS();
            wbs.Name = NewWBSName;
            wbs.Description = NewWBSDescription;
            wbs.Code = NewWBSCode;
            wbs.TaxArea = NewWBSTaxArea;
            wbs.CreatedDate = DateTimeOffset.Now.ToUnixTimeSeconds();

            return wbs;
        }

        private bool WBSisValid(WBS wbs, out string statusMessage)
        {
            // Check for empty attributes
            if (string.IsNullOrWhiteSpace(wbs.Name))
            {
                statusMessage = "Name cannot be empty.";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(wbs.Code))
            {
                statusMessage = "Code cannot be empty.";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(wbs.TaxArea))
            {
                statusMessage = "Tax Area cannot be empty.";
                return false;
            }

            // Check for duplicate WBS objects
            bool duplicateName = _DBcontext.WBSs.SingleOrDefault(w => w.Name == wbs.Name) != null;
            bool duplicateCode = _DBcontext.WBSs.SingleOrDefault(w => w.Code == wbs.Code) != null;
            if (duplicateName)
            {
                statusMessage = "Duplicate WBS name found.";
            }
            else if (duplicateCode)
            {
                statusMessage = "Duplicate WBS code found.";
            }
            else
            {
                statusMessage = "Success";
            }

            return !(duplicateName || duplicateCode);
        }

        private void ResetNewWBSFields()
        {
            NewWBSName = "";
            NewWBSDescription = "";
            NewWBSCode = "";
            NewWBSTaxArea = "";
        }


        private ICommand _deleteWBSCommand;
        public ICommand DeleteWBSCommand
        {
            get
            {
                if (_deleteWBSCommand == null)
                {
                    _deleteWBSCommand = new RelayCommand(
                        param => deleteWBS(),
                        param => (SelectedWBS != null)
                        );
                }

                return _deleteWBSCommand;
            }
        }

        private void deleteWBS()
        {
            _DBcontext.WBSs.Remove(SelectedWBS);
            _DBcontext.SaveChanges();

            WBSs.Remove(SelectedWBS);
            SelectedWBS = null;

        }
    }
}
