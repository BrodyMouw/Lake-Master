using System;
using System.Collections.Generic;
using System.Text;

namespace LakeLife.Helpers
{
    public static class CartCounter
    {
        public static int CartCount()
        {
            return Calculate();
        }

        public static int Calculate()
        {
            int count = 0;

            if (Settings.ItemStatus1)
                count = count + 1;
            if (Settings.ItemStatus2)
                count = count + 1;
            if (Settings.ItemStatus3)
                count = count + 1;
            if (Settings.ItemStatus4)
                count = count + 1;

            return count;
        }
    }
}
