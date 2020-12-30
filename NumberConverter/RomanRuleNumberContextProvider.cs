using System.Collections.Generic;

namespace NumberConverter
{
    public class RomanRuleNumberContextProvider
    {
        public virtual Dictionary<string, int> ContextUnits
        {
            get
            {
                Dictionary<string, int> contextUnities = new Dictionary<string, int>();
                contextUnities["I"] = 1;
                contextUnities["V"] = 5;
                contextUnities["X"] = 10;
                contextUnities["L"] = 50;
                contextUnities["C"] = 100;
                contextUnities["D"] = 500;
                contextUnities["M"] = 1000;
                return contextUnities;
            }
        }
    }
}
