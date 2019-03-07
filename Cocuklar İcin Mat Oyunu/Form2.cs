using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cocuklar_İcin_Mat_Oyunu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int x, b1, b2, b3, b4;
        int time = 10,level=1,skor=0;
        CheckBox[] ch;

        void _skor()
        {
            if (time <= 2)
            {
                skor += 10; label6.Text = "+10";
            }
            else if (time <= 4)
            {
                skor += 20; label6.Text = "+20";
            }
            else if (time <= 6)
            {
                skor += 30; label6.Text = "+30";
            }
            else if (time <= 8)
            {
                skor += 40; label6.Text = "+40";
            }
            else if (time <= 9)
            {
                skor += 50; label6.Text = "+50";
            }
            label5.Text = skor.ToString();
        }

        void _level()
        {          
            if (skor < 150)
            { level = 1; label8.Text = "1"; }
            else if(skor<300)
            { level = 2; label8.Text = "2"; }
            else if(skor<450)
            { level = 3; label8.Text = "3"; }
            else if(skor<600)
            { level = 4; label8.Text = "4"; }
            else if (skor < 750)
            { level = 5; label8.Text = "5"; }
        }

            void start(int min,int max)
        {
            Random s = new Random();
            x = s.Next(min, max);
            label1.Text = x.ToString();

            do
            {
                b1=s.Next(1,x-1);
                b2=s.Next(1,x-1);
                b3=s.Next(1,x-1);
                b4=s.Next(1,x-1);
    
            }while((b1+b2!=x && b1+b3!=x && b1+b4!=x && b2+b3!=x && b2+b4 !=x && b3+b4!=x) && (b1+b2+b3!=x && b1+b2+b4!=x && b1+b3+b4!=x && b2+b3+b4!=x));

            button1.Text = b1.ToString();
            button2.Text = b2.ToString();
            button3.Text = b3.ToString();
            button4.Text = b4.ToString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            ch = new CheckBox[4] {checkBox1,checkBox2,checkBox3,checkBox4};
            start(2, 20);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            answer(ch);
            _level();
            falseChecked(ch);

            switch(level)
            {
                case 1: start(1, 20); break;
                case 2: start(20, 30); break;
                case 3: start(30, 50); break;
                case 4: start(50, 60); break;
                case 5: start(60, 80); break;
            }
        }

        void BtnChecked(CheckBox ch)
        {
            if(ch.Checked)
            {
                ch.Checked = false;
            }
            else
            {
                ch.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnChecked(checkBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BtnChecked(checkBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BtnChecked(checkBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BtnChecked(checkBox4);
        }

        void answer(CheckBox [] check)
        {
            int sum = 0;
            int[] A =new int[5]{ b1 , b2 , b3 , b4 , x };

            for (int i=0 ; i<check.Length;i++)
            {
                 if(check[i].Checked)
                 {
                     sum += A[i];
                 }
                if(A[4]==sum && time!=-1)
                {
                    _skor();
                    this.BackColor = Color.Green;
                }
                else
                {
                    label6.Text = "+0";
                    this.BackColor = Color.Red;
                }
            }
        }

        void falseChecked(CheckBox[] ch)
        {
            foreach(CheckBox item in ch)
            {
                item.Checked = false;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label3.Text = time.ToString();
            if(time !=-1)
                time--;

            if(time == -1)
            {
                time = 10;
                answer(ch);
                start(2, 20);
                falseChecked(ch);
            }
        }
    }
}
