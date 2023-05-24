using System.Numerics;
using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using System.Reflection.Emit;
using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class InvaderController
    {
        private IInvader invader;
        private List<IProjectile> projectiles;

        public RectangleShape invaderRect = new RectangleShape(new Vector2f(40, 40));
        private Vector2i grid;
        private float invaderPositionInGrid;

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
            invaderRect.Position = new Vector2f(invaderRect.Size.X * 2 + (Globals.windowSize.X / invaderRect.Size.X * 3) * invader.InvaderPosition.X, invaderPositionInGrid);
            // Weitere Initialisierungen
        }

        public void Update(int level, int tempLevel)
        {
            if (level < 7)
            {
                tempLevel = level; // at high speeds the invaders get out of sequence so I limited them to speed 10 as max
            }

            moveStep = moveClock.ElapsedTime;
            randomTime = randomClock.ElapsedTime;

            MoveInvader(level, tempLevel);

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

        private void MoveInvader(int level, int tempLevel)
        {
            if (!(invaderRect.Position.X < 0 && invader.Velocity.X < 0) &&
                !((invaderRect.Position.X + invaderRect.Size.X) > Globals.windowSize.X && invader.Velocity.X > 0))
            {
                if (moveStep.AsSeconds() > 1f / (float)tempLevel)
                {
                    invaderRect.Position = new Vector2f(invaderRect.Position.X + invader.Velocity.X, invaderRect.Position.Y + invader.Velocity.Y);
                    

                    /*Globals.InvaderTexture(ref invader.InvaderRect, animation);

                    if (animation == 0)
                    {
                        animation = 1;
                    }
                    else if (animation == 1)
                    {
                        animation = 0;
                    }
                    */
                    

                    moveClock.Restart();
                }
            }
            else
            {
                //invader.Velocity.X *= -1;
                if (level < 10)
                    level++;
            }

            UpdateInvaderLevel(level);

            if (invaderRect.Position.Y != invaderPositionInGrid)
            {
                invaderRect.Position = new Vector2f(invaderRect.Position.X, invaderPositionInGrid);
            }
         
        }

        void UpdateInvaderLevel(int level)
        {
            invaderPositionInGrid = ((Globals.windowSize.Y / invaderRect.Size.Y * 3) * invader.InvaderPosition.Y) + 20 * level;
        }

    }
}

