using System;
using static System.Console;
using System.Media;
using AsciiArtUtil;

namespace BadApple
{
    class Program
    {
        public static SoundPlayer musicPlayer = new SoundPlayer();

        static void Main(string[] args)
        {
            Title = "Bad Apple!";

            BackgroundColor = ConsoleColor.White;

            ForegroundColor = ConsoleColor.Black;

            var frameFiles = Directory.GetFiles("Images");

            var musicFile = Directory.GetFiles("Music");

            int width = 230;

            int height = 74;

            SetWindowSize(width, height);

            SetBufferSize(width, height);

            int speed = ChooseSpeed();
            
            Clear();

            SetCursorPosition(0, 0);

            PlayMusic(musicFile[0]);

            foreach (var frame in frameFiles)
            {
                AnimationUtils.Animate(frame, speed);
            }

            ReadKey(true);
        }

        public static int ChooseSpeed()
        {
            WriteLine("What Speed Do You Want? 0 To 100 (The higher, The Slower, 0 Is Normal)");

            try
            {
                int speed = Convert.ToInt32(ReadLine());

                if (speed < 1)
                {
                    WriteLine("Speed Set To 0");

                    speed = 0;
                }
                else if (speed > 100)
                {
                   WriteLine("Speed Set To 100");

                    speed = 100; 
                }

                WriteLine("Enter To Start");

                ReadLine();
                
                return speed;
            }
            catch (Exception e)
            {
                WriteLine("Input Is Invalid " + e);

                WriteLine("Speed Set To 0");
            }

            return 0;
        }

        public static void PlayMusic(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Image file not found!", filePath);
            }

            musicPlayer.SoundLocation = filePath;

            musicPlayer.Play();
        }
    }
}