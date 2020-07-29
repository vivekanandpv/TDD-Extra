using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarInfo.Core.Domain;
using CarInfo.Core.ViewModels;

namespace CarInfo.Core.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarListViewModel>> Get();
        Task<CarListViewModel> Get(int id);
        Task<CarListViewModel> Add(CarAddViewModel vm);
        Task<CarListViewModel> Update(int id, CarUpdateViewModel vm);
        Task Delete(int id);
        Car FromAddViewModel(CarAddViewModel viewModel);
        IEnumerable<CarListViewModel> ToListViewModel(IEnumerable<Car> cars);
        CarListViewModel ToListViewModel(Car car);
        Task<Car> FromUpdateViewModel(int id, CarUpdateViewModel viewModel);
    }
}
