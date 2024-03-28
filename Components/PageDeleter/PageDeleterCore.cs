namespace Blazor.PDF.Toolkit.Components.PageDeleter;

class PageDeleterCore
{
    public static void RefreshPageDeleter()
    {
        PageDeleter.UploadedFile = null;
        PageDeleter.TotalPages = 0;
        PageDeleter.PagesToDelete = "";
        PageDeleter.PagesToDeleteInfo = "(Format/Examples: 2 or 3,7 or 15-30)";
        PageDeleter.PagesToDeleteValidator = PageDeleter.ValidatorStates.EMPTY;
        PageDeleter.TotalPagesToDelete = 0;
        PageDeleter.IsDeletionComplete = false;
        PageDeleter.IsDeletionInitiated = false;
    }
}