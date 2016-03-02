using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GeekDinner.ClientModels;
using GeekDinner.Core.Interfaces;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Converters;

namespace GeekDinner.Core
{
    public class Dinner
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title may not be longer than 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(256, ErrorMessage = "Description may not be longer than 256 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(20, ErrorMessage = "Hosted By name may not be longer than 20 characters")]
        [Display(Name = "Host's Name")]
        public string HostedBy { get; set; }

        [Required(ErrorMessage = "Contact info is required")]
        [StringLength(20, ErrorMessage = "Contact info may not be longer than 20 characters")]
        [Display(Name = "Contact Info")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, ErrorMessage = "Address may not be longer than 50 characters")]
        [Display(Name = "Address, City, State, ZIP")]
        public string Address { get; set; }

        public string Country { get; set; }
        public TimeSpan RsvpDeadline { get; set; }
        public List<Rsvp> Rsvps { get; set; } = new List<Rsvp>();
        [Range(1, 1000)]
        public int? MaxAttendees { get; set; }

        public bool IsHostedBy(string userName)
        {
            return String.Equals(HostedBy, userName, StringComparison.Ordinal);
        }

        private DateTime RsvpDeadlineDateTime()
        {
            return EventDate - RsvpDeadline;
        }

        public RsvpResult AddRsvp(string name, string email, DateTime currentDateTime)
        {
            if (currentDateTime > RsvpDeadlineDateTime())
            {
                return new RsvpResult("Failed - Past deadline.");
            }
            var rsvp = new Rsvp()
            {
                DateCreated = currentDateTime,
                EmailAddress = email,
                Name = name
            };
            if (MaxAttendees.HasValue)
            {
                if (Rsvps.Count(r => !r.IsWaitlist) >= MaxAttendees.Value)
                {
                    rsvp.IsWaitlist = true;
                    Rsvps.Add(rsvp);

                    return new RsvpResult("Waitlist");
                }
            }
            Rsvps.Add(rsvp);

            return new RsvpResult("Success");
        }
    }
}
