using System;
using System.Linq;
using System.Data;
using RDotNet;

namespace DTree
{
    static class Program
    {
        static string predict(this REngine engine, double sl, double sw, double pl, double pw, string species)
        {
            engine.Evaluate(string.Format(
                "p <- data.frame(Sepal.Length={0}, Sepal.Width={1}, Petal.Length={2}, Petal.Width={3}, Species=\"{4}\")",
                sl, sw, pl, pw, species));
            engine.Evaluate("ctreepred <- predict(iris_ctree, newdata=p)");

            return engine.GetSymbol("ctreepred").AsCharacter()[0];
        }

        static void Main(string[] args)
        {
            REngine.SetEnvironmentVariables();
            using (var engine = REngine.GetInstance())
            {
                engine.Evaluate("load(file=\"d-tree.RData\")");

                Console.WriteLine(engine.predict(5.1f, 3.5f, 1.4f, 0.2f, "setosa"));
                Console.WriteLine(engine.predict(7.1f, 3.0f, 5.9f, 2.1f, "virginica"));
                Console.WriteLine(engine.predict(4.9f, 2.4f, 3.3f, 1.0f, "versicolor"));
            }
        }
    }
}
