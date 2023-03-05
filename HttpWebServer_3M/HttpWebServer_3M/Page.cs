using System;
namespace HttpWebServer_3M
{
    // 😎😎😎😎😎😎😎😎😎
    public static class Page
    {
        private const string header = "<html>" +
            "<head><meta charset=utf-8></head>" +
            "<body>";

        private const string footer = "</body></html>";

        public const string Index = header +
            "<h1><strong>Main MATH Page&nbsp;</strong>➕</h1>" +
            "<p>Добро пожаловать на самый математический сайт в мире!&nbsp;😎</p>" +
            "<p>Тут вы сможете складывать числа!&nbsp;😍</p>" +
            footer;

        public const string Error = header +
            "<h1>ERROR</h1>" + footer;

        public const string Info = header + 
            "<h1>INFO</h1>" + footer;

        public static string Math = header + "Что-то пошло не так..." + footer;

        public static string Input = header +
            "<form action=\"math\">" +
            "<label>A: </label>" +
            "<input type=\"text\" name=\"a\"><br>" +
            "<label>B: </label>" +
            "<input type=\"text\" name=\"b\"> <br><br>" +
            "<input type=\"submit\">" +
            "</form>" +
            footer;


        public static string MathTemplate = header +
            "<h1>MATH</h1>" +
            "<h2>{a} + {b} = {sum}</h2>"
            + footer;
    }
}

