/***************************************************
**
** Invaderclass for the Space Invaders Game
**
***************************************************/
using SFML.Graphics;
using SFML.System;

namespace bitbox
{
    class SpaceInvadersInvader
    {
        public RectangleShape invaderRect = new RectangleShape(new Vector2f(40, 40));
        public bool isDead = false;
        private static Vector2f speed = new Vector2f(SpaceInvadersGame.windowSize.X/80, 0);
        private Vector2i invaderPosition = new Vector2i(0, 0);

        private static float newLevelPosition;
        private static int level = 1;
        private static int tempLevel = 0;

        private Time moveStep = new Time();
        private Time randomTime = new Time();
        private Clock moveClock = new Clock();
        private Clock randomClock = new Clock();

        private Vector2i grid;

        public List<SpaceInvadersProjectile> projectiles = new List<SpaceInvadersProjectile>();

        Random random1;
        Random random2;
        Random randomShoot;

        public SpaceInvadersInvader(Vector2i position, int gridX, int gridY)
        {
            random1 = new Random(position.X * position.Y * 10);
            random2 = new Random((position.Y + 1) / (position.X + 1) * 100);
            randomShoot = new Random(invaderPosition.X + invaderPosition.Y + gridX + gridY);
            grid = new Vector2i(gridX, gridY);

            invaderPosition = position;
            UpdateLevel();
            invaderRect.Position = new Vector2f(invaderRect.Size.X*2 + (SpaceInvadersGame.windowSize.X / invaderRect.Size.X * 3) * invaderPosition.X, newLevelPosition);
        }

        public void UpdateInvader()
        {

            if (level < 7)
            {
                tempLevel = level;
            }

            moveStep = moveClock.ElapsedTime;
            randomTime = randomClock.ElapsedTime;

            MoveInvader();

            for (int i = 0; i < projectiles.Count; i++)
            {
                if (!projectiles[i].isDead)
                {
                    projectiles[i].Update();
                }
                else
                {
                    projectiles.RemoveAt(i);
                }
            }

            if (invaderPosition.Y == 4)
            {
                Fire();
            }

        }

        private void MoveInvader()
        {
            if (!(invaderRect.Position.X < 0 && speed.X < 0) &&
                !((invaderRect.Position.X + invaderRect.Size.X) > SpaceInvadersGame.windowSize.X && speed.X > 0))
            {
                if (moveStep.AsSeconds() > 1f / (float)tempLevel)
                {
                    invaderRect.Position = new Vector2f(invaderRect.Position.X + speed.X, invaderRect.Position.Y + speed.Y);                 
                    moveClock.Restart();
                }
            }
            else
            {
                speed.X *= -1;
                if(level < 10)
                    level++;
            }

            UpdateLevel();

            if (invaderRect.Position.Y != newLevelPosition)
            {
                invaderRect.Position = new Vector2f(invaderRect.Position.X, newLevelPosition);
            }

        }
        private void UpdateLevel()
        {
            newLevelPosition = ((SpaceInvadersGame.windowSize.Y / invaderRect.Size.Y * 3) * invaderPosition.Y) + 20 * level;
        }   

        private void Fire()
        {
            if (randomTime.AsSeconds() > randomShoot.Next(1, 20))
            {
                if (random1.Next(1, 20) == random2.Next(1, 20))
                {
                    projectiles.Add(new SpaceInvadersProjectile(invaderRect.Position.X + invaderRect.Size.X / 2, invaderRect.Position.Y));
                }

                randomClock.Restart();
            }
        }     
    }
}