namespace P01.Stream_Progress
{
    public interface IFileType
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
