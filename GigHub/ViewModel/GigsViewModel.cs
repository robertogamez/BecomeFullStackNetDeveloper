using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModel
{
    public class GigsViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public string Heading { get; set; }
    }
}