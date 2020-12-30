using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NumberConverter
{
    public class DefinitionParser
    {
        private IList<string> _input;
        private Dictionary<string, string> _numeral;
        private Dictionary<string, string> _invalidNumeral;
        private Dictionary<CreditData, double> _credits;
        private Regex _numeralDefinition;
        private Regex _invalidDefinition;
        private Regex _creditsDefinition;

        public DefinitionParser(IList<string> input)
        {
            this._input = input;
            _numeralDefinition = new Regex(@"^(.*) is ([I|V|X|M|C|D|L])$");
            _invalidDefinition = new Regex(@"^(.*) is ([^IVXMCDL]*)$");
            _creditsDefinition = new Regex(@"^(.*) (.*) is (\d+) Credits$");
            this.ParseErrors();
        }

        private void ParseErrors()
        {
            _invalidNumeral = new Dictionary<string, string>();
            foreach (string line in _input)
            {
                Match matcher = _invalidDefinition.Match(line);
                if (matcher.Success)
                {
                    _invalidNumeral[matcher.Groups[1].Value] = matcher.Groups[2].Value;
                }
            }
        }

        public bool HasErrors
        {
            get
            {
                return _invalidNumeral.Count > 0;
            }
        }

        public List<string> Errors
        {
            get
            {
                List<string> _list = new List<string>();
                foreach (KeyValuePair<string, string> key in _invalidNumeral)
                {
                    _list.Add(key.Key + " has invalid Roman numeral assigned '" + key.Value + "'");
                }
                return _list;
            }
        }

        public Dictionary<string, string> Numeral
        {
            get
            {
                if (_numeral != null)
                {
                    return _numeral;
                }
                _numeral = new Dictionary<string, string>();
                foreach (string line in _input)
                {
                    Match matcher = _numeralDefinition.Match(line);
                    if (matcher.Success)
                    {
                        _numeral[matcher.Groups[1].Value] = matcher.Groups[2].Value;
                    }
                }
                return _numeral;
            }
        }

        public Dictionary<CreditData, double> Credits
        {
            get
            {
                if (_credits != null)
                {
                    return _credits;
                }
                _credits = new Dictionary<CreditData, double>();
                foreach (string line in _input)
                {
                    Match matcher = _creditsDefinition.Match(line);
                    if (matcher.Success)
                    {
                        _credits[new CreditData(matcher.Groups[1].Value, matcher.Groups[2].Value)] = double.Parse((matcher.Groups[3].Value));
                    }
                }
                return _credits;
            }
        }
    }
}
