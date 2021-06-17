using AppXam.Common.Models;
using AppXam.Views.WorkTaskViews;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace AppXam.ViewModels.WorkTaskViewModels
{
    public class WorkTaskListViewModel : BaseViewModel
    {
        #region TaskList
        private ObservableCollection<WorkTask> taskList;
        public ObservableCollection<WorkTask> TaskList
        {
            get { return this.taskList; }
            set { this.SetValue(ref this.taskList, value); }
        }
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        #endregion

        #region AddWorkTaskCommand
        public ICommand AddWorkTaskCommand => new RelayCommand(this.AddWorkTask);

        private async void AddWorkTask()
        {
            MainViewModel.GetInstance().WorkTaskAddViewModel = new WorkTaskAddViewModel(this);
            await App.Navigator.PushAsync(new WorkTaskAddPage());
        }
        #endregion

        #region CompletedWorkTaskCommand
        public ICommand CompletedWorkTaskCommand => new RelayCommand<WorkTask>(this.CompletedWorkTask);
        private async void CompletedWorkTask(WorkTask obj)
        {
            obj.Status = true;
            await App.Database.SaveWorkTaskAsync(obj);
            UpdateWorkTasks();
        }
        #endregion

        #region DeleteWorkTaskCommand
        public ICommand DeleteWorkTaskCommand => new RelayCommand<WorkTask>(this.DeleteWorkTask);
        private async void DeleteWorkTask(WorkTask obj)
        {
            string selectedOption = await App.Current.MainPage.DisplayActionSheet("¿Desea eliminar la tarea?", "Cancelar", "Sí");

            switch (selectedOption)
            {
                case "Sí":
                    await App.Database.DeleteWorkTaskAsync(obj);
                    UpdateWorkTasks();
                    break;
                default:
                    break;
            }
        }
        #endregion

        public WorkTaskListViewModel()
        {
            this.IsRefreshing = false;
            LoadWorkTasks();
        }

        private async void LoadWorkTasks()
        {
            this.TaskList = new ObservableCollection<WorkTask>(await App.Database.GetWorkTasksAsync());
        }

        public void UpdateWorkTasks()
        {
            LoadWorkTasks();
        }
    }
}
