using CollateralManagement.Model;
using CollateralManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollateralController : ControllerBase
    {
        private ICollateralService _collateralservice;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CollateralController));

        public CollateralController(ICollateralService collateralservice)
        {
            _collateralservice = collateralservice;
           
        }
        [HttpGet]
        public IActionResult GetCollateral(int loanid, int customerid, string type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (type == "Real Estate" || type == "Real Estate")
                    {
                        _log4net.Info("RealEstate Get method is called");
                        var result = _collateralservice.GetCollateral(loanid, customerid, type);
                        return Ok(result);
                    }
                    else if(type == "Cash" || type == "cash")
                    {
                        _log4net.Info("CashDeposit Get method is called");
                        var result = _collateralservice.GetCashDeposits(loanid, customerid, type);
                        return Ok(result);
                    }
                    else
                    {
                        _log4net.Error("Check input data to call a method");
                        return NotFound();
                        throw new CustomException("Check Values of parameter");
                    }
                }
                else
                {
                    _log4net.Error("Unable get data from RealEstate or CashDeposit method");
                    return BadRequest();
                    throw new CustomException("Values are not bound to Model");

                }
            }
            catch (Exception)
            {

                _log4net.Error("Unable to connect check the connection");
                return NotFound();
                throw new CustomException("Check the Database connection");
            }


        }

        [HttpPost("SaveRealEstate")]

        public IActionResult Post([FromBody] Collateral_RealEstate collateral)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("Collateral RealEstate Post Method Called");
                    _collateralservice.PostCollateralRealEstate(collateral);
                    return Ok();
                    
                }
                else
                {
                    _log4net.Error("Collateral RealEstate Post unable to connect");
                    return BadRequest();
                    throw new CustomException("Unable to get Real Estate Details");
                }
            }
            catch (Exception e)
            {
                _log4net.Error("An Exception occured in Collaterald RealEstate Post method and message is " +e);
                return NotFound();
                throw new CustomException("Unable to connect to database");
            }

        }

        [HttpPost("SaveCashDetails")]

        public IActionResult PostCashDetails([FromBody] Collateral_CashDeposits collateral)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("Collateral CashDeposit Post Method Called");
                    _collateralservice.PostCollateralCashDeposit(collateral);
                    return Ok();
                }
                else
                {
                    _log4net.Error("Collateral CashDeposit Post unable to connect");
                    return BadRequest();
                    throw new CustomException("Unable to get Real Estate Details");
                }
            }
            catch (Exception e)
            {
                _log4net.Error("An Exception occured in Collaterald CashDeposit Post method and message is " + e);
                return NotFound();
                throw new CustomException("Unable to connect to database");
            }

        }

    }
}
