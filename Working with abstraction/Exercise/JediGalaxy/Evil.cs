namespace JediGalaxy
{
    public class Evil
    {        
        public Evil()
        {

        }

        public int Row { get; set; }
        public int Col { get; set; }

        public void Move(int[,] galaxyMatrix, int rows, int cols)
        {
            var positionValidator = new PositionValidator();

            while (Row >= 0 && Col >= 0)
            {
                if (positionValidator.Validate(Row, Col, rows, cols))
                {
                    galaxyMatrix[Row, Col] = 0;
                }

                Row--;
                Col--;
            }
        }
    }
}
