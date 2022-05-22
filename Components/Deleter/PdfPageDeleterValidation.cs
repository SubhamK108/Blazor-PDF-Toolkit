using System;
using System.Text.RegularExpressions;
using static Components.Deleter.PdfPageDeleter;


namespace Components.Deleter
{
    class PdfPageDeleterValidation
    {
        public static bool ValidatePageNumber(string pageno)
        {
            if ((! Regex.IsMatch(pageno, @"^([1-9]+)$")) && (! Regex.IsMatch(pageno, @"^([1-9]{1})([0-9]*)\-([0-9]+)$")))
            {
                PageValidationErrorMessage = "Invalid Page Number Format!  ❌";
                return false;
            }

            else if (! pageno.Contains('-'))
            {
                if (Convert.ToInt32(pageno) > TotalPages)
                {
                    PageValidationErrorMessage = $"Invalid Page Number! There are only {TotalPages} pages.  ❌";
                    return false;
                }
                else
                {
                    return true;
                }
            }

            else if (pageno.Contains('-'))
            {
                if (Convert.ToInt32(pageno.Split('-')[0]) > TotalPages || Convert.ToInt32(pageno.Split('-')[1]) > TotalPages)
                {
                    PageValidationErrorMessage = $"Invalid Page Number Range! There are only {TotalPages} pages.  ❌";
                    return false;
                }
                else if (Convert.ToInt32(pageno.Split('-')[1]) - Convert.ToInt32(pageno.Split('-')[0]) + 1 > TotalPages)
                {
                    PageValidationErrorMessage = $"Invalid Page Number Range! There are only {TotalPages} pages.  ❌";
                    return false;
                }
                else if (Convert.ToInt32(pageno.Split('-')[1]) - Convert.ToInt32(pageno.Split('-')[0]) + 1 == TotalPages)
                {
                    PageValidationErrorMessage = $"Invalid Page Number Range! There must be at least 1 page left in the PDF after the deletion process.  ❌";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            else
            {
                return true;
            }
        }
    }
}