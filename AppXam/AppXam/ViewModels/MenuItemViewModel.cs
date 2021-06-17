using AppXam.ViewModels.WorkTaskViewModels;
using AppXam.Views.WorkTaskViews;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppXam.ViewModels
{
    public class MenuItemViewModel : Common.Models.Menu
    {
        public ICommand SelectMenuCommand => new RelayCommand(this.SelectMenu);

        private async void SelectMenu()
        {
            App.Master.IsPresented = false;

            if (this.PageName == "NoPage")
                return;

            switch (this.PageName)
            {
                case "WorkTaskListPage":
                    MainViewModel.GetInstance().WorkTaskListViewModel = new WorkTaskListViewModel();
                    await App.Navigator.PushAsync(new WorkTaskListPage());
                    break;
            }
        }
    }
}
