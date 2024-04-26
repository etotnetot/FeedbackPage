using Microsoft.Extensions.DependencyInjection;
using Feedback.BLL.Services;
using Microsoft.Extensions.Configuration;

using Feedback.DAL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();