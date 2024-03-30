namespace Blazor.PDF.Toolkit.Components.ImageConverter;

public class ImageConverterCore
{
    public static void RefreshImageConverter()
    {
        ImageConverter.UploadedImage = null;
        ImageConverter.IsConversionComplete = false;
        ImageConverter.IsConversionInitiated = false;
        ImageConverter.ImageOrientation = null;
        ImageConverter.PreviewImageUrl = "";
    }
}