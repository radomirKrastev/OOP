namespace JediGalaxy
{
    public class Ivo
    {
        public Ivo()
        {

        }

        public int Row { get; set; }
        public int Col { get; set; }
        public long CollectedStarsValue { get; set; }


        public void Move(int [,] galaxyMatrix, int rows, int cols)
        {
            var positionValidator = new PositionValidator();
            
            while (Row >= 0 && Col < galaxyMatrix.GetLength(1))
            {

                if (positionValidator.Validate(Row,Col,rows,cols))
                {
                    CollectedStarsValue += galaxyMatrix[Row, Col];
                }

                Col++;
                Row--;
            }
        }
    }
}
