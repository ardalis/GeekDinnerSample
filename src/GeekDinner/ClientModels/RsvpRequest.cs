using System.ComponentModel.DataAnnotations;

namespace GeekDinner.ClientModels
{
    public class RsvpRequest
    {
        [Required(ErrorMessage = "DinnerId is required")]
        public int DinnerId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}