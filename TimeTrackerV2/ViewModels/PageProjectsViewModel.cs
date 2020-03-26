using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TimeTrackerV2.Data;
using System.Linq;
using System.Diagnostics;

namespace TimeTrackerV2
{
    public class PageProjectsViewModel : ObservableObject, IPageViewModel
    {

        #region Fields

        private DatabaseContext _DBContext;

        #endregion

        #region Properties/Commands

        public string Name
        {
            get { return "Project"; }
        }

        public ObservableCollection<WBS> WBSs { get; set; }
        public ObservableCollection<Project> Projects { get; set; }

        private Project selectedProject;
        public Project SelectedProject
        {
            get { return selectedProject; }
            set
            {
                if (value != selectedProject)
                {
                    selectedProject = value;
                    OnPropertyChanged("SelectedProject");
                }
            }
        }


        private string newProjectName;
        public string NewProjectName
        {
            get { return newProjectName; }
            set
            {
                if (newProjectName != value)
                {
                    newProjectName = value;
                    OnPropertyChanged("NewProjectName");
                }
            }
        }

        private string newProjectDescription;
        public string NewProjectDescription
        {
            get { return newProjectDescription; }
            set
            {
                if (newProjectDescription != value)
                {
                    newProjectDescription = value;
                    OnPropertyChanged("NewProjectDescription");
                }
            }
        }

        private string newProjectType;
        public string NewProjectType
        {
            get { return newProjectType; }
            set
            {
                if (newProjectType != value)
                {
                    newProjectType = value;
                    OnPropertyChanged("NewProjectType");
                }
            }
        }

        private WBS newProjectWBS;
        public WBS NewProjectWBS
        {
            get { return newProjectWBS; }
            set
            {
                if (newProjectWBS != value)
                {
                    newProjectWBS = value;
                    OnPropertyChanged("NewProjectWBS");
                }
            }
        }


        private string statusMessage;
        public string StatusMessage
        {
            get { return statusMessage; }
            set
            {
                if (statusMessage != value)
                {
                    statusMessage = value;
                    OnPropertyChanged("StatusMessage");
                }
            }
        }
        #endregion

        #region Constructor
        public PageProjectsViewModel(DatabaseContext _context, ObservableCollection<Project> projects, ObservableCollection<WBS> wbss)
        {
            _DBContext = _context;
            Projects = projects;
            WBSs = wbss;
        }

        #endregion

        #region Add New Project Command

        private ICommand _addProjectCommand;
        public ICommand AddProjectCommand
        {
            get
            {
                if (_addProjectCommand == null)
                {
                    _addProjectCommand = new RelayCommand(
                        param => AddProject());
                }
                return _addProjectCommand;
            }
        }

        private void AddProject()
        {
            Project project = CreateNewProjectFromFields();

            string tempStatusMessage;
            if (!NewProjectIsValid(project, out tempStatusMessage))
            {
                StatusMessage = tempStatusMessage;
                return;
            }

            _DBContext.InsertIntoDatabase(project);
            StatusMessage = "Project successfully added.";

            // Update projects observable collection to include new item
            Projects.Add(project);

            ResetNewProjectFields();

        }

        private Project CreateNewProjectFromFields()
        {
            Project project = new Project();
            project.Name = NewProjectName;
            project.Description = NewProjectDescription;
            project.Type = NewProjectType;
            project.WBS = NewProjectWBS;
            project.Active = 1;
            project.CreatedDate = DateTimeOffset.Now.ToUnixTimeSeconds();

            return project;
        }

        private bool NewProjectIsValid(Project project, out string statusMessage)
        {
            // Check for empty attributes
            if (string.IsNullOrWhiteSpace(project.Name))
            {
                statusMessage = "Name cannot be empty.";
                return false;
            }
            else if (project.WBS == null)
            {
                statusMessage = "Project must have associated WBS.";
                return false;
            }

            // Check for duplicate projects
            bool isDuplicateName = _DBContext.Projects.SingleOrDefault(p => p.Name == project.Name) != null;
            if (isDuplicateName)
            {
                statusMessage = "Duplicate Project Name found.";
                return false;
            }

            statusMessage = "Project is valid.";
            return true;
        }

        private void ResetNewProjectFields()
        {
            NewProjectName = "";
            NewProjectDescription = "";
            NewProjectType = "";
            NewProjectWBS = null;
        }
        #endregion


        #region Delete Project Command
        private ICommand _deleteProjectCommand;
        public ICommand DeleteProjectCommand
        {
            get
            {
                if (_deleteProjectCommand == null)
                {
                    _deleteProjectCommand = new RelayCommand(
                        param => DeleteProject(),
                        param => (SelectedProject != null)
                        );
                }

                return _deleteProjectCommand;
            }
        }

        private void DeleteProject()
        {
            _DBContext.DeleteFromDatabase(SelectedProject);

            Projects.Remove(SelectedProject);
            Trace.WriteLine((SelectedProject == null));
            SelectedProject = null;
        }


        #endregion
    }
}
