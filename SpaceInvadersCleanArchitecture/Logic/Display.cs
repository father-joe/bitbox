using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    class Display : IDisplay
    {
        private RenderWindow _window;
        private IWindowController windowController = new WindowController();

        private IBarrierController initBarrier;
        private IInvaderController initInvader;
        private IPlayerController initPlayer;
        private ITextureManager textureManager;
        private IProjectileController initProjectile;

        private RectangleShape barrierRect;
        private RectangleShape invaderRect;
        private RectangleShape playerRect;
        private RectangleShape projectileRect;



        public void Init()
        {
            initBarrier = new BarrierController();
            barrierRect = new RectangleShape(new Vector2f(initBarrier.size.X, initBarrier.size.Y));

            initInvader = new InvaderController();
            invaderRect = new RectangleShape(new Vector2f(initInvader.size.X, initInvader.size.Y));

            initPlayer = new PlayerController();
            playerRect = new RectangleShape(new Vector2f(initPlayer.size.X, initPlayer.size.Y));

            initProjectile = new ProjectileController();
            projectileRect = new RectangleShape(new Vector2f(initProjectile.size.X, initProjectile.size.Y));

            textureManager = new TextureManager();

            ContextSettings settings = new ContextSettings();
            settings.DepthBits = 24;
            settings.MajorVersion = 3;
            settings.MinorVersion = 3;         

            _window = new RenderWindow(new VideoMode((uint)windowController.GetWindowWidth(), (uint)windowController.GetWindowHight()), "Space Invader");
            Console.WriteLine("windowController: " + windowController.GetWindowWidth());
            Console.WriteLine("Globals: " + Globals.windowSize.X);
            _window.SetFramerateLimit(60);
        }

        public void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            Close();
        }
        public void Close()
        {
            _window.Close();
        }

        public void Clear()
        {
            _window.Clear();
        }

        public void Update()
        {
            _window.Display();
        }

        public void DrawPlayer(ref IPlayerController player)
        {
            //Console.WriteLine(player.PlayerRect.Position.X);
            //_window.Draw(player.PlayerRect);

            playerRect.Position = new Vector2f(player.position.X, player.position.Y);
            playerRect.Texture = textureManager.GetPlayerTexture();
            _window.Draw(playerRect);

            /*for (int i = 0; i < player.projectiles.Count; i++)
            {
                _window.Draw(player.projectiles[i].projectileRect);
            }*/
        }
        public void DrawInvaders(ref IInvaderController[,] invaders, int animation)
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null) // checks if the element is null
                    {
                        //_window.Draw(invaders[i, j].invaderRect);

                        invaderRect.Position = new Vector2f(invaders[i, j].position.X, invaders[i, j].position.Y);
                        invaderRect.Texture = textureManager.GetInvaderTextrue(animation);
                        _window.Draw(invaderRect);

                        /*
                        for (int p = 0; p < invaders[i, j].projectiles.Count; p++)
                        {
                            _window.Draw(invaders[i, j].projectiles[p].projectileRect);
                        }
                        */
                    }
                }
            }
        }

        public void DrawBarriers(ref IBarrierController[] barriers)
        {
            for (int i = 0; i < barriers.Length; i++)
            {
                barrierRect.Position = new Vector2f(barriers[i].position.X, barriers[i].position.Y);
                barrierRect.Texture = textureManager.GetBarrierTexture();
                _window.Draw(barrierRect);
            }
        }

        public void DrawProjectiles(ref List<ProjectileController> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if(projectiles[i] != null)
                {
                    projectileRect.Position = new Vector2f(projectiles[i].position.X, projectiles[i].position.Y);
                    _window.Draw(projectileRect);
                }
                
            }
        }

        public void CheckForEvents()
        {
            _window.DispatchEvents();
            _window.Closed += OnClose;
        }

        public bool IsOpen()
        {
            return _window.IsOpen;
        }

        /*
        private static Display _Instance; // Singleton
        private Display() { }
        public static Display GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Display();
            }

            return _Instance;
        }
        */
    }
}

