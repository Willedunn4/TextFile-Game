using TextFile_Game;

class Program
{
    static void Main(string[] args)
    {
        DungeonCrawlerGame game = new DungeonCrawlerGame();
        game.LoadMonsters("Stats.txt");
        game.CreateRooms();
        game.StartGame();
    }
}