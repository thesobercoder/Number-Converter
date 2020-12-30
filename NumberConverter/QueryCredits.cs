using System.Collections.Generic;

namespace NumberConverter
{
    public class QueryCredits : Query
    {
        private GalaxyCurrencyContextProvider _galaxyContextProvider;
        private Dictionary<string, double> _currency;
        private CreditData _credits;

        public QueryCredits(CreditData credits, GalaxyCurrencyContextProvider galaxyContextProvider)
        {
            this._credits = credits;
            this._galaxyContextProvider = galaxyContextProvider;
            this._currency = galaxyContextProvider.ContextCurrency;
        }

        public override string Ask()
        {
            return string.Format("{0} {1} is {2:F0} Credits", _credits.Number, _credits.Currency, CalculateCredits(_credits));
        }

        private double CalculateCredits(CreditData credit)
        {
            return (new GalaxyRuleNumberTranslator(credit.Number, _galaxyContextProvider)).Compute() * this._currency[credit.Currency];
        }
    }
}
