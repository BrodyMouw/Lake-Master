using System;
using System.Collections.Generic;
using System.Text;

namespace LakeLife.Helpers
{
    public static class CalculateTotal
    {
        public static double calculateTotal()
        {
            return Calculate();
        }

        public static double Calculate()
        {
            double price = 0;

            if (Settings.ItemStatus1)
                price += 60.0;
            if (Settings.ItemStatus2)
                price += 300.0;
            if (Settings.ItemStatus3)
                price += 900;
            if (Settings.ItemStatus4)
                price += 0;

            return price;
        }
    }
}
