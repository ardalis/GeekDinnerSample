using System;
using System.Linq;
using GeekDinner.Core;
using Xunit;

namespace GeekDinner.Tests
{
    public class DinnerAddRsvp
    {
        private readonly DateTime _testEventDate;
        private readonly TimeSpan _rsvpHours;
        public DinnerAddRsvp()
        {
            // 1 Jun 2016 18:00
            _testEventDate = new DateTime(2016, 6, 1, 18, 0, 0);
            _rsvpHours = TimeSpan.FromHours(2);
        }

        [Fact]
        public void ReturnsFailedPastDeadlineIfCalledPastDeadline()
        {
            var dinner = GetTestDinner();

            var result = dinner.AddRsvp("name", "email", GetCurrentTimePastDeadline());

            Assert.Equal("Failed - Past deadline.", result.Status);
        }
        [Fact]
        public void ReturnsSuccessWhenMaxAttendeesNotSetAndBeforeDeadline()
        {
            var dinner = GetTestDinner();


            var result = dinner.AddRsvp("name", "email", GetCurrentTimeBeforeDeadline());

            Assert.Equal("Success", result.Status);
        }
        [Fact]
        public void ReturnsSuccessWhenMaxAttendeesNotExceededAndBeforeDeadline()
        {
            var dinner = GetTestDinner();
            dinner.MaxAttendees = 5;

            var result = dinner.AddRsvp("name", "email", GetCurrentTimeBeforeDeadline());

            Assert.Equal("Success", result.Status);
            Assert.Equal(1, dinner.Rsvps.Count());
        }
        [Fact]
        public void ReturnsWaitlistWhenMaxAttendeesAtLimitAndBeforeDeadline()
        {
            var dinner = GetTestDinner();
            dinner.MaxAttendees = 1;

            var result = dinner.AddRsvp("name", "email", GetCurrentTimeBeforeDeadline());
            result = dinner.AddRsvp("name2", "email2", GetCurrentTimeBeforeDeadline());

            Assert.Equal("Waitlist", result.Status);
            Assert.Equal(1, dinner.Rsvps.Count(r => r.IsWaitlist));
        }

        private DateTime GetCurrentTimeBeforeDeadline()
        {
            return _testEventDate.AddDays(-1);
        }
        private DateTime GetCurrentTimePastDeadline()
        {
            return _testEventDate.AddHours(-1);
        }

        private Dinner GetTestDinner()
        {
            return new Dinner()
            {
                EventDate = _testEventDate,
                RsvpDeadline = _rsvpHours // 16:00 deadline
            };
        }
    }
}
