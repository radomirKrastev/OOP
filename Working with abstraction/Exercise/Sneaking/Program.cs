namespace Sneaking
{
    using System;
    using RoomObjects;

    class Sneaking
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var room = CreateRoom(rows);
            var heroSam = InitializeSam(room);

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies(room);

                var samRow = heroSam.Position[0];
                var samCol = heroSam.Position[1];

                var enemyOnSamRow = GetEnemy(samRow,samCol,room);
                var enemyRow = enemyOnSamRow[0];
                var enemyCol = enemyOnSamRow[1];
                var isEnemyDangerous = GetEnemyStatus(room, samRow, samCol, enemyRow, enemyCol);
                
                if (isEnemyDangerous)
                {
                    Console.WriteLine(heroSam.Die(room));
                    Console.WriteLine(room.ToString());
                    break;
                }
                else if (isEnemyDangerous)
                {
                    Console.WriteLine(heroSam.Die(room));
                    Console.WriteLine(room.ToString());
                    break;
                }

                heroSam.Move(room, moves[i]);
                samRow = heroSam.Position[0];
                samCol = heroSam.Position[1];

                enemyOnSamRow = GetEnemy(samRow, samCol, room);
                enemyRow = enemyOnSamRow[0];
                enemyCol = enemyOnSamRow[1];

                if (room.Field[enemyRow][enemyCol] == 'N' && samRow == enemyOnSamRow[0])
                {
                    room.Field[enemyRow][enemyCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    Console.WriteLine(room.ToString());
                    break;
                }
            }
        }

        private static bool GetEnemyStatus(Room room,int samRow, int samCol, int enemyRow, int enemyCol )
        {
            var isEnemyDangerous = samCol < enemyCol && room.Field[enemyRow][enemyCol] == 'd' && enemyRow == samRow;
            var isEnemyThreat = enemyCol < samCol && room.Field[enemyRow][enemyCol] == 'b' && enemyRow == samRow;

            if(isEnemyDangerous || isEnemyThreat)
            {
                return true;
            }

            return false;            
        }

        private static int [] GetEnemy(int samRow, int samCol, Room room)
        {
            int[] getEnemy = new int[2];
            for (int j = 0; j < room.Field[samRow].Length; j++)
            {
                if (room.Field[samRow][j] != '.' && room.Field[samRow][j] != 'S')
                {
                    getEnemy[0] = samRow;
                    getEnemy[1] = j;
                }
            }

            return getEnemy;
        }
        
        private static void MoveEnemies(Room room)
        {
            for (int row = 0; row < room.Field.Length; row++)
            {
                for (int col = 0; col < room.Field[row].Length; col++)
                {
                    if (room.Field[row][col] == 'b')
                    {
                        var enemy = new Enemy();
                        enemy.MoveRight(room, row, col);
                        col++;
                    }
                    else if(room.Field[row][col] == 'd')
                    {
                        var enemy = new Enemy();
                        enemy.MoveLeft(room, row, col);
                    }                    
                }
            }           
        }

        private static Sam InitializeSam(Room room)
        {
            var sam = new Sam();

            for (int row = 0; row < room.Field.Length; row++)
            {
                for (int col = 0; col < room.Field[row].Length; col++)
                {
                    if (room.Field[row][col] == 'S')
                    {
                        sam = new Sam(row, col);
                    }
                }
            }

            return sam;
        }

        private static Room CreateRoom(int rows)
        {
            var field = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                field[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    field[row][col] = input[col];
                }
            }

            return new Room(field);
        }
    }
}
