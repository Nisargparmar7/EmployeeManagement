using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class UserReposetory : IuserReposetory
    {
        private readonly EmployeeDbContext _context;

        public UserReposetory(EmployeeDbContext context)
        {
            _context = context;
        }
        public List<UserModel> getAll()
        {
            return _context.Users.ToList();
        }

        public UserModel getUserModelById(int id)
        {
            return _context.Users.Find(id);
        }

        public UserModel Login(string username, string password)
        {
            return _context.Users
                          .FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public UserModel Register(UserModel user)
        {
            if (_context.Users.Any(u => u.UserName == user.UserName || u.Email == user.Email))
            {
                return null;
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
