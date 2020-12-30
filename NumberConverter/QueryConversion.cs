using System.Collections.Generic;

namespace NumberConverter
{
    public class QueryConversion : Query
    {
        private GalaxyCurrencyContextProvider _galaxyContextProvider;
        private Dictionary<string, double> _currency;
        private ConversionData _credits;

        public QueryConversion(ConversionData credits, GalaxyCurrencyContextProvider galaxyContextProvider)
        {
            this._credits = credits;
            this._galaxyContextProvider = galaxyContextProvider;
            this._currency = galaxyContextProvider.ContextCurrency;
        }

        public override string Ask()
        {
            return string.Format("{0:F0} Silver is {1} {2}", CalculateConversion(_credits), _credits.Credit.Number, _credits.Credit.Currency);
        }

        private double CalculateConversion(ConversionData credit)
        {
            return ((new GalaxyRuleNumberTranslator(credit.Credit.Number, _galaxyContextProvider)).Compute() * this._currency[credit.Credit.Currency]) / this._currency[credit.Currency];
        }
    }
}
