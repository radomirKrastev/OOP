namespace JediGalaxy
{
    public class PositionValidator
    {
        public bool Validate(int row, int col, int rows, int cols)
        {
            var validRow = row >= 0 && row < rows;
            var validCol = col >= 0 && col < cols;

            if (validRow && validCol)
            {
                return true;
            }

            return false;
        }
    }
}
