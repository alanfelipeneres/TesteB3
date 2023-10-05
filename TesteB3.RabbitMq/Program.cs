// See https://aka.ms/new-console-template for more information
using TesteB3.RabbitMq;

Console.WriteLine("Hello, World!");

Publisher publisher = new Publisher();
publisher.SendMessage("Teste 2", "fila 1");

Console.ReadLine();