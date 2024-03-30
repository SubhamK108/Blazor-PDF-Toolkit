namespace Blazor.PDF.Toolkit.Components.ImageConverter;

public class ImageConverter
{
    public static ProcessedFile? UploadedImage { get; set; } = null;
    public static bool IsConversionComplete { get; set; } = false;
    public static bool IsConversionInitiated { get; set; } = false;
    public static ImageOrientations? ImageOrientation { get; set; } = null;
    public static string PreviewImageUrl { get; set; } = "";
    public static long MaxSizeAllowed { get; } = 20971520;
    public static string[] ImageTypesAllowed { get; } = ["image/png", "image/jpg", "image/jpeg"];

    public enum ImageOrientations
    {
        PORTRAIT,
        LANDSCAPE
    };
}