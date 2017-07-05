using Sino.WilddogClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var wilddog = new WilddogClient("");
            var child = wilddog.Child("eventdata");
            var node = child.Child("13.json");

            string s = node.Insert(new
            {
                A = 1,
                B = "123"
            });
        }
    }
}
