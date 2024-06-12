using System;

namespace GemHunters
{
    
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

  
    public class Player
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }

        public void Move(char direction)
        {
            switch (direction)
            {
                case 'U': Position.Y -= 1; break;
                case 'D': Position.Y += 1; break;
                case 'L': Position.X -= 1; break;
                case 'R': Position.X += 1; break;
            }
        }
    }

    
    public class Cell
    {
        public string Occupant { get; set; }

        public Cell()
        {
            Occupant = "-";
        }
    }

    
    public class Board
    {
        public Cell[,] Grid { get; set; }

        public Board()
        {
            Grid = new Cell[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
            InitializeBoard();
        }

        private void InitializeBoard()
        {
         
            Grid[0, 0].Occupant = "P1";
            Grid[5, 5].Occupant = "P2";

           
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(6);
                    y = rand.Next(6);
                } while (Grid[x, y].Occupant != "-");
                Grid[x, y].Occupant = "G";
            }

            
            for (int i = 0; i < 5; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(6);
                    y = rand.Next(6);
                } while (Grid[x, y].Occupant != "-");
                Grid[x, y].Occupant = "O";
            }
        }

        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(Grid[i, j].Occupant + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsValidMove(Player player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

            switch (direction)
            {
                case 'U': newY -= 1; break;
                case 'D': newY += 1; break;
                case 'L': newX -= 1; break;
                case 'R': newX += 1; break;
            }

            return newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && Grid[newX, newY].Occupant != "O";
        }

        public void CollectGem(Player player)
        {
            if (Grid[player.Position.X, player.Position.Y].Occupant == "G")
            {
                player.GemCount++;
                Grid[player.Position.X, player.Position.Y].Occupant = "-";
            }
        }
    }

   
    public class Game
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentTurn { get; set; }
        public int TotalTurns { get; set; }

        public Game()
        {
            Board = new Board();
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        public void Start()
        {
            while (!IsGameOver())
            {
                Board.Display();
                Console.WriteLine($"{CurrentTurn.Name}'s turn. Enter your move (U, D, L, R):");
                char move = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (Board.IsValidMove(CurrentTurn, move))
                {
                    MovePlayer(CurrentTurn, move);
                    Board.CollectGem(CurrentTurn);
                    TotalTurns++;
                    SwitchTurn();
                }
                else
                {
                    Console.WriteLine("Invalid Move.Please Try Again.");
                }
            }

            AnnounceWinner();
        }

        private void MovePlayer(Player player, char direction)
        {
            
            Board.Grid[player.Position.X, player.Position.Y].Occupant = "-";

            player.Move(direction);

            
            Board.Grid[player.Position.X, player.Position.Y].Occupant = player.Name;
        }

        public void SwitchTurn()
        {
            CurrentTurn = CurrentTurn == Player1 ? Player2 : Player1;
        }

        public bool IsGameOver()
        {
            return TotalTurns >= 30;
        }

        public void AnnounceWinner()
        {
            if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine("P1 WINS!");
            }
            else if (Player2.GemCount > Player1.GemCount)
            {
                Console.WriteLine("P2 WINS!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
