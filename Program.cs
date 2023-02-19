using System.Text;
using Newtonsoft.Json; 
using Newtonsoft.Json.Linq;

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

//TODO: put your key here (https://platform.openai.com/account/api-keys) 
var apiKey = "your key here";

app.MapPost("/questionChatGPT", async (Question question) => {
    if(string.IsNullOrEmpty(question.Asked)){
      return await ChatGPT.GetOpenAICompletion("What is the meaning of life?", apiKey); 
    }
    else {
      return await ChatGPT.GetOpenAICompletion( question.Asked, apiKey);      
    }
});

app.Run();

record Question(int Id, string Asked, string Answer = "")
{ 
}

public static class ChatGPT{

    public static async Task<string> GetOpenAICompletion(string prompt, string apiKey)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var json = new JObject(
            new JProperty("model", "text-davinci-002"),
            new JProperty("prompt", prompt),
            new JProperty("temperature", 0.5),
            new JProperty("max_tokens", 50),
            new JProperty("n", 1),
            new JProperty("stop", ".")
        );

        using var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("https://api.openai.com/v1/completions", content);

        if (!response.IsSuccessStatusCode)
        {
            return $"Request failed with status code {response.StatusCode}";
        }

        var responseJson = JObject.Parse(await response.Content.ReadAsStringAsync());
        var choices = responseJson.SelectToken("choices");
        var completion = choices?[0].SelectToken("text")?.ToString();

        return completion;
    }

}

