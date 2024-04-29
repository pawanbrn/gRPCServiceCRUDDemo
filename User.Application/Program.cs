using Grpc.Net.Client;
using ProductOfferGrpcService.Protos;

var channel = GrpcChannel.ForAddress("http://localhost:5263");
var client = new UserOfferService.UserOfferServiceClient(channel);

var serverReply = client.GetUserOfferList(new EmptyRequestArg { });
Console.WriteLine(serverReply);

Console.ReadLine();