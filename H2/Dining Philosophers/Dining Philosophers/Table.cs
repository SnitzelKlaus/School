using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers
{
    public class Table
    {
        public static Fork[] Forks = new Fork[5];
        public void StartDining()
        {
            for(int i = 0; i < Forks.Length; i++) //Creating philosophers with id and left/right hand, defined from Forks!
            {
                Fork leftHand = new Fork(i);
                Fork rightHand = new Fork(i-1);

                if (rightHand.Id < 0)
                    rightHand.Id = Forks.Length - 1;

                _ = new Philosophers(i, leftHand, rightHand);
            }
        }
    }
}
