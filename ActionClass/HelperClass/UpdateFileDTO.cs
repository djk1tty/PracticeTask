namespace FileExchangerAPI.ActionClass.HelperClass
{
    public class UpdateFileDTO
    {
        public int Id { get; set; }

        public string FileName{ get; set; } = null!;

        public string StoragePath { get; set; } = null!;

        public string MimeType { get; set; } = null!;

    }
}
