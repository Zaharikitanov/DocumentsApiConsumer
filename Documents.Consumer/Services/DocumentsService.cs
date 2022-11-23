using Documents.Consumer.Database.Settings;
using Documents.Consumer.Services.Interfaces;
using DocumentsApi.Messages;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Documents.Consumer.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IMongoCollection<DocumentBusMessage> _documentsCollection;

        public DocumentsService(
            IOptions<DocumentStoreDatabaseSettings> documentStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                documentStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                documentStoreDatabaseSettings.Value.DatabaseName);

            _documentsCollection = mongoDatabase.GetCollection<DocumentBusMessage>(
                documentStoreDatabaseSettings.Value.DocumentCollectionName);
        }

        public async Task<List<DocumentBusMessage>> GetAsync() =>
            await _documentsCollection.Find(_ => true).ToListAsync();

        public async Task<DocumentBusMessage?> GetAsync(string id) =>
            await _documentsCollection.Find(x => x.MessageId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(DocumentBusMessage newDocumentBusMessage) =>
            await _documentsCollection.InsertOneAsync(newDocumentBusMessage);

        public async Task UpdateAsync(string id, DocumentBusMessage updatedDocumentBusMessage) =>
            await _documentsCollection.ReplaceOneAsync(x => x.MessageId == id, updatedDocumentBusMessage);

        public async Task RemoveAsync(string id) =>
            await _documentsCollection.DeleteOneAsync(x => x.MessageId == id);
    }
}
