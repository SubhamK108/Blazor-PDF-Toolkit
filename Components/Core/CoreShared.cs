namespace Blazor.PDF.Toolkit.Components.Core;

public class CoreShared
{
    public static void RefreshCore()
    {
        Core.IsUploadComplete = false;
        Core.IsUploadInitiated = false;
        Core.IsUploadFailed = false;
        Core.UploadMessage = string.Empty;
        Core.UploadErrorMessage = string.Empty;
        Core.SubmitMessage = string.Empty;
        Core.DownloadMessage = string.Empty;
        Core.FinalPdfFilename = string.Empty;
        Core.FinalPdfUrl = string.Empty;
    }
}