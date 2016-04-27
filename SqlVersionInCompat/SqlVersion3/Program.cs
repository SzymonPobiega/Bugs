using System;
using System.Threading.Tasks;
using NServiceBus;

class Program
{
    static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        Console.Title = "SqlVersionInCompat.SqlVersion3";
        var endpointConfiguration = new EndpointConfiguration("SqlVersionInCompat.SqlVersion3");
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        endpointConfiguration.AuditProcessedMessagesTo("audit");

        var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
        transport.ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=SqlVersionInCompat;Integrated Security=True");

        var endpoint = await Endpoint.Start(endpointConfiguration);
        await endpoint.Send("SqlVersionInCompat.SqlVersion2", new MessageA());
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        await endpoint.Stop();
    }

}