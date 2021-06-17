using AppXam.Common.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppXam.ViewModels.WorkTaskViewModels
{
    public class WorkTaskAddViewModel : BaseViewModel
    {
        #region WorkTaskDescription
        private string workTaskDescription;
        public string WorkTaskDescription
        {
            get { return this.workTaskDescription; }
            set
            {
                this.SetValue(ref this.workTaskDescription, value);
            }
        }
        #endregion

        #region SaveWorkTaskCommand
        public ICommand SaveWorkTaskCommand => new RelayCommand(this.SaveWorkTask);
        private async void SaveWorkTask()
        {
            if (!string.IsNullOrEmpty(this.WorkTaskDescription))
            {
                await App.Database.SaveWorkTaskAsync(new WorkTask
                {
                    Description = this.WorkTaskDescription,
                    Status = false
                });
            }

            this.Parent.UpdateWorkTasks();
            await App.Navigator.PopAsync();
        }
        #endregion

        public WorkTaskListViewModel Parent { get; set; }

        public WorkTaskAddViewModel(WorkTaskListViewModel _parent)
        {
            this.WorkTaskDescription = string.Empty;
            this.Parent = _parent;
        }
    }
}
