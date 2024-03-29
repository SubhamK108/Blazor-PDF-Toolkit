namespace Blazor.PDF.Toolkit.Components.Core;

public class Core
{
    public static bool IsUploadComplete { get; set; } = false;
    public static bool IsUploadInitiated { get; set; } = false;
    public static bool IsUploadFailed { get; set; } = false;
    public static string UploadMessage { get; set; } = string.Empty;
    public static string UploadErrorMessage { get; set; } = string.Empty;
    public static string SubmitMessage { get; set; } = string.Empty;
    public static string DownloadMessage { get; set; } = string.Empty;
    public static string FinalPdfFilename { get; set; } = string.Empty;
    public static string FinalPdfUrl { get; set; } = string.Empty;

    public enum UploadTypes
    {
        PDF,
        IMAGE
    }
}