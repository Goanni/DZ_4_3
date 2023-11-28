using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4_3
{
    public class MyArray
    {
        private int[] mass;

        public MyArray(int n)
        {
            mass = new int[n];
        }
        public void InputData(int[] values)
        {
            if (values.Length > mass.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < values.Length; i++)
            {

                mass[i] = values[i];
            }
        }
        public void InputDataRandom()
        {
            Random random = new Random();
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = random.Next(100);
            }
        }
        public void Print(in int first, in int second)
        {
            for (int i = first; i <= second; i++)
            {
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine("\n");
        }
        public void FindValue(in int value, out List<int> index)
        {
            index = new List<int>();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == value)
                {
                    index.Add(i);
                }
            }
        }
        public void Resize(in int newSize)
        {
            int[] temp = new int[newSize];
            for (int i = 0; i < newSize; i++)
            {
                temp[i] = mass[i];
            }
            mass = temp;
        }
        public void DelValue(in int value) 
        {
            FindValue(value, out List<int> index);
            for (int i = index.Count - 1; i > -1; i--)
            {
                int ind = index[i];
                for (int j = ind; j < mass.Length - 1; j++)
                {
                    mass[j] = mass[j + 1];
                }
            }
            Resize(mass.Length - index.Count);
        }
        public void FindMax(out int max)
        {
            max = int.MinValue;

            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] > max)
                {
                    max = mass[i];
                }
            }
        }
        public void Add(in MyArray array2, out int[] masssum)
        {
            masssum = new int[mass.Length];
            array2.InputDataRandom();
            Console.WriteLine("Второй массив: \n");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write(array2.mass[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Итог сложения:");
            for (int i = 0; i < mass.Length; i++)
            {
                masssum[i] = mass[i] + array2.mass[i];
            }
        }
        public void Sort()
        {
            for (int i = 0; i < mass.Length - 1; i++)
            {
                for (int j = 0; j < mass.Length - i - 1; j++)
                {
                    if (mass[j] > mass[j + 1])
                    {
                        int temp = mass[j];
                        mass[j] = mass[j + 1];
                        mass[j + 1] = temp;
                    }
                }
            }
        }
    }
    class DZ_4_3_
    {
        static void Main()
        {
            Console.WriteLine("Введите размерность массива:");
            int N = int.Parse(Console.ReadLine());
            MyArray myArray = new MyArray(N);
            string Change;
            do
            {
                Console.WriteLine("Выберите команду:" + "\n" + "1) Заполнить массив вручную" + "\n" + "2) Заполнить массив рандомными числами" +
                     "\n" + "3) Вывести на экран указанный диапазон массива" + "\n" + "4) Найти значение в массиве" + "\n" + "5) Удалить из массива искомый элемент" +
                     "\n" + "6) Найти максимум" + "\n" + "7) Сложение массивов поэлементно" + "\n" + "8) Сортировать массив по возрастанию" + "\n" + "9) Выход!");
                Change = Console.ReadLine();
                switch (Change)
                {
                    case "1":
                        Console.WriteLine("Введите значения массива:");
                        int[] input = Console.ReadLine().Split(' ').Select(it => Convert.ToInt32(it)).ToArray();
                        try
                        {
                            myArray.InputData(input);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine("Ошибка");
                        }
                        break;
                    case "2":
                        myArray.InputDataRandom();
                        break;
                    case "3":
                        Console.WriteLine("Введите нижнюю границу диапазона:");
                        int first = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите верхнюю границу диапазона:");
                        int second = int.Parse(Console.ReadLine());
                        myArray.Print(in first, in second);
                        break;
                    case "4":
                        Console.WriteLine("Введите значение:");
                        int value = int.Parse(Console.ReadLine());
                        myArray.FindValue(in value, out List<int> index);
                        for (int i = 0; i < index.Count; i++)
                        {
                            Console.Write(index[i] + " ");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "5":
                        Console.WriteLine("Введите значение:");
                        int valuedel = int.Parse(Console.ReadLine());
                        myArray.DelValue(in valuedel);
                        break;
                    case "6":
                        myArray.FindMax(out int max);
                        Console.WriteLine(max);
                        break;
                    case "7":
                        MyArray array2 = new MyArray(N);
                        array2.InputDataRandom();
                        myArray.Add(in array2, out int[] mass);
                        for(int i=0; i<mass.Length; i++)
                        {
                            Console.Write(mass[i] + " ");
                        }
                        Console.WriteLine("\n");
                        break;
                    case "8":
                        myArray.Sort();
                        break;
                    case "9":
                        Console.WriteLine("bye");
                        break;
                    default:
                        Console.WriteLine("Неверно введена команда");
                        break;
                }
            } while (Change != "exit");
        }
    }
}
