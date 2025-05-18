using System;
using System.Collections.Generic;

namespace FileExchangerAPI.Models;

public partial class File
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime UploadedAt { get; set; }

    public string StoragePath { get; set; } = null!;

    public string MimeType { get; set; } = null!;

    public int FileSize { get; set; }

    public string FileName { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
