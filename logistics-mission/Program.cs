using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDotNet;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();

            engine.Initialize();



            engine.Evaluate("load('c:/Users/hcs64648/Desktop/iris_logit.RData')");
            //var iris_logit = engine.GetSymbol("iris_logit");
            //var flower_func_logit = engine.GetSymbol("flower_func_logit");

            var rv = engine.Evaluate("flower_func_logit(1,1,1,1)");
            Console.WriteLine(rv.ToString());

            engine.Dispose();
        }
    }
}
