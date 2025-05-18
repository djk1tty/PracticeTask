using FileExchangerAPI.ActionClass.HelperClass;
using FileExchangerAPI.ActionClass;

namespace FileExchangerAPI.Interface
{
    public interface IUser
    {
        public List<UserDTO> GetUsers();

        public List<UserDTO> GetUser(int id);

        public List<string> AddUser(UserCreate user);

        public List<string> UpdateUser(int id, UpdateUserDTO user);

        public List<string> DeleteUser(int id);
    }
}
