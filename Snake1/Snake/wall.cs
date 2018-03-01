using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace Snake
{
    [Serializable]
    public class Wall
    {
        public List<Point> format;
        public string sgn;
        public int cnt;
        public void A()
        {
            StreamWriter sw = new StreamWriter("wall.xml", false);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            xs.Serialize(sw, this);
            sw.Close();
        }
        public Wall B()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Wall));
            FileStream fs = new FileStream("wall.xml", FileMode.Open, FileAccess.Read);
            Wall wall = xs.Deserialize(fs) as Wall;
            fs.Close();
            return wall;
        }
        public void ReadLevel()
        {
            StreamReader sw = new StreamReader(@"C:\Users\Lenovo\source\repos\Snake\" + cnt + ".txt");
            format = new List<Point>();
            int mani = int.Parse(sw.ReadLine());
            for (int i = 0; i < mani; i++)
            {
                string line = sw.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {

                    if (line[j] == '*')
                    {
                        format.Add(new Point(j, i));
                    }
                }
            }
            sw.Close();
        }
        public Wall()
        {
            sgn = "o";
            format = new List<Point>();
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Point p in format)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.WriteLine(sgn);
            }

        }
        public void Level(Wall wall, snake snake)
        {
            if (snake.body.Count == 4)
            {
                Console.Clear();
                wall.cnt++;
                wall.ReadLevel();
                int a = 1;
                for (int i = 0; i < snake.body.Count; i++)
                {
                    snake.body[i].x = a;
                    snake.body[i].y = 10;
                    a++;
                }
            }
            if (snake.body.Count == 8)
            {

                Console.Clear();
                wall.cnt++;
                wall.ReadLevel();
                int b = 1;
                for (int i = 0; i < snake.body.Count; i++)
                {
                    snake.body[i].x = b;
                    snake.body[i].y = 10;
                    b++;
                }
            }
        }
    }
}