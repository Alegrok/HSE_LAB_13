using System;
using System.Collections.Generic;
using System.Text;

namespace HSE_LAB_13
{
    public class Journal
    {
        private readonly List<JournalEntry> journal = new List<JournalEntry>();

        public void HandleEvent(object obj, CollectionHandlerEventArgs arg)
        {
            journal.Add(new JournalEntry(arg));
        }

        public override string ToString()
        {
            string str = "";
            foreach (var journalEntry in journal)
            {
                str += journalEntry + "\n";
            }
            return str;
        }

        private class JournalEntry
        {
            public string Name { get; set; }

            public string Type { get; set; }

            public string Data { get; set; }

            public JournalEntry(CollectionHandlerEventArgs eventArg)
            {
                Name = eventArg.name;
                Type = eventArg.type;
                Data = eventArg.animal.ToString();
            }

            public override string ToString()
            {
                return $"Событие {Type} произошло в коллекции {Name} с элементом {Data}";
            }
        }
    }
}
