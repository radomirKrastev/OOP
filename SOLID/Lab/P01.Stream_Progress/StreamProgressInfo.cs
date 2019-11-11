namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IFileType fileType;

        public StreamProgressInfo(IFileType file)
        {
            this.fileType = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.fileType.BytesSent * 100) / this.fileType.Length;
        }
    }
}
