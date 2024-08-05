using System.Text;

namespace Baitap02_chuong5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Student[] students = new Student[5];

            //Nhập thông tin cho từng sinh viên
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student();

                Console.Write($"Nhập tên sinh viên thứ {i + 1}: ");
                students[i].Name = Console.ReadLine();

                Console.Write($"Nhập điểm của sinh viên thứ {i + 1}: ");
                students[i].Score = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();
            }

            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (students[i].Score < students[j].Score)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            Console.WriteLine("3 sinh viên có điểm số cao nhất là :");
            for (int i = 0; i < 3 && i < students.Length; i++)
            {
                Console.WriteLine($"Tên : {students[i].Name}, Điểm số : {students[i].Score}");
            }
        }
    }

    class Student
    {
        public string Name;
        public double Score;
    }

}
