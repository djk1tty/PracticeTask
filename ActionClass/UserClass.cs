using FileExchangerAPI.ActionClass.HelperClass;
using FileExchangerAPI.Interface;
using FileExchangerAPI.Models;

namespace FileExchangerAPI.ActionClass
{
        public class UserClass : IUser
        {
            private readonly FileExchangeDbContext _context;
            public UserClass(FileExchangeDbContext context)
            {
                _context = context;
            }
            public List<string> AddUser(UserCreate user)
            {
                try
                {

                    User createdUser = new User()
                    {
                        Username = user.Username,
                        Email = user.Email,
                        PasswordHash = user.PasswordHash,
                        CreatedAt = user.CreatedAt,
                    };

                    _context.Users.Add(createdUser);
                    _context.SaveChanges();

                    int userId = createdUser.Id;

                    Results.Created();
                    return [$"Пользователь успешно создан. ID: {userId}"];
                }
                catch (Exception)
                {
                    Results.BadRequest(new List<string> { "Ошибка в ходе выполнения данного запроса" });
                    throw;
                }
            }

            public List<string> DeleteUser(int id)
            {
                try
                {
                    var user = _context.Users.Find(id);

                    if (user == null)
                    {
                        return new List<string> { "Пользователь не найден" };
                    }

                    _context.Users.Remove(user);
                    _context.SaveChanges();

                    Results.NoContent();
                    return ["Пользователь успешно удален"];
                }
                catch
                {
                    Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                    throw;
                }
            }

            public List<UserDTO> GetUser(int id)
            {
                try
                {
                    var user = _context.Users.Find(id);

                    if (user == null)
                    {
                        Results.NotFound(new List<string> { $"Пользователя c ID {id} не существует" });
                    }
                    var userData = _context.Users.Where(r => r.Id == id).Select(x => new UserDTO()
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Email = x.Email,
                        PasswordHash = x.PasswordHash,
                        CreatedAt = (DateTime)x.CreatedAt,
                    }
                    ).ToList();
                    return userData;
                }
                catch
                {
                    Results.BadRequest();
                    throw;
                }
            }

            public List<UserDTO> GetUsers()
            {
                try
                {
                    var usersData = _context.Users.Select(x => new UserDTO()
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Email = x.Email,
                        PasswordHash = x.PasswordHash,
                        CreatedAt = (DateTime)x.CreatedAt,
                    }
                    ).ToList();
                    return usersData;
                }
                catch
                {
                    Results.BadRequest();
                    throw;
                }
            }

            public List<string> UpdateUser(int id, UpdateUserDTO user)
            {
                try
                {
                    var userData = _context.Users.FirstOrDefault(x => x.Id == id);

                            userData.Username = user.Username;
                            userData.Email = user.Email;
                            userData.PasswordHash = user.PasswordHash;
                            userData.CreatedAt = user.CreatedAt;

                    _context.Users.Update(userData);
                    _context.SaveChanges();

                    Results.Ok();
                    return ["Данные пользователя успешно обновлены"];
                }
                catch
                {
                    Results.BadRequest();
                    throw;
                }
            }
        }
}
