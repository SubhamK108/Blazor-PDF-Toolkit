namespace Blazor.PDF.Toolkit.Components.PageDeleter;

using PageDeleterValidatorResult = (PageDeleter.ValidatorStates, int, string);

public class PageDeleterValidator
{
    public static PageDeleterValidatorResult ValidatePagesToDelete(string pagesToDelete, int totalPages)
    {
        const string REGEX1 = @"^([1-9])(\d*)$"; // RegEx for a Single Number
        const string REGEX2 = @"^([1-9])((\,(([1-9])(\d*)))+)$"; // RegEx for Multiple Numbers Separated by ','
        const string REGEX3 = @"^(([1-9])(\d*))\-(([1-9])(\d*))$"; // RegEx for a Range (2 Numbers Separated by a '-')
        int validPagesToDelete = 0;
        string validatorResultInfo = "";
        PageDeleter.ValidatorStates validatorState = PageDeleter.ValidatorStates.CHECKING;

        if (!Regex.IsMatch(pagesToDelete, REGEX1) && !Regex.IsMatch(pagesToDelete, REGEX2) && !Regex.IsMatch(pagesToDelete, REGEX3))
        {
            validatorResultInfo = "Invalid Format! ❌";
            validatorState = PageDeleter.ValidatorStates.INVALID;
            return (validatorState, validPagesToDelete, validatorResultInfo);
        }

        if (pagesToDelete.Contains(","))
        {
            List<int> pageNumbersToDelete = [];

            foreach (string pageNumber in pagesToDelete.Split(","))
            {
                int currentPageNum = Convert.ToInt32(pageNumber);
                if (currentPageNum < 0 || currentPageNum > totalPages)
                {
                    validatorResultInfo = $"'{currentPageNum}' - Invalid Page Number! Page number must be between 1 & {totalPages}. ❌";
                    validatorState = PageDeleter.ValidatorStates.INVALID;
                    return (validatorState, validPagesToDelete, validatorResultInfo);
                }

                if (!pageNumbersToDelete.Contains(currentPageNum))
                {
                    pageNumbersToDelete.Add(currentPageNum);
                }

                if (pageNumbersToDelete.Count == totalPages)
                {
                    validatorResultInfo = "Invalid! You can't delete all the pages. ❌";
                    validatorState = PageDeleter.ValidatorStates.INVALID;
                    return (validatorState, validPagesToDelete, validatorResultInfo);
                }
            }

            validPagesToDelete = pageNumbersToDelete.Count;
            validatorResultInfo = $"{validPagesToDelete} pages will be deleted. ✅";
            validatorState = PageDeleter.ValidatorStates.VALID;
            return (validatorState, validPagesToDelete, validatorResultInfo);
        }

        if (pagesToDelete.Contains("-"))
        {
            int firstNumber = Convert.ToInt32(pagesToDelete.Split("-")[0]);
            int secondNumber = Convert.ToInt32(pagesToDelete.Split("-")[1]);

            if (firstNumber > secondNumber)
            {
                (firstNumber, secondNumber) = (secondNumber, firstNumber);
            }

            if (firstNumber > totalPages || secondNumber > totalPages || secondNumber - firstNumber + 1 > totalPages)
            {
                validatorResultInfo = $"Invalid Page Number Range! There are only {totalPages} pages. ❌";
                validatorState = PageDeleter.ValidatorStates.INVALID;
            }
            else if (secondNumber - firstNumber + 1 == totalPages)
            {
                validatorResultInfo = "Invalid Page Number Range! You can't delete all the pages. ❌";
                validatorState = PageDeleter.ValidatorStates.INVALID;
            }
            else
            {
                validPagesToDelete = secondNumber - firstNumber + 1;
                validatorResultInfo = $"{validPagesToDelete} pages will be deleted. ✅";
                validatorState = PageDeleter.ValidatorStates.VALID;
            }

            return (validatorState, validPagesToDelete, validatorResultInfo);
        }

        if (Convert.ToInt32(pagesToDelete) > totalPages)
        {
            validatorResultInfo = $"Invalid Page Number! There are only {totalPages} pages. ❌";
            validatorState = PageDeleter.ValidatorStates.INVALID;
        }
        else
        {
            validPagesToDelete = 1;
            validatorResultInfo = "1 page will be deleted. ✅";
            validatorState = PageDeleter.ValidatorStates.VALID;
        }

        return (validatorState, validPagesToDelete, validatorResultInfo);
    }
}