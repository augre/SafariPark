using System;

namespace LSP
{
    class Program
    {
        private static void Main()
        {
            // They can all be substituted by the base class
            var birds = new Bird[]
            {
                new Duck(),
                new Colibri(),
                new Penguin(),
                new Ostrich()
            };

            FlyBirdsFly(birds);
        }

        public static void FlyBirdsFly(Bird[] birds)
        {
            foreach (var bird in birds)
            {
                bird.Fly();
            }
        }
    }


}
