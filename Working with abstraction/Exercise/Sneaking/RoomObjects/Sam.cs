namespace Sneaking.RoomObjects
{
    public class Sam
    {
        public Sam()
        {

        }

        public Sam(int row, int col)
        {
            this.Position = new int[2] { row, col };
        }

        public int[] Position { get; private set; }

        public void Move(Room room,char move)
        {
            room.Field[this.Position[0]][this.Position[1]] = '.';
            switch (move)
            {
                case 'U':
                    this.Position[0]--;
                    break;
                case 'D':
                    this.Position[0]++;
                    break;
                case 'L':
                    this.Position[1]--;
                    break;
                case 'R':
                    this.Position[1]++;
                    break;
                default:
                    break;
            }
            room.Field[this.Position[0]][this.Position[1]] = 'S';
        }

        public string Die(Room room)
        {
            room.Field[this.Position[0]][this.Position[1]] = 'X';
            return $"Sam died at {this.Position[0]}, {this.Position[1]}";
        }
    }
}
