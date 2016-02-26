using System;
using System.Collections.Generic;
using System.Linq;
using GeekDinner.Controllers;
using GeekDinner.Core;
using GeekDinner.Core.Interfaces;
using Microsoft.AspNet.Mvc;
using Moq;
using Xunit;

namespace GeekDinner.Tests
{
    public class DinnerAddRsvpShould
    {
        private readonly DateTime _testEventDate;
        public DinnerAddRsvpShould()
        {
            // 1 Jun 2016 18:00
            _testEventDate = new DateTime(2016, 6, 1, 18, 0, 0);
        }

        [Fact]
        public void ReturnFailedPastDeadlineIfCalledAfterDeadline()
        {
            var currentTime = _testEventDate.AddHours(-1); // 17:00
            var dinner = new Dinner()
            {
                EventDate = _testEventDate,
                RsvpDeadline = TimeSpan.FromHours(2) // 16:00 deadline
            };

            var result = dinner.AddRsvp("name", "email", currentTime);

            Assert.Equal("Failed - Past deadline.", result.Status);
        }
    }
}
