using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class Food
    {

        public ConsoleColor color;
        public char sign;
        public Point loc;
        public Food()
        {
            color = ConsoleColor.Red;
            sign = '0';
        }
        public void A()
        {
            StreamWriter sw = new StreamWriter("food.xml", false);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            xs.Serialize(sw, this);
            sw.Close();
        }
        public Food B()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            FileStream fs = new FileStream("food.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Food food = xs.Deserialize(fs) as Food;
            fs.Close();
            return food;
        }
        public void SetRandomPosition(Wall wall, snake snake)
        {
            int x = new Random().Next(1, 25);
            int y = new Random().Next(1, 25);
            while (Checking(wall, snake, x, y))
            {
                x = new Random().Next(1, 25);
                y = new Random().Next(1, 25);
            }
            loc = (new Point(x, y));
        }
        public bool Checking(Wall wall, snake snake, int x, int y)
        {

            for (int i = 0; i < wall.format.Count; i++)
            {
                for (int j = 0; j < snake.body.Count; j++)
                {
                    if ((snake.body[j].x == x && snake.body[j].y == y) || (wall.format[i].x == x && wall.format[i].y == y))
                        return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(loc.x, loc.y);
            Console.Write(sign);
        }
    }
}
