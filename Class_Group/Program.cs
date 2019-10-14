using System;
using System.Collections.Generic;
using System.Linq; //упроститель жизни =)
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Baza2
{
    class Program
    {
        static void Main()
        {
            var first_name = new List<string>();
            var last_name = new List<string>();

            const string fileGroup = "GroupStud.txt";

            using (var txtFile = new StreamReader(fileGroup))
            {
                while (!txtFile.EndOfStream) 
                {
                    var text = txtFile.ReadLine();

                    var values = text.Split(' ');

                    first_name.Add(values[1]);
                    last_name.Add(values[0]);

                    //Console.WriteLine(text);
                }
            }

            var Group_NP = NEWGroup(first_name.ToArray(), last_name.ToArray(), 25); //число создаваемых студентов
            foreach (var stud in Group_NP)
                stud.Visualise();
            

            Console.ReadLine();

        }

       

        class Group
        {
            public string FirstName;
            public string LastName;
            public int[] Ratings;
            public void Visualise()
            {
                Console.Write("{0}, {1} ", LastName, FirstName);
                if (Ratings != null)
                {
                    for (int i = 0; i < Ratings.Length; i++)
                        Console.Write("{0} ",  Ratings[i]); //КАК ЭТО ПРОИСХОДИТ???????????????????
                }

                Console.WriteLine();
            }

        }

        static Group[] NEWGroup (string[] FirstNames, string[] LastNames, int Count)
        {

            var NewGroup = new Group[Count]; //создаем массив типа Group ?
            var end = new Random(); //генератор случ чисел
            for (var i = 0; i < Count; i++)
            {
                var first_name = FirstNames[end.Next(0, FirstNames.Length)];//рандомное число от 0 до длины массива
                var last_name = LastNames[end.Next(0, LastNames.Length)];

                var groupONE = new Group(); //создаем переменную типа сласса Group ?

                groupONE.FirstName = first_name;
                groupONE.LastName = last_name;
                groupONE.Ratings = GetRandomRatings(end, 10, 2, 3, 4, 5);

                NewGroup[i] = groupONE;

            }
            return NewGroup;
        }

        static int GetRandom(Random rnd, params int[] Variants)
        {
            int index = rnd.Next(0, Variants.Length);
            return Variants[index];
        }

        static int[] GetRandomRatings(Random rnd, int count, params int[] Variants)
        {

            var result = new int[count];
            for (int i = 0; i < count; i++)
                result[i] = GetRandom(rnd, Variants);
            return result;
        }

    }




}
