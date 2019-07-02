using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using System.IO;
using Newtonsoft.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BroAPI
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>

        public void FunctionHandler( ILambdaContext context)
        {
            string json;
            BroList bros;
            string startupPath = Environment.CurrentDirectory + "\\BroNames.json";
            Console.WriteLine(startupPath);

            using (StreamReader r = new StreamReader(startupPath))
            {
                 json = r.ReadToEnd();
                 bros = JsonConvert.DeserializeObject<BroList>(json);
            }
        }
        public class BroName
        {
            public string Name { get; set; }
        }

        public class BroList
        {
            public List<string> BroNames { get; set; }
        }



    }
}