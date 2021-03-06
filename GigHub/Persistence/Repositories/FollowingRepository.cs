﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public Following GetFollowing(string followerId, string followeId)
        {
            return _context.Followings
                        .SingleOrDefault(f => f.FolloweeId == followeId && f.FollowerId == followerId);
        }
    }
}