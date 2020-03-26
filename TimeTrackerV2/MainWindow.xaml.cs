using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TimeTrackerV2.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using ShowMeTheXAML;

namespace TimeTrackerV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Data application EF Core context
        /// </summary>
        //private DatabaseContext _context = new DatabaseContext();

        public MainWindow()
        {
            InitializeComponent();
            //LoadData();

            //DataContext = this;
        }

        //public ObservableCollection<WBS> WBSModels { get; set; }
        //public ObservableCollection<Project> ProjectModels { get; set; }
        //public ObservableCollection<Task> TaskModels { get; set; }
        //public ObservableCollection<TaskHistoryItem> TaskHistoryItemModels { get; set; }

        //private void LoadData()
        //{
        //    #region create new ProjectWBS Model
        //    //var items = _context.Projects
        //    //    .Join(_context.WBSs,
        //    //    proj => proj.WBSId,
        //    //    wbs => wbs.WBSId,
        //    //    (proj, wbs) => new
        //    //    {
        //    //        proj.ProjectId,
        //    //        ProjectName = proj.Name,
        //    //        ProjectDescription = proj.Description,
        //    //        ProjectType = proj.Type,
        //    //        ProjectActive = proj.Active,
        //    //        proj.WBSId,
        //    //        WBSCode = wbs.Code,
        //    //        WBSName = wbs.Name,
        //    //        WBSDescription = wbs.Description,
        //    //        WBSTaxArea = wbs.TaxArea
        //    //    }).ToList();
        //    #endregion

        //    WBSModels = new ObservableCollection<WBS>(_context.WBSs.ToList());
        //    ProjectModels = new ObservableCollection<Project>(_context.Projects.ToList());
        //    TaskModels = new ObservableCollection<Task>(_context.Tasks.ToList());
        //    TaskHistoryItemModels = new ObservableCollection<TaskHistoryItem>(_context.TaskHistoryItems.ToList());

        //    foreach (var a in WBSModels)
        //    {
        //        Trace.WriteLine(a.Name);
        //        Trace.WriteLine(a.Projects.Count);
        //    }
            
        //}
        

        //private void TrackerButton_Click(object sender, RoutedEventArgs e)
        //{

        //}




        ///// <summary>
        ///// Close the database when window is closed
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    this._context.Dispose();
        //}


    }
}
