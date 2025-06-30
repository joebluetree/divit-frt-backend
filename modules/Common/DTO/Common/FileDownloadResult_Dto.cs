using System;
namespace Common.DTO.Common
{

    public class FileDownloadResult_Dto
    {
        public MemoryStream? FileStream { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }

    }
}