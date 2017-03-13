using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;

using BenchmarkDotNet.Attributes;

namespace mongobench
{
    [TargetSystemJob]
    public class MongoSerializationResolutionBenchmark
    {
        private readonly IBsonSerializerRegistry _registry;

        private readonly Type _type;

        public MongoSerializationResolutionBenchmark()
        {
            _registry = BsonSerializer.SerializerRegistry;
            _type = typeof(BsonDocument);
        }

        [Benchmark]
        public void GetSerializer()
        {
            _registry.GetSerializer(_type);
        }
    }
}
