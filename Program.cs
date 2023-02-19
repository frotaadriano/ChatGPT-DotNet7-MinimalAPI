using System.Security.AccessControl;
using System.Text;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection(); 

app.MapGet("/questions", () => new Question[]{ new (1,"asked1", "answer1"), new (2, "asked2", "answer2")});
app.MapGet("/questions/{question}", (string question) => $"Your question was: {question}");

var questionArray = new Question[]{
    new (1,"asked1", "answer1"),
    new (1,"asked2", "answer2"),
    new (1,"asked3", "answer3"),
    new (1,"asked4", "answer4"),
    new (1,"asked5", "answer5"),
    new (1,"asked6", "answer6")
};

app.MapGet("/questionsQS", (int query_string_qtd) =>  {

    var answer = JsonConvert.SerializeObject(questionArray.Take(query_string_qtd));
    
    return new Question(
        Id:1,
        Asked:"",
        Answer:answer
    );
});

app.MapPost("/questions", (Question question) => question); 


app.Run();

record Question(int Id, string Asked, string Answer = "")
{ 
}
