using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Enemy
    {
        Random rnd = new Random();
        Button b;
        public int speed_x;
        public int speed_y;
        public int m_speed = 1;
        public int dang_coord_x1;
        public int dang_coord_y1;
        public int dang_coord_x2;
        public int dang_coord_y2;

        public Enemy(FirstLevel f1, Button b, int size, int x, int y)
        {
            this.b = b;
            b.Size = new Size(size, size);
            b.Location = new Point(x, y);
            b.BackColor = Color.Red;
            dang_coord_x1 = x;
            dang_coord_y1 = y;
            dang_coord_x2 = x + size;
            dang_coord_y2 = y + size;

            if (x%2==0) speed_x = m_speed;
            else if (x%3==0) speed_x = -m_speed;
            else speed_x = 0;

            if (y % 2 == 0) speed_y = m_speed;
            else if (y % 3 == 0) speed_y = -m_speed;
            else speed_y = 0;

            while (speed_x == 0 && speed_y == 0)
            {
                speed_x = rnd.Next(-m_speed, m_speed);
                speed_y = rnd.Next(-m_speed, m_speed);
            }
        }
        public void new_Location(int rnd) {
            if (b.Location.X == 735)
            {
                speed_x = -speed_x;
                speed_y = rnd;
            }
            if (b.Location.X == 20)
            {
                speed_x = -speed_x;
                speed_y = rnd;
            }
            if (b.Location.Y == 700)
            {
                speed_x = rnd;
                speed_y = -speed_y;
            }
            if (b.Location.Y == 20)
            {
                speed_x = rnd; 
                speed_y = -speed_y;
            }
            dang_coord_x1 += speed_x;
            dang_coord_y1 += speed_y;
            dang_coord_x2 += speed_x;
            dang_coord_y2 += speed_y;
            b.Location = new Point(b.Location.X + speed_x, b.Location.Y + speed_y);
        }
    }
   

    class Monet {
        public int dx1, dx2, dy1, dy2;
        public Button b;

        public Monet(FirstLevel f1, Button b, int x, int y) {

            this.b = b;
            b.Location = new System.Drawing.Point(x, y);
            b.Size = new Size(30, 30);
            b.BackColor = Color.Yellow;

            dx1 = x;
            dy1 = y;
            dx2 = x + 30;
            dy2 = y + 30;
        }
    }


    class Person
    {
        public Button person_vkl = new Button();

        public Person(FirstLevel f1, string name)
        {
            person_vkl.Location = new System.Drawing.Point(50, 50);
            person_vkl.Size = new System.Drawing.Size(30, 30);
            person_vkl.Text = name;
            f1.Controls.Add(person_vkl);
        }
    }
}
