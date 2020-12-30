using System;
using System.Text.RegularExpressions;

namespace NumberConverter
{
    public class QueryValidation
    {
        private Regex _numberPattern;
        private Regex _creditsPattern;
        private Regex _conversionPattern;

        public QueryValidation()
        {
            _numberPattern = new Regex(@"^how much is (.*) \?$");
            _creditsPattern = new Regex(@"^how many Credits is (.*) (.*) \?$");
            _conversionPattern = new Regex(@"^how many (.*) is (.*) (.*) \?$");
        }

        public bool IsNumberQuery(string query)
        {
            return _numberPattern.Match(query).Success;
        }

        public bool IsCreditsQuery(string query)
        {
            return _creditsPattern.Match(query).Success;
        }

        public bool IsConversionQuery(string query)
        {
            Match matcher = _conversionPattern.Match(query);
            return matcher.Success;
        }

        public bool IsValidQuery(string query)
        {
            return IsCreditsQuery(query) || IsNumberQuery(query);
        }

        public string GetNumber(string query)
        {
            Match matcher = _numberPattern.Match(query);
            if (matcher.Success)
            {
                return matcher.Groups[1].Value;
            }
            return "";
        }

        public CreditData GetCredits(string query)
        {
            Match matcher = _creditsPattern.Match(query);
            if (matcher.Success)
            {
                return new CreditData(matcher.Groups[1].Value, matcher.Groups[2].Value);
            }
            return new CreditData("", "");
        }

        public ConversionData GetConversion(string query)
        {
            Match matcher = _conversionPattern.Match(query);
            if (matcher.Success)
            {
                return new ConversionData(new CreditData(matcher.Groups[2].Value, matcher.Groups[3].Value), matcher.Groups[1].Value);
            }
            return new ConversionData(new CreditData("", ""), "");
        }
    }
}
