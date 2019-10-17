namespace Sneaking.RoomObjects
{
    public class Enemy
    {
        public void MoveLeft(Room room, int row, int col)
        {
            if (row >= 0 && row < room.Field.Length && col - 1 >= 0 && col - 1 < room.Field[row].Length)
            {
                room.Field[row][col] = '.';
                room.Field[row][col - 1] = 'd';
            }
            else
            {
                room.Field[row][col] = 'b';
            }
        }

        public void MoveRight(Room room, int row, int col)
        {
            if (row >= 0 && row < room.Field.Length && col + 1 >= 0 && col + 1 < room.Field[row].Length)
            {
                room.Field[row][col] = '.';
                room.Field[row][col + 1] = 'b';
            }
            else
            {
                room.Field[row][col] = 'd';
            }
        }
    }
}
