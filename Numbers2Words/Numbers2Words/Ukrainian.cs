using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers2Words
{
    class Ukrainian
    {
        public void js()
        {
            using (JavascriptContext context = new JavascriptContext())
            {

                // Setting external parameters for the context
              
                context.SetParameter("message", "Hello World !");
                context.SetParameter("number", 1);

                // Script
                string script = @"
        var i;
        for (i = 0; i < 5; i++)
          
        number += i;
    ";

                // Running the script
                context.Run(script);

                // Getting a parameter
                Console.WriteLine("number: " + context.GetParameter("number"));
            }
        }
    }
}
