namespace BattleShipsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleShipsGame game = new BattleShipsGame(10);
            Console.WriteLine(game.Shoot(0, 0));
            Console.WriteLine(game.Shoot(1, 1));
            Console.WriteLine(game.Shoot(1, 3));
            Console.WriteLine(game.Shoot(1, 2));
            Console.WriteLine(game.Shoot(0, 1));
            Console.WriteLine(game.Shoot(0, 2));
            Console.WriteLine(game.Shoot(0, 3));
        }
    }

    // a class for a ship

    public class Ship
    {
        public List<(int, int)> Coordinates { get; set; }
        public int Hits { get; set; } = 0;

        public Ship(List<(int, int)> coordinates)
        {
            Coordinates = coordinates;
        }

        public bool IsSunk()
        {
            return Hits >= Coordinates.Count;
        }

    }
    public class BattleShipsGame
    {

        // create battlefield 100x100
        private readonly int _boardSize;

        private string[][] _battleField;

        private List<Ship> _ships = new List<Ship>();

        // a method to Initialize the board 

        private void InitializeBoard()
        {
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    _battleField[i] = new string[_boardSize];
                    _battleField[i][j] = "water";
                }
            }
        }

        // a method to place ships on the board

        private void PlaceShips()
        {
            Ship ship1 = new Ship(new List<(int, int)> { (0, 0), (0, 1), (0, 2) });
            Ship ship2 = new Ship(new List<(int, int)> { (2, 2), (3, 2), (4, 2) });
            _ships.Add(ship1);
            _ships.Add(ship2);

            foreach (Ship ship in _ships)
            {
                foreach (var (x, y) in ship.Coordinates)
                {
                    _battleField[x][y] = "ship";
                }
            }

        }

        public BattleShipsGame(int boardSize)
        {
            _boardSize = boardSize;
            _battleField = new string[_boardSize][];
            InitializeBoard();
            PlaceShips();
        }


        // method shoot to simulate the game. It return "missed", "hit", "sunk", "shot"

        public string Shoot(int x, int y)
        {

            // if the input coordinates are beyond the board - return message
            if (x < 0 || x > _boardSize || y < 0 || y > _boardSize)
            {
                return "The coordinates are not valid.";
            }
            string cell = _battleField[x][y];

            if (cell == "hit" || cell == "sunk")
            {
                return "already hit";

            }
            else if (cell == "ship")
            {
                _battleField[x][y] = "hit";
                Ship? shipHit = null;
                // check each ship in the ships 
                foreach (Ship ship in _ships)
                {
                    // if the input coordinates belong to this ship - update the Hits' count
                    if (ship.Coordinates.Contains((x, y)))
                    {
                        ship.Hits++;
                        shipHit = ship;
                        break;
                    }

                }
                // if the IsSunk is true - update all cells belong to the ship and mark them "sunk"
                if (shipHit is not null && shipHit.IsSunk())
                {
                    foreach (var (xC, yC) in shipHit.Coordinates)
                    {
                        _battleField[xC][yC] = "sunk";
                    }

                    return "sunk";
                }
                return "hit";
            }
            return "miss";

        }
    }
}
