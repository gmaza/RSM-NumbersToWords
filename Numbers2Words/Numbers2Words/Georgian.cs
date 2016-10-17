using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers2Words
{
    public class Georgian
    {

        public string BanknoteName { get; set; }
        public string CoinString { get; set; }
        public Georgian(string banknoteName, string coinString)
        {
            BanknoteName = banknoteName;
            CoinString = coinString;
        }

        public string Convert(decimal money)
        {
            string s = money.ToString("0.00", CultureInfo.InvariantCulture);
            string[] parts = s.Split('.');
            int Banknote = int.Parse(parts[0]);
            int coin = int.Parse(parts[1]);

            return PrintString(Banknote) + " " + BanknoteName + " da " + PrintString(coin) + " " + CoinString;
        }

        private string TwoDigitHelper(int t)
        {
            switch (t)
            {
                case 0: return ("ნული");
                case 1: return ("ერთი");
                case 2: return ("ორი");
                case 3: return ("სამი");
                case 4: return ("ოთხი");
                case 5: return ("ხუთი");
                case 6: return ("ექვსი");
                case 7: return ("შვიდი");
                case 8: return ("რვა");
                case 9: return ("ცხრა");
                case 10: return ("ათი");
                case 11: return ("თერთმეტი");
                case 12: return ("თორმეტი");
                case 13: return ("ცამეტი");
                case 14: return ("თოთხმეტი");
                case 15: return ("თხუტმეტი");
                case 16: return ("თექვსმეტი");
                case 17: return ("ჩვიდმეტი");
                case 18: return ("თვრამეტი");
                case 19: return ("ცხრამეტი");
                case 20: return ("oცი");
                case 40: return ("ორმოცი");
                case 60: return ("სამოცი");
                case 80: return ("ოთხმოცი");
                default: return null;
            }
        }
        //221
        private string TwoDigit(int t)
        {
            if (t == 20 || t == 40 || t == 60 || t == 80)
            {
                return TwoDigitHelper(t);
            }

            switch (t / 20)
            {
                case 1: return "ოცდა" + TwoDigitHelper(t % 20);
                case 2: return "ორმოცდა" + TwoDigitHelper(t % 20);
                case 3: return "სამოცდა" + TwoDigitHelper(t % 20);
                case 4: return "ოთხმოცდა" + TwoDigitHelper(t % 20);
                default:
                    break;
            }

            return TwoDigitHelper(t);
        }

        private string ThreeDigit(int t)
        {
            if (t < 100) return (TwoDigit(t));
            string rv = "ას";
            int dig = t / 100;
            if (dig > 1)
            {
                if (dig != 8 && dig != 9)
                {
                    rv = TwoDigitHelper(dig).Substring(0, TwoDigitHelper(dig).Length - 1) + rv;
                }
                else
                {
                    rv = TwoDigitHelper(dig) + rv;
                }

            }
            string tmp = TwoDigit(t % 100);
            if (tmp == "ნული") return rv + "i";
            return (rv + " " + tmp);
        }

        public string PrintString(int t)
        {
            string rv = "";
            if (t < 0)
            {
                rv += "მინუს ";
                t = 0 - t;
            }
            string bil = ThreeDigit(t / 1000000000);
            t = t % 1000000000;
            string mil = ThreeDigit(t / 1000000);
            t = t % 1000000;
            string tho = ThreeDigit(t / 1000);
            t = t % 1000;
            string dg = ThreeDigit(t);

            if (bil != "ნული")
            {
                if (bil != "ერთი")
                    rv += bil + " ";
                rv += "მილიარდ ";
            }
            if (mil != "ნული")
            {
                if (mil != "ერთი")
                    rv += mil + " ";
                rv += "მილიონ ";
            }
            if (tho != "ნული")
            {
                if (tho != "ერთი")
                    rv += tho + " ";
                rv += "ათას ";
            }
            if (dg != "ნული")
                rv += dg;
            if (dg == "ნული" && rv != "ნული" && rv != "")
                rv = rv.Substring(0, rv.Length - 1) + "i";
            if (rv == "") rv = "ნული";
            return rv;
        }
    }
}
