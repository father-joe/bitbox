using SFML.Graphics;
using SFML.Audio;
using System.Text;

namespace bitbox
{
    /// <summary>
    /// Class for handling IO and storing the game assets
    /// </summary>
    public static class Assets
    {
        public static Texture Background { get; private set; }
        public static List<Texture> Tetrominos { get; private set; }
        public static List<Texture> Block { get; private set; }
        public static List<Texture> Preview { get; private set; }
        public static SFML.Graphics.Font Font { get; private set; }
        public static Texture Icon { get; private set; }
        public static Sound Move { get; private set; }
        public static Sound ClrLn { get; private set; }
        public static Sound Tetris { get; private set; }
        public static Sound Place { get; private set; }
        public static Sound Die { get; private set; }

        private static string path = @"Assets\Data.dat";

        static Assets()
        {
            Tetrominos = new List<Texture>();
            Block = new List<Texture>();
            Preview = new List<Texture>();
        }

        public static void LoadAssets()
        {
            // Load Background Texture
            Background = new Texture("./Textures/Background.png");

            // Load Block Textures
            Block.Add(new Texture("./Textures/blocks32.png", new IntRect(256, 0, 32, 32)));
            for (int i = 0; i < 8; i++)
            {
                Block.Add(new Texture("./Textures/blocks32.png", new IntRect(i * 32, 0, 32, 32)));
            }

            // Load Preview
            for (int i = 0; i < 5; i++)
            {
                Preview.Add(new Texture("./Textures/Prev_Tetromino.png", new IntRect(i * 96, 0, 96, 64)));
            }
            Preview.Add(new Texture("./Textures/Prev_Tetromino.png", new IntRect(480, 0, 64, 64)));
            Preview.Add(new Texture("./Textures/Prev_Tetromino.png", new IntRect(545, 16, 128, 32)));

            // Fix order
            Texture temp = Preview[2];
            Preview[2] = Preview[3];
            Preview[3] = temp;

            // Load font
            Font = new SFML.Graphics.Font("./Fonts/Font.ttf");

            // Load icon
            Icon = new Texture("./Textures/Icon.png");

            // Load Sounds
            Die = new Sound(new SoundBuffer("./Audio/Die.wav"));
            Move = new Sound(new SoundBuffer("./Audio/Move.wav"));
            Place = new Sound(new SoundBuffer("./Audio/Place.wav"));
            ClrLn = new Sound(new SoundBuffer("./Audio/LnClear.wav"));
            Tetris = new Sound(new SoundBuffer("./Audio/Tetris.wav"));
        }

        public static void DisposeAssets()
        {
            Background.Dispose();
            foreach (Texture t in Tetrominos) t.Dispose();
            foreach (Texture t in Block) t.Dispose();
            foreach (Texture t in Preview) t.Dispose();
            Font.Dispose();
            Icon.Dispose();
            Move.Dispose();
            ClrLn.Dispose();
            Tetris.Dispose();
            Place.Dispose();
            Die.Dispose();
        }

        public static void SaveHighScore(int score)
        {
            // Data to save
            string encriptedData = XOR(Convert.ToString((long)score * 3895177120L, 2));

            // Delete existing file
            if (File.Exists(path)) File.Delete(path);

            // Create a file to write to
            using (var sw = File.CreateText(path))
            {
                sw.Write(encriptedData);
            }
        }

        public static int RetreiveHighScore()
        {
            if (!File.Exists(path)) return 0;

            string data = XOR(File.ReadAllText(path));
            long score = Convert.ToInt64(data, 2) / 3895177120L;
            
            return (int)score;
        }

        private static string XOR(string data)
        {
            string key = "9eJ;+^/Ic>c{XcgH";

            var result = new StringBuilder();

            // XOR Data
            for (int i = 0; i < data.Length; i++)
                result.Append((char)((uint)data[i] ^ (uint)key[i % key.Length]));

            return result.ToString();
        }
    }
}
