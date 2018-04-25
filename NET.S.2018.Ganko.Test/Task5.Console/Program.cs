namespace Task5.Console
{
    using System.Collections.Generic;
    using System;
    using Task5.Solution;

    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>
                {
                    new PlainText {Text = "Some plain text"},
                    new Hyperlink {Text = "google.com", Url = "https://www.google.by/"},
                    new BoldText {Text = "Some bold text"}
                };

            Document document = new Document(parts);

            Console.WriteLine(document.ConvertToHtml());

            Console.WriteLine(document.ConvertToPlainText());

            Console.WriteLine(document.ConvertToLaTex());
        }
    }
}
