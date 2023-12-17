using System.Collections.ObjectModel;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General;
using CarShop.UserInterface.General;
using CarShop.UserInterface.ViewModels.Interfaces;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface ICarTableViewModel
    {
    }

    public class CarTableViewModel : ObservableObject, ICarTableViewModel, ITableViewModel<CarDTO>
    {
        #region Properties and Indexers
        public ObservableCollection<CarDTO> Items { get; set; }
        public string Title { get; set; }
        #endregion

        #region Constructors
        static CarTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(CarTableViewModel), typeof(CarTableWindow));
        }

        public CarTableViewModel()
        {
            Title = "List of cars";
        }
        #endregion
    }
}
