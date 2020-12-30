using System;
using System.IO;
using System.Collections.Generic;

namespace NumberConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("You need to provide the file path");
                Console.WriteLine("");
                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();
                Environment.Exit(0);
            }

            TranslatorLoader _translatorLoader = null;
            try
            {
                _translatorLoader = new TranslatorLoader(args[0]);
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found");
                Console.WriteLine("");
                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!_translatorLoader.IsValidFile)
            {
                Console.Error.WriteLine("Invalid input file");
                Console.WriteLine("");
                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();
                Environment.Exit(0);
            }

            DefinitionParser _definitionParser = _translatorLoader.Parser;
            if (_definitionParser.HasErrors)
            {
                Console.WriteLine(string.Join(Environment.NewLine, _definitionParser.Errors.ToArray()));
                Console.WriteLine("");
                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();
                Environment.Exit(0);
            }

            QueryValidation _queryValidation = new QueryValidation();
            foreach (string query in _translatorLoader.Queries)
            {
                Console.WriteLine(Query.Create(_definitionParser, _queryValidation, query).Ask());
            }

            Console.WriteLine("");
            Console.WriteLine("Press <ENTER> to terminate");
            Console.ReadLine();
        }
    }
}
