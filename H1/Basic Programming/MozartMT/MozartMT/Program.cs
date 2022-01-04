using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MozartMT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Minuetten\n2) Trioen\n");
            Console.Write("Choose a game: ");
            int game = int.Parse(Console.ReadLine());

            switch (game)
            {
                case 1:
                    Minuetten();
                    break;
                case 2:
                    Trioen();
                    break;
            }
        }

        static void Minuetten()
        {
            Random random = new Random();
            int terningFirst;
            int terningSecond;
            int total;

            while (true)
            {
                string[,] vals =
                    {
                    {"M96", "M22", "M141", "M41", "M105", "M122", "M11", "M30", "M70", "M121", "M26", "M9", "M112", "M49", "M109", "M14"},
                    {"M32", "M6", "M128", "M63", "M146", "M46", "M134", "M81", "M117", "M39", "M126", "M56", "M174", "M18", "M116", "M83"},
                    {"M69", "M95", "M158", "M13", "M153", "M55", "M110", "M24", "M66", "M139", "M15", "M132", "M73", "M58", "M145", "M79"},
                    {"M40", "M17", "M113", "M85", "M161", "M2", "M159", "M100", "M90", "M176", "M7", "M34", "M67", "M160", "M52", "M170"},
                    {"M148", "M74", "M163", "M45", "M80", "M97", "M36", "M107", "M25", "M143", "M64", "M125", "M76", "M136", "M1", "M93"},
                    {"M104", "M157", "M27", "M167", "M154", "M68", "M118", "M91", "M138", "M71", "M150", "M29", "M101", "M162", "M23", "M151"},
                    {"M152", "M60", "M171", "M53", "M99", "M133", "M21", "M127", "M16", "M155", "M57", "M175", "M43", "M168", "M89", "M172"},
                    {"M119", "M84", "M114", "M50", "M140", "M86", "M169", "M94", "M120", "M88", "M48", "M166", "M51", "M115", "M72", "M111"},
                    {"M98", "M142", "M42", "M156", "M75", "M129", "M62", "M123", "M65", "M77", "M19", "M82", "M137", "M38", "M149", "M8"},
                    {"M3", "M87", "M165", "M61", "M135", "M47", "M147", "M33", "M102", "M4", "M31", "M164", "M144", "M59", "M173", "M78"},
                    {"M54", "M130", "M10", "M103", "M28", "M37", "M106", "M5", "M35", "M20", "M108", "M92", "M12", "M124", "M44", "M131"},
                };

                for (int i = 0; i <= 15; i++)
                {
                    terningFirst = random.Next(1, 7);
                    terningSecond = random.Next(1, 7);
                    total = terningFirst + terningSecond;

                    #region
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Kast din terning: ");
                    Console.ReadKey();
                    Console.Write("Du slog: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(terningFirst);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nKast igen: ");

                    Console.Write("Du slog: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(terningSecond);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nI alt: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(total);
                    #endregion

                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

                    sp.SoundLocation = @"C:\Programming\CSharp\SchoolProjects\MozartMT\Wave\" + vals[total - 1, i] + ".wav";
                    sp.Play();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nPlaying: " + sp.SoundLocation);

                    Console.ReadKey();
                }
            }
        }

        static void Trioen()
        {
            Random random = new Random();
            int terning;

            while (true)
            {
                string[,] vals = {
                    {"T72", "T6", "T59", "T25", "T81", "T41", "T89", "T13", "T36", "T5", "T46", "T79", "T30", "T95", "T19", "T66"},
                    {"T56", "82", "T42", "T74", "T14", "T7", "T26", "T71", "T76", "T20", "T64", "T84", "T8", "T35", "T47", "T88"},
                    {"T75", "T39", "T54", "T1", "T65", "T43", "T15", "T80", "T9", "T34", "T93", "T48", "T69", "T58", "T90", "T21"},
                    {"T40", "T73", "T16", "T68", "T29", "T55", "T2", "T61", "T22", "T67", "T49", "T77", "T57", "T87", "T33", "T10",},
                    {"T83", "T3", "T28", "T53", "T37", "T17", "T44", "T70", "T63", "T85", "T32", "T96", "T12", "T23", "T50", "T91",},
                    {"T18", "T45", "T62", "T38", "T4", "T27", "T52", "T94", "T11", "T92", "T24", "T86", "T51", "T60", "T78", "T31",}
                };

                for (int i = 0; i <= 31; i++)
                {
                    terning = random.Next(1, 7);

                    #region
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Kast din terning: ");
                    Console.ReadKey();
                    Console.Write("Du slog: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(terning);
                    #endregion

                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

                    sp.SoundLocation = @"C:\Programming\CSharp\SchoolProjects\MozartMT\Wave\" + vals[terning - 1, i] + ".wav";
                    sp.Play();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nPlaying: " + sp.SoundLocation);

                    Console.ReadKey();
                }
            }
        }
    }
}