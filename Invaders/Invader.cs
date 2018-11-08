using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invaders
{
    class Invader
    {
        Random random = new Random();

        private int Levens = 5;
        private Button Invaderelement;

        public Invader(Button btn, int levens)
        {
            this.Invaderelement = btn;
            this.Levens = levens;

            this.Invaderelement.Top = 0;
        }

        public void InvadersToAarde(decimal moeilijkheidsgraad)
        {
            this.Invaderelement.Top = this.Invaderelement.Top + Convert.ToInt32(moeilijkheidsgraad);
        }

        public void VerliesLeven(int randomLeft)
        {
            this.Invaderelement.Top = 0;
            this.Invaderelement.Left = randomLeft;
            Levens--;
        }

       

        public bool IsInvaderOnEarth()
        {
            if (this.Invaderelement.Top > 250)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal object getElement()
        {
            return Invaderelement;
        }

        internal int getLevens()
        {
            return this.Levens;
        }
    }
}
