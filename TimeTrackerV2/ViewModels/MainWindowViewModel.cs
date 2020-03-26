using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TimeTrackerV2.Data;

namespace TimeTrackerV2
{
    public class MainWindowViewModel : ObservableObject
    {


        //TODO: Need to add something that closes the database when the window closes
        // See here: https://stackoverflow.com/questions/3683450/handling-the-window-closing-event-with-wpf-mvvm-light-toolkit

        #region Fields

        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        /// <summary>
        /// Data application EF Core context
        /// </summary>
        private DatabaseContext _context;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            _context = new DatabaseContext();
            LoadApplicationData();

            // Add available pages
            PageViewModels.Add(new PageTrackerViewModel(_context, Projects, Tasks, TaskHistoryItems));
            PageViewModels.Add(new PageWBSViewModel(_context, WBSs));
            PageViewModels.Add(new PageProjectsViewModel(_context, Projects, WBSs));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #endregion

        #region Properties / Commands

        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<WBS> WBSs { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        public ObservableCollection<TaskHistoryItem> TaskHistoryItems { get; set; }

        private string someRandomString;
        public string SomeRandomString
        {
            get { return someRandomString; }
            set
            {
                someRandomString = value;
                OnPropertyChanged("SomeRandomString");
            }
        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new List<IPageViewModel>();
                }

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            //Close database connection
            _context.Dispose();
        }

        #endregion

        #region Methods
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
            {
                PageViewModels.Add(viewModel);
            }

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        private void LoadApplicationData()
        {
            Projects = new ObservableCollection<Project>(_context.Projects);
            WBSs = new ObservableCollection<WBS>(_context.WBSs);
            Tasks = new ObservableCollection<Task>(_context.Tasks);
            TaskHistoryItems = new ObservableCollection<TaskHistoryItem>(_context.TaskHistoryItems);
        }

        #endregion
    }
}
