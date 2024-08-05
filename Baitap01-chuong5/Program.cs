using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Baitap_Chuong5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Item[] items = new Item[5];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item();
                Console.WriteLine($"Nhập thông tin cho món hàng thứ {i + 1}");
                Console.Write("Mã số : ");
                items[i].id = Convert.ToInt16(Console.ReadLine());

                Console.Write("Tên hàng : ");
                items[i].name = Console.ReadLine();

                Console.Write("Giá cả : ");
                items[i].price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Số lượng : ");
                items[i].quantity = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
            }

            //hiển thị tên từng món hàng và tổng giá trị của nó
            double totalWarehouseValue = 0;
            Console.WriteLine("Thông tin các món hàng có trong kho :");
            foreach(var item in items)
            {
                double itemValue = item.totalValue();
                Console.WriteLine($"Tên hàng : {item.name}, Tổng giá trị hàng : {itemValue.ToString("C", CultureInfo.CurrentCulture)}");
                totalWarehouseValue += itemValue;
            }

            Console.WriteLine($"\nTổng giá trị kho hàng : {totalWarehouseValue.ToString("C", CultureInfo.CurrentCulture)}");
        }
    }

    class Item
    {
        public int id;
        public string name;
        public double price;
        public int quantity;

        public double totalValue()
        {
            return price*quantity;
        }
    }
}

