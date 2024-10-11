var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

int workerThread,  threads;
ThreadPool.GetAvailableThreads(out workerThread, out threads);

var succes = ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
ThreadPool.GetAvailableThreads(out workerThread, out threads);
//ThreadPool.GetAvailableThreads(out workerThread, out threads);  thread sayýsýný buluyoruz.
//Cpu'nun thread sayýsýna göre senkron ve asenkron'a verdiði tepkiyi görebiliriz. 


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
