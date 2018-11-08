using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invaders
{
    public partial class Invaders : Form
    {
        List<Invader> invaders = new List<Invader> { };
        decimal moeilijkheidsgraad;
        int score;

        Random random = new Random();

        public Invaders()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            moeilijkheidsgraad = numUpDownSnelheidInv.Value * 1;
            for (int i = 0; i < numUpDownAantalInv.Value; i++)
            {
                Button b = new Button();
                b.Height = 30;
                b.Width = 30;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = Color.Black;
                b.Left = random.Next(10, 580);
                Controls.Add(b);
                Invader invader = new Invader(b, 5);                
                invaders.Add(invader);
                b.Click += new EventHandler(b_Click);
            }
            timerInvaders.Start();
            btnStart.Hide();
            numUpDownSnelheidInv.Hide();
            lblMoeilijkheid.Hide();
            numUpDownAantalInv.Hide();
            label2.Hide();
            label3.Hide();
        }

        private void b_Click(object sender, EventArgs e)
        {
            score += (Convert.ToInt32(moeilijkheidsgraad) * 1);
            for (int i = 0; i < invaders.Count; i++)
            {
                Invader invader = invaders[i];
                if (invader.getElement() == sender)
                {
                    invader.VerliesLeven(random.Next(0, 580));
                    
                    if (invader.getLevens() <= 0)
                    {
                        invaders.Remove(invader);
                        this.Controls.Remove((Button)sender);
                    }
                }
            }
        }

        private void timerInvaders_Tick(object sender, EventArgs e)
        {
            labelScore.Text = "Score: " + score.ToString();
            for(int i = 0; i < invaders.Count; i++)
            {
                Invader invader = invaders[i];
                invader.InvadersToAarde(moeilijkheidsgraad);
                if (invader.IsInvaderOnEarth())
                {
                    invaders.Remove(invader);
                    ClearButtons();
                    btnStart.Show();
                    numUpDownSnelheidInv.Show();
                    lblMoeilijkheid.Show();
                    numUpDownAantalInv.Show();
                    label2.Show();
                    label3.Show();
                    score = 0;
                }
            }
        }
        public void ClearButtons()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (Controls[i] is Button && Controls[i] != btnStart)
                {
                    invaders.Clear();
                    this.Controls.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
