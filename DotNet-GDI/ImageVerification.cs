using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DotNet_GD
{
    public class ImageVerification
    {
        private static readonly Random rd = new Random();
        public static Bitmap GetNumberVerification(int length = 50)
        {
            var img = new Bitmap(200, 80);
            var gh = Graphics.FromImage(img);
            var font = new Font("微软雅黑", 32);
            var pen = new Pen(Color.Gainsboro);
            gh.FillRectangle(Brushes.MintCream, 0, 0, img.Width, img.Height);
            for (var i = 0; i < 1000; i++)
            {
                gh.DrawRectangle(pen, rd.Next(img.Width), rd.Next(img.Height), 1, 1);
            }

            for (var i = 0; i < length; i++)
            {
                var brush = new SolidBrush(GetRandomColor());
                gh.DrawString(GetRandNumber(), font, brush, 32 * (i + 1), 13);
            }

            gh.Dispose();
            return img;
        }



        private static string GetRandNumber()
        {
            return rd.Next(0, 9).ToString(CultureInfo.InvariantCulture);
        }

        private static Color GetRandomColor()
        {
            var r = rd.Next(0, 255);
            var g = rd.Next(0, 255);
            var b = rd.Next(0, 255);
            return Color.FromArgb(100, r, g, b);
        }
    }
}
