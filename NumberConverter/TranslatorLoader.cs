using System;
using System.Collections.Generic;
using System.IO;

namespace NumberConverter
{
    public class TranslatorLoader
    {
        private List<string> _definitions;
        private List<string> _queries;
        private string _inputFile;

        public TranslatorLoader(string inputFile)
        {
            this._inputFile = inputFile;
            this._definitions = new List<String>();
            this._queries = new List<String>();
            this.ReadAndLoadFile();
        }

        private void ReadAndLoadFile()
        {
            string line;
            using (StreamReader reader = new StreamReader(_inputFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.EndsWith("?"))
                        _queries.Add(line);
                    else
                        _definitions.Add(line);
                }
            }
        }

        public bool IsValidFile
        {
            get
            {
                if (_definitions.Count <= 0 || _queries.Count <= 0)
                    return false;
                else
                    return true;
            }
        }

        public DefinitionParser Parser
        {
            get
            {
                return new DefinitionParser(_definitions);
            }
        }

        public IList<string> Queries
        {
            get
            {
                return _queries;
            }
        }
    }
}
