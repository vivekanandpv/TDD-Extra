using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfo.Core.DataAccess;
using CarInfo.Core.Domain;
using CarInfo.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarInfo.Core.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ICarContext _context;

        public CarRepository(ICarContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> Get()
        {
            return await _context.CarCollection.ToListAsync();
        }

        public async Task<Car> Get(int id)
        {
            return await _context.CarCollection.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car> Fetch(int id)
        {
            return await _context.CarCollection.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car> Add(Car car)
        {
            await _context.CarCollection.AddAsync(car);
            await _context.Instance.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Update(Car car)
        {
            _context.Instance.Entry(car).State = EntityState.Modified;
            await _context.Instance.SaveChangesAsync();

            return car;
        }

        public async Task Delete(int id)
        {
            _context.CarCollection.Remove(await Fetch(id));
            await _context.Instance.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.CarCollection.AnyAsync(c => c.Id == id);
        }
    }
}
