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

        public void PlayerControls()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                playerSpeed.X = 3;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                playerSpeed.X = -3;
            }
            else
            {
                playerSpeed.X = 0;
            }

            updatePlayer();
        }

        private void updatePlayer()
        {
            if (!(playerRect.Position.X < 0 && playerSpeed.X < 0) && !((playerRect.Position.X + playerRect.Size.X) > SpaceInvadersGame.windowSize.X && playerSpeed.X > 0))
            {
                playerRect.Position = new Vector2f(playerRect.Position.X + playerSpeed.X, playerRect.Position.Y + playerSpeed.Y);
            }
        }

        public SpaceInvadersPlayer()
        {
            playerRect.Position = new Vector2f(playerRect.Position.X + SpaceInvadersGame.windowSize.X/2 - playerRect.Size.X/2, SpaceInvadersGame.windowSize.Y - (int)(playerRect.Size.Y*1.5));
            // Texture playerTexture
            // playerRect.Texture = playerTexture
        }
    }
}