using System;
using System.Text.Json.Serialization;

namespace mortgage.mortgageui.Models
{
    public class Mortgage
    {
        
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }
        [JsonPropertyName("mortgageRate")]
        public double MortgageRate { get; set; }
        [JsonPropertyName("riskLevel")]
        public string RiskLevel { get; set; }
    }
}