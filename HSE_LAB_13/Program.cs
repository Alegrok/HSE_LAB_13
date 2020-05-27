using System;

namespace HSE_LAB_13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объект для создания элементов коллекции
            var animal = new Animals();

            // Создании двух коллекций MyNewCollection и два объекта Journal
            var myFirstNewTree = new MyNewTree<Animals>();
            myFirstNewTree.NameCollection = "Первая коллекция";
            var mySecondNewTree = new MyNewTree<Animals>();
            mySecondNewTree.NameCollection = "Первая коллекция";
            var firstJournal = new Journal();
            var secondJournal = new Journal();

            // Подпишем первый объект Journal на события из первой коллекции
            myFirstNewTree.CollectionCountChanged += firstJournal.HandleEvent;
            myFirstNewTree.CollectionInvokesHandler += firstJournal.HandleEvent;
            myFirstNewTree.CollectionReferenceChanged += firstJournal.HandleEvent;

            // Подпишем второй объект Journal на события из первой и второй коллекции
            mySecondNewTree.CollectionInvokesHandler += secondJournal.HandleEvent;
            mySecondNewTree.CollectionReferenceChanged += secondJournal.HandleEvent;
            mySecondNewTree.CollectionInvokesHandler += secondJournal.HandleEvent;
            mySecondNewTree.CollectionReferenceChanged += secondJournal.HandleEvent;

            // Созданим рандомные объекты на основе animal
            var animal1 = (Animals)animal.CreateObjectAnimalsRandom().Clone();
            var animal2 = (Animals)animal.CreateObjectAnimalsRandom().Clone();
            var animal3 = (Animals)animal.CreateObjectAnimalsRandom().Clone();
            var animal4 = (Animals)animal.CreateObjectAnimalsRandom().Clone();
            var animal5 = (Animals)animal.CreateObjectAnimalsRandom().Clone();
            var animal6 = (Animals)animal.CreateObjectAnimalsRandom().Clone();

            // Внесем изменения в первую коллекцию
            myFirstNewTree.Add(animal1);
            myFirstNewTree.Add(animal2);
            myFirstNewTree.Add(animal3);
            myFirstNewTree.Add(animal4);
            myFirstNewTree.Add(animal5);
            myFirstNewTree.Remove(animal3);
            myFirstNewTree.Remove(2);
            myFirstNewTree[0] = animal6;
            myFirstNewTree.GetByIndex(1);

            // Внесем изменения во вторую коллекцию
            mySecondNewTree.Add(animal1);
            mySecondNewTree.Add(animal2);
            mySecondNewTree.Add(animal3);
            mySecondNewTree.Add(animal4);
            mySecondNewTree.Add(animal5);
            mySecondNewTree.Remove(animal3);
            mySecondNewTree.Remove(2);
            mySecondNewTree[0] = animal6;
            mySecondNewTree.GetByIndex(1);

            // Выведем данные журнала
            Console.WriteLine(firstJournal);
            Console.WriteLine(secondJournal);
        }
    }
}
