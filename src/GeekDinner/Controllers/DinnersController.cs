using GeekDinner.ClientModels;
using GeekDinner.Core.Interfaces;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Internal;

namespace GeekDinner.Controllers
{
    public class DinnersController : Controller
    {
        private readonly IDinnerRepository _dinnerRepository;
        private readonly IDateTime _systemClock;

        public DinnersController(IDinnerRepository dinnerRepository,
                                IDateTime systemClock)
        {
            _dinnerRepository = dinnerRepository;
            _systemClock = systemClock;
        }

        public IActionResult Index()
        {
            return View(_dinnerRepository.List());
        }

        [HttpPost]
        public IActionResult AddRsvp([FromBody]RsvpRequest rsvpRequest)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            var dinner = _dinnerRepository.GetById(rsvpRequest.DinnerId);
            if (dinner == null)
            {
                return HttpNotFound("Dinner not found.");
            }
            var result = dinner.AddRsvp(rsvpRequest.Name,
                rsvpRequest.Email,
                _systemClock.Now);

            _dinnerRepository.Update(dinner);
            return Ok(result);
        }
    }
}
