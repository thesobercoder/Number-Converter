using System;

namespace NumberConverter
{
    public class QueryNumber : Query
    {
        private GalaxyRuleNumberContextProvider _galaxyContextProvider;
        private string _number;

        public QueryNumber(string number, GalaxyRuleNumberContextProvider galaxyContextProvider)
        {
            this._number = number;
            this._galaxyContextProvider = galaxyContextProvider;
        }

        public override string Ask()
        {
            return string.Format("{0} is {1}", _number, (new GalaxyRuleNumberTranslator(_number, _galaxyContextProvider)).Compute());
        }
    }
}
