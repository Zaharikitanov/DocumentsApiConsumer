using Documents.Consumer.Services.Interfaces;
using DocumentsApi.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Documents.Consumer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService _service;

        public DocumentsController(IDocumentsService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<List<DocumentBusMessage>> Get() =>
            await _service.GetAsync();

        [HttpGet("{messageId}")]
        public async Task<ActionResult<DocumentBusMessage>> Get(string messageId)
        {
            var documentBusMessage = await _service.GetAsync(messageId);

            if (documentBusMessage is null)
            {
                return NotFound();
            }

            return documentBusMessage;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DocumentBusMessage newDocumentBusMessage)
        {
            await _service.CreateAsync(newDocumentBusMessage);

            return CreatedAtAction(nameof(Get), new { messageId = newDocumentBusMessage.MessageId }, newDocumentBusMessage);
        }

        [HttpPut("{messageId}")]
        public async Task<IActionResult> Update(string messageId, DocumentBusMessage updatedDocumentBusMessage)
        {
            var documentBusMessage = await _service.GetAsync(messageId);

            if (documentBusMessage is null)
            {
                return NotFound();
            }

            updatedDocumentBusMessage.MessageId = documentBusMessage.MessageId;

            await _service.UpdateAsync(messageId, updatedDocumentBusMessage);

            return NoContent();
        }

        [HttpDelete("{messageId}")]
        public async Task<IActionResult> Delete(string messageId)
        {
            var documentBusMessage = await _service.GetAsync(messageId);

            if (documentBusMessage is null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(messageId);

            return NoContent();
        }
    }
}
