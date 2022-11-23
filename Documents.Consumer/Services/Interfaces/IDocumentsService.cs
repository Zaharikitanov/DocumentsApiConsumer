using DocumentsApi.Messages;

namespace Documents.Consumer.Services.Interfaces
{
    public interface IDocumentsService
    {
        Task CreateAsync(DocumentBusMessage newDocumentBusMessage);
        Task<List<DocumentBusMessage>> GetAsync();
        Task<DocumentBusMessage?> GetAsync(string id);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, DocumentBusMessage updatedDocumentBusMessage);
    }
}