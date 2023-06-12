using System.Text.Json;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcRandomNumbersClient;

//For local run
//using var channel = GrpcChannel.ForAddress("https://localhost:7280");

using var channel = GrpcChannel.ForAddress("http://host.docker.internal:8080");
var client = new Numbers.NumbersClient(channel);

Console.WriteLine("Start...");

for (var j = 0; j < 10; j++)
{
    for (var i = 0; i < 100; i++)
    {
        var reply = await client.GetNumberAsync(new Empty());
        Console.WriteLine("Random number: " + GetNumber(reply));
        await Task.Delay(100);
    }
    
    await Task.Delay(1000);
}

Console.WriteLine("End...");


long GetNumber(NumberReply numberReply)
{
    var json = JsonFormatter.Default.Format(numberReply.Data);
    var document = JsonDocument.Parse(json);

    long.TryParse(document.RootElement.GetProperty("number").GetString(), out var result);
    return result;
}