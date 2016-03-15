using System;
using GeekDinner.Core.Interfaces;

namespace GeekDinner.Infrastructure
{
    public class MachineClockDateTime : IDateTime
    {
        public DateTime Now { get { return DateTime.Now; } }
    }
}