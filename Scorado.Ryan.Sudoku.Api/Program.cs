using Scorado.Ryan.Sudoku.Game;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IBoardStorage, BoardStorage>();
builder.Services.AddTransient<Solver, BruteForceSolver>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
