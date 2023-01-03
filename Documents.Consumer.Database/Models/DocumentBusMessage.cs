using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using STP.AspNetCore.Bus.Abstractions;

namespace DocumentsApi.Messages
{
    public class DocumentBusMessage : BusMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }    
        public string MessageId { get; set; } = null!;

        [BsonElement("DocumentId")]
        public Guid DocumentId { get; set; }

        public string DocumentName { get; set; } = null!;

        public int Version { get; set; }

        public string FileName { get; set; } = null!;

        public long FileSize { get; set; }
    }
}
