using System.Security.AccessControl;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection(); 

app.MapGet("/questions", () => new Question[]{ new (1,"asked1", "answer1"), new (2, "asked2", "answer2")});
app.MapGet("/questions/{question}", (string question) => $"Your question was: {question}");

app.MapPost("/questions", (Question question) => question); 


app.Run();

record Question(int Id, string Asked, string Answer = "");
