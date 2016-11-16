using System;

namespace _1.FigtherAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int px1 = int.Parse(Console.ReadLine());
            int py1 = int.Parse(Console.ReadLine());
            int px2 = int.Parse(Console.ReadLine());
            int py2 = int.Parse(Console.ReadLine());
            int figtherX = int.Parse(Console.ReadLine());
            int figtherY = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());

            int hitX = figtherX + distance;
            int hitY = figtherY;

            int upOfHitX = hitX;
            int upOfHitY = hitY + 1;
            int rightOfHitX = hitX + 1;
            int rightOfHitY = hitY;
            int belowHitX = hitX;
            int belowHitY = hitY - 1;

            int damage = 0;

            if (hitX >= Math.Min(px1,px2) && hitX <= Math.Max(px1,px2) && hitY >= Math.Min(py1,py2) && hitY <=Math.Max(py1,py2) )
            {
                damage += 100;
            }

            if (upOfHitX >= Math.Min(px1, px2) && upOfHitX <= Math.Max(px1, px2) && upOfHitY >= Math.Min(py1, py2) && upOfHitY <= Math.Max(py1, py2))
            {
                damage += 50;
            }

            if (rightOfHitX >= Math.Min(px1, px2) && rightOfHitX <= Math.Max(px1, px2) && rightOfHitY >= Math.Min(py1, py2) && rightOfHitY <= Math.Max(py1, py2))
            {
                damage += 75;
            }

            if (belowHitX >= Math.Min(px1, px2) && belowHitX <= Math.Max(px1, px2) && belowHitY >= Math.Min(py1, py2) && belowHitY <= Math.Max(py1, py2))
            {
                damage += 50;
            }

            Console.WriteLine(damage + "%");
        }
    }
}
