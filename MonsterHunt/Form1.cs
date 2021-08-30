using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace MonsterHunt
{

    //Valamikezdete
    public partial class Form1 : Form
    {

        public int[] ConvertType(int index)
        {
            
            int[] temp = new int[2];
            switch (index)
            {
                case 0:
                    temp[0] = 3;
                    temp[1] = 1;
                    return temp;

                case 1:
                    temp[0] = 1;
                    temp[1] = 3;
                    return temp;
                case 2:
                    temp[0] = 2;
                    temp[1] = 2;
                    return temp;
                default:
                    temp[0] = 0;
                    temp[1] = 0;
                    return temp;
            }
        }

        public int[] ConvertRace(int index)
        {
            int[] temp = new int[2];
            switch (index)
            {
                case 0:
                    temp[0] = 10;
                    temp[1] = 12;
                    return temp;

                case 1:
                    temp[0] = 12;
                    temp[1] = 10;
                    return temp;
                case 2:
                    temp[0] = 11;
                    temp[1] = 11;
                    return temp;
                default:
                    temp[0] = 0;
                    temp[1] = 0;
                    return temp;
            }
        }
        public double ConvertRank(int index)
        {
            switch (index)
            {
                case 0:
                    return 1;
                case 1:
                    return 1.5;
                case 2:
                    return 2;
                default:
                    return 0;
            }
        }
        
        public Form1()
        {
            InitializeComponent();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("water.wav");
            player.Play();
            string[] type = new string[] { "Dragon", "Ooze", "Monstrous" };//string tombbe letrehozom az opciokat
            string[] race1 = new string[] { "Drake", "Wyvern", "Wyrm" };
            string[] race2 = new string[] { "Slime", "Jelly", "Sludge" };
            string[] race3 = new string[] { "Undead", "Construct", "Elemental" };
            string[] rank = new string[] { "Minion", "Miniboss", "Boss" };
            textBox1.Enabled = false; //ne lehessen bele irni
            textBox2.Enabled = false;
            for (int i = 0; i < type.Length; i++)//feltoltom az 1.combot a tombom hossza a max.i++ lepteti
            {
                comboBox1.Items.Add(type[i]);
            }

            comboBox1.SelectedIndexChanged += (s, e) => //feltoltom a 2.combot az 1.combon alapulva, Changed eventtel
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox2.Items.Clear();
                    pictureBox1.Image = Image.FromFile("dragon.png");
                    for (int i = 0; i < race1.Length; i++)
                    {
                        comboBox2.Items.Add(race1[i]);
                    }
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    comboBox2.Items.Clear();
                    pictureBox1.Image = Image.FromFile("ooze.png");
                    for (int i = 0; i < race2.Length; i++)
                    {
                        comboBox2.Items.Add(race2[i]);
                    }
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    pictureBox1.Image = Image.FromFile("monstrous.png");
                    for (int i = 0; i < race3.Length; i++)
                    {
                        comboBox2.Items.Add(race3[i]);
                    }

                }
            };
            for (int i = 0; i < rank.Length; i++) //feltoltom a 3.combot
            {
                comboBox3.Items.Add(rank[i]);
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //normalisan mukodjon
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            pictureBox4.Image = Image.FromFile("exp.png");
            pictureBox5.Image = Image.FromFile("gold.png");
            



            comboBox1.SelectedIndexChanged += (s, e) =>
            {
                System.Media.SoundPlayer player1 = new System.Media.SoundPlayer("lion.wav");
                player1.Play();
                switch (comboBox1.SelectedIndex) //kicsi ikon mert maskent nem megy
                {
                    case 0:
                        {
                            pictureBox1.Image = Image.FromFile("dragon.png");
                            break;
                        }
                    case 1:
                        {
                            pictureBox1.Image = Image.FromFile("ooze.png");
                            break;
                        }
                    case 2:
                        {
                            pictureBox1.Image = Image.FromFile("monstrous.png");
                            break;
                        }
                    default:
                        break;
                }
            };
 
            comboBox3.SelectedIndexChanged += (s, e) =>
            {
                System.Media.SoundPlayer player3 = new System.Media.SoundPlayer("dead.wav");
                player3.Play();
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            pictureBox2.Image = Image.FromFile("minion.png");
                            break;
                        }
                    case 1:
                        {
                            pictureBox2.Image = Image.FromFile("miniboss.png");
                            break;
                        }
                    case 2:
                        {
                            pictureBox2.Image = Image.FromFile("boss.png");
                            break;
                        }
                    default:
                        break;
                }
            };
            numericUpDown1.ValueChanged += (s, e) =>
            {
                if (numericUpDown1.Value <= 35)
                {
                    pictureBox3.Image = Image.FromFile("op1.png");
                }
                if (numericUpDown1.Value > 35 && numericUpDown1.Value <= 75)
                {
                    pictureBox3.Image = Image.FromFile("op2.png");
                }
                if (numericUpDown1.Value > 75 && numericUpDown1.Value <= 100)
                {
                    pictureBox3.Image = Image.FromFile("op3.png");
                }
            };


            
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;


            button1.Click += (s, e) =>
            {               
               
                textBox1.Text = Tapasztalat(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, Convert.ToInt32(numericUpDown1.Value)).ToString();
                textBox2.Text = Arany(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, Convert.ToInt32(numericUpDown1.Value)).ToString();
                if (Convert.ToInt32(textBox1.Text)> 0)
                {
                    MessageBox.Show("Ügyes vagy, " + textBox1.Text + " szintet léptél :)");
                    System.Media.SoundPlayer player6 = new System.Media.SoundPlayer("yay.wav");
                    player6.Play();

                }
                else
                {
                    MessageBox.Show("Sajnos meghaltál a küldetés közben :(");
                    System.Media.SoundPlayer player5 = new System.Media.SoundPlayer("die.wav");
                    player5.Play();
                    
                }
               
            };
        }

        public double ConvertSize(int index)
        {
            switch (index)
            {
                case 0:
                    return 1.2;
                case 1:
                    return 2;
                case 2:
                    return 2.5;
                default:
                    return 0;
            }
        }


        private double Arany(int combo1, int combo2, int combo3, int szint)
        {
            int[] tipi = ConvertType(combo1);
            int[] raci = ConvertRace(combo2);

            double gold = tipi[0] * raci[0] * (szint / 2) + ConvertRank(combo3);

            return Math.Round(gold, 0);
        }

        private double Tapasztalat(int combo1, int combo2, int combo3, int szint)
        {
            int[] tipi = ConvertType(combo1);
            int[] raci = ConvertRace(combo2);

            double exp = (tipi[1] * raci[1] * (szint / 2) + ConvertRank(combo3))/10;

            return Math.Round(exp, 0);
        }

    }

}
