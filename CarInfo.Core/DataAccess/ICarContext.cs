using System;
using System.Collections.Generic;
using System.Text;
using CarInfo.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarInfo.Core.DataAccess
{
    public interface ICarContext : IDbContext
    {
        public DbSet<Car> CarCollection { get; set; }
    }
}
