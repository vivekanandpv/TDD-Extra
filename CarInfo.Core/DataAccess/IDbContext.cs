using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CarInfo.Core.DataAccess
{
    public interface IDbContext
    {
        public DbContext Instance { get; }
    }
}
