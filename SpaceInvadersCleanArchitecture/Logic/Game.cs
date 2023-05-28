using System.Diagnostics;
using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    class TestGame : IGame, IGameObserver
    {
        static bool gameOver = false;
        static int invaderCount = 0;
        private int _invaderAnimation;


        private Stopwatch watch = new Stopwatch();
        private bool watchOff = true;
        private long duration;

        List<ProjectileController> projectiles = new List<ProjectileController>(); //TODO: Interface verwenden (aber wie?)

        public void run()
        {
            IBarrierController[] barriers = new BarrierController[4];
            InitializeBarriers(ref barriers);

            IMovableObject[,] invaders = new InvaderController[5, 11];

            InitializeInvaders(ref invaders);

            Vector2 velocity = new Vector2(0, 0);
            IMovableObject player = new PlayerController();            

            IInputController input = new InputController();

            IDisplay display = new Display();

            ICollisionController collisionController = new CollisionController();

            watch.Start();

            display.Init();
            while (display.IsOpen())
            {
                display.Clear(); // Clears the window from the previous display
                display.CheckForEvents(); // Checks for events such as closing the window

                //player.PlayerControls();
                //TODO: check if really Clean architecture
                if (player != null)
                {
                    player.Update(input.GetPlayerInput());
                    if (input.Fire())
                    {
                        duration = watch.ElapsedMilliseconds;
                        if (duration > 300)
                        {
                            AddProjectile(player.position.X + player.size.X / 2, player.position.Y, true);
                            watch.Restart();
                        }
                    }
                }                
                //input.PlayerControl();//get Playerinput and set velocity
                //Console.WriteLine("Player: " + player.PlayerRect.Position.X);
                Loop(ref player, ref invaders, ref barriers, ref projectiles);

                //CheckCollision(ref player, ref invaders, ref barriers, ref projectiles);
                collisionController.CheckCollision(ref player, ref invaders, ref barriers, ref projectiles);
                DeletOpjects(ref player, ref invaders, ref barriers, ref projectiles);
                
                display.DrawEntities(ref player, ref invaders, GetInvaderAnimation(), ref barriers, ref projectiles);
                display.Update(); // Draws on the window from the buffer

                if (player == null)
                {
                    display.Close();
                }
            }
        }

        private void InitializeInvaders(ref IMovableObject[,] invaders)
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    invaders[i, j] = new InvaderController(new Vector2(j, i), new Vector2(3, 0), i , j); // j is row, i is column
                }
            }
        }
        private void InitializeBarriers(ref IBarrierController[] barriers)
        {
            for (int i = 0; i < barriers.Length; i++)
            {
                barriers[i] = new BarrierController(i);
            }
        }

        private void Loop(ref IMovableObject player, ref IMovableObject[,] invaders, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles) // Loops through all the invaders and updates their position
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null) // checks if the element is already null
                    {
                        
                        if (true) //TODO if(!invader.idDead) implementieren
                        {
                            invaders[i, j].Update(0);
                            if(invaders[i, j].isFire)
                            {
                                AddProjectile(invaders[i, j].position.X + invaders[i, j].size.X/2, invaders[i, j].position.Y, false);
                            }
                            SetInvaderAnimation(invaders[i, j].GetAnimation());                            

                        }
                        else
                        {
                            invaders[i, j] = null;
                        }
                        
                    }
                }
            }
            /*for (int i = 0; i < barriers.Length; i++)
            {
                //barriers[i].TrackProjectile(ref player.projectiles);
            }*/

            for(int i = 0; i < projectiles.Count; i++)
            {
                if(projectiles[i] != null)
                {
                    projectiles[i].Update(0);
                }
            }

            if (invaderCount == invaders.GetLength(0) * invaders.GetLength(1))
            {
                gameOver = true;
            }
        }

        private void DeletOpjects(ref IMovableObject player, ref IMovableObject[,] invaders, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles)
        {
            DeleteProjectiles(ref projectiles);
            DeleteInvaders(ref invaders);
            DeletePlayer(ref player);
        }

        private void DeleteProjectiles(ref List<ProjectileController> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i] != null)
                {
                    if (projectiles[i].isDead == true)
                    {
                        projectiles[i] = null;
                    }
                }
            }
        }

        private void DeleteInvaders(ref IMovableObject[,] invaders)
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null)
                    {
                        if (invaders[i, j].isDead == true)
                        {
                            invaders[i, j] = null;
                        }
                    }
                }
            }
        }

        private void DeletePlayer(ref IMovableObject player)
        {
            if (player != null)
            {
                if (player.isDead)
                {
                    player = null;
                }
            }            
        }

        /*private void CheckCollision(ref IPlayerController player, ref IInvaderController[,] invaders, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles)
        {
            CheckCollisionWithBorders(ref projectiles);
            CheckCollisionWithBarriers(ref barriers, ref projectiles);
            CheckCollisionWithPlayer(ref player, ref projectiles);
            CheckCollisionWithInvader(ref invaders, ref projectiles);

        }

        private void CheckCollisionWithBorders(ref List<ProjectileController> projectiles)
        {
            for(int i = 0; i < projectiles.Count; i++)
            {
                if(projectiles[i] != null)
                {
                    if(projectiles[i].position.Y == 0 || projectiles[i].position.Y > 1920 / 2)
                    {
                        projectiles[i] = null;
                    }
                }
            }

        }

        private void CheckCollisionWithBarriers(ref IBarrierController[] barriers, ref List<ProjectileController> projectiles)
        {
            for(int i = 0; i < projectiles.Count; i++)
            {                
                for(int j = 0; j < barriers.Length; j++)
                { 
                    if(projectiles[i] != null)
                    {
                        if(!projectiles[i].isPlayerProjectile)
                        {
                            if(projectiles[i].position.Y > (barriers[j].position.Y) &&
                            ((projectiles[i].position.X >= barriers[j].position.X) && (projectiles[i].position.X <= (barriers[j].position.X + barriers[j].size.X))))
                            {
                                projectiles[i] = null;
                            }
                        }
                        else
                        {
                            if(projectiles[i].position.Y < (barriers[j].position.Y + barriers[j].size.Y) &&
                            ((projectiles[i].position.X >= barriers[j].position.X) && (projectiles[i].position.X <= (barriers[j].position.X + barriers[j].size.X))))
                            {
                                projectiles[i] = null;
                            }
                        }
                        
                    }
                }
            }
        }
                                                                              
        private void CheckCollisionWithPlayer(ref IPlayerController player, ref List<ProjectileController> projectiles)
        {
            for(int i = 0; i < projectiles.Count; i++)
            {
                if(projectiles[i] != null)
                {
                    if(!projectiles[i].isPlayerProjectile)
                    {
                        if(projectiles[i].position.Y > (player.position.Y) &&
                        ((projectiles[i].position.X >= player.position.X) && (projectiles[i].position.X <= (player.position.X + player.size.X))))
                        {
                            projectiles[i] = null;
                        }
                    }
                }
            }
        }

        private void CheckCollisionWithInvader(ref IInvaderController[,] invaders, ref List<ProjectileController> projectiles)
        {
            for(int i = 0; i < projectiles.Count; i++)
            {
                for (int j = 0; j < invaders.GetLength(0); j++)
                {
                    for (int k = 0; k < invaders.GetLength(1); k++)
                    {
                        if(projectiles[i] != null)
                        {
                            if(projectiles[i].isPlayerProjectile)
                            {
                                if(projectiles[i].position.Y < (invaders[j, k].position.Y) &&
                                ((projectiles[i].position.X >= invaders[j, k].position.X) && (projectiles[i].position.X <= (invaders[j, k].position.X + invaders[j, k].size.X))))
                                {
                                    projectiles[i] = null;
                                }
                            }                            
                        }
                    }
                }
            }            
        }*/        
            
        

        private void AddProjectile(float positionX, float positionY, bool playerProjectile)
        {

            projectiles.Add(new ProjectileController(new Vector2(positionX, positionY), playerProjectile));
        }

        private void SetInvaderAnimation(int animation)
        {
            _invaderAnimation = animation;
        }

        private int GetInvaderAnimation()
        {
            return _invaderAnimation;
        }
        
        
        
        
        
        // List of observers
        private List<IObserver> _observers = new List<IObserver>();

        // Method for adding an observer
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            _observers.Add(observer);
        }

        // Method for removing an observer
        public void Detach(IObserver observer)
        {
            Console.WriteLine("Subject: Detached an observer.");
            _observers.Remove(observer);
        }
        public void Notify()
        {
            Console.WriteLine("SpaceInvaders: Notifying observers...");
            foreach(IObserver observer in  _observers)
            {
                observer.Update(this);
            }
        }
        
    }
}
