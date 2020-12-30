using System;

namespace NumberConverter
{
    public class CreditData
    {
        private string _number;
        private string _currency;

        public CreditData(string number, string currency)
        {
            this._number = number;
            this._currency = currency;
        }

        public string Number
        {
            get
            {
                return this._number;
            }
        }

        public string Currency
        {
            get { return this._currency; }
        }

        public override int GetHashCode()
        {
            return _currency.GetHashCode();
        }

        public override bool Equals(object otherCreditData)
        {
            if (!(otherCreditData is CreditData))
            {
                return false;
            }
            CreditData other = (CreditData)otherCreditData;
            return _number.Equals(other.Number) && _currency.Equals(other.Currency);
        }
    }
}
