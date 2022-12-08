/***************************************************
**
** Playerclass for the Space Invaders Game
**
***************************************************/
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace bitbox
{
    class SpaceInvadersPlayer
    {
        public Vector2f playerSpeed = new Vector2f(0, 0);
        public RectangleShape playerRect = new RectangleShape(new Vector2f(100, 50));
        public bool isDead = false;

        private Time shootDelay = new Time();
        private Clock shootClock = new Clock();

        public List<SpaceInvadersProjectile> projectiles = new List<SpaceInvadersProjectile>();

        public void PlayerControls()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                playerSpeed.X = 3;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                playerSpeed.X = -3;
            }
            else
            {
                playerSpeed.X = 0;
            }

            if (shootDelay.AsSeconds() > 0.3f)
            {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    Fire();
                }
                shootClock.Restart();
            }

            updatePlayer();
        }

        private void updatePlayer()
        {
            shootDelay = shootClock.ElapsedTime;

            if (!(playerRect.Position.X < 0 && playerSpeed.X < 0) && !((playerRect.Position.X + playerRect.Size.X) > SpaceInvadersGame.windowSize.X && playerSpeed.X > 0))
            {
                playerRect.Position = new Vector2f(playerRect.Position.X + playerSpeed.X, playerRect.Position.Y + playerSpeed.Y);
            }
            
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
        }

        private void Fire()
        {
            projectiles.Add(new SpaceInvadersProjectile(playerRect.Position.X + playerRect.Size.X/2, playerRect.Position.Y, true));
        }

        public SpaceInvadersPlayer()
        {
            playerRect.Position = new Vector2f(playerRect.Position.X + SpaceInvadersGame.windowSize.X/2 - playerRect.Size.X/2, SpaceInvadersGame.windowSize.Y - (int)(playerRect.Size.Y*1.5));
            // Texture playerTexture
            // playerRect.Texture = playerTexture
        }
    }
}