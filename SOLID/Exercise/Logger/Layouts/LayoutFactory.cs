namespace Logger.Layouts
{
    using System;
    using Layouts.Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            if (type.ToLower() == "simplelayout")
            {
                return new SimpleLayout();
            }
            else if (type.ToLower() == "xmllayout")
            {
                return new XmlLayout();
            }
            else
            {
                throw new ArgumentException("invalid layout!");
            }
        }
    }
}
