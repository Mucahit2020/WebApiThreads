var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

int workerThread,  threads;
ThreadPool.GetAvailableThreads(out workerThread, out threads);

var succes = ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
ThreadPool.GetAvailableThreads(out workerThread, out threads);
//ThreadPool.GetAvailableThreads(out workerThread, out threads);  thread say�s�n� buluyoruz.
//Cpu'nun thread say�s�na g�re senkron ve asenkron'a verdi�i tepkiyi g�rebiliriz. 


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
