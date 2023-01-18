using BLPC.Models;

namespace PreasantionPC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu = -1;
            int N = 0;
            while (true) {
                Console.WriteLine("1 - Add PC:");
                N = Convert.ToInt32(Console.ReadLine());
                if (N > 0) {
                    break;
                }
            }
            do
            {
                Console.WriteLine("1 - Add PC\n"+
                    "2 - View all PC\n" +
                    "3 - Search PC\n" +
                    "4 - Delete PC\n" +
                    "5 - Add PC\n" +
                    "0 - Exit\n");

                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu) {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:
                        int menu1 = -1;
                        do
                        {
                            Console.WriteLine("1 - By Id\n" +
                                "2 - By Name\n" +
                                "3 - Price from\n" +
                                "4 - Price up to\n" +
                                "0 - Exit\n");

                            menu1 = Convert.ToInt32(Console.ReadLine());
                            switch (menu1)
                            {
                                case 1:

                                    break;
                                case 2:

                                    break;
                                case 3:

                                    break;
                                case 4:

                                    break;
                            }
                        } while (menu1 != 0);
                        break;
                    case 4:

                        break;
                    case 5:

                        break;

                }
            } while (menu != 0);
        }
    }
}