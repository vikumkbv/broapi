using System;
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
        public string FunctionHandler(ILambdaContext context)
        {
            //get name list
            var broList = GetBroNames();

            //randomize
            var broCount = (broList.BroNames.Count() - 1);
            Random rand =  new Random();
            var index = rand.Next(0, broCount);
            //return
            return broList.BroNames[index].ToString();

        }


        public BroList GetBroNames()
        {
            string startupPath = Environment.CurrentDirectory + "\\BroNames.json";
            Console.WriteLine(startupPath);

            using (StreamReader r = new StreamReader(startupPath))
            {
                string json = r.ReadToEnd();
                BroList bros = JsonConvert.DeserializeObject<BroList>(json);
                return bros;
            }
        }

    }
}