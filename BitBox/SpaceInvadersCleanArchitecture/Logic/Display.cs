using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public class Display : IDisplay
    {
        private RenderWindow _window;
        private IWindowController windowController = new WindowController();

        private IBarrierController initBarrier;
        private IMovableObject initInvader;
        private IMovableObject initPlayer;
        private ITextureManager textureManager;
        private IMovableObject initProjectile;

        private RectangleShape barrierRect;
        private RectangleShape invaderRect;
        private RectangleShape playerRect;
        private RectangleShape projectileRect;
        private bool _isClosed;



        public void Init()
        {
            initBarrier = new BarrierController();
            barrierRect = new RectangleShape(new Vector2f(initBarrier.size.X, initBarrier.size.Y));

            initInvader = new InvaderController();
            invaderRect = new RectangleShape(new Vector2f(initInvader.size.X, initInvader.size.Y));

            initPlayer = new PlayerController();
            Console.WriteLine("Size: " + initPlayer.size);
            playerRect = new RectangleShape(new Vector2f(initPlayer.size.X, initPlayer.size.Y));

            initProjectile = new ProjectileController();
            Console.WriteLine("Projectile Size: " + initProjectile.size);
            projectileRect = new RectangleShape(new Vector2f(initProjectile.size.X, initProjectile.size.Y));

            textureManager = new TextureManager();

            ContextSettings settings = new ContextSettings();
            settings.DepthBits = 24;
            settings.MajorVersion = 3;
            settings.MinorVersion = 3;         

            _window = new RenderWindow(new VideoMode((uint)windowController.GetWindowWidth(), (uint)windowController.GetWindowHight()), "Space Invader");
            SetIsClosed(_window.IsOpen);
            Console.WriteLine("windowController: " + windowController.GetWindowWidth());
            _window.SetFramerateLimit(60);
        }

        public void SetIsClosed(bool isClosed)
        {
            _isClosed = isClosed;
        }

        public bool GetIsClosed()
        {
            return _isClosed;
        }

        public void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            Close();
        }
        public void Close()
        {
            _window.Close();
            SetIsClosed(_window.IsOpen);
        }

        public void Clear()
        {
            _window.Clear();
        }

        public void Update()
        {
            _window.Display();
        }

        //public void DrawEntities(ref IMovableObject player, ref IMovableObject[,] invaders, int animation, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles)
        public void DrawEntities( IMovableObject player,  IMovableObject[,] invaders, int animation,  IBarrierController[] barriers,  List<IMovableObject> projectiles)
        {
            DrawPlayer( player);
            DrawInvaders( invaders, animation);
            DrawBarriers( barriers);
            DrawProjectiles( projectiles);
        }

        public void DrawPlayer( IMovableObject player)
        {
            if (player != null)
            {
                playerRect.Position = new Vector2f(player.position.X, player.position.Y);
                playerRect.Texture = textureManager.GetPlayerTexture();
                _window.Draw(playerRect);
            }
            
        }
        
        public void DrawInvaders( IMovableObject[,] invaders, int animation)
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null) // checks if the element is null
                    {
                        invaderRect.Position = new Vector2f(invaders[i, j].position.X, invaders[i, j].position.Y);
                        invaderRect.Texture = textureManager.GetInvaderTextrue(animation);
                        _window.Draw(invaderRect);
                    }
                }
            }
        }

        public void DrawBarriers( IBarrierController[] barriers)
        {
            for (int i = 0; i < barriers.Length; i++)
            {
                barrierRect.Position = new Vector2f(barriers[i].position.X, barriers[i].position.Y);
                barrierRect.Texture = textureManager.GetBarrierTexture();
                _window.Draw(barrierRect);
            }
        }

        public void DrawProjectiles( List<IMovableObject> projectiles)
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
    }
}

