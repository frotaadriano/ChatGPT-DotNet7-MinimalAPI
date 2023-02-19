## Tecnologias utilizadas
- .NET 6.0 - uma plataforma de desenvolvimento para criar aplicativos multiplataforma e serviços web modernos.
- C# - uma linguagem de programação moderna e orientada a objetos projetada pela Microsoft.
- System.Net.Http - um namespace que fornece classes para enviar solicitações HTTP e receber respostas HTTP de um servidor.

## VS CODE Extensions
- REST Client v0.25.1

## Criando o projeto  

- dotnet new webapi -n MinhaAPI            >>>> api normal com controllers
- dotnet new webapi -minimmal -n MinhaAPI  >>>> minimal API 

## Minimal APIs quick reference
https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#webapi

## Tutorial: Create a minimal API with ASP.NET Core
https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-7.0&tabs=visual-studio 
 


## Abordagem
O código usa o namespace `System.Net.Http` para criar uma instância de `HttpClient`, que é usada para fazer uma solicitação `POST` para a API da OpenAI. A solicitação `POST` contém um corpo `JSON` que especifica o modelo da OpenAI a ser usado, a `prompt` para a qual desejamos obter uma resposta, o tamanho máximo dos tokens, a temperatura, o parâmetro `top-p` e outras opções para controlar o comportamento do modelo. Além disso, a solicitação contém um cabeçalho de autorização que contém a chave da API da OpenAI.

O código usa a palavra-chave `async` para indicar que a operação de solicitação da API é assíncrona. Isso permite que o thread da interface do usuário continue funcionando enquanto a solicitação está sendo processada em segundo plano.

O código usa o método `SendAsync` do objeto `HttpClient` para enviar a solicitação à API da OpenAI. O método `SendAsync` é uma operação assíncrona que retorna uma instância de `HttpResponseMessage`, que contém o status da resposta HTTP e o corpo da resposta.

O código usa a palavra-chave `await` para aguardar a conclusão da solicitação HTTP antes de continuar a execução do método. A palavra-chave `await` faz com que o thread da interface do usuário aguarde a conclusão da solicitação da API antes de continuar.

Por fim, o código verifica o status da resposta HTTP e retorna o conteúdo da resposta em forma de string ou uma mensagem de erro caso ocorra algum problema.

## Como executar o código
Para executar o código acima, você precisa ter o .NET 6.0 SDK instalado em sua máquina. Você também precisa de uma chave de API da OpenAI válida.

Para executar o código, basta copiar e colar o código em um arquivo .cs e executar o método `GetOpenAICompletions`. Certifique-se de substituir "YOUR_OPENAI_API_KEY" pela sua chave de API da OpenAI.

- Commando: dotnet run -lp https
- Swagger: https://localhost:7222/swagger/index.html

## Conclusão
O código acima é um exemplo simples de como consumir a API da OpenAI usando o .NET Minimal API. O código usa o namespace `System.Net.Http` para enviar uma solicitação `POST` para a API da OpenAI e recebe uma resposta `JSON` em forma de string. A partir daí, você pode usar a biblioteca `Newtonsoft.Json` para desserializar a resposta JSON em um objeto .NET.

## Screenshots

![App Screenshot](https://raw.githubusercontent.com/frotaadriano/ChatGPT-DotNet7-MinimalAPI/master/ScreenShots/chatgpt%20csharp.jpg)

