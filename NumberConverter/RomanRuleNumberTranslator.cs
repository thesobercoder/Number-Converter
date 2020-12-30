using System;
using System.Collections.Generic;

namespace NumberConverter
{
    public class RomanRuleNumberTranslator
    {
        protected internal IList<string> _number;
        protected internal Dictionary<string, int> _numberUnits;
        private int _computationIndex;

        public RomanRuleNumberTranslator(string number)
            : this(number, new RomanRuleNumberContextProvider())
        {
        }

        public RomanRuleNumberTranslator(string number, RomanRuleNumberContextProvider contextProvider)
        {
            this.TokenizeNumber(number);
            this._numberUnits = contextProvider.ContextUnits;
        }

        protected virtual void TokenizeNumber(string number)
        {
            this._number = new List<string>();
            foreach (char token in number.ToCharArray())
            {
                this._number.Add(token.ToString());
            }
        }

        public int Compute()
        {
            int arabic = 0;
            _computationIndex = 0;
            for (; _computationIndex < _number.Count; _computationIndex++)
            {
                arabic = SubtractFromNextIfNecessary(arabic);
                arabic += ArabicValue(_computationIndex);
            }
            return arabic;
        }

        private int SubtractFromNextIfNecessary(int arabic)
        {
            int next = _computationIndex + 1;
            if (next < _number.Count && ArabicValue(_computationIndex) < ArabicValue(next))
            {
                arabic -= ArabicValue(_computationIndex);
                _computationIndex++;
            }
            return arabic;
        }

        private int ArabicValue(int index)
        {
            return _numberUnits[_number[index]];
        }
    }
}
