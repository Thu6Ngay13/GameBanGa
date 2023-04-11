using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBanGa
{
    public class Egg : Chicken
    {
        
        private int eggSpeed;
        private int eggFrameTh;

        private int nState;
        private Bitmap eggBreak;
        private List<Bitmap> eggBreakframes;

        public Egg(int width, int heigh, Bitmap image) 
            : base(width, heigh, image)
        {
        }

        public void speed(int eggSpeed, int eggFrameTh)
        {
            this.eggSpeed = eggSpeed;
            this.eggFrameTh = eggFrameTh;
        }

        public void eggNextState()
        {
            if (eggFrameTh + 1 == nState) return;
                
        }
    }
}
