namespace Blazor.PDF.Toolkit.Components.Merger;

public class Merger
{
    public static List<ProcessedFile> UploadedFiles { get; set; } = [];
    public static bool IsMergeComplete { get; set; } = false;
    public static bool IsMergeInitiated { get; set; } = false;
    public static int MaxFilesAllowed { get; } = 20;
    public static long MaxSizeAllowed { get; } = 20971520;
    public static string FileTypeAllowed { get; } = "application/pdf";
}