using System;

namespace TestTaskUsar.Domain.Core.DTO
{
    public class MessageDTO
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
