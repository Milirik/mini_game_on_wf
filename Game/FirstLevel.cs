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
    public partial class FirstLevel : Form
    {
        Random rnd = new Random();
        private string name;
        string secret_massage;
        private int move_x, move_y = 0;
        Person person;
        public main m = null;
        public int curr = 0;
        List<Enemy> enemies = new List<Enemy>();
        List<Monet> monets = new List<Monet>();
        List<Monet> monets2 = new List<Monet>();
        int k_m = 3;

        public FirstLevel(string name, main m, string lvl)
        {
            this.name = name;
            this.m = m;
            person = new Person(this, name);

            int k_e = 10;
            if (lvl == "2")
            {
                k_e = 15;
            }
            else if (lvl == "3") {
                k_e = 20;
            }
            else if (lvl == "4")
            {
                k_e = 30;
                k_m = 8;
            }

            for (int i = 0; i < k_e; i++) {
                Button b = new Button();
                Enemy a = new Enemy(this, b, rnd.Next(35, 100), rnd.Next(100, 700), rnd.Next(100, 700));
                Controls.Add(b);
                enemies.Add(a);
            }

            for (int i = 0; i < k_m; i++)
            {
                Button b1 = new Button();
                Monet a = new Monet(this, b1, rnd.Next(200, 600), rnd.Next(200, 600));
                Controls.Add(b1);
                monets.Add(a);
            }

            InitializeComponent();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(move);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(FirstLevel_KeyDown);
        }

        private void move(object sender, EventArgs e)
        {
            if (person.person_vkl.Location.X > 745 || person.person_vkl.Location.Y > 717 || person.person_vkl.Location.X < 13 || person.person_vkl.Location.Y < 15)
            {
                move_x = 0;
                move_y = 0;
                timer1.Stop();
                MessageBox.Show("Game Over");
                this.Close();
            }
            if (person.person_vkl.Location.X > 660 && person.person_vkl.Location.Y > 660 )
            {
                move_x = 0;
                move_y = 0;
                timer1.Stop();
                if (label3.Text == "8")
                    secret_massage = "Уважение тебе за прохождение самого сложного уровня!";
                MessageBox.Show(String.Format("GG WP! Собрано монет:{0}", label3.Text + secret_massage),"Congratulations!");
               
                this.Close();
            }

            foreach (Enemy ei in enemies)
            {
     
                int a_x = ei.dang_coord_x1;
                int a_y = ei.dang_coord_y1;
                int a_x1 = ei.dang_coord_x2;
                int a_y1 = ei.dang_coord_y2;

                int b_x = person.person_vkl.Location.X;
                int b_y = person.person_vkl.Location.Y;
                int b_x1 = person.person_vkl.Location.X + 30;
                int b_y1 = person.person_vkl.Location.Y + 30;
                
                if (!((a_y > b_y1) || (a_y1 < b_y) || (a_x1 < b_x) || (a_x > b_x1)))
                {
                    move_x = 0;
                    move_y = 0;
                    timer1.Stop();
                    MessageBox.Show("Game Over");
                    this.Close();
                }
            }

            foreach (Monet m in monets) {
                int b_x = person.person_vkl.Location.X;
                int b_y = person.person_vkl.Location.Y;
                int b_x1 = person.person_vkl.Location.X + 30;
                int b_y1 = person.person_vkl.Location.Y + 30;

                if (!((m.dy1 > b_y1) || (m.dy2 < b_y) || (m.dx2 < b_x) || (m.dx1 > b_x1)))
                {
                    m.b.Visible = false;
                }
                monets2 = new List<Monet>(monets);
            }

            foreach (Monet m in monets2)
            {
                if (m.b.Visible == false)
                { monets.Remove(m); }
            }

            label3.Text = (k_m - monets.Count).ToString();
            person.person_vkl.Location = new Point(person.person_vkl.Location.X + move_x, person.person_vkl.Location.Y + move_y);
            foreach (Enemy ei in enemies) { ei.new_Location(rnd.Next(-ei.m_speed, ei.m_speed)); }
        }

        private void FirstLevel_FormClosing(object sender, FormClosingEventArgs e)
        { m.Show(); }

        private void FirstLevel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "W":
                    move_x = 0;
                    move_y = -3;
                    break;
                case "A":
                    move_x = -3;
                    move_y = 0;
                    break;
                case "S":
                    move_x = 0;
                    move_y = 3;
                    break;
                case "D":
                    move_x = 3;
                    move_y = 0;
                    break;
            }
        }

    }
}
