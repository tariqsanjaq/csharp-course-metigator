using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Task15_CollectionsDataStructures
{
    internal class ContactManager
    {
        private readonly Stack<string> _undoHistory = new Stack<string>();
        private readonly Queue<string> _pendingOperations = new Queue<string>();
        private readonly List<Contact> _contacts = new();
        private readonly Dictionary<string, List<Contact>> _contactsByCity =
            new Dictionary<string, List<Contact>>(StringComparer.OrdinalIgnoreCase);



        public void Add(Contact contact)
        {
            ArgumentNullException.ThrowIfNull(contact);
            _contacts.Add(contact);
            if (_contactsByCity.TryGetValue(contact.City, out List<Contact>? cityContacts))
            {
                cityContacts.Add(contact);
            }
            else
            {
                List<Contact> list = new List<Contact>();
                _contactsByCity[contact.City] = list;
                list.Add(contact);
            }
            RecordAction($"Added contact: {contact.Name}");
        }

        public bool Remove(int id)
        {
            Contact? contact = default;

            foreach (var item in _contacts)
            {
                if (item.Id == id)
                {
                    contact = item;
                    break;
                }
            }

            if (contact == null)
                return false;

            _contacts.Remove(contact);

            if (_contactsByCity.TryGetValue(contact.City, out List<Contact>? cityContacts))
            {
                cityContacts.Remove(contact);

                if (cityContacts.Count == 0)
                    _contactsByCity.Remove(contact.City);
            }
            RecordAction($"Removed contact: {contact.Name}");
            return true;
        }

        public Contact? FindById(int id)
        {
            foreach (var item in _contacts)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }
            return null;
        }


        public List<Contact> SearchByName(string part)
        {
            List<Contact> list = new List<Contact>();
            foreach (var item in _contacts)
            {
                if (item.Name.Contains(part, StringComparison.OrdinalIgnoreCase))
                {
                    list.Add(item);
                }

            }
            return list;
        }
        public List<Contact> GetByCity(string city)
        {
            if (_contactsByCity.TryGetValue(city, out List<Contact>? cityContacts))
                return cityContacts;

            return new List<Contact>();
        }

        public ReadOnlyCollection<Contact> GetAll() => _contacts.AsReadOnly();

        public string? Undo()
        {
            if (_undoHistory.TryPop(out string? action))
                return action;

            return null;
        }
        public void RecordAction(string action)
        {
            _undoHistory.Push(action);
        }

        public void QueueOperation(string operation)
        {
            _pendingOperations.Enqueue(operation);
        }

        public string? ProcessNextOperation()
        {
            if (_pendingOperations.TryDequeue(out string? operation))
                return operation;

            return null;
        }
    }
}
