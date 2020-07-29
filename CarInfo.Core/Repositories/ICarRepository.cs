using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarInfo.Core.Domain;
using CarInfo.Core.ViewModels;

namespace CarInfo.Core.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> Get();
        Task<Car> Get(int id);
        Task<Car> Fetch(int id);
        Task<Car> Add(Car car);
        Task<Car> Update(Car car);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
