using System;
using GeekDinner.Core.Interfaces;

namespace GeekDinner.Infrastructure
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now { get { return System.DateTime.Now; } }
    }
}