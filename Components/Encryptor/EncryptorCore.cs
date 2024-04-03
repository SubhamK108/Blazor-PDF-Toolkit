namespace Blazor.PDF.Toolkit.Components.Encryptor;

public class EncryptorCore
{
    public static void EncryptPdf()
    {
        using MemoryStream stream = new();
        byte[] password = Encoding.UTF8.GetBytes(Encryptor.Password);
        WriterProperties writerProperties = new();
        writerProperties.SetStandardEncryption(
            password,
            password,
            EncryptionConstants.ALLOW_PRINTING | EncryptionConstants.ALLOW_MODIFY_ANNOTATIONS | EncryptionConstants.ALLOW_MODIFY_CONTENTS,
            EncryptionConstants.ENCRYPTION_AES_256 | EncryptionConstants.DO_NOT_ENCRYPT_METADATA
        );
        PdfWriter pdfWriter = new(stream, writerProperties);
        PdfReader pdfReader = new(new MemoryStream(Encryptor.UploadedFile!.Content!));
        PdfDocument pdfDocument = new(pdfReader, pdfWriter);

        pdfDocument.Close();
        pdfReader.Close();
        pdfWriter.Close();

        string fileName = Encryptor.UploadedFile!.FileName!;
        Core.Core.FinalPdfFilename = $"{fileName[..(fileName.Length - 4)]} (Encrypted)";
        Core.Core.FinalPdfUrl = $"data:application/pdf;base64,{Convert.ToBase64String(stream.ToArray())}";
    }

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