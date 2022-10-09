using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Model
{
    public class Collateral_RealEstate
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int typeid { get; set; }
		public int Loan_Id { get; set; }
		public string CollateralType { get; set; }
		public int Customer_Id { get; set; }
		public int Collateral_Id { get; set; }
		public string Address { get; set; }
		public int CurrentValue { get; set; }
		public int RatePerSqFt { get; set; }
		public int DepreciationRate { get; set; }
	}
}
