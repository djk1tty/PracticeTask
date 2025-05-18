using System.ComponentModel.DataAnnotations;

namespace FileExchangerAPI.ActionClass
{
    public class FileCreate
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public string StoragePath { get; set; }
        [Required]
        public DateTime UploadedAt { get; set; }
        [Required]
        public int FileSize { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
