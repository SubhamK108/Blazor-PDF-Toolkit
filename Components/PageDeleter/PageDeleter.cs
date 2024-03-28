namespace Blazor.PDF.Toolkit.Components.PageDeleter;

class PageDeleter
{
    public static ProcessedFile? UploadedFile { get; set; } = null;
    public static int TotalPages { get; set; } = 0;
    public static string PagesToDelete { get; set; } = "";
    public static string PagesToDeleteInfo { get; set; } = "(Format/Examples: 2 or 3,7 or 15-30)";
    public static ValidatorStates PagesToDeleteValidator { get; set; } = ValidatorStates.EMPTY;
    public static int TotalPagesToDelete { get; set; } = 0;
    public static bool IsDeletionComplete { get; set; } = false;
    public static bool IsDeletionInitiated { get; set; } = false;
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