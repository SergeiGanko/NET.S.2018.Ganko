namespace Task5.Solution
{
    public abstract class DocumentPartVisitor
    {
        public void DynamicVisit(DocumentPart part) 
            => Visit((dynamic)part);

        public abstract string Visit(PlainText part);

        public abstract string Visit(Hyperlink part);

        public abstract string Visit(BoldText part);
    }
}
