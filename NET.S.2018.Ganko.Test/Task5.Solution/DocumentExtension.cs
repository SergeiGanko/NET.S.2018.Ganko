namespace Task5.Solution
{
    public static class DocumentExtension
    {
        public static string ConvertToPlainText(this Document doc)
        {
            var visitor = new ConvertToPlainTextVisitor();

            foreach (var part in doc.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }

        public static string ConvertToHtml(this Document doc)
        {
            var visitor = new ConvertToHtmlVisitor();

            foreach (var part in doc.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }

        public static string ConvertToLaTex(this Document doc)
        {
            var visitor = new ConvertToLaTexVisitor();

            foreach (var part in doc.Parts)
            {
                visitor.DynamicVisit(part);
            }

            return visitor.Line;
        }
    }
}
