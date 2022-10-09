using CollateralManagement.Data;
using CollateralManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Service
{
    public class CollateralService : ICollateralService
    {
        private CollateralDb _collateralDb;

        public CollateralService(CollateralDb collateralDb)
        {
            _collateralDb = collateralDb;
        }


        public Collateral_RealEstate GetCollateral(int loanid, int customerid, string type)
        {

            return _collateralDb.Collateral_RealEstate.FirstOrDefault(n => n.Loan_Id == loanid && n.Customer_Id == customerid && n.CollateralType == type);
            //  var result = _collateralDb.Collateral_RealEstate.Select(n => n.Loan_Id == loanid && n.Customer_Id == customerid && n.CollateralType == type).FirstOrDefault();
            //  return result;
        }

        public Collateral_CashDeposits GetCashDeposits(int loanid, int customerid, string type)
        {
            return _collateralDb.Collateral_CashDeposits.FirstOrDefault(n => n.Loan_Id == loanid && n.Customer_Id == customerid && n.CollateralType == type);
        }



        public Collateral_RealEstate PostCollateralRealEstate(Collateral_RealEstate collateral_RealEstate)
        {
            _collateralDb.Collateral_RealEstate.Add(collateral_RealEstate);
            _collateralDb.SaveChanges();
            return collateral_RealEstate;
        }

        public Collateral_CashDeposits PostCollateralCashDeposit(Collateral_CashDeposits cash)
        {
            _collateralDb.Collateral_CashDeposits.Add(cash);
            _collateralDb.SaveChanges();
            return cash;
        }
    }
}
