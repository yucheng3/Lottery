using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_台灣樂透
{
    public partial class Form1 : Form
    {
        bool specialball = true;
        int timerr= 0;
        int[] lottery;
        int[] number;
        Random ran= new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void 搖獎(int n,int a) 
        {

            lottery = new int[n-1]; //共39個號碼
            for (int i = 0; i <= lottery.GetUpperBound(0); i++)
            {
                lottery[i] = i + 1;
            }

            number = new int[a]; //產生陣列,放入開獎的五個號碼
            Random r = new Random();
            for (int k = 0; k <= number.GetUpperBound(0); k++) //產生五個號碼
            {

                int t = r.Next(1, n-1);
                if (lottery[t] == 0)
                {

                    k--; //如果是0表示已經用過 故重新產生.
                }
                else
                {

                    number[k] = lottery[t];
                    lottery[t] = 0;//開出的號碼設為0,以便偵測是否為重複號碼
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            timerr = 0;
            排序號碼1.Text = "";
            排序號碼2.Text = "";
            排序號碼3.Text = "";
            排序號碼4.Text = "";
            排序號碼5.Text = "";
            大樂透特別號.Text = "";
            specialball = true;
            搖獎(49, 5);

           timer1.Enabled = true;


        }

        private void btn539_Click(object sender, EventArgs e)
        {
            
            timerr = 0;
            排序號碼1.Text = "";
            排序號碼2.Text = "";
            排序號碼3.Text = "";
            排序號碼4.Text = "";
            排序號碼5.Text = "";
            大樂透特別號.Text = "";
            timer1.Enabled = true;
            specialball = false;
            搖獎(39, 5);


        }


        private void btn四星彩_Click(object sender, EventArgs e)
        {
            timerr = 0;
            timer2.Enabled = true;
   
            int[] number = new int[4];
            Random r = new Random();
            for (int k = 0; k <= number.GetUpperBound(0); k++) //產生4個碼
            {
                int t = r.Next(0, 9); // 隨機產生 範圍0~9的號碼
                number[k] = t;
            }

            四星彩千位.Text = number[0].ToString();
            四星彩百位.Text = number[1].ToString();
            四星彩十位.Text = number[2].ToString();
            四星彩個位.Text = number[3].ToString();
            
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerr++;
            if (timerr < 20)
            {
                號碼1.Text = String.Format("{0:00} ", ran.Next(1, 49));
                號碼2.Text = String.Format("{0:00} ", ran.Next(1, 49));
                號碼3.Text = String.Format("{0:00} ", ran.Next(1, 49));
                號碼4.Text = String.Format("{0:00} ", ran.Next(1, 49));
                號碼5.Text = String.Format("{0:00} ", ran.Next(1, 49));
                if (specialball)
                {
                    大樂透特別號.Text = String.Format("{0:00} ", ran.Next(1, 49));
                }
            }
            if (timerr == 20)
            {
                號碼1.Text = String.Format("{0:00} ", number[0]);
                號碼2.Text = String.Format("{0:00} ", number[1]);
                號碼3.Text = String.Format("{0:00} ", number[2]);
                號碼4.Text = String.Format("{0:00} ", number[3]);
                號碼5.Text = String.Format("{0:00} ", number[4]);

                //特別號產生
                if (specialball)
                {
                    Random aaa = new Random();
                    int special = aaa.Next(1, 49);
                    大樂透特別號.Text = String.Format("{0:00} ", special);
                }
            }

            if (timerr > 26)
            {                //小到大排序
                Array.Sort(number);
                排序號碼1.Text = String.Format("{0:00} ", number[0]);
                排序號碼2.Text = String.Format("{0:00} ", number[1]);
                排序號碼3.Text = String.Format("{0:00} ", number[2]);
                排序號碼4.Text = String.Format("{0:00} ", number[3]);
                排序號碼5.Text = String.Format("{0:00} ", number[4]);
                timer1.Enabled = false;
            }



        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timerr++;
            
            if (timerr < 20)
            {
                四星彩個位.Text = String.Format("{0:0} ", ran.Next(1, 9));
                四星彩十位.Text = String.Format("{0:0} ", ran.Next(1, 9));
                四星彩百位.Text = String.Format("{0:0} ", ran.Next(1, 9));
                四星彩千位.Text = String.Format("{0:0} ", ran.Next(1, 9));
         
            }
            if (timerr == 20)
            {
                timer2.Enabled = false;
            }

        }

    


    

    }
}
