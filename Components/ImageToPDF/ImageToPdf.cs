namespace Components.ImageToPDF
{
    class ImageToPdf
    {
        public static bool IsUploadComplete { get; set; } = false;
        public static bool IsConversionComplete { get; set; } = false;
        public static bool IsSubmitComplete { get; set; } = false;
        public static byte[] ImageFile { get; set; }
        public static string SubmitMessage { get; set; } = string.Empty;
        public static string UploadMessage { get; set; } = string.Empty;
        public static string UploadErrorMessage { get; set; } = string.Empty;
        public static string DownloadMessage { get; set; } = string.Empty;
        public static long TotalSize { get; set; } = 0;
        public static long MaxSizeAllowed { get; } = 20971520;
        public static string FileType { get; set; } = "image/jpg";
        public static string[] FileTypesAllowed { get; } = new string[] {"image/png", "image/jpg", "image/jpeg", "image/svg+xml"};
        public static string Format { get; } = "data:application/pdf;base64,";
        public static string FinalConvertedPdfURL { get; set; } = string.Empty;
    }
}