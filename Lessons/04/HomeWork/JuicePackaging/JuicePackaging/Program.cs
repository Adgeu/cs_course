using System;

namespace JuicePackaging
{
    [Flags]
    enum JuiceContainer
    {
        OneL = 0b1,
        FiveL = 0b1 << 1,
        TwentyL = 0b1 << 2,
    }

    class Program
    {
        static void Main(string[] args)
        {
            JuiceContainer conteinersInUse = 0b0;
            int countTwenty;
            int countFive;
            int countOne;

            // Input
            Console.WriteLine("Какой объем сока (в литрах) требуется упаковать?");
            float V = float.Parse(Console.ReadLine());
            
            // Calculation
            if ((countTwenty = (int)(V / 20)) > 0) 
                conteinersInUse |= JuiceContainer.TwentyL;

            V %= 20;            

            if ((countFive = (int)(V / 5)) > 0)
                conteinersInUse |= JuiceContainer.FiveL;

            V %= 5;

            if ((countOne = (int)Math.Ceiling(V)) > 0)
                conteinersInUse |= JuiceContainer.OneL;

            // Printing results
            Array allContainers = Enum.GetValues(typeof(JuiceContainer));
            for (int i = allContainers.Length - 1; i >= 0; i--)
            {
                if ((conteinersInUse & (JuiceContainer)allContainers.GetValue(i)) == JuiceContainer.TwentyL)
                    Console.WriteLine("20 л: " + countTwenty);
                else if ((conteinersInUse & (JuiceContainer)allContainers.GetValue(i)) == JuiceContainer.FiveL)
                    Console.WriteLine("5 л: " + countFive);
                else if ((conteinersInUse & (JuiceContainer)allContainers.GetValue(i)) == JuiceContainer.OneL)
                    Console.WriteLine("1 л: " + countOne);
            }
        }
    }
}
