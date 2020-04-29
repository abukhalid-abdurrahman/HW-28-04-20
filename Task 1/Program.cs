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
        static object locker = new object();
        static void Insert()
        {
            lock (locker)
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
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
