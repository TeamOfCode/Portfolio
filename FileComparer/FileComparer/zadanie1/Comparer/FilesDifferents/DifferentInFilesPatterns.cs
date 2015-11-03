namespace ClassLibrary1.zadanie1.Logic.FilesDifferents
{
    public static class DifferentInFilesPatterns
    {
        public static string LinesDetailsPattern = "plik 1: {0}\nplik 2: {1}\n\n";
        public static string OneLineEmptyPattern = "w lini {0} jeden z plików nie zawiera znaków\n";

        public static string LinesEqualsWithIgnoreCasePattern =
            "linia {0} w pierwszym pliku zawiera ten sam ciąg znaków jak linia {0}\n" +
            "w drugim pliku ale wielkość liter jest różna\n";

        public static string DifferentLinePattern =
            "linia {0} w pierwszym pliku zawiera inny ciąg znaków jak linia {0} w drugim pliku\n";
    }
}