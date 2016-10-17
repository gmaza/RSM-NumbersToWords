using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers2Words
{
    public class Ukrainian
    {
        public string Convert(decimal money)
        {
            var result = string.Empty;
            using (JavascriptContext context = new JavascriptContext())
            {
                context.SetParameter("nnn", money.ToString());
                string script = File.ReadAllText(@"numbersToUkrainian.js");
                context.Run(script);

                result = context.GetParameter("result").ToString();                        
            }
            return result;
        }
    }
}
