namespace Sneaking.RoomObjects
{
    using System.Text;

    public class Room
    {
        public Room(char[][] field)
        {
            this.Field = field;
        }

        public char [][] Field { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int row = 0; row < this.Field.Length; row++)
            {
                for (int col = 0; col < this.Field[row].Length; col++)
                {
                    output.Append((this.Field[row][col]).ToString());
                }
                output.AppendLine();
            }

            return output.ToString(); 
        }
    }
}
