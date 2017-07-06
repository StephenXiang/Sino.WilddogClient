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
            var child = wilddog.Child("test");
            var node = child.Child("a.json");

            string s = node.InsertJson("{a : 1,b : 'c'}");
        }
    }
}
