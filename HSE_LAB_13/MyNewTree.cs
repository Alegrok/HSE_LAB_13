using System;
using System.Collections.Generic;
using System.Text;

namespace HSE_LAB_13
{
    public class MyNewTree<T> : MyTree<T>
    {
        public event CollectionHandler CollectionCountChanged; // при изменении количества элементов коллекции
        public event CollectionHandler CollectionInvokesHandler; // при вызове элемента из коллекции
        public event CollectionHandler CollectionReferenceChanged; // при изменении элемента из коллекции

        public string nameCollection = "Неизвестная коллекция";

        public string NameCollection { get; set; }

        public override void Add(T data)
        {
            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(NameCollection, "Add", data as Animals));
            base.Add(data);
        }

        public override bool Remove(int index)
        {
            if (base.Remove(index))
            {
                var elem = base.GetByIndex(index);
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(NameCollection, "RemoveByKey", elem as Animals));
                return true;
            }
            return false;
        }

        public override bool Remove(T data)
        {
            if (base.Remove(data))
            {
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(NameCollection, "RemoveByData", data as Animals));
                return true;
            }
            return false;
        }

        public override void SetValueByIndex(int index, T value)
        {
            CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs(NameCollection, "SetValueByIndex", value as Animals));
            base.SetValueByIndex(index, value);
        }

        public override T GetByIndex(int index)
        {
            var data = base.GetByIndex(index);
            CollectionInvokesHandler?.Invoke(this, new CollectionHandlerEventArgs(NameCollection, "GetByIndex", data as Animals));
            return base.GetByIndex(index);
        }
    }
}
