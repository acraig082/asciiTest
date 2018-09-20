using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.CodeDom;
using System.CodeDom.Compiler;
namespace asciiTest
{
    class Program
    {

        

        static int[] cColors = { 0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF, 0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF };

        public static void ConsoleWritePixel(Color cValue)
        {
            Color[] cTable = cColors.Select(x => Color.FromArgb(x)).ToArray();
            char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 }; // 1/4, 2/4, 3/4, 4/4
            int[] bestHit = new int[] { 0, 0, 4, int.MaxValue }; //ForeColor, BackColor, Symbol, Score

            for (int rChar = rList.Length; rChar > 0; rChar--)
            {
                for (int cFore = 0; cFore < cTable.Length; cFore++)
                {
                    for (int cBack = 0; cBack < cTable.Length; cBack++)
                    {
                        int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                        int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                        int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                        int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - B) * (cValue.B - B);
                        if (!(rChar > 1 && rChar < 4 && iScore > 50000)) // rule out too weird combinations
                        {
                            if (iScore < bestHit[3])
                            {
                                bestHit[3] = iScore; //Score
                                bestHit[0] = cFore;  //ForeColor
                                bestHit[1] = cBack;  //BackColor
                                bestHit[2] = rChar;  //Symbol
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = (ConsoleColor)bestHit[0];
            Console.BackgroundColor = (ConsoleColor)bestHit[1];
            Console.Write(rList[bestHit[2] - 1]);
        }


        public static void ConsoleWriteImage(Bitmap source)
        {
            int sMax = 39;
            decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
            Size dSize = new Size((int)(source.Width * percent), (int)(source.Height * percent));
            Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
            for (int i = 0; i < dSize.Height; i++)
            {
                for (int j = 0; j < dSize.Width; j++)
                {
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2, i));
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2 + 1, i));
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
            
        }

        static void Main()
        {
            CompilerParameters cp = new CompilerParameters();
            cp.CompilerOptions = "/optimize /target:winexe /win32icon:program.ico";

            Console.WindowWidth = 78;
            Console.WindowHeight = 39;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = @"C:\Users\xacfi_000\Downloads\Om.wav";
            player.Play();

            Bitmap sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board3.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board4.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board5.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board6.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board6b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board6c.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board6e.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board10b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board10c.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board10.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\Church2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\Church3.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\z.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\z2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\x1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\x3.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\x4.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\face1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\face0.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\face2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board11.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board11b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board11c.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board11d.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board11e.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12c.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12d.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12e.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12f.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12g.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12h.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12i.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12j.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board12k.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13c.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13d.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13e.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13f.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13g.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13h.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13i.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board13j.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board14.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board14b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board14c.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board14d.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board14e.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board14f.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board15.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board15b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16_1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16_2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16b1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16b2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16c1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16c2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16d1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16d2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16e1.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board16e2.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board17.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board17b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18b.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18c.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18d.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18e.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18f.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18g.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18h.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18i.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18j.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18k.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18l.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18m.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18n.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18o.jpg", true);
            ConsoleWriteImage(sB1);
            sB1 = new Bitmap(@"C:\Users\xacfi_000\MyTextAdventure\story_board18p.jpg", true);
            ConsoleWriteImage(sB1);

            Console.ReadKey();
         
            
        } 

    }
}
