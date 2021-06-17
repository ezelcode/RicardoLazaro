using AppXam.ViewModels.WorkTaskViewModels;
using System.Collections.ObjectModel;

namespace AppXam.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel _instance;
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        #region WorkTask
        public WorkTaskListViewModel WorkTaskListViewModel { get; set; }
        public WorkTaskAddViewModel WorkTaskAddViewModel { get; set; }
        #endregion

        public MainViewModel()
        {
            _instance = this;
            this.LoadMenu();
        }

        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "\uf1c4",
                Title = "Lista de Tareas",
                PageName = "WorkTaskListPage",
            });
        }

        public static MainViewModel GetInstance()
        {
            if (_instance == null)
                return new MainViewModel();

            return _instance;
        }
    }
}
