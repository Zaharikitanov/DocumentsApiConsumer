using Documents.Consumer.Services.Interfaces;
using DocumentsApi.Messages;
using STP.AspNetCore.Bus.Abstractions;

namespace Documents.Consumer.Handlers
{
    public class PublishedDocumentHandler : IHandleAsync<DocumentBusMessage>
    {
        private readonly IDocumentsService _service;

        public PublishedDocumentHandler(IDocumentsService service)
        {
            _service = service;
        }

        public async Task HandleAsync(IMessageContext<DocumentBusMessage> messageContext)
        {
            await _service.CreateAsync(messageContext.Message);
        }
    }
}
