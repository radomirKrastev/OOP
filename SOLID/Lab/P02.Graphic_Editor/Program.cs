namespace P02.Graphic_Editor
{
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var shapes = new List<IShape>();

            shapes.Add(new Circle());
            shapes.Add(new Square());
            shapes.Add(new Rectangle());
            shapes.Add(new Pyramid());

            var graphicEditor = new GraphicEditor();

            foreach (var shape in shapes)
            {
                graphicEditor.DrawShape(shape);
            }
        }
    }
}
