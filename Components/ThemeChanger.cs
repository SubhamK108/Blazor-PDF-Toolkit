namespace Components
{
    class ThemeChanger
    {
        public static bool IsFirstLoad { get; set; } = true;
        public static string ThemeIcon { get; set; } = "";
        public static string MainThemeID { get; private set; } = "main";
        public static string SpecialSectionTheme { get; private set; } = "main special";
        public static string ContentSectionTheme { get; private set; } = "main";

        public static void ToggleTheme()
        {
            if (ThemeIcon == "icon solid fas fa-sun")
            {
                ThemeIcon = "icon solid fas fa-moon";
                MainThemeID = "main-light";
                SpecialSectionTheme = "main-light special";
                ContentSectionTheme = "main-light";
            }
            else
            {
                ThemeIcon = "icon solid fas fa-sun";
                MainThemeID = "main-dark";
                SpecialSectionTheme = "main-dark special";
                ContentSectionTheme = "main-dark";
            }
        }
    }
}