namespace Task5.Solution
{
    public class ConvertToHtmlVisitor : DocumentPartVisitor
    {
        public string Line { get; private set; }

        public override string Visit(PlainText part) 
            => Line += part.Text;

        public override string Visit(Hyperlink part) 
            => Line += "<a href=\"" + part.Url + "\">" + part.Text + "</a>";

        public override string Visit(BoldText part) 
            => Line += "<b>" + part.Text + "</b>";
    }
}
