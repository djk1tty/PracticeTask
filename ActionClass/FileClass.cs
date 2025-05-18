using FileExchangerAPI.ActionClass.HelperClass;
using FileExchangerAPI.Interface;
using FileExchangerAPI.Models;
using File = FileExchangerAPI.Models.File;

namespace FileExchangerAPI.ActionClass
{
    public class FileClass : IFile
    {
        private readonly FileExchangeDbContext _context;
        public FileClass(FileExchangeDbContext context)
        {
            _context = context;
        }
        public List<string> AddFile(FileCreate file)
        {
            try
            {

                File createdFile = new File()
                {
                    FileName = file.FileName,
                    UserId = file.UserId,
                    UploadedAt = file.UploadedAt,
                    MimeType = file.MimeType,
                    StoragePath = file.StoragePath,
                    FileSize = file.FileSize,
                };

                _context.Files.Add(createdFile);
                _context.SaveChanges();

                int fileId = createdFile.Id;

                Results.Created();
                return [$"Файл успешно создан id - {fileId}"];
            }
            catch (Exception)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }

        public List<File> GetFileById(int id)
        {
            try
            {
                var project = _context.Files.Find(id);

                if (project == null)
                {
                    Results.NotFound(new List<string> { $"Проекта с id {id} не существует" });
                }
                var fileData = _context.Files.Where(r => r.Id == id).Select(x => new File()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    UserId = x.UserId,
                    UploadedAt = x.UploadedAt,
                    MimeType = x.MimeType,
                    StoragePath = x.StoragePath,
                    FileSize = x.FileSize
                }
                ).ToList();
                return fileData;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<File> GetFiles()
        {
            try
            {
                var fileData = _context.Files.Select(x => new File()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    UserId = x.UserId,
                    UploadedAt = x.UploadedAt,
                    MimeType = x.MimeType,
                    StoragePath = x.StoragePath,
                    FileSize = x.FileSize,
                }
                ).ToList();
                return fileData;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<string> UpdateFile(int id, UpdateFileDTO file)
        {
            try
            {
                var fileData = _context.Files.FirstOrDefault(x => x.Id == id);

                fileData.FileName = file.FileName;
                fileData.MimeType = file.MimeType;
                fileData.StoragePath = file.StoragePath;
                

                _context.Files.Update(fileData);
                _context.SaveChanges();

                Results.Ok();
                return ["Данные о файле успешно обновлены"];
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
        public List<string> DeleteFile(int id)
        {
            try
            {
                var file = _context.Files.Find(id);

                if (file == null)
                {
                    return new List<string> { "Файл не найден" };
                }

                _context.Files.Remove(file);
                _context.SaveChanges();

                Results.NoContent();
                return ["Файл успешно удален"];
            }
            catch
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }
    }
}
