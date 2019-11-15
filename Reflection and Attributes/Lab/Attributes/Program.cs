[Author ("Ventsi")]

public class Program
{
    [Author("Gosho")]
    public static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}