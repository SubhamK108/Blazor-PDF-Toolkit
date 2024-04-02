namespace Blazor.PDF.Toolkit.Components.PageDeleter;

public class PageDeleterCore
{
    private static List<int> GetPageNumbersToDelete(string pagesToDelete)
    {
        if (pagesToDelete.Contains(","))
        {
            List<int> pages = [];
            foreach (string pageNum in pagesToDelete.Split(","))
            {
                pages.Add(Convert.ToInt32(pageNum));
            }
            pages.Sort();
            return pages;
        }

        if (pagesToDelete.Contains("-"))
        {
            List<int> pages = [];
            int firstPage = Convert.ToInt32(pagesToDelete.Split("-")[0]);
            int lastPage = Convert.ToInt32(pagesToDelete.Split("-")[1]);
            if (firstPage > lastPage)
            {
                (lastPage, firstPage) = (firstPage, lastPage);
            }
            for (int pageNum = firstPage; pageNum <= lastPage; pageNum++)
            {
                pages.Add(pageNum);
            }
            return pages;
        }

        return [Convert.ToInt32(pagesToDelete)];
    }

    public static void DeletePagesFromPdf()
    {
        using MemoryStream stream = new();
        PdfWriter pdfWriter = new(stream);
        PdfReader pdfReader = new(new MemoryStream(PageDeleter.UploadedFile!.Content!));
        PdfDocument pdfDocument = new(pdfReader, pdfWriter);

        List<int> pageNumsToDelete = GetPageNumbersToDelete(PageDeleter.PagesToDelete);
        int totalPagesDeleted = 0;
        foreach (int pageNum in pageNumsToDelete)
        {
            pdfDocument.RemovePage(pageNum - totalPagesDeleted);
            totalPagesDeleted++;
        }

        pdfDocument.Close();
        pdfReader.Close();
        pdfWriter.Close();

        string fileName = PageDeleter.UploadedFile!.FileName!;
        Core.Core.FinalPdfFilename = $"{fileName[..(fileName.Length - 4)]} (Modified)";
        Core.Core.FinalPdfUrl = $"data:application/pdf;base64,{Convert.ToBase64String(stream.ToArray())}";
    }

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