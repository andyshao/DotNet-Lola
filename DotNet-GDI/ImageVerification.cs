using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace DotNet_GD
{
    public class ImageVerification
    {
        private static readonly Random Rd = new Random(~unchecked((int)DateTime.Now.Ticks));
        public static VerifyData CreateVerifyStr(int length = 4)
        {
            var font = new Font("宋体", 25, FontStyle.Bold);
            var val = new StringBuilder();
            var img = new Bitmap((int)(length * font.Size), font.Height + 10);
            var gh = Graphics.FromImage(img);
            gh.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height);

            var pen = new Pen(GetRandColor(), 2f);
            var lines = GetPoints(img.Width, img.Height).ToArray();
            gh.DrawLines(pen, lines);

            for (var i = 0; i < length; i++)
            {
                var s = GetRandNo(1);
                val.Append(s);
                gh.DrawString(s, font, new SolidBrush(GetRandColor()), (font.Size - 10) * i + (int)(length * 3.5), (img.Height - font.Height) / 2f + 2);
            }

            img = TwistImage(img);
            gh.Dispose();

            return new VerifyData { BitMap = img, MsStream = GetStream(img), Value = val.ToString() };
        }

        public static VerifyData CreateVerifyCalc()
        {
            var font = new Font("Arial", 25);
            var val = new List<string>();
            var img = new Bitmap((int)(4 * font.Size), font.Height + 10);
            var gh = Graphics.FromImage(img);
            gh.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height);

            var pen = new Pen(GetRandColor(), 2f);
            var lines = GetPoints(img.Width, img.Height).ToArray();
            gh.DrawLines(pen, lines);


            var s = GetRandNo(1, true);
            val.Add(s);
            gh.DrawString(s, font, new SolidBrush(GetRandColor()), (int)(4 * 3.5), (img.Height - font.Height) / 2f + 2);
            s = GetRandCalc();
            val.Add(s);
            gh.DrawString(s, font, new SolidBrush(GetRandColor()), (font.Size - 5) * 1 + (int)(4 * 3.5), (img.Height - font.Height) / 2f + 2);

            s = GetRandNo(1, true);
            val.Add(s);
            gh.DrawString(s, font, new SolidBrush(GetRandColor()), (font.Size - 5) * 2 + (int)(4 * 3.5), (img.Height - font.Height) / 2f + 2);
            img = TwistImage(img);
            gh.Dispose();

            return new VerifyData { BitMap = img, MsStream = GetStream(img), Value = GetValue(val).ToString() };
        }

        private static MemoryStream GetStream(Image img)
        {
            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            return ms;
        }

        private static int GetValue(List<string> list)
        {
            if (list.ElementAt(1) == "÷" && list.ElementAt(2) == "0") return 0;
            switch (list.ElementAt(1))
            {
                case "+":
                    return Convert.ToInt32(list.ElementAt(0)) + Convert.ToInt32(list.ElementAt(2));
                case "-":
                    return Convert.ToInt32(list.ElementAt(0)) - Convert.ToInt32(list.ElementAt(2));
                case "×":
                    return Convert.ToInt32(list.ElementAt(0)) * Convert.ToInt32(list.ElementAt(2));
                case "÷":
                    return Convert.ToInt32(list.ElementAt(0)) / Convert.ToInt32(list.ElementAt(2));
            }
            return 0;
        }

        private static string GetRandNo(int length, bool isJustNo = false)
        {
            var p = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var result = string.Empty;
            var n = isJustNo ? 9 : p.Length;
            var m = isJustNo ? 1 : 0;
            for (var i = 0; i < length; i++)
                result += p[Rd.Next(m, n)];
            return result;
        }

        private static string GetRandCalc()
        {
            var p = new[] { '+', '-', '×', '÷' };
            return p[Rd.Next(0, 4)].ToString();
        }

        private static Color GetRandColor()
        {
            var r = Rd.Next(0, 255);
            var g = Rd.Next(0, 255);
            var b = Rd.Next(0, 255);
            return Color.FromArgb(255, r, g, b);
        }

        private static IEnumerable<Point> GetPoints(int iwidth, int iheight, int plen = 6)
        {
            for (var i = 0; i < plen; i++)
            {
                var x = iwidth / (plen - 1) * i;
                var y = Rd.Next(10, iheight - 10);
                yield return new Point(x, y);
            }
        }

        private static Bitmap TwistImage(Bitmap srcBmp, bool bXDir = true, double dMultValue = 9, double dPhase = 6)
        {
            const double pi2 = 6.283185307179586476925286766559;
            var destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

            // 将位图背景填充为白色
            var graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();

            double dBaseAxisLen = bXDir ? destBmp.Height : destBmp.Width;

            for (var i = 0; i < destBmp.Width; i++)
            {
                for (var j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (pi2 * j) / dBaseAxisLen : (pi2 * i) / dBaseAxisLen;
                    dx += dPhase;
                    var dy = Math.Sin(dx);

                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                    var color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                        && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }
    }

    public class VerifyData
    {
        public Bitmap BitMap { get; set; }
        public MemoryStream MsStream { get; set; }
        public string Value { get; set; }
    }
}
