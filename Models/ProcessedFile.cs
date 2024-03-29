namespace Blazor.PDF.Toolkit.Models;

public class ProcessedFile
{
    public Guid Id { get; set; }
    public string? FileName { get; set; }
    public byte[]? Content { get; set; }
}