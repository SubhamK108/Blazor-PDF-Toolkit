namespace Blazor.PDF.Toolkit.Components.PageExtractor;

class PageExtractor
{
    public static ProcessedFile? UploadedFile { get; set; }
    public static int TotalPages { get; set; } = 0;
    public static string PagesToExtract { get; set; } = "";
    public static string PagesToExtractInfo { get; set; } = "(Format/Examples: 2 or 3,7 or 15-30)";
    public static ValidatorStates PagesToExtractValidator { get; set; } = ValidatorStates.EMPTY;
    public static int TotalPagesToExtract { get; set; } = 0;
    public static bool IsExtractionComplete { get; set; } = false;
    public static bool IsExtractionInitiated { get; set; } = false;
    public static long MaxSizeAllowed { get; } = 20971520;
    public static string FileTypeAllowed { get; } = "application/pdf";

    public enum ValidatorStates
    {
        VALID,
        INVALID,
        CHECKING,
        EMPTY
    };
}