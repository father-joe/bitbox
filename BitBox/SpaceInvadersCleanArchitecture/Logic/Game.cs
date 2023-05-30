﻿using System.Diagnostics;
using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    //class TestGame : IGame, IGameObserver
    public class TestGame : IGameCombined
    {
        public bool gameOver = false;
        static int invaderCount = 0;
        private int _invaderAnimation;


        private readonly Stopwatch watch = new Stopwatch();
     
        readonly List<IMovableObject> projectiles = new List<IMovableObject>();

        public void run()
        {
            
            IBarrierController[] barriers = new BarrierController[4];
            InitializeBarriers(barriers);

            IMovableObject[,] invaders = new InvaderController[5, 11];         
            InitializeInvaders(invaders);

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

                if (player != null)
                {
                    player.Update(input.GetPlayerInput());
                    if (input.Fire())
                    {
                        long duration = watch.ElapsedMilliseconds;
                        if (duration > 300)
                        {
                
                            AddProjectile(player.position.X + player.size.X / 2, player.position.Y, true);
                            watch.Restart();
                        }
                    }
                }                
                Loop(invaders, projectiles);
       
                collisionController.CheckCollision( player,  invaders,  barriers,  projectiles);                
                
                DeletOpjects( invaders,  barriers,  projectiles);
                var updatedPlayer = DeletePlayer(player); 
                display.DrawEntities(updatedPlayer,  invaders, GetInvaderAnimation(),  barriers,  projectiles);
                display.Update(); // Draws on the window from the buffer

                if (CheckIfGameOver(updatedPlayer,  invaders))
                {
                    display.Close();
                }
            }
        }

        private void InitializeInvaders( IMovableObject[,] invaders)
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    invaders[i, j] = new InvaderController(new Vector2(j, i), new Vector2(3, 0), i , j); // j is row, i is column
                }
            }
        }
        private void InitializeBarriers( IBarrierController[] barriers)
        {
            for (int i = 0; i < barriers.Length; i++)
            {
                barriers[i] = new BarrierController(i);
            }
        }

        private void Loop(IMovableObject[,] invaders, List<IMovableObject> projectiles) // Loops through all the invaders and updates their position
        {
            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null) // checks if the element is already null
                    {
                        
                        invaders[i, j].Update(0);
                        if(invaders[i, j].isFire)
                        {
                            AddProjectile(invaders[i, j].position.X + invaders[i, j].size.X/2, invaders[i, j].position.Y, false);
                        }
                        SetInvaderAnimation(invaders[i, j].GetAnimation());                            
                       
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

        public void DeletOpjects(IMovableObject[,] invaders,  IBarrierController[] barriers,  List<IMovableObject> projectiles)
        {
            //DeleteProjectiles(ref projectiles);
            DeleteProjectiles( projectiles);
            //DeleteInvaders(ref invaders);
            DeleteInvaders( invaders);
        }

        public void DeleteProjectiles(List<IMovableObject> projectiles)
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

        public void DeleteInvaders( IMovableObject[,] invaders)
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

        public IMovableObject DeletePlayer(IMovableObject player)
        {
            if (player != null)
            {
                if (player.isDead)
                {
                    player = null;
                    return player;     
                }
                return player;
            }
            return player;
        }

        public bool CheckIfGameOver( IMovableObject player,  IMovableObject[,] invaders)
        {
            if (player == null)
            {
                gameOver = true;
                return true;
            }

            for (int i = 0; i < invaders.GetLength(0); i++)
            {
                for (int j = 0; j < invaders.GetLength(1); j++)
                {
                    if (invaders[i, j] != null)
                    {
                        gameOver = false;
                        return false;
                    }                    
                }
            }
            gameOver = true;
            return true;
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
      
        
        public void NotifyOpen()
        {
            Console.WriteLine("Subject: Notifying observers...");
            foreach (IObserver observer in _observers)
            {
                observer.Open(this);
            }
        }

        public void NotifyClose()
        {
            Console.WriteLine("Subject: Notifying observers...");
            foreach (IObserver observer in _observers)
            {
                observer.Close(this);
            }
        }
    }
}
