using System;

namespace GeekDinner.Core
{
    public class Rsvp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsWaitlist { get; set; }
    }
}