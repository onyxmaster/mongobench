using System;

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace mongobench
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TargetSystemJobAttribute : Attribute, IConfigSource
    {
        public TargetSystemJobAttribute()
        {
            var job = Job.RyuJitX64.WithGcServer(true).WithGcForce(false);
            Config = ManualConfig.Create(DefaultConfig.Instance).With(job);
        }

        public IConfig Config { get; }
    }
}
