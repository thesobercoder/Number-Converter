using System.Collections.Generic;

namespace NumberConverter
{
    public class GalaxyRuleNumberContextProvider : RomanRuleNumberContextProvider
    {
        protected internal DefinitionParser _definitionParser;
        public GalaxyRuleNumberContextProvider(DefinitionParser definitionParser)
        {
            this._definitionParser = definitionParser;
        }

        public override Dictionary<string, int> ContextUnits
        {
            get
            {
                Dictionary<string, int> parentContextUnities = base.ContextUnits;
                Dictionary<string, string> numeral = _definitionParser.Numeral;
                Dictionary<string, int> contextUnities = new Dictionary<string, int>();
                foreach (string source in numeral.Keys)
                {
                    contextUnities[source] = parentContextUnities[numeral[source]];
                }
                return contextUnities;
            }
        }
    }
}
