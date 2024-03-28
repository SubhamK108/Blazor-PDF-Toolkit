namespace Blazor.PDF.Toolkit.Components.Encryptor;

class EncryptorCore
{
    public static void RefreshEncryptor()
    {
        Encryptor.UploadedFile = null;
        Encryptor.Password = "";
        Encryptor.ReTypedPassword = "";
        Encryptor.EncryptorInfo = "Re-Enter the Password:";
        Encryptor.EncryptorValidator = Encryptor.ValidatorStates.EMPTY;
        Encryptor.IsEncryptionComplete = false;
        Encryptor.IsEncryptionInitiated = false;
    }
}