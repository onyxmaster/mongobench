using System.IO;

using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

using BenchmarkDotNet.Attributes;

namespace mongobench
{
    [TargetSystemJob]
    public class BsonWriterBenchmark
    {
        private readonly MemoryStream _stream;

        private readonly IBsonSerializer<BsonDocument> _serializer;

        private readonly BsonDocument _document;

        public BsonWriterBenchmark()
        {
            _serializer = BsonSerializer.SerializerRegistry.GetSerializer<BsonDocument>();
            _stream = new MemoryStream(DocumentCount * 30);
            _document = new BsonDocument("_id", 0);
        }

        const int DocumentCount = 10;

        [Benchmark(OperationsPerInvoke = DocumentCount)]
        public void WriteMessage()
        {
            _stream.Position = 0;
            using (var writer = new BsonBinaryWriter(_stream))
            {
                var context = BsonSerializationContext.CreateRoot(writer);
                for (int i = 0; i < DocumentCount; i++)
                {
                    _serializer.Serialize(context, _document);
                }
            }
        }
    }
}
