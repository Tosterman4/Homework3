using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Program
    {

        static bool subzero(string num,out int vivnum)
        {
            string incnum=num;
            if (int.TryParse(incnum, out int cornum) && incnum!="0")//попытка конвертации и проверка на нулевое значение
            {
                vivnum = cornum;
                return false;
            }
            else
            {
                Console.WriteLine("Incoorect data. Try again.");
                vivnum = 0;
                return true;
            }
        }
        static (string firstName, string lastName, int age, string[] petsName, string[] favcolors) AllAbout()
        {
            (string firstName,string lastName,int age, string[] petsName, string[] favcolors) anketa;//пустой кортеж
            bool forPet;//переменная для проверки наличия питомцев
            string numForInt;//переменная для ввода данных
            int corrNumForInt;//переменная для конвертированных данных

            Console.WriteLine("What is your first name?");
            anketa.firstName = Console.ReadLine();//заполнение имени

            Console.WriteLine("What is your last name?");
            anketa.lastName = Console.ReadLine();//заполнение фамилии

            Console.WriteLine("How old are you?");
            do//цикл на заполнение переменной пока данные не будут сконвертированы
            {
                numForInt = Console.ReadLine();
            }
            while (subzero(numForInt, out corrNumForInt));
            anketa.age = corrNumForInt;//заполнение возраста

            Console.WriteLine("Do you have a pet? Type true or false.");
            forPet = Convert.ToBoolean(Console.ReadLine());//булево значение для проверки на наличие питомцев

            Console.WriteLine("How many pets do you have?");
            do//цикл на заполнение переменной пока данные не будут сконвертированы
            {
                numForInt = Console.ReadLine();
            }
            while(subzero(numForInt, out corrNumForInt));
            anketa.petsName = arrayPets(corrNumForInt);//заполнение массива имен через метод 

            Console.WriteLine("How much do you have favourite colors?");
            do//цикл на заполнение переменной пока данные не будут сконвертированы
            {
                numForInt = Console.ReadLine();
            }
            while (subzero(numForInt, out corrNumForInt));
            anketa.favcolors=arrayColors(corrNumForInt);//заполнение массива цветов через метод 
            return anketa;//возврат кортежа
        }
        static string[] arrayPets(int num)
        {
            string[] array = new string[num];
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Type name of {i+1} pet");
                array[i]= Console.ReadLine();
            }
            return array;
        }
        static string[] arrayColors(int num)
        {
            string[] array = new string[num];
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Type name of {i+1} color");
                array[i] = Console.ReadLine();
            }
            return array;
        }
        static void showAllAbout()
        {
            (string firstName, string lastName, int age, string[] petsName, string[] favcolors) completeAnketa = AllAbout();
            Console.WriteLine("\nALL ABOUT YOU\n");
            Console.WriteLine($"First name is {completeAnketa.firstName}");
            Console.WriteLine($"Last name is {completeAnketa.lastName}");
            Console.WriteLine($"Age is {completeAnketa.age}\n");
            int i = 1, j = 1;
            foreach (string item in completeAnketa.petsName)//цикл на вывод массива в консоль
            {
                Console.WriteLine($"Your {i} pet`s name is {item}");
                i++;
            }
            Console.WriteLine("\n");
            foreach (string item in completeAnketa.favcolors)//цикл на вывод массива в консоль
            {
                Console.WriteLine($"Your {j} favourite color is {item}");
                j++;
            }

        }
        static void Main(string[] args)
        {
            showAllAbout();
            Console.ReadKey();
        }
    }
}
