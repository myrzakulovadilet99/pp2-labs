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
    public class snake
    {
        public List<Point> body;
        string sign ;
        public int cnt;
      
        public snake()
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
            sign = "@";
            cnt = 0;
        }
        public void A()
        {
            StreamWriter sw = new StreamWriter("snake.xml", false);
            XmlSerializer xs = new XmlSerializer(typeof(snake));
            xs.Serialize(sw, this);
            sw.Close();
        }
        public snake B()
        {
            XmlSerializer xs = new XmlSerializer(typeof(snake));
            FileStream fs = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            snake snake = xs.Deserialize(fs) as snake;
            fs.Close();
            return snake;
        }

        public void Move(int dx, int dy)
        {
             int xx = body[0].x + dx;
            int yy = body[0].y + dy;
            if (body.Count > 1)
            {
                if (xx == body[1].x && yy == body[1].y)
                    return;
            }
            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.WriteLine(" ");
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;
            if (body[0].x < 0)
                body[0].x = Console.WindowWidth - 1;
            if (body[0].x > Console.WindowWidth - 1)
                body[0].x = 0;
            if (body[0].y < 0)
                body[0].y = Console.WindowHeight - 1;
            if (body[0].y > Console.WindowHeight - 1)
                body[0].y = 0;
        }
        public bool CollisionWithWall(snake snake, Wall wall)
        {
            for (int i = 1; i < snake.body.Count; i++)
            {
                for (int j = 0; j < wall.format.Count; j++)
                {
                    if ((snake.body[0].x == snake.body[i].x && snake.body[0].y == snake.body[i].y) || (snake.body[0].x == wall.format[j].x && snake.body[0].y == wall.format[j].y))
                        return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            int index = 0;
            foreach (Point p in body)
            {
                if (index == 0)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                index++;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
        public void FinalWrite()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            StreamReader sr = new StreamReader(@"C:\Users\Lenovo\source\repos\Snake\Final.txt");
            Console.WriteLine("Игрок" + sr.ReadLine() + "\nсчет " + sr.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            sr.Close();
            Console.WriteLine("Пожалуйста, укажите свое имя");
        }
        public void Save(string username, int cnt)
        {
            Console.Clear();
            Console.WriteLine("!!!КОНЕЦ ИГРЫ!!!");
            StreamReader ssr = new StreamReader(@"C:\Users\Lenovo\source\repos\Snake\Final.txt");
            string name = ssr.ReadLine();
            int oldRecord = int.Parse(ssr.ReadLine());
            ssr.Close();
            if (cnt > oldRecord)
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\Lenovo\source\repos\Snake\Final.txt");
                sw.Write(username);
                sw.WriteLine();
                sw.Write(cnt);
                sw.Close();
            }
            Console.ReadKey();
        }
       
       

    }
}
