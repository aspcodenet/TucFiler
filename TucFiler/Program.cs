using System.Threading.Channels;

var app = new App();
app.Run();


public class Player
{
    public string Name { get; set; }
    public int Jersey { get; set; }
    public string Team { get; set; }

}

public class App
{
    //OBS! Vill ni köra Json (allra BÄSTA = vanligast)
    // eller CsvHelper så ÄR DET OK SÅKLART!!
    //Nu visar jag en hemmasnickrad lösning


    //1. VAR ÄR FIL J-VELN??? - sökvägar osv
    
    public List<Player> InitializeFromFile()
    {
        return new List<Player>();
    }
    private void SaveAllToFile(List<Player> list)
    {
        var strings = new List<string>();
        foreach (var player in list)
        {
            strings.Add(player.Name +"," + player.Jersey + "," + player.Team);
        }
        File.WriteAllLines("players.txt", strings);
    }
    public void Run()
    {
        var list = InitializeFromFile();
        while (true)
        {
            Console.WriteLine("1. Skapa spelare");
            Console.WriteLine("2. Lista spelare");
            Console.WriteLine("3. Exit");
            Console.Write("Action:");
            string sel = Console.ReadLine();
            if (sel == "1")
            {
                Console.WriteLine("*** SKAPA NY SPELARE ***");
                Console.Write("Ange namn:");
                string namn = Console.ReadLine();
                Console.Write("Ange jersey:");
                int jersey = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ange team:");
                string team = Console.ReadLine();

                list.Add(new Player { Jersey = jersey, 
                    Name = namn, 
                    Team = team});
            }
            if (sel == "2")
            {
                foreach (var p in list)
                    Console.WriteLine($"{p.Name} {p.Jersey}");
            }
            if(sel == "3")
               break;
        }

         
        //Vid ändring - alt innan vi slutar
        SaveAllToFile(list);

    }

 
}
