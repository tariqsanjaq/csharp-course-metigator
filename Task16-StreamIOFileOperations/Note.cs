using System;
using System.Collections.Generic;
using System.Text;

namespace Task16_StreamIOFileOperations
{
    internal class Note
    {
        private readonly int _id;
        private readonly DateTime _createdAt;
        private string _title;
        private string _content;

        public int Id { get { return _id; } }
        public DateTime CreatedAt { get { return _createdAt; } }
        public string Title { get { return _title; } private set { _title = value; } }
        public string Content { get { return _content; } private set { _content = value; } }

        public Note(int id, string title, string content)
        {
            _id = id;
            _createdAt = DateTime.Now;
            Title = title;
            Content = content;

        }

        public override string ToString()
        {
            return $"Id : {Id}\nCreated : {CreatedAt.ToString("yyyy/MM/dd HH:mm")}\nTitle : {Title}\nContent : {Content}";
        }


    }
}
