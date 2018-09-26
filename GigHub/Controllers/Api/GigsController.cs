using GigHub.Core;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig == null)
            {
                return NotFound();
            }

            if (gig.IsCanceled)
            {
                return NotFound();
            }

            if (gig.ArtistId != userId)
            {
                return Unauthorized();
            }

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }

    }
}
