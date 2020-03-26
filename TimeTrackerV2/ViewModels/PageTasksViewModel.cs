using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TimeTrackerV2.Data;

namespace TimeTrackerV2
{
    public class PageTasksViewModel : ObservableObject, IPageViewModel
    {

        private DatabaseContext _DBContext;
        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        //public ObservableCollection<TaskHistoryItem> TaskHistoryItemModels { get; set; }

        public string Name
        {
            get { return "Task Creation"; }
        }


        public PageTasksViewModel(DatabaseContext _context, ObservableCollection<Project> projects, ObservableCollection<Task> tasks)
        {
            _DBContext = _context;
            Projects = projects;
            Tasks = tasks;
        }


    }
}
