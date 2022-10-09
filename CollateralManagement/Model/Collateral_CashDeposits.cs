using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Model
{
    public class Collateral_CashDeposits
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int typekey { get; set; }
		public int Loan_Id { get; set; }
		public string CollateralType { get; set; }
		public int Customer_Id { get; set; }
		public int Collateral_Id { get; set; }
		public string BankName { get; set; }
		public int CurrentValue { get; set; }
		public int InterestRate { get; set; }
		public int DepositAmount { get; set; }
		public string LockPeriod { get; set; }
	}
}
