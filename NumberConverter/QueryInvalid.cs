using System;

namespace NumberConverter
{
    public class QueryInvalid : Query
    {
        public override string Ask()
        {
            return "I have no idea what you are talking about";
        }
    }
}
