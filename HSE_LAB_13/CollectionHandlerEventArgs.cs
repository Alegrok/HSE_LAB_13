using System;
using System.Collections.Generic;
using System.Text;

namespace HSE_LAB_13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class CollectionHandlerEventArgs : EventArgs
    {
        public readonly string name;
        public readonly string type;
        public readonly int index;
        public readonly Animals animal;

        public CollectionHandlerEventArgs(string name, string type, Animals animal)
        {
            this.name = name;
            this.type = type;
            this.animal = animal;
        }

        public override string ToString()
        {
            return $"Событие {type} произошло в коллекции {name} с элементом {animal}";
        }
    }
}
