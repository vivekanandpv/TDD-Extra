using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfo.Core.Domain;
using CarInfo.Core.Exceptions;
using CarInfo.Core.Repositories;
using CarInfo.Core.ViewModels;

namespace CarInfo.Core.Services
{
    public class CarService: ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CarListViewModel>> Get()
        {
            return ToListViewModel(await _repository.Get());
        }

        public async Task<CarListViewModel> Get(int id)
        {
            return ToListViewModel(await _repository.Get(id));
        }

        public async Task<CarListViewModel> Add(CarAddViewModel vm)
        {
            return ToListViewModel(await _repository.Add(FromAddViewModel(vm)));
        }

        public async Task<CarListViewModel> Update(int id, CarUpdateViewModel vm)
        {
            if (!await _repository.Exists(id))
            {
                throw new CarNotFoundException($"Car not found with id: {id}");
            }

            return ToListViewModel(await _repository.Update(await FromUpdateViewModel(id, vm)));
        }

        public async Task Delete(int id)
        {
            if (!await _repository.Exists(id))
            {
                throw new CarNotFoundException($"Car not found with id: {id}");
            }

            await _repository.Delete(id);
        }

        public Car FromAddViewModel(CarAddViewModel viewModel)
        {
            //  consider using AutoMapper here
            return new Car()
            {
                Colour = viewModel.Colour,
                CreatedOn = DateTime.UtcNow,
                Make = viewModel.Make,
                Model = viewModel.Model,
                UID = Guid.NewGuid().ToString(),
                VIN = viewModel.VIN,
                Year = viewModel.Year
            };
        }

        public IEnumerable<CarListViewModel> ToListViewModel(IEnumerable<Car> cars)
        {
            return cars.Select(c => new CarListViewModel
            {
                Year = c.Year,
                Model = c.Model,
                Make = c.Make,
                Colour = c.Colour,
                Id = c.Id
            });
        }

        public CarListViewModel ToListViewModel(Car car)
        {
            return new CarListViewModel
            {
                Model = car.Model,
                Make = car.Make,
                Year = car.Year,
                Colour = car.Colour,
                Id = car.Id
            };
        }

        public async Task<Car> FromUpdateViewModel(int id, CarUpdateViewModel viewModel)
        {
            var car = await _repository.Get(id);
            car.Make = viewModel.Make;
            car.Model = viewModel.Model;
            car.Year = viewModel.Year;
            car.Colour = viewModel.Colour;

            return car;
        }
    }
}
