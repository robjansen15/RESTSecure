using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTSecure
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "password123";
            string input = "hello world.";


            new REST<string>().POST(input, "/hello/there", token);

            Console.Read();
        }
    }
}
