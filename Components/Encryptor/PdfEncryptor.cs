namespace Components.Encryptor
{
    class PdfEncryptor
    {
        public static bool IsUploadComplete { get; set; } = false;
        public static bool IsEncryptionComplete { get; set; } = false;
        public static bool IsSubmitComplete { get; set; } = false;
        public static byte[] PdfFile { get; set; }
        public static string SubmitMessage { get; set; } = string.Empty;
        public static string UploadMessage { get; set; } = string.Empty;
        public static string UploadErrorMessage { get; set; } = string.Empty;
        public static string DownloadMessage { get; set; } = string.Empty;
        public static long TotalSize { get; set; } = 0;
        public static long MaxSizeAllowed { get; } = 20971520;
        public static string FileType { get; set; } = "application/pdf";
        public static string FileTypeAllowed { get; } = "application/pdf";
        public static string Format { get; } = "data:application/pdf;base64,";
        public static string FinalEncryptedPdfURL { get; set; } = string.Empty;
    }
}