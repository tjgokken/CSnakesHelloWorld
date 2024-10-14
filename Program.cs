using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSnakesHelloWorld;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                var home = Path.Combine(Environment.CurrentDirectory, "."); // Python module directory
                services
                    .WithPython()
                    .WithHome(home)
                    .FromFolder(@"C:\Python312", "3.12")
                    .FromNuGet("3.12.0"); // Specify Python version via NuGet
            });

        var app = builder.Build();
        var env = app.Services.GetRequiredService<IPythonEnvironment>();

        // Invoke the Python function
        var numbers = new List<double> { 10.5, 20.0, 30.75, 40.25, 50.0 };
        var module = env.Hello();
        var res = module.HelloWorld("TJ");
        var result = module.ProcessNumbers(numbers);
        //var result2 = module.SummarizeData(@"C:\MyPath");
        Console.WriteLine(res);
        Console.WriteLine($"Mean: {result["mean"]}, Median: {result["median"]}, " +
                          $"Std Dev: {result["stdev"]}");
    }
}