using System;
namespace Common.DTO.UserAdmin
{
    public class FileDownloadResult_Dto
    {
        public MemoryStream? FileStream { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }

    }
}