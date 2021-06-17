using Xamarin.Forms;
using AppXam.Views;
using AppXam.ViewModels;
using AppXam.ViewModels.WorkTaskViewModels;
using AppXam.Data;
using System;
using System.IO;

namespace AppXam
{
    public partial class App : Application
    {
        static AppXamDatabase database;
        public static AppXamDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppXamDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public static MasterPage Master { get; internal set; }
        public static NavigationPage Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainViewModel.GetInstance().WorkTaskListViewModel = new WorkTaskListViewModel();
            this.MainPage = new MasterPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
