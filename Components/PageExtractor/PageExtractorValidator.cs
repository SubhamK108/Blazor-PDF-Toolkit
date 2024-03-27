namespace Blazor.PDF.Toolkit.Components.PageExtractor;

using PageExtractorValidatorResult = (PageExtractor.ValidatorStates, int, string);

class PageExtractorValidator
{
    public static PageExtractorValidatorResult ValidatePagesToExtract(string pagesToExtract, int totalPages)
    {
        const string REGEX1 = @"^([1-9])(\d*)$"; // RegEx for a Single Number
        const string REGEX2 = @"^([1-9])((\,(([1-9])(\d*)))+)$"; // RegEx for Multiple Numbers Separated by ','
        const string REGEX3 = @"^(([1-9])(\d*))\-(([1-9])(\d*))$"; // RegEx for a Range (2 Numbers Separated by a '-')
        int validPagesToExtract = 0;
        string validatorResultInfo = "";
        PageExtractor.ValidatorStates validatorState = PageExtractor.ValidatorStates.CHECKING;

        if (!Regex.IsMatch(pagesToExtract, REGEX1) && !Regex.IsMatch(pagesToExtract, REGEX2) && !Regex.IsMatch(pagesToExtract, REGEX3))
        {
            validatorResultInfo = "Invalid Format! ❌";
            validatorState = PageExtractor.ValidatorStates.INVALID;
            return (validatorState, validPagesToExtract, validatorResultInfo);
        }

        if (pagesToExtract.Contains(","))
        {
            List<int> pageNumbersToDelete = [];

            foreach (string pageNumber in pagesToExtract.Split(","))
            {
                int currentPageNum = Convert.ToInt32(pageNumber);
                if (currentPageNum < 0 || currentPageNum > totalPages)
                {
                    validatorResultInfo = $"'{currentPageNum}' - Invalid Page Number! Page number must be between 1 & {totalPages}. ❌";
                    validatorState = PageExtractor.ValidatorStates.INVALID;
                    return (validatorState, validPagesToExtract, validatorResultInfo);
                }

                if (!pageNumbersToDelete.Contains(currentPageNum))
                {
                    pageNumbersToDelete.Add(currentPageNum);
                }

                if (pageNumbersToDelete.Count == totalPages)
                {
                    validatorResultInfo = "Invalid! You can't extract all the pages. ❌";
                    validatorState = PageExtractor.ValidatorStates.INVALID;
                    return (validatorState, validPagesToExtract, validatorResultInfo);
                }
            }

            validPagesToExtract = pageNumbersToDelete.Count;
            validatorResultInfo = $"{validPagesToExtract} pages will be extracted. ✅";
            validatorState = PageExtractor.ValidatorStates.VALID;
            return (validatorState, validPagesToExtract, validatorResultInfo);
        }

        if (pagesToExtract.Contains("-"))
        {
            int firstNumber = Convert.ToInt32(pagesToExtract.Split("-")[0]);
            int secondNumber = Convert.ToInt32(pagesToExtract.Split("-")[1]);

            if (firstNumber > secondNumber)
            {
                (firstNumber, secondNumber) = (secondNumber, firstNumber);
            }

            if (firstNumber > totalPages || secondNumber > totalPages || secondNumber - firstNumber + 1 > totalPages)
            {
                validatorResultInfo = $"Invalid Page Number Range! There are only {totalPages} pages. ❌";
                validatorState = PageExtractor.ValidatorStates.INVALID;
            }
            else if (secondNumber - firstNumber + 1 == totalPages)
            {
                validatorResultInfo = "Invalid Page Number Range! You can't extract all the pages. ❌";
                validatorState = PageExtractor.ValidatorStates.INVALID;
            }
            else
            {
                validPagesToExtract = secondNumber - firstNumber + 1;
                validatorResultInfo = $"{validPagesToExtract} pages will be extracted. ✅";
                validatorState = PageExtractor.ValidatorStates.VALID;
            }

            return (validatorState, validPagesToExtract, validatorResultInfo);
        }

        if (Convert.ToInt32(pagesToExtract) > totalPages)
        {
            validatorResultInfo = $"Invalid Page Number! There are only {totalPages} pages. ❌";
            validatorState = PageExtractor.ValidatorStates.INVALID;
        }
        else
        {
            validPagesToExtract = 1;
            validatorResultInfo = "1 page will be extracted. ✅";
            validatorState = PageExtractor.ValidatorStates.VALID;
        }

        return (validatorState, validPagesToExtract, validatorResultInfo);
    }
}