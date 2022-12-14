using BirthdayManager.Data;
using BirthdayManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthdayManager.Services
{
    public class FriendService
    {
        private readonly BirthdayManagerContext _context;

        public FriendService(BirthdayManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Friend>> GetAll()
        {
            return await _context.Friend.ToListAsync();
        }

        public async Task<Friend> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var friend = await _context.Friend
                .FirstOrDefaultAsync(m => m.FriendId == id);
            if (friend == null)
            {
                return null;
            }

            return friend;
        }

        public async Task Create(Friend friend)
        {
            _context.Add(friend);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Friend friend)
        {
            _context.Update(friend);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Friend friend)
        {
            _context.Friend.Remove(friend);
            await _context.SaveChangesAsync();
        }
    }
}