using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016002627
{
    public partial class Form1 : Form
    {
        #region Variables
        //VARIABLES
        PictureBox PendingImage1;// Storing The First Flipped Card
        PictureBox PendingImage2;// Storing The Second Image 
        Random Location = new Random(); // Selects Random Value From X And Y And Assigns A New Location To Each Card
        List<Point> points = new List<Point>(); //List To Hold Cards Points
        Boolean GameStart = false; //Timer Start Variable
        Boolean GameOver = false;
        bool again = false; //Play Again Or No
        int Pairs = 0;
        int count = 0;  //Timer Variable 
        int pairsclicked = 0;
        #endregion Variables

        public Form1()
        {
            InitializeComponent();
            AssignIcons();
            timelabel();
            Cards();
        }
        private void Memory_Board(object sender, EventArgs e)
        {

        } 

        #region Card Images     
        private void Cards()
        {
            Card1.Image = Properties.Resources.ace_of_clubs; //1
            DupCard1.Image = Properties.Resources.ace_of_diamonds;//2
            Card2.Image = Properties.Resources.ace_of_hearts;//2
            DupCard2.Image = Properties.Resources.ace_of_spades;//1
            Card3.Image = Properties.Resources._2_of_clubs;//3
            DupCard3.Image = Properties.Resources._2_of_diamonds;//4
            Card4.Image = Properties.Resources._2_of_hearts;//4
            DupCard4.Image = Properties.Resources._2_of_spades;//3
            Card5.Image = Properties.Resources._3_of_clubs_copy;//5
            DupCard5.Image = Properties.Resources._3_of_diamonds_copy;//6
            Card6.Image = Properties.Resources._3_of_hearts;//6
            DupCard6.Image = Properties.Resources._3_of_spades_copy;//5
            Card7.Image = Properties.Resources._4_of_clubs;//7
            DupCard7.Image = Properties.Resources._4_of_diamonds;//8
            Card8.Image = Properties.Resources._4_of_hearts;//8
            DupCard8.Image = Properties.Resources._4_of_spades;//7
            Card9.Image = Properties.Resources._5_of_clubs;//9
            DupCard9.Image = Properties.Resources._5_of_diamonds;//10
            Card10.Image = Properties.Resources._5_of_hearts;//10
            DupCard10.Image = Properties.Resources._5_of_spades;//9
            Card11.Image = Properties.Resources._6_of_clubs;//11
            DupCard11.Image = Properties.Resources._6_of_diamonds;//12
            Card12.Image = Properties.Resources._6_of_hearts;//12
            DupCard12.Image = Properties.Resources._6_of_spades;//11
            Card13.Image = Properties.Resources._7_of_clubs;//13
            DupCard13.Image = Properties.Resources._7_of_diamonds;//14
            Card14.Image = Properties.Resources._7_of_hearts;//14
            DupCard14.Image = Properties.Resources._7_of_spades;//13
            Card15.Image = Properties.Resources._8_of_clubs;//15
            DupCard15.Image = Properties.Resources._8_of_diamonds;//16
            Card16.Image = Properties.Resources._8_of_hearts;//16
            DupCard16.Image = Properties.Resources._8_of_spades;//15
            Card17.Image = Properties.Resources._9_of_clubs;//17
            DupCard17.Image = Properties.Resources._9_of_diamonds;//18
            Card18.Image = Properties.Resources._9_of_hearts;//18
            DupCard18.Image = Properties.Resources._9_of_spades;//17
            Card19.Image = Properties.Resources.jack_of_clubs;//19
            DupCard19.Image = Properties.Resources.jack_of_diamonds;//20
            Card20.Image = Properties.Resources.jack_of_hearts2;//20
            DupCard20.Image = Properties.Resources.jack_of_spades;//19
            Card21.Image = Properties.Resources.queen_of_clubs;//21
            DupCard21.Image = Properties.Resources.queen_of_diamonds;//22
            Card22.Image = Properties.Resources.queen_of_hearts;//22
            DupCard22.Image = Properties.Resources.queen_of_spades;//21
            Card23.Image = Properties.Resources.king_of_clubs;//23
            DupCard23.Image = Properties.Resources.king_of_diamonds;//24
            Card24.Image = Properties.Resources.king_of_hearts;//24
            DupCard24.Image = Properties.Resources.king_of_spades;//23
            Card25.Image = Properties.Resources._10_of_clubs;//25
            DupCard25.Image = Properties.Resources._10_of_diamonds;//26
            Card26.Image = Properties.Resources._10_of_hearts;//26
            DupCard26.Image = Properties.Resources._10_of_spades;//25      
        }
        #endregion
        #region Methods

        private void NewGame()
        {
            count = 0;
            Pairs = 0;
            pairsclicked = 0;
            GameStart = false;
        }
        private void timelabel() // Declaring the text for the timePlaying label.
        {
            Played.Text = "Time PLayed: " + count.ToString();
        }
        private void pairs() // Declaring the text for the timePlaying label.
        {
            Score.Text = "Pairs: " + Pairs;
        }
        private void GameOverBanner()
        {
            if (GameOver == true)
                Winner.Visible = true;
            else
                Winner.Visible = false;
        } 

        private void AssignIcons() // Rearrages the picturebox locations in the CardHolder(panel).
        {
            foreach (PictureBox picture in CardHolder.Controls) // For every PictureBox within CardHolder(panel), add it it the list of points in random order.
            {
                picture.Enabled = false; // Disables every PictureBox in CardHolder.
                points.Add(picture.Location); // Adds every PictureBox to the points list, in random order.
            }
            foreach (PictureBox picture in CardHolder.Controls) // Place every PictureBox into CardHolder in a random order.
            {
                int next = Location.Next(points.Count); // Declares the variable next, which is a random non-negative number within the limits of the points list.
                Point p = points[next]; // Declares the variable p, which is a random location from within the points list. 
                picture.Location = p; // Sets the location of each PictureBox to p.
                points.Remove(p); // Removes the location of each PictureBox from the list. 
            }
            timer1.Start();
            timer2.Start();
            timer4.Start();
            timer5.Start();
        }
        #endregion
        #region Timers
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (PictureBox picture in CardHolder.Controls)
            {
                picture.Enabled = true;
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.BeeRed;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop(); // Stops the timer, so it only performs the commands within once, until it's started again.
            foreach (PictureBox picture in CardHolder.Controls) // For every PictureBox within CardHolder...
            {
                picture.Enabled = true; // Enable every PictureBox.
                picture.Cursor = Cursors.Hand; // Set the cursor as a hand when it is above any of the PictureBoxes.
                picture.Image = Properties.Resources.BeeRed; // Set the image of every PictureBox to a card back.
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            PendingImage1.Image = Properties.Resources.BeeRed;
            PendingImage2.Image = Properties.Resources.BeeRed;
            PendingImage1 = null;
            PendingImage2 = null;
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (GameStart == true)
            {
                count++;
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (Pairs == 26)
                GameOver = true;
            GameOverBanner();
            AllPairs.Text = "All Pairs Clicked:" + pairsclicked.ToString();
            Played.Text = "Time PLayed: " + count.ToString();
            Score.Text = "Pairs:" + Pairs;
        }
        #endregion
        #region Playing Cards
        private void Card1_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card1.Image = Properties.Resources.ace_of_clubs;

                if (PendingImage1 == null)
                {
                    PendingImage1 = Card1;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card1;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card1.Enabled = false;
                        DupCard2.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard1_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard1.Image = Properties.Resources.ace_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard1;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard1;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card2.Enabled = false;
                        DupCard1.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card2.Image = Properties.Resources.ace_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card2;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card2;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card2.Enabled = false;
                        DupCard1.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard2.Image = Properties.Resources.ace_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard2;
                }

                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard2;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card1.Enabled = false;
                        DupCard2.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card3.Image = Properties.Resources._2_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card3;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card3;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card3.Enabled = false;
                        DupCard4.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard3.Image = Properties.Resources._2_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard3;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard3;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card4.Enabled = false;
                        DupCard3.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card4.Image = Properties.Resources._2_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card4;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card4;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card4.Enabled = false;
                        DupCard3.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;                        
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard4.Image = Properties.Resources._2_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard4;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard4;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card3.Enabled = false;
                        DupCard4.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card5.Image = Properties.Resources._3_of_clubs_copy;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card5;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card5;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card5.Enabled = false;
                        DupCard6.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard5_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard5.Image = Properties.Resources._3_of_diamonds_copy;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard5;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard5;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card6.Enabled = false;
                        DupCard5.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card6.Image = Properties.Resources._3_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card6;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card6;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card6.Enabled = false;
                        DupCard5.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {

            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard6.Image = Properties.Resources._3_of_spades_copy;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard6;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard6;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card5.Enabled = false;
                        DupCard6.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card7.Image = Properties.Resources._4_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card7;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card7;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card7.Enabled = false;
                        DupCard8.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard7.Image = Properties.Resources._4_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard7;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard7;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card8.Enabled = false;
                        DupCard7.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card8.Image = Properties.Resources._4_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card8;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card8;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card8.Enabled = false;
                        DupCard7.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard8.Image = Properties.Resources._4_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard8;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard8;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card7.Enabled = false;
                        DupCard8.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;

                Card9.Image = Properties.Resources._5_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card9;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card9;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card9.Enabled = false;
                        DupCard10.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard9_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard9.Image = Properties.Resources._5_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard9;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard9;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card10.Enabled = false;
                        DupCard9.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;

                Card10.Image = Properties.Resources._5_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card10;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card10;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card10.Enabled = false;
                        DupCard9.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;

                DupCard10.Image = Properties.Resources._5_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard10;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard10;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card9.Enabled = false;
                        DupCard10.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card11.Image = Properties.Resources._6_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card11;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card11;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card11.Enabled = false;
                        DupCard12.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard11.Image = Properties.Resources._6_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard11;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard11;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card12.Enabled = false;
                        DupCard11.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card12.Image = Properties.Resources._6_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card12;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card12;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card12.Enabled = false;
                        DupCard11.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard12.Image = Properties.Resources._6_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard12;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard12;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card11.Enabled = false;
                        DupCard12.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card13_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card13.Image = Properties.Resources._7_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card13;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card13;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card13.Enabled = false;
                        DupCard14.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard13_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;

                DupCard13.Image = Properties.Resources._7_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard13;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard13;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card13.Enabled = false;
                        DupCard14.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card14_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card14.Image = Properties.Resources._7_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card14;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card14;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card14.Enabled = false;
                        DupCard13.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard14_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard14.Image = Properties.Resources._7_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard14;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard14;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card13.Enabled = false;
                        DupCard14.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card15_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card15.Image = Properties.Resources._8_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card15;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card15;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card15.Enabled = false;
                        DupCard16.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard15_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard15.Image = Properties.Resources._8_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard15;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard15;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card16.Enabled = false;
                        DupCard15.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card16_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card16.Image = Properties.Resources._8_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card16;
                }

                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card16;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card16.Enabled = false;
                        DupCard15.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard16_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard16.Image = Properties.Resources._8_of_spades;
                if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage1 = DupCard16;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard16;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card15.Enabled = false;
                        DupCard16.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card17_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card17.Image = Properties.Resources._9_of_clubs;
                if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage1 = Card17;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card17;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card17.Enabled = false;
                        DupCard18.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard17_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard17.Image = Properties.Resources._9_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard17;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard17;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card18.Enabled = false;
                        DupCard17.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card18_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card18.Image = Properties.Resources._9_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card18;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card18;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card18.Enabled = false;
                        DupCard17.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard18_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard18.Image = Properties.Resources._9_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard18;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard18;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card17.Enabled = false;
                        DupCard18.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card19_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card19.Image = Properties.Resources.jack_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card19;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card19;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card19.Enabled = false;
                        DupCard20.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard19_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard19.Image = Properties.Resources.jack_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard19;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard19;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card20.Enabled = false;
                        DupCard19.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card20_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card20.Image = Properties.Resources.jack_of_hearts2;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card20;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card20;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card20.Enabled = false;
                        DupCard19.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard20_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard20.Image = Properties.Resources.jack_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard20;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard20;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card19.Enabled = false;
                        DupCard20.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card21_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card21.Image = Properties.Resources.queen_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card21;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card21;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card21.Enabled = false;
                        DupCard22.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard21_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard21.Image = Properties.Resources.queen_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard21;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard21;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card21.Enabled = false;
                        DupCard22.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card22_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card22.Image = Properties.Resources.queen_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card22;
                }

                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card22;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card22.Enabled = false;
                        DupCard21.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
                {
                }
            }
        }

        private void DupCard22_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard22.Image = Properties.Resources.queen_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard22;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard22;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card21.Enabled = false;
                        DupCard22.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card23_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card23.Image = Properties.Resources.king_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card23;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card23;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card23.Enabled = false;
                        DupCard24.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard23_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard23.Image = Properties.Resources.king_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard23;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard23;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card24.Enabled = false;
                        DupCard23.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card24_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card24.Image = Properties.Resources.king_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card24;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card24;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card24.Enabled = false;
                        DupCard23.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard24_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard24.Image = Properties.Resources.king_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard24;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard24;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card23.Enabled = false;
                        DupCard24.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card25_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card25.Image = Properties.Resources._10_of_clubs;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card25;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card25;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card25.Enabled = false;
                        DupCard26.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard25_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard25.Image = Properties.Resources._10_of_diamonds;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard25;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard25;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card26.Enabled = false;
                        DupCard25.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void Card26_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                Card26.Image = Properties.Resources._10_of_hearts;
                if (PendingImage1 == null)
                {
                    PendingImage1 = Card26;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = Card26;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card26.Enabled = false;
                        DupCard25.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

        private void DupCard26_Click(object sender, EventArgs e)
        {
            if (PendingImage1 == null || PendingImage1 != null && PendingImage2 == null)
            {
                GameStart = true;
                DupCard26.Image = Properties.Resources._10_of_spades;
                if (PendingImage1 == null)
                {
                    PendingImage1 = DupCard26;
                }
                else if (PendingImage1 != null && PendingImage2 == null)
                {
                    PendingImage2 = DupCard26;
                }
                if (PendingImage1 != null && PendingImage2 != null)
                {
                    if (PendingImage1.Tag == PendingImage2.Tag)
                    {
                        Card25.Enabled = false;
                        DupCard26.Enabled = false;
                        PendingImage1 = null;
                        PendingImage2 = null;
                        Pairs++;
                        pairsclicked++;
                    }
                    else
                    {
                        pairsclicked++;
                        timer3.Start();
                    }
                }
            }
        }

       private void button1_Click_1(object sender, EventArgs e)
        {
            timer4.Stop();
            AssignIcons(); // Randomizes PictureBox locations.
            NewGame(); // Resets neccessary variables.
        }

    }
    #endregion
  }
