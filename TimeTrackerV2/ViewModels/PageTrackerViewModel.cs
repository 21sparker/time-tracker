using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using TimeTrackerV2.Data;
using System.Windows.Input;
using System.Diagnostics;

namespace TimeTrackerV2
{
    public class PageTrackerViewModel : ObservableObject, IPageViewModel
    {
        private DatabaseContext _DBContext;

        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        public ObservableCollection<TaskHistoryItem> TaskHistoryItems { get; set; }

        public CountdownTimeViewModel CountdownTimer { get; set; }

        public string Name
        {
            get { return "Tracker"; }
        }

        private Project trackedProject;
        public Project TrackedProject
        {
            get { return trackedProject; }
            set
            {
                if (trackedProject != value)
                {
                    trackedProject = value;
                    OnPropertyChanged("TrackedProject");
                }
            }
        }

        private TimeSpan trackedTime;
        public TimeSpan TrackedTime
        {
            get { return trackedTime; }
            set
            {
                trackedTime = value;
                OnPropertyChanged("TrackedTime");
            }
        }

        private bool isTracking;
        public bool IsTracking
        {
            get { return isTracking; }
            set
            {
                if (isTracking != value)
                {
                    isTracking = value;
                    OnPropertyChanged("IsTracking");
                }
            }
        }


        public PageTrackerViewModel(DatabaseContext _context,
            ObservableCollection<Project> projects, ObservableCollection<Task> tasks, ObservableCollection<TaskHistoryItem> taskHistoryItems)
        {
            _DBContext = _context;
            Projects = projects;
            Tasks = tasks;
            TaskHistoryItems = taskHistoryItems;

            CountdownTimer = new CountdownTimeViewModel();
        }


        private ICommand _trackProjectCommand;
        public ICommand TrackProjectCommand
        {
            get
            {
                if (_trackProjectCommand == null)
                {
                    _trackProjectCommand = new RelayCommand(
                        param => this.TrackProject((Project)param));
                }

                return _trackProjectCommand;
            }
        }

        private void TrackProject(Project project)
        {
            if (TrackedProject == project)
            {
                if (IsTracking)
                {
                    EndTracking();
                }
                else
                {
                    StartTracking();
                }
            }
            else
            {
                EndTracking();
                TrackedProject = project;
                StartTracking();
            }            
        }

        private void StartTracking()
        {

        }

        private void EndTracking()
        {

        }
    }
}
