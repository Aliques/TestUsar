using System;

namespace TestTaskUsar.Domain.Core
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;
    }
}
