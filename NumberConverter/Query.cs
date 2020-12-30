using System;

namespace NumberConverter
{
	public abstract class Query
	{
		protected internal DefinitionParser _definitionParser;
		protected internal QueryValidation _queryValidation;

		public static Query Create(DefinitionParser definitionParser, QueryValidation queryValidation, string query)
		{
			if (queryValidation.IsNumberQuery(query))
			{
				return new QueryNumber(queryValidation.GetNumber(query), new GalaxyRuleNumberContextProvider(definitionParser));
			}

			if (queryValidation.IsCreditsQuery(query))
			{
				return new QueryCredits(queryValidation.GetCredits(query), new GalaxyCurrencyContextProvider(definitionParser));
			}

            if (queryValidation.IsConversionQuery(query))
            {
                return new QueryConversion(queryValidation.GetConversion(query), new GalaxyCurrencyContextProvider(definitionParser));
            }

			return new QueryInvalid();
		}

		public abstract string Ask();
	}
}
