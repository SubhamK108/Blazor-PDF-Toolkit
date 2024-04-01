namespace Blazor.PDF.Toolkit.Components.Merger;

public class MergerCore
{
    public static void MergePdfs()
    {
        using MemoryStream stream = new();
        PdfWriter pdfWriter = new(stream);
        pdfWriter.SetSmartMode(false);
        PdfDocument pdfDocument = new(pdfWriter);
        pdfDocument.InitializeOutlines();

        foreach (ProcessedFile file in Merger.UploadedFiles)
        {
            PdfDocument currentPdf = new(new PdfReader(new MemoryStream(file.Content!)));
            currentPdf.CopyPagesTo(1, currentPdf.GetNumberOfPages(), pdfDocument);
            currentPdf.Close();
        }

        pdfDocument.Close();

        Core.Core.FinalPdfFilename = "Merged PDF";
        Core.Core.FinalPdfUrl = $"data:application/pdf;base64,{Convert.ToBase64String(stream.ToArray())}";
    }

    public static void RefreshMerger()
    {
        Merger.UploadedFiles = [];
        Merger.IsMergeComplete = false;
        Merger.IsMergeInitiated = false;
    }
}