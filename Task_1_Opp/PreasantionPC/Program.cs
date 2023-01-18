using BLPC.Models;
using System;
using System.Diagnostics;

namespace PreasantionPC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu = -1;
            int N = 0;
            int size = 0;
            while (true) {
                do {
                    Console.WriteLine("Enter max count PC:");
                } while (!int.TryParse(Console.ReadLine(), out N));
                if (N > 0) {
                    break;
                }
            }
            List<PC> PClist = new List<PC>();
            do
            {
                Console.WriteLine("1 - Add PC\n"+
                    "2 - View all PC\n" +
                    "3 - Search PC\n" +
                    "4 - Delete PC\n" +
                    "5 - Start all PC\n" +
                    "0 - Exit\n");
                do {
                    Console.WriteLine("Enter number: ");
                } while (!int.TryParse(Console.ReadLine(), out menu));
                
                switch (menu) {
                    case 1:
                        if (N > size) {

                            int id = size;
                            string? name;
                            float price;
                            PCCategory category = PCCategory.Gaming;

                            do
                            {
                                Console.WriteLine("Enter name: ");
                                name = Console.ReadLine();
                            } while (String.IsNullOrEmpty(name));
                            do
                            {
                                Console.WriteLine("Enter price: ");
                            } while (!float.TryParse(Console.ReadLine(), out price) && price > 0);
                            bool valid = true;
                            do {
                                int tmp;
                                do {
                                    Console.WriteLine("Enter category(1 - Gaming, 2 - Office, 3 - Professional, 4 - Budgetary): ");
                                } while (!int.TryParse(Console.ReadLine(), out tmp));
                                valid = true;
                                switch (tmp) {
                                    case 1:
                                        category = PCCategory.Gaming;
                                        break;
                                    case 2:
                                        category = PCCategory.Office;
                                        break;
                                    case 3:
                                        category = PCCategory.Professional;
                                        break;
                                    case 4:
                                        category = PCCategory.Budgetary;
                                        break;
                                    default:
                                        valid = false;
                                        break;
                                }
                            } while (valid == false);

                            PClist.Add(new PC(id, name, price, category));

                            size++;
                        }
                        else {
                            Console.WriteLine("You reach limit\n");
                        }
                        break;
                    case 2:
                        if (PClist.Count > 0) {
                            foreach (PC pc in PClist) {
                                Console.WriteLine(pc);
                            }
                        } else {
                            Console.WriteLine("Nothing to view\n");
                        }
                        break;
                    case 3:
                        int menu1 = -1;
                        do
                        {
                            Console.WriteLine("1 - By Id\n" +
                                "2 - By Name\n" +
                                "3 - Price from\n" +
                                "4 - Price up to\n" +
                                "0 - Back\n");
                            do {
                                Console.WriteLine("Enter number: ");
                            } while (!int.TryParse(Console.ReadLine(), out menu1));
                            switch (menu1)
                            {
                                case 1:
                                    int id = 0;
                                    do {
                                        Console.WriteLine("Enter id: ");
                                    } while (!int.TryParse(Console.ReadLine(), out id) && id > 0);

                                    foreach (PC pc in PClist) {
                                        if (pc.Id == id) {
                                            Console.WriteLine(pc);
                                        } 
                                    }
                                    menu1 = 0;
                                    break;
                                case 2:
                                    string? name;
                                    do {
                                        Console.WriteLine("Enter name: ");
                                        name = Console.ReadLine();
                                    } while (String.IsNullOrEmpty(name));

                                    foreach (PC pc in PClist) {
                                        if (pc.Name?.ToLower() == name.ToLower()) {
                                            Console.WriteLine(pc);
                                        }
                                    }
                                    menu1 = 0;
                                    break;
                                case 3:
                                    float price = 0;
                                    do {
                                        Console.WriteLine("Enter price: ");
                                    } while (!float.TryParse(Console.ReadLine(), out price) && price > 0);

                                    foreach (PC pc in PClist) {
                                        if (pc.Price >= price) {
                                            Console.WriteLine(pc);
                                        }
                                    }
                                    menu1 = 0;
                                    break;
                                case 4:
                                    do {
                                        Console.WriteLine("Enter price: ");
                                    } while (!float.TryParse(Console.ReadLine(), out price) && price > 0);

                                    foreach (PC pc in PClist) {
                                        if (pc.Price <= price) {
                                            Console.WriteLine(pc);
                                        }
                                    }
                                    menu1 = 0;
                                    break;
                            }
                        } while (menu1 != 0);
                        break;
                    case 4:
                        if (size > 0) {
                            int menu2 = -1;
                            do
                            {
                                Console.WriteLine("1 - By Id\n" +
                                    "2 - By Name\n" +
                                    "0 - Back\n");
                                do {
                                    Console.WriteLine("Enter number: ");
                                } while (!int.TryParse(Console.ReadLine(), out menu2));
                                bool valid = false;
                                switch (menu2)
                                {
                                    case 1:
                                        int id = 0;
                                        do {
                                            Console.WriteLine("Enter id: ");
                                        } while (!int.TryParse(Console.ReadLine(), out id) && id > 0);
                                        for (int i = 0; i < PClist.Count; i++) {
                                            if (PClist[i].Id == id) {
                                                PClist.Remove(PClist[i]);
                                                size--;
                                                valid = true;
                                                break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        string? name;
                                        do {
                                            Console.WriteLine("Enter name: ");
                                            name = Console.ReadLine();
                                        } while (String.IsNullOrEmpty(name));

                                        for (int i = 0; i < PClist.Count; i++)
                                        {
                                            if (PClist[i].Name?.ToLower() == name.ToLower()) {
                                                PClist.Remove(PClist[i]);
                                                size--;
                                                valid = true;
                                                break;
                                            }
                                        }
                                        break;
                                }
                                if (valid == true) {
                                    Console.WriteLine("Successful delete!");
                                    menu2 = 0;
                                }
                                else {
                                    Console.WriteLine("Not such object with this data!");
                                }
                            } while (menu2 != 0);
                            
                        }
                        else {
                            Console.WriteLine("Nothing to delete\n");
                        }
                        break;
                    case 5:
                        foreach (PC pc in PClist) {
                            pc.start();
                        }
                        break;
                }
            } while (menu != 0);
        }
    }
}