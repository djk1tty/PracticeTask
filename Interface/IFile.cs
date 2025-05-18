using FileExchangerAPI.ActionClass.HelperClass;
using FileExchangerAPI.ActionClass;
using FileExchangerAPI.Models;
using File = FileExchangerAPI.Models.File;

namespace FileExchangerAPI.Interface
{
    public interface IFile
    {
        public List<File> GetFiles();

        public List<File> GetFileById(int id);

        public List<string> AddFile(FileCreate file);

        public List<string> UpdateFile(int id, UpdateFileDTO file);

        public List<string> DeleteFile(int id);
    }
}
