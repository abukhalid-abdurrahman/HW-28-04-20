using System;
using System.Collections.Generic;
using System.Threading;

namespace Task_1
{
    class Client
    {
        public int Id;
        public int Age;
        public decimal Balance;
        public string FirstName;
    }

    class Program
    {
        static int clientId = 0;
        static List<Client> clients = new List<Client>();
        static int InputId()
        {
            Console.Write("Input ID: ");
            int Id = int.Parse(Console.ReadLine());
            return Id;
        }

        static Client FindById(int Id)
        {
            Client resClient = null;
            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    if (client.Id == Id)
                    {
                        resClient = client;
                        break;
                    }
                    else
                        return resClient;
                }
            }
            else
                return resClient;

            return resClient;
        }
        static void Insert()
        {
            Client client = new Client();
            clientId++;
            Console.Write("Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Возраст: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Баланс: ");
            decimal balance = decimal.Parse(Console.ReadLine().Replace('.', ','));
            client.Id = clientId;
            client.FirstName = firstName;
            client.Age = age;
            client.Balance = balance;
            clients.Add(client);
        }

        static void Update(object Id)
        {
            Console.Write("Баланс: ");
            decimal balance = decimal.Parse(Console.ReadLine().Replace('.', ','));

            Client client = FindById((int)Id);
            Client updatedClient = new Client();

            updatedClient.Id = client.Id;
            updatedClient.FirstName = client.FirstName;
            updatedClient.Age = client.Age;
            updatedClient.Balance = balance;
            clients.RemoveAt((int)Id - 1);
            clients.Add(updatedClient);
        }
        static void UI()
        {
            string menu = "\n1.\tInsert Client\n2.\tUpdate Client\n3.\tDelete Client\n4.\tSelect Client\n0.\tExit\n";
            Console.WriteLine(menu);
            string cmd = string.Empty;
            while (cmd != "0")
            {
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        Thread threadInsert = new Thread(new ThreadStart(Insert));
                        threadInsert.Start();
                        threadInsert.Join();
                        break;
                    case "2":
                        {
                            int Id = InputId();
                            Thread threadUpdate = new Thread(new ParameterizedThreadStart(Update));
                            threadUpdate.Start(Id);
                            threadUpdate.Join();
                        }
                        break;
                    case "3":
                        //Thread threadDelete = new Thread(new ThreadStart(Delete));
                        //threadDelete.Start();
                        break;
                    case "4":
                        //Thread threadSelect = new Thread(new ThreadStart(Select));
                        //threadSelect.Start();
                        foreach(Client c in clients)
                        {
                            Console.WriteLine(c.Id + ": " + c.FirstName);
                            Console.WriteLine(c.Id + ": " + c.Balance);
                        }
                        break;
                }
                Console.WriteLine(menu);
            }
        }
        static void Main(string[] args)
        {
            UI();
        }
    }
}
