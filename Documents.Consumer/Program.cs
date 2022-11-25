using Documents.Consumer.Database.Settings;
using Documents.Consumer.Handlers;
using Documents.Consumer.Services;
using Documents.Consumer.Services.Interfaces;
using STP.AspNetCore.Bus.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDocumentsService, DocumentsService>();
builder.Services.AddMessageHandlers(typeof(PublishedDocumentHandler).Assembly);

builder.Services.Configure<DocumentStoreDatabaseSettings>(
    builder.Configuration.GetSection("DocumentStoreDatabase"));

builder.Services.AddLsb<ICloudBus, CloudBus>(
                builder.Configuration.GetSection("CloudLsb"),
                (namedQueueFactgory, svcProvider, lsbSettings, log) => namedQueueFactgory
                    .ForServer()
                    .RegisterSubscriptions(c =>
                    {
                        try
                        {
                            c.SubscribeMessageHandlers(
                                                        serviceProvider: svcProvider,
                                                        assembliesContainingMessageHandlers: new[]
                                                        {
                                typeof(PublishedDocumentHandler).Assembly,
                                                        },
                                                        logger: log);
                        }
                        catch (global::System.Exception ex)
                        {
                            global::System.Console.WriteLine(ex.Message);
                            throw;
                        }
                        
                    })
                    .WithSettings(lsbSettings)
                    .CreateQueue());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseLsb();

app.Run();
