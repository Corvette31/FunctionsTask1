using System;

namespace FunctionsTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fio = {"Иванов Иван Иванович" , "Петров Петр Петрович" , "Смирнова Светлана Викторовна" };
            string[] post = {"Директор" , "Программист", "Бухгалтер" };
            string usepIput = "";
            bool isRun = true;

            Console.WriteLine("Доступные команды: \n1 - добаить досье\n2 - вывести все досье\n3 - удалить досье\n4 - поиск по фамилии\n5 - выход\n");

            while (isRun)
            {
                Console.Write("Введите команду : ");
                usepIput = Console.ReadLine();

                switch (usepIput)
                {
                    case "1":
                        AddDossier(ref fio, ref post);
                        break;
                    case "2":
                        ShowDossier(fio, post);
                        break;
                    case "3":
                        DeleteDossier(ref fio, ref post);
                        break;
                    case "4":
                        SearchDossier(fio, post);
                        break;
                    case "5":
                        isRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static void ResizeArray(ref string[] array, int size)
        {
            string [] tempArray = new string[size];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
        }

        static void ResizeArray(ref string[] array, int size, int skipSymbolPosition)
        {
            string[] tempArray = new string[size];
            int currentIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == skipSymbolPosition - 1)
                {
                    continue;
                }
                tempArray[currentIndex] = array[i];
                currentIndex++;
            }

            array = tempArray;
        }

        static void AddDossier(ref string[] fio, ref string[] post)
        {
            Console.Write("Введите ФИО : ");

            ResizeArray(ref fio, fio.Length + 1);
            fio[fio.Length - 1] = Console.ReadLine();

            Console.Write("Введите должность : ");
            ResizeArray(ref post, post.Length + 1);
            post[post.Length - 1] = Console.ReadLine();

            Console.WriteLine("Досье добавлено"); 
        }

        static void ShowDossier(string[] fio, string[] post)
        {
            for (int i = 0; i < fio.Length; i++)
            {
                Console.WriteLine($"{i + 1} Сотрудник: {fio[i]} Должность: {post[i]}");
            }
        }

        static void DeleteDossier(ref string[] fio, ref string[] post)
        {
            Console.Write("Укажите номер досье которое нужно удалить : ");
            int dossierNumber = Convert.ToInt32(Console.ReadLine());

            if (dossierNumber > fio.Length || dossierNumber <= 0)
            {
                Console.WriteLine("Ошибка. Досье с таким номером не существует!");
                return;
            }

            ResizeArray(ref fio, fio.Length - 1, dossierNumber);
            ResizeArray(ref post, post.Length - 1, dossierNumber);
        }

        static void SearchDossier(string[] fio, string[] post)
        {
            Console.Write("Укажите фамилию для поиска : ");
            string surname = Console.ReadLine();
            bool isFind = false;

            for (int i = 0; i < fio.Length; i++)
            {
                foreach (var fioItem in fio[i].Split(" "))
                {
                    if (fioItem.ToLower() == surname.ToLower())
                    {
                        Console.WriteLine($"Найден сотрудник: {i + 1} {fio[i]} Должность : {post[i]}");
                        isFind = true;
                    }
                }
            }

            if (isFind == false)
            {
                Console.WriteLine($"Сотрудник с фамилией {surname} не найден");
            }
        }
    }
}
