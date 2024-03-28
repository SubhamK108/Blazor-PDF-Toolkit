namespace Blazor.PDF.Toolkit.Components.Encryptor;

class Encryptor
{
    public static ProcessedFile? UploadedFile { get; set; } = null;
    public static string Password { get; set; } = "";
    public static string ReTypedPassword { get; set; } = "";
    public static string EncryptorInfo { get; set; } = "Re-Enter the Password:";
    public static ValidatorStates EncryptorValidator { get; set; } = ValidatorStates.EMPTY;
    public static bool IsEncryptionComplete { get; set; } = false;
    public static bool IsEncryptionInitiated { get; set; } = false;
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