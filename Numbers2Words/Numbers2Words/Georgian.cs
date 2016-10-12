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
                case 0: return ("nuli");
                case 1: return ("erti");
                case 2: return ("ori");
                case 3: return ("sami");
                case 4: return ("otxi");
                case 5: return ("xuti");
                case 6: return ("eqvsi");
                case 7: return ("shvidi");
                case 8: return ("rva");
                case 9: return ("cxra");
                case 10: return ("ati");
                case 11: return ("tertmeti");
                case 12: return ("tormeti");
                case 13: return ("cameti");
                case 14: return ("totxmeti");
                case 15: return ("txutmeti");
                case 16: return ("teqvsmeti");
                case 17: return ("chvidmeti");
                case 18: return ("tvrameti");
                case 19: return ("cxrameti");
                case 20: return ("oci");
                case 40: return ("ormoci");
                case 60: return ("samoci");
                case 80: return ("otxmoci");
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
                case 1: return "ocda" + TwoDigitHelper(t % 20);
                case 2: return "ormocda" + TwoDigitHelper(t % 20);
                case 3: return "samocda" + TwoDigitHelper(t % 20);
                case 4: return "otxmocda" + TwoDigitHelper(t % 20);
                default:
                    break;
            }

            return TwoDigitHelper(t);
        }

        private string ThreeDigit(int t)
        {
            if (t < 100) return (TwoDigit(t));
            string rv = "as";
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
            if (tmp == "nuli") return rv + "i";
            return (rv + " " + tmp);
        }

        public string PrintString(int t)
        {
            string rv = "";
            if (t < 0)
            {
                rv += "minus ";
                t = 0 - t;
            }
            string bil = ThreeDigit(t / 1000000000);
            t = t % 1000000000;
            string mil = ThreeDigit(t / 1000000);
            t = t % 1000000;
            string tho = ThreeDigit(t / 1000);
            t = t % 1000;
            string dg = ThreeDigit(t);

            if (bil != "nuli")
            {
                if (bil != "erti")
                    rv += bil + " ";
                rv += "miliard ";
            }
            if (mil != "nuli")
            {
                if (mil != "erti")
                    rv += mil + " ";
                rv += "milion ";
            }
            if (tho != "nuli")
            {
                if (tho != "erti")
                    rv += tho + " ";
                rv += "atas ";
            }
            if (dg != "nuli")
                rv += dg;
            if (dg == "nuli" && rv != "nuli" && rv != "")
                rv = rv.Substring(0, rv.Length - 1) + "i";
            if (rv == "") rv = "nuli";
            return rv;
        }
    }
}
