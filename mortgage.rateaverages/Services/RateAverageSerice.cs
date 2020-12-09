using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace mortgage.rateaverages
{
    public class RateAverageSerice: RateAverage.RateAverageBase
    {
        private readonly ILogger<RateAverageSerice> _logger;
        public RateAverageSerice(ILogger<RateAverageSerice> logger)
        {
            _logger = logger;
        }
        public override Task<RateAverageReply> GetAverageRate(RateAverageRequest request, ServerCallContext context)
        {
             double rate = GetRandomNumber(2,5);
            var requestReply = new RateAverageReply();
            requestReply.MortgageRate = rate;
            switch (rate)
            {
                case double n when rate < 3:
                    requestReply.RiskLevel = "Low Risk";
                    break;

                case double n when rate > 3 && rate < 4:
                    requestReply.RiskLevel = "Medium Risk";
                    break;

                case double n when rate > 4 :
                    requestReply.RiskLevel = "High Risk";
                    break;

                default:
                    requestReply.RiskLevel = "No risk identified";
                    break;
            }

            return Task.FromResult(requestReply);
        }
        public double GetRandomNumber(double minimum, double maximum)
        { 
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}