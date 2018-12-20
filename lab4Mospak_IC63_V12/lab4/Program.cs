using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        public class Game
        {
            public int id;
            public string game;
            public string kind;
            public Game(int a, string b, string c)
            {
                this.id = a;
                this.game = b;
                this.kind = c;
            }
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; game=" + this.game + "; kind=" + this.kind + ")";
            }
        }
        public class Team
        {
            public int id;
            public string name;
            public int GameID;
            public string level;
            public Game Game { get; set; }
            public Team(int i, string n, int g, string l)
            {
                this.id = i;
                this.name = n;
                this.GameID = g;
                this.level = l;
            }
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; name=" + this.name + "; GameID=" + this.GameID.ToString() + "; level=" + this.level + ")";
            }
        }
        public class Gamers
        {
            public int id;
            public string name;
            public int TeamID;
            public string city;
            public int victories;
            public Gamers(int i, string n, int t, string c, int v)
            {
                this.id = i;
                this.name = n;
                this.TeamID = t;
                this.city = c;
                this.victories = v;
            }
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; name=" + this.name + "; TeamID=" + this.TeamID.ToString() + "; city=" + this.city + "; victories=" + this.victories + ")";
            }
        }
        static List<Game> g1 = new List<Game>()
        {
            new Game(1, "CS" , "Shooter"),
            new Game(2, "Dota", "MMO"),
            new Game(3, "Fortnite", "Survival"),
            new Game(4, "PUBG", "Survival"),
            new Game(5, "FIFA", "Simulator")
        };
        static List<Game> g2 = new List<Game>()
        {
            new Game(1, "CS" , "Shooter"),
            new Game(7,"Diablo", "Survival" ), 
            new Game(8, "Mario", "Action")
        };
        static List<Team> t1 = new List<Team>()
        {
            new Team(11, "NAVI", 1 , "high"),
            new Team(12, "VP", 1 , "low"),
            new Team(13, "KPI", 2 , "mid"),
            new Team(14, "ZNTU", 2 , "low"),
            new Team(15, "Olders", 5 , "mid"),
            new Team(16, "Teenagers", 5 , "high"),
            new Team(17, "Lovers", 3 , "high"),
            new Team(18, "Haters", 4 , "low")
        };
        static List<Gamers> gam = new List<Gamers>()
        {
            new Gamers(111, "Oleh", 17, "Kiev", 5),
            new Gamers(112, "Danil", 14, "Zaporizhzha",3),
            new Gamers(113, "Den", 11, "Kiev",6),
            new Gamers(114, "Nikita", 13, "Kiev",6),
            new Gamers(115, "Dima", 13, "Kiev",4),
            new Gamers(116, "Maks", 14, "Zaporizhzha",2),
            new Gamers(117, "Yevgen", 12, "Zaporizhzha",3),
            new Gamers(118, "Kate", 11, "Zaporizhzha",1),
            new Gamers(119, "Diana", 18, "Moscow",1),
            new Gamers(120, "Ihor", 15, "Zaporizhzha",5),
            new Gamers(121, "Natali", 15, "Zaporizhzha",4),
            new Gamers(122, "Yura", 12, "Kiev",7),
            new Gamers(123, "Fam", 16, "Kiev",2),
            new Gamers(124, "Alexandra", 16, "Zaporizhzha",0)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №4\nМосьпак Олег\nГруппа: IС-63\nВариант:12(свой:турнир по играм)");
            Console.WriteLine();
            Console.WriteLine("Перечень игр на турнире:");
            var q1 = from x in g1
                     select x;
            foreach (var x in q1)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Объединение 2 списка с общими елементами");
            foreach (var x in g1.Concat(g2))
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Название всех игр:");
            var q2 = from x in g1
                     select x.game;
            foreach (var x in q2)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Команды будут учавствовать в таких играх:");
            var q3 = from x in g1
                     join y in t1 on x.id equals y.GameID
                     select new { Team = y.name, Game = x.game };
            foreach (var x in q3)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Группировка команд по играм:");
            var q4 = from z in
                         (from x in g1
                          join y in t1 on x.id equals y.GameID
                          select new { Team = y.name, Game = x.game })
                     orderby z.Game
                     group z by z.Game;

            foreach (var x in q4)
            {
                Console.Write("{0,-10}", x.Key + ":");
                int k = 1;
                foreach (var h in x)
                {
                    if (k == 1) { Console.Write(h.Team); k++; }
                    else { Console.Write(" vs " + h.Team); k = 0; }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Сортировка игроков по раним победам:");
            var q5 = from x in gam
                     orderby x.victories descending
                     select new { x.name, x.city, x.victories };
            foreach (var x in q5)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Среднее значение побед по играм:");
            var q6 = (from x in g1
                      join y in t1 on x.id equals y.GameID
                      join z in gam on y.id equals z.TeamID
                      select new { Game = x.game, Gamers = z.name, victories = z.victories }).GroupBy(u => u.Game)
                          .Select(g => new { Game = g.Key, AvarageGamersvictories = g.Average(u => u.victories) });
            foreach (var x in q6)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Игроки из Киева будут играть в такие игры:");
            var q7 = from x in g1
                     join y in t1 on x.id equals y.GameID
                     join z in gam on y.id equals z.TeamID
                     where z.city == "Kiev"
                     select new { Game = x.game, Gamer = z.name };
            foreach (var u in q7)
                Console.WriteLine(u);
            Console.WriteLine();

            Console.WriteLine("Игры в которые играют запорожцы с использованием Distinct");
            var q8 = (from x in g1
                      join y in t1 on x.id equals y.GameID
                      join z in gam on y.id equals z.TeamID
                      where z.city == "Kiev"
                      select new { Game = x.game }).Distinct();
            foreach (var x in q8)
                Console.WriteLine(x);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}