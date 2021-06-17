using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Exam
{
    public class SecondTask
    {
        private const bool extendedMode = false;
        private const int k = 3;
        private const int m = 3;
        public void ShowResults()
        {
            var variantA = (2 + k) * (10 - m);
            var binNumber = DecimalToBinary(variantA);
            var hexNumber = DecimalToHex(variantA);
            Console.WriteLine("a) binary and hex numbers: " + binNumber + " " + hexNumber);
            var variantB = (2 + 7 * k) * (10 + 5 * m) * (19 + 4 * k + 3 * m);
            var RGB = DeciminalToRGB(variantB);
            var HSV = RGBToHSV(RGB);
            Console.WriteLine("b) RGB and HSV numbers: " +
                              "(" + RGB.R +" "+ RGB.G +" "+ RGB.B + "), (" + HSV.X +" "+ HSV.Y +" "+ HSV.Z +")");
            Console.WriteLine("d) Bugs With floats:");
            BugsWithFloatingPoint();
        }

        private void BugsWithFloatingPoint()
        {
            var a = 1f;
            var b = 0.000000000000000000000000001f;
            Console.WriteLine(a + " + " + b + " = " + (a+b));

            var c = 0.1d;
            var d = 0.2d;
            Console.WriteLine(c + " + " + d + " = " + (c+d));
        }

        private Vector3 RGBToHSV(Color rgb)
        {
            var max = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
            
            var color = Color.FromArgb(rgb.R, rgb.G, rgb.B);
            var hue = color.GetHue();
            var saturation = color.GetSaturation();
            var value = max / 255f;

            return new Vector3(hue, saturation, value);
        }

        private Color DeciminalToRGB(int color)
        {
            var red =   ( color >>  0 ) & 255;
            var green = ( color >>  8 ) & 255;
            var blue =  ( color >> 16 ) & 255;
            return Color.FromArgb(red, green, blue);
        }

        private string DecimalToHex(int num)
        {
            return Convert.ToString(num, 16);
        }

        private string DecimalToBinary(int num)
        {
            var result = string.Empty;
            var rem = 0;
            
            while (num > 0)
            {
                rem = num % 2;
                if (extendedMode)
                    Console.WriteLine(" rem " +rem);
                num /= 2;
                if (extendedMode)
                    Console.WriteLine(" num " +num);
                result = rem + result;
                if (extendedMode)
                    Console.WriteLine(" Result " + result);
            }
            
            return result;
        }
    }
}