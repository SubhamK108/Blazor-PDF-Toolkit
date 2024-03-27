namespace Blazor.PDF.Toolkit.Components.PageExtractor;

class PageExtractorCore
{
    public static void RefreshPageExtractor()
    {
        PageExtractor.UploadedFile = null;
        PageExtractor.TotalPages = 0;
        PageExtractor.PagesToExtract = "";
        PageExtractor.PagesToExtractInfo = "(Format/Examples: 2 or 3,7 or 15-30)";
        PageExtractor.PagesToExtractValidator = PageExtractor.ValidatorStates.EMPTY;
        PageExtractor.TotalPagesToExtract = 0;
        PageExtractor.IsExtractionComplete = false;
        PageExtractor.IsExtractionInitiated = false;
    }
}