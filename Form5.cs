using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kids_Quiz_Game
{
    public partial class Form5 : Form
    {
        string sValue; //= AppDomain.CurrentDomain.BaseDirectory + @"\Animals\";
        private PictureBox[] pPic = new PictureBox[201];
        private Label[] cList = new Label[18];
        int iPick,iErr;
        public string sString;
        public string sString2;
        public string sString3;
        private CheckBox[] pRB = new CheckBox[201];       
        Color[] fRB = new Color[40];
        Color[] BRB = new Color[40];
        private System.Speech.Synthesis.SpeechSynthesizer speaker = new System.Speech.Synthesis.SpeechSynthesizer();
        public Form5()           

        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            int i ;
            iErr = 0;
            label1.Text = sString;
            label2.Text = sString2;
            sValue = AppDomain.CurrentDomain.BaseDirectory + @"\";
            sValue += sString + (char)92;
            //TabPage myTabPage = new TabPage("0");
            Animal.Text = sString3;
            //TabControl1.TabPages.
            cList[1] = label3;
            cList[2] = label4;
            cList[3] = label5;
            cList[4] = label6;
            cList[5] = label7;
            cList[6] = label8;
            cList[7] = label9;
            cList[8] = label10;
            pPic[1] = pictureBox2;
            pPic[2] = pictureBox3;
            pPic[3] = pictureBox4;
            pPic[4] = pictureBox5;
            pPic[5] = pictureBox6;
            pPic[6] = pictureBox7;
            pPic[7] = pictureBox8;
            pPic[8] = pictureBox9;
            //
            // Quiz
            pPic[20] = pictureBox21;
            pPic[21] = pictureBox20;
            pPic[22] = pictureBox23;
            pPic[23] = pictureBox24;
            pPic[24] = pictureBox22;
            pPic[25] = pictureBox25;
            pRB[1] = rb01;
            pRB[2] = rb02;
            pRB[3] = rb03;
            pRB[4] = rb04;
            pRB[5] = rb05;
            pRB[6] = rb06;
            pRB[7] = rb07;
            pRB[8] = rb08;
            pRB[9] = rb09;
            pRB[10] = rb10;
            pRB[11] = rb11;
            pRB[12] = rb12;
            pRB[13] = rb13;
            pRB[14] = rb14;
            pRB[15] = rb15;
            pRB[16] = rb16;
            pRB[17] = rb17;
            pRB[18] = rb18;
            pRB[19] = rb19;
            pRB[20] = rb20;
            pRB[21] = rb21;
            pRB[22] = rb22;
            pRB[23] = rb23;
            pRB[24] = rb24;
            for (i = 1; i <= 24; i++)
            {
                
                pRB[i].Click += pRB_Click; // Click Event
                fRB[i] = pRB[i].ForeColor;
                BRB[i] = pRB[i].BackColor;
            }
            for (i = 1; i <= 8; i++)
            {

                pPic[i].Click += pPic_Click; // Click Event
                cList[i].Click += cList_Click; // Click Event      
            }
            // pPic[8] = pictureBox10;
            //pPic[5] = pictureBox2;
            GetFiles();
            MyGame();
        }

        private void cList_Click(object sender, EventArgs e)
        {
            string sMsg;
            sMsg = Convert.ToString(((Label)sender).Text);
            speaker.SpeakAsync(sMsg);
        }
        private void pPic_Click(object sender, EventArgs e)
        {
            string sMsg;
            sMsg = Convert.ToString(((PictureBox)sender).Tag);
            speaker.SpeakAsync(sMsg);
        }
        private void pRB_Click(object sender, EventArgs e)
        {
            int i,j,l,k;           
            double iDou;
            string sMsg;
            LblC.Text = ((CheckBox)sender).Name + "   Tag=" + ((CheckBox)sender).Text;// sender.name();
            sMsg = ((CheckBox)sender).Name;
            i = Convert.ToInt32(sMsg.Substring(2, 2));
            iPick = i;
            iDou = Convert.ToDouble(sMsg.Substring(2, 2));
            iDou = (i - 0.999) / 4;
            iDou = (int) iDou;
            j = Convert.ToInt32(iDou)+20;
            k = ((Convert.ToInt32(iDou) + 1) * 4 ) -3;
            sMsg = Convert.ToString(pPic[j].Tag);
            // j = (i - .04) / 4;
            LblC.Text =i + "   Tag=" + ((CheckBox)sender).Text + " " + j + " " + sMsg + " " + k; // sender.name();
            if (String.Compare(sMsg, ((CheckBox)sender).Text) == 0)
            {
                listBox2.Items.Add(k);
                speaker.SpeakAsync(sMsg);

                for (l = k; l <= k + 3; l++)
                {
                    listBox2.Items.Add(l + " " + k);
                    if (l != i)
                    {
                        pRB[l].Visible = false;  // Click Event
                    }
                  

                }
               // pRB[i].Visible = true;
                listBox2.Items.Add(i + " =true");
            }
            else
            {
                speaker.SpeakAsync(((CheckBox)sender).Text);               
                ((CheckBox)sender).BackColor = Color.Black;
                ((CheckBox)sender).ForeColor = Color.Tomato;
                //pRB[i].Visible = false;
                //listBox2.Items.Add(i + " =false");
                timer1.Start();
            }
        }

        public void GetFiles()
        {
            int i;
            string sMsg;
            //var di = new DirectoryInfo(sValue);           
            DirectoryInfo di = new DirectoryInfo(sValue);
            // 
            // Read all Jpgs
            // 
            // listBox1.Items.Clear();  // Clear ListBox
            var diar1 = di.GetFiles("*.jpg");
            // list the names of all files in the specified directory
            foreach (var dra in diar1)
            {
                sMsg = dra.ToString();
                i = sMsg.Length;
                if (i<11 )
                    listBox1.Items.Add(sMsg.ToUpper());
            }
            label18.Text = Convert.ToString(listBox1.Items.Count);
        }
        public void MyQuiz()
        {
            int i, j, k, l,iOff;
            string sMsg;
            int Num;
            Random MyRnd = new Random();
            iErr = 0;
            for (i = 1; i <= 8; i++)
            {
                cList[i].Text = "";
                cList[i].Tag = "";

            }
            for (i = 1; i <= 24; i++)
            {
                pRB[i].Text = "";
                pRB[i].Tag = "";
                pRB[i].Checked = false;
                pRB[i].Visible = true;
                pRB[i].BackColor = BRB[i];
                pRB[i].ForeColor = fRB[i];
            }
            listBox2.Items.Clear();
            iOff = 1;
            for (l = 1; l <= 6; l++)
            {
                Num = MyRnd.Next(0, listBox1.Items.Count);
                j = 0;
                k = 1;
                while (j == 0)
                {
                    Num = MyRnd.Next(0, listBox1.Items.Count);
                    iErr += 1;
                    if (iErr > 10000)
                        return;
                    j = Num;
                    //Dont Place in same spot & Insure Tile Not Used Before
                    for (i = 1; i <= 6; i++)
                    {
                        sMsg = Convert.ToString(cList[i].Tag);
                        if (String.Compare(sMsg, listBox1.Items[Num].ToString()) == 0)
                            j = 0;
                    }
                    for (i = 1; i <= 6; i++)
                    {
                        k = i;
                        if ((j > 0) & (String.Compare(cList[i].Text, "") == 0))
                            break; //Skip out of this for loop           
                    }
                }
                sMsg = listBox1.Items[j].ToString();
                cList[k].Text = sMsg.Substring(0, sMsg.Length - 4);
                cList[k].Tag = listBox1.Items[j].ToString();
                pPic[k + 19].Image = Image.FromFile(sValue + cList[k].Tag);
                pPic[k + 19].Tag = cList[k].Text;
                listBox2.Items.Add(k + 19 + " " + cList[k].Text);
                Num = MyRnd.Next(0, 4);
                //pRB(1).text = "HI";
                pRB[Num + iOff].Text = Convert.ToString(pPic[k + 19].Tag);
                iOff += 4;
            }
            //iOff = 1;
            //Num = MyRnd.Next(0, 4);
            ////pRB(1).text = "HI";
            //pRB[Num + iOff].Text = Convert.ToString(pPic[20].Tag);
            sMsg = "";
            for (l = 1; l <= 24; l++)
            {
                if ( (String.Compare(pRB[l].Text, "") == 0))
                {                  
                    j = 0;
                    while (j == 0)
                    {
                        Num = MyRnd.Next(0, listBox1.Items.Count);
                        j = 90;
                        sMsg = listBox1.Items[Num].ToString();
                        for (i = 1; i <= 24; i++)
                        {

                            if ((String.Compare(pRB[i].Text, sMsg.Substring(0, sMsg.Length - 4)) == 0))
                            {
                                j = 0;
                                break;
                            }
                        }
                    }
                    pRB[l].Text = sMsg.Substring(0, sMsg.Length - 4);
                }
            }


        }
        public void MyGame()
        {
            int i,j,k,l;
            string sMsg;
            int Num;
            iErr = 0;
            Random MyRnd = new Random();
            for (i = 1; i <= 8; i++)
            {
                cList[i].Text = "";
                cList[i].Tag = "";

            }
            for (l = 1; l<= 8; l++)
            {
                Num = MyRnd.Next(0, listBox1.Items.Count);
               
                j = 0;
                k = 1;
                while (j == 0)
                {
                    Num = MyRnd.Next(0, listBox1.Items.Count);
                    j = Num;
                    iErr += 1;
                    if (iErr > 10000)
                        return;
                    //Dont Place in same spot & Insure Tile Not Used Before
                    for (i = 1; i <= 8; i++)
                    {
                        sMsg = Convert.ToString(cList[i].Tag);
                        if (String.Compare(sMsg, listBox1.Items[i].ToString()) == 0)
                            j = 0;
                    }
                    for (i = 1; i <= 8; i++)
                    {
                        k = i;
                        if ((j > 0) & (String.Compare(cList[i].Text, "") == 0))
                            break; //Skip out of this for loop           
                    }
                }
                sMsg= listBox1.Items[j].ToString();
                cList[k].Text = sMsg.Substring(0, sMsg.Length-4); 
                cList[k].Tag = listBox1.Items[j].ToString();
                pPic[k].Image = Image.FromFile(sValue + cList[k].Tag);
                pPic[k].Tag = cList[k].Text;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void o3_3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void o2_2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MyGame();
        }

        private void o3_1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            // if (e.tabControl1.)
           // int iTab = tabControl1.SelectedIndex;

        }

       
      

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Animals.
            if (tabControl1.SelectedTab == Quiz)
                MyQuiz(); 
            if (tabControl1.SelectedTab == Animal)
                MyGame();
        }

        private void rb08_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pRB[iPick].Visible = false;
            timer1.Stop();
        }
    }
}
