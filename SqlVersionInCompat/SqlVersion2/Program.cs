using System;
using NServiceBus;

class Program
{
    static void Main()
    {
        Console.Title = "SqlVersionInCompat.SqlVersion2";
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("SqlVersionInCompat.SqlVersion2");
        var transport = busConfiguration.UseTransport<SqlServerTransport>();
        transport.ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=SqlVersionInCompat;Integrated Security=True");
        busConfiguration.UsePersistence<InMemoryPersistence>();

        using (Bus.Create(busConfiguration).Start())
        {
            Console.WriteLine("Press any key to exit");
            Console.WriteLine("Waiting for message from the Sender");
            Console.ReadKey();
        }
    }
}