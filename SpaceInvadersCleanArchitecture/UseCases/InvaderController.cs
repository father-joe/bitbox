using System.Numerics;
using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using System.Reflection.Emit;
using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class InvaderController :IInvaderController
    {
        private IInvader invader;
        private List<IProjectile> projectiles;
        private RectangleShape _invaderRect = new RectangleShape(new Vector2f(40, 40));

        public RectangleShape invaderRect { get { return _invaderRect; } }
        private Vector2i grid;
        private float invaderPositionInGrid;

        private int hight = 1;
        private int speed = 0;

        private Time moveStep = new Time();
        private Time randomTime = new Time();
        private Clock moveClock = new Clock();
        private Clock randomClock = new Clock();
        Random rnd1; // random projectile fire
        Random rnd2; // random projectile fire
        Random rndShoot; // random projectile fire

        public InvaderController(Vector2 position, Vector2 velocity, int gridX, int gridY)
        {
            invader = new Invader(position, velocity);
            projectiles = new List<IProjectile>();
            grid = new Vector2i(gridX, gridY);
            UpdateInvaderLevel();
            _invaderRect.Position = new Vector2f(_invaderRect.Size.X * 2 + (Globals.windowSize.X / _invaderRect.Size.X * 3) * invader.InvaderPosition.X, _invaderRect.Position.Y);
            // Weitere Initialisierungen
        }

        public void Update()
        {
            /*if (hight < 7)
            {
                speed = hight; // at high speeds the invaders get out of sequence so I limited them to speed 10 as max
            }*/
            speed = 8;

            moveStep = moveClock.ElapsedTime;
            randomTime = randomClock.ElapsedTime;

            MoveInvader(speed);

            /*
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (!projectiles[i].isDead)
                {
                    projectiles[i].Update();
                }
                else
                {
                    projectiles.RemoveAt(i); // Removes the instance of the, out of window bounds, projectile
                }
            }
            */

            if (invader.InvaderPosition.Y == 4)
            {
                invader.Fire();
            }
        }

        private void MoveInvader(int speed)
        {
            
            if (!(_invaderRect.Position.X < 0 && invader.Velocity.X < 0) &&
                !((_invaderRect.Position.X + _invaderRect.Size.X) > Globals.windowSize.X && invader.Velocity.X > 0))
            {
                //Console.WriteLine("invaderRect.Position.X = " + invaderRect.Position.X);
                //Console.WriteLine("invader.Velocity.X = " + invader.Velocity.X);

                if (moveStep.AsSeconds() > 1f / (float)speed)
                {
                    //Console.WriteLine("invaderRect.Position.X alt = " + invaderRect.Position.X);

                    _invaderRect.Position = new Vector2f(_invaderRect.Position.X + invader.Velocity.X, _invaderRect.Position.Y + invader.Velocity.Y);

                    //Console.WriteLine("Position Y = " + _invaderRect.Position.Y);

                    //Console.WriteLine("invaderRect.Position.X neu = " + invaderRect.Position.X);
                    

                    /*Globals.InvaderTexture(ref invader.InvaderRect, animation);

                    if (animation == 0)
                    {
                        animation = 1;
                    }
                    else if (animation == 1)
                    {
                        animation = 0;
                    }*/
                    
                    

                   moveClock.Restart();
                }
            }
            else
            {                
                invader.ChangeDirektion();
                //if (hight < 10)
                //    hight++;
                hight++;
                UpdateInvaderLevel();
            }

            //UpdateInvaderLevel(hight);

            /*if (invaderRect.Position.Y != invaderPositionInGrid)
            {
                invaderRect.Position = new Vector2f(invaderRect.Position.X, invaderPositionInGrid);
            }*/
         
        }

        private void UpdateInvaderLevel()
        {
            _invaderRect.Position = new Vector2f(_invaderRect.Position.X, ((Globals.windowSize.Y / _invaderRect.Size.Y * 3) * invader.InvaderPosition.Y) + 20 * hight);
        }

    }
}

