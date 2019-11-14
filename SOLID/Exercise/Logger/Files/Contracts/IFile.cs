namespace Logger.Files.Contracts
{
    public interface IFile
    {
        int Size { get; }

        void Write(string message);
    }
}
