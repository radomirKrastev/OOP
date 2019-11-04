namespace CollectionHierarchy
{
    using System;
    using Collections;

    public class Program
    {
        public static void Main()
        {
            var strings = Console.ReadLine().Split(" ");
            var removeOperations = int.Parse(Console.ReadLine());

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i == strings.Length - 1)
                {
                    Console.Write(addCollection.Add(strings[i]));
                    continue;
                }

                Console.Write(addCollection.Add(strings[i]) + " ");           
            }

            Console.WriteLine();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i == strings.Length - 1)
                {
                    Console.Write(addRemoveCollection.Add(strings[i]));
                    continue;
                }

                Console.Write(addRemoveCollection.Add(strings[i]) + " ");
            }
            
            Console.WriteLine();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i == strings.Length - 1)
                {
                    Console.Write(myList.Add(strings[i]));
                    continue;
                }

                Console.Write(myList.Add(strings[i]) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                if (i == removeOperations - 1)
                {
                    Console.Write(addRemoveCollection.Remove());
                    continue;
                }

                Console.Write(addRemoveCollection.Remove() + " ");
            }
            
            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                if (i == removeOperations - 1)
                {
                    Console.Write(myList.Remove());
                    continue;
                }

                Console.Write(myList.Remove() + " ");
            }
            
            Console.WriteLine();
        }
    }
}
