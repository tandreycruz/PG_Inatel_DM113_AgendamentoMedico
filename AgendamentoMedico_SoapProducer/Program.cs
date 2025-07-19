using AgendamentoMedico_SoapProducer.Service;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IAgendamentoMedicoService, AgendamentoMedicoService>();

var app = builder.Build();

app.UseSoapEndpoint<IAgendamentoMedicoService>("/Service.asmx", new SoapEncoderOptions());

app.Run();
