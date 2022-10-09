using CollateralManagement.Controllers;
using CollateralManagement.Data;
using CollateralManagement.Model;
using CollateralManagement.Service;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace CollateralManagementTest
{
    [TestFixture]
    public class Tests
    {
        CollateralController controller;
          Mock<ICollateralService> mockservice;
        
        [SetUp]
        public void Setup()
        {
             mockservice = new Mock<ICollateralService>();
              controller = new CollateralController(mockservice.Object);

        }

        [Test]
        public void Post_Valid_Collateral_CashDeposit()
        {
            Collateral_CashDeposits cash = new Collateral_CashDeposits()
            {
                Loan_Id = 1,
                CollateralType = "Cash",
                Customer_Id = 5,
                Collateral_Id = 1,
                BankName = "SBI",
                CurrentValue = 500000,
                InterestRate = 7,
                DepositAmount = 500000,
                LockPeriod = "3 Years"
            };
            mockservice.Setup(s => s.PostCollateralCashDeposit(cash)).Returns(cash);
            var result = controller.PostCashDetails(cash);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }


        public void Post_Valid_Collateral_RealEstate()
         {
             Collateral_RealEstate estate = new Collateral_RealEstate()
             {
                 Loan_Id = 1,
                 CollateralType = "Real Estate",
                 Customer_Id = 5,
                 Collateral_Id = 1,
                 CurrentValue = 500000,
                 RatePerSqFt = 4500,
                 DepreciationRate =10
             };

             mockservice.Setup(s => s.PostCollateralRealEstate(estate)).Returns(estate);
             var result = controller.Post(estate);
             var okResult = (IStatusCodeActionResult)result;
             Assert.AreEqual(200, okResult.StatusCode);
         }

         [Test]

         public void Post_Invalid_Collateral_RealEstate()
         {
             Collateral_RealEstate estate = null;

             mockservice.Setup(s => s.PostCollateralRealEstate(estate));
             var result = controller.Post(estate);
             var okResult = (IStatusCodeActionResult)result;
             Assert.AreEqual(400, okResult.StatusCode);
         }

      

         [Test]
         [TestCase(1,5,"Real Estate")]
         public void get_valid_collateral_realestate_details(int loanid, int customerid, string type)
         {
           
             Collateral_RealEstate estate = new Collateral_RealEstate()
             {
                 Loan_Id = 1,
                 CollateralType = "Real Estate",
                 Customer_Id = 5,
                 Collateral_Id = 1,
                 CurrentValue = 500000,
                 RatePerSqFt = 4500,
                 DepreciationRate = 10
             };

             mockservice.Setup(s => s.GetCollateral(loanid, customerid, type)).Returns(estate);
             var result = controller.GetCollateral(loanid, customerid, type);
             var okResult = (IStatusCodeActionResult)result;
             Assert.AreEqual(200, okResult.StatusCode);
         }

         public void get_valid_collateral_cashdetails_details()
         {
             int loanid = 1, cusotmerid = 5;
             var type = "Cash";

             Collateral_CashDeposits cash = new Collateral_CashDeposits()
             {
                 Loan_Id = 1,
                 CollateralType = "Cash",
                 Customer_Id = 5,
                 Collateral_Id = 1,
                 BankName = "SBI",
                 CurrentValue = 500000,
                 InterestRate = 7,
                 DepositAmount = 500000,
                 LockPeriod = "3 Years"
             };

             mockservice.Setup(s => s.GetCashDeposits(loanid, cusotmerid, type)).Returns(cash);
             var result = controller.GetCollateral(loanid, cusotmerid, type);
             var okResult = (IStatusCodeActionResult)result;
             Assert.AreEqual(200, okResult.StatusCode);
         }
    }
}