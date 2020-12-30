using System;

namespace NumberConverter
{
    public class ConversionData
    {
        private CreditData _credit;
        private string _currency;

        public ConversionData(CreditData number, string currency)
        {
            this._credit = number;
            this._currency = currency;
        }

        public CreditData Credit
        {
            get
            {
                return this._credit;
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
            if (!(otherCreditData is ConversionData))
            {
                return false;
            }
            ConversionData other = (ConversionData)otherCreditData;
            return _credit.Equals(other.Credit) && _currency.Equals(other.Currency);
        }
    }
}
