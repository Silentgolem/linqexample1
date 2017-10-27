using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    public class Player
    {
        public Guid _id { get; set; }
        public string _name { get; set; }
        public int _xp { get; set; }

        public override string ToString()
        {
            return _id.ToString() + " " + _name + " " + _xp.ToString();
        }
    }
    class Program
    {
        static List<Player> Players = new List<Player>() {
            new Player{_id=Guid.NewGuid(), _name="Joe",_xp=100 },
            new Player{_id=Guid.NewGuid(), _name="Mary",_xp=10 },
            new Player{_id=Guid.NewGuid(), _name="Tom",_xp=2000 },
            new Player{_id=Guid.NewGuid(), _name="Tom",_xp=2001 }
        };
        static void Main(string[] args)
        {
            //return the first occurunce of a match or null
            Player found = Players.FirstOrDefault(p => p._name == "Mary");
            if (found != null)
            {
                Console.WriteLine("{0}", found.ToString());
            }
            else
            {
                Console.WriteLine("Not found");
            }
            Console.WriteLine();

            //return the first occurunce of a possisbly duplicate record
            Player foundCopy = Players.FirstOrDefault(p => p._name.Contains("Tom"));
            if (foundCopy != null)
            {
                Console.WriteLine("{0}", foundCopy.ToString());
            }
            else
            {
                Console.WriteLine("Not found");
            }
            Console.WriteLine();

            //return all xp values over 100
            List<Player> topPlayers = Players.Where(plr => plr._xp >= 100).ToList();
            if (topPlayers.Count>0)
            {
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}", item.ToString());
                }

            }
            else
            {
                Console.WriteLine("Not found");
            }
            Console.WriteLine();

            //return a scoreboard
            Console.WriteLine("Scoreboard");
            var ScoreBoard = Players.OrderByDescending(p=>p._xp)
                                    .Select(scores=>new { scores._name,scores._xp });
                foreach (var item in ScoreBoard)
                {
                    Console.WriteLine("{0} {1}", item._name,item._xp);
                }
            Console.WriteLine();

            //stop at end
            Console.ReadKey();

        }

    }
}
