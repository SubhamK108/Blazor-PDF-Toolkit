namespace Blazor.PDF.Toolkit.Components.PageExtractor;

public class PageExtractorCore
{
    private static List<int> GetPageNumbersToExtract(string pagesToExtract)
    {
        if (pagesToExtract.Contains(","))
        {
            List<int> pages = [];
            foreach (string pageNum in pagesToExtract.Split(","))
            {
                pages.Add(Convert.ToInt32(pageNum));
            }
            pages.Sort();
            return pages;
        }

        if (pagesToExtract.Contains("-"))
        {
            List<int> pages = [];
            int firstPage = Convert.ToInt32(pagesToExtract.Split("-")[0]);
            int lastPage = Convert.ToInt32(pagesToExtract.Split("-")[1]);
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

        return [Convert.ToInt32(pagesToExtract)];
    }

    public static void ExtractPagesFromPdf()
    {
        using MemoryStream stream = new();
        PdfWriter pdfWriter = new(stream);
        pdfWriter.SetSmartMode(false);
        PdfDocument pdfDocument = new(pdfWriter);
        pdfDocument.InitializeOutlines();

        PdfDocument sourceDocument = new(new PdfReader(new MemoryStream(PageExtractor.UploadedFile!.Content!)));
        List<int> pageNumsToExtract = GetPageNumbersToExtract(PageExtractor.PagesToExtract);
        sourceDocument.CopyPagesTo(pageNumsToExtract, pdfDocument);

        sourceDocument.Close();
        pdfDocument.Close();

        string fileName = PageExtractor.UploadedFile!.FileName!;
        Core.Core.FinalPdfFilename = $"{fileName[..(fileName.Length - 4)]} (Extracted)";
        Core.Core.FinalPdfUrl = $"data:application/pdf;base64,{Convert.ToBase64String(stream.ToArray())}";
    }

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