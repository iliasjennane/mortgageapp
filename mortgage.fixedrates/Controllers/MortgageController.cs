using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mortgage.fixedrates.Models;

namespace mortgage.fixedrates.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("{version:apiVersion}/[controller]")]
    public class MortgageController : ControllerBase
    {

        private readonly ILogger<MortgageController> _logger;

        public MortgageController(ILogger<MortgageController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<Mortgage> GetMortgage(MortgageRequestor requestor)
        {
            double rate = GetRandomNumber(2,5);
            var mortgage = new Mortgage(){Firstname = requestor.Firstname, Lastname = requestor.Lastname};
            mortgage.MortgageRate = rate;
            switch (rate)
            {
                case double n when rate < 3:
                    mortgage.RiskLevel = "Low Risk";
                    break;

                case double n when rate > 3 && rate < 4:
                    mortgage.RiskLevel = "Medium Risk";
                    break;

                case double n when rate > 4 :
                    mortgage.RiskLevel = "High Risk";
                    break;

                default:
                    mortgage.RiskLevel = "No risk identified";
                    break;
            }

            return new ActionResult<Mortgage>(mortgage);
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<Mortgage> GetMortgage_V2(MortgageRequestor requestor)
        {
            double rate = GetRandomNumber(2,8);
            var mortgage = new Mortgage(){Firstname = requestor.Firstname, Lastname = requestor.Lastname};
            mortgage.MortgageRate = rate;
            switch (rate)
            {
                case double n when rate < 3:
                    mortgage.RiskLevel = "Low Risk";
                    break;

                case double n when rate > 3 && rate < 4:
                    mortgage.RiskLevel = "Medium Risk";
                    break;

                 case double n when rate > 4 && rate < 6:
                    mortgage.RiskLevel = "High Risk";
                    break;
                 case double n when rate > 6 :
                    mortgage.RiskLevel = "Very High Risk";
                    break;
                default:
                    mortgage.RiskLevel = "No risk identified";
                    break;
            }

            return new ActionResult<Mortgage>(mortgage);
        }

        private double GetRandomNumber(double minimum, double maximum)
        { 
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
