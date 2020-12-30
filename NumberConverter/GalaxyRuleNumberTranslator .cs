using System.Collections.Generic;

namespace NumberConverter
{
    public class GalaxyRuleNumberTranslator : RomanRuleNumberTranslator
    {
        public GalaxyRuleNumberTranslator(string number, RomanRuleNumberContextProvider galaxyContextProvider)
            : base(number, galaxyContextProvider)
        {
        }

        protected override void TokenizeNumber(string number)
        {
            this._number = new List<string>(number.Split(' '));
        }
    }
}
