using System.Text;

namespace Baitap03_chuong5
{
    internal class Program
    {
        static CD[] catalog = new CD[1000];
        static int cdCounter = 1;
        static int currentCDCount = 0;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool isExit = true;
            while (isExit) 
            {
                Console.WriteLine();
                Console.WriteLine("Menu");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Add CD");
                Console.WriteLine("2. Search CD");
                Console.WriteLine("3. Display catalog");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addCD();
                        break;
                    case 2:
                        searchCD();
                        break;
                    case 3:
                        DisplayCatalog();
                        break;
                    case 4:
                        isExit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                        break;
                }
            }
        }

        private static void DisplayCatalog()
        {
            if (currentCDCount == 0) 
            {
                Console.WriteLine("Catalog trống");
                return;
            }

            Console.WriteLine("|{0,-10}|{1,-20}|{2,-25}|{3,-10}   |", "CD No", "CD Name", "CD Type", "CD Price");
            Console.WriteLine(new string('-', 73));

            for (int i = 0; i < currentCDCount; i++)
            {
                Console.WriteLine("|{0,-10}|{1,-20}|{2,-25}|{3,-10:C}VND|", catalog[i].CDId, catalog[i].CDName, catalog[i].CDType, catalog[i].CDPrice);
            }
        }

        private static void searchCD()
        {
            Console.Write("Nhap ten CD muon tim : ");
            string name = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < currentCDCount; i++)
            {
                if (catalog[i].CDName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    Console.WriteLine($"CD trung co ten {name} : " +
                        $"ID :{catalog[i].CDId}, " +
                        $"Name :{catalog[i].CDName}, " +
                        $"Type :{catalog[i].CDType}, " +
                        $"Price :{catalog[i].CDPrice}");
                }
            }

            if (!found)
            {
                Console.WriteLine("Khong tim thay CD");
            }
        }

        private static void addCD()
        {
            if(currentCDCount >= 1000)
            {
                Console.WriteLine("Catalog is full! Cannot add more CDs!");
                return;
            }

            Console.Write("Nhap ten CD : ");
            string name = Console.ReadLine();
            Console.Write("Nhap type CD : ");
            string type = Console.ReadLine();
            Console.Write("Nhap gia CD : ");
            double price = Convert.ToDouble(Console.ReadLine());

            CD newCD = new CD(cdCounter++ , name, type, price);
            catalog[currentCDCount++] = newCD;

            Console.WriteLine("Them CD thanh cong");
        }
    }

    class CD
    {
        public int CDId;
        public string CDName;
        public string CDType;
        public double CDPrice;

        public CD(int id,string name,string type, double price) 
        {
            this.CDId = id;
            this.CDName = name;
            this.CDType = type;
            this.CDPrice = price;
        }
    }


}
