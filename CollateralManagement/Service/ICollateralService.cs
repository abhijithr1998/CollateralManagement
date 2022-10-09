using CollateralManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Service
{
   public   interface ICollateralService
    {
        public Collateral_RealEstate GetCollateral(int loanid, int customerid, string type);

        public Collateral_CashDeposits GetCashDeposits(int loanid, int customerid, string type);

        public Collateral_RealEstate PostCollateralRealEstate(Collateral_RealEstate collateral_RealEstate);
        public Collateral_CashDeposits PostCollateralCashDeposit(Collateral_CashDeposits cash);
    }
}
