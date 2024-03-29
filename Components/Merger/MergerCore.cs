namespace Blazor.PDF.Toolkit.Components.Merger;

public class MergerCore
{
    public static void RefreshMerger()
    {
        Merger.UploadedFiles = [];
        Merger.IsMergeComplete = false;
        Merger.IsMergeInitiated = false;
    }
}