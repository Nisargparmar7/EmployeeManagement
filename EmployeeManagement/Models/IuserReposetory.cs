using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public interface IuserReposetory
    {
        public List<UserModel> getAll();
        public UserModel Register(UserModel user);

        public UserModel getUserModelById(int id);

        public UserModel Login(string username, string password);

    }
}
