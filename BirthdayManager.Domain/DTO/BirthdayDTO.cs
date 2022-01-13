using System;

namespace BirthdayManager.Domain.DTO
{
    public class BirthdayDTO
    {
        public class Create 
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }

        public class Get
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }

    }
}