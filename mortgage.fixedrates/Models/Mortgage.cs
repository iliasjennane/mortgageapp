using System;
namespace mortgage.fixedrates.Models
{
    public class Mortgage
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double MortgageRate { get; set; }
        public string RiskLevel { get; set; }
    }
}