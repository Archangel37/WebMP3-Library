using System.Text.RegularExpressions;

namespace WebMP3.FilesWorkers
{
    public static class LinkCreator
    {
        public static string CreateLinkToVideoSearch(string Authors, string Title)
        {
            if (string.IsNullOrWhiteSpace(Authors) || string.IsNullOrWhiteSpace(Title)) return null;
            string temp = (Authors + " - " + Title).Trim().Replace(',',' ');
            temp = Regex.Replace(temp, "\\s+", "+");
            temp = Regex.Replace(temp, "&", "%26");

            return @"https://www.google.ru/search?q=" + temp + @"&newwindow=1&source=lnms&tbm=vid";
        }
    }
}