using System.Reflection;

using BenchmarkDotNet.Running;

namespace mongobench
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).RunAll();
        }
    }
}
