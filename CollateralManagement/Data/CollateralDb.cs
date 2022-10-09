using CollateralManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Data
{
    public class CollateralDb : DbContext
    {
        public CollateralDb(DbContextOptions<CollateralDb> options) : base(options)
        {

        }
        public DbSet<Collateral_RealEstate> Collateral_RealEstate { get; set; }
        public DbSet<Collateral_CashDeposits> Collateral_CashDeposits { get; set; }
    }
}
