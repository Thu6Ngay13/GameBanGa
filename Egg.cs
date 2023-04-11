using System.Collections.Generic;
using System.Drawing;

namespace GameBanGa
{
    public class Egg : ObjectGame
    {
        
        private int eggSpeed;
        private int eggFrameTh = 0;

        private int nState;
        private Bitmap eggBreak;
        private List<Bitmap> eggBreakframes;

        public Egg(int width, int heigh, Bitmap image, Bitmap eggBreak) 
            : base(width, heigh, image)
        {
            this.eggBreak = eggBreak;
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
