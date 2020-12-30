using System.Collections.Generic;

namespace NumberConverter
{
    public class GalaxyCurrencyContextProvider : GalaxyRuleNumberContextProvider
    {
        public GalaxyCurrencyContextProvider(DefinitionParser definitionParser)
            : base(definitionParser)
        {
        }

        public Dictionary<string, double> ContextCurrency
        {
            get
            {
                Dictionary<string, double> currency = new Dictionary<string, double>();
                Dictionary<CreditData, double> credits = _definitionParser.Credits;
                foreach (CreditData credit in credits.Keys)
                {
                    double currencyValue = credits[credit] / (new GalaxyRuleNumberTranslator(credit.Number, this)).Compute();
                    currency[credit.Currency] = currencyValue;
                }
                return currency;
            }
        }
    }
}
