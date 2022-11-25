using Documents.Consumer.Services.Interfaces;
using STP.AspNetCore.Bus;
using STP.Lsb;

namespace Documents.Consumer.Services
{
    public class CloudBus : LexolutionServiceBus, ICloudBus
    {
        public CloudBus(ILexolutionQueue queue)
            : base(queue)
        {
        }
    }
}
