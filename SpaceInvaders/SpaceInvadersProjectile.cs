/***************************************************
**
** Projectileclass for the Space Invaders Game
**
***************************************************/
using SFML.Graphics;
using SFML.System;

namespace bitbox
{
    class SpaceInvadersProjectile
    {
        public bool playerProjectile = false;
        public bool isDead = false;
        public RectangleShape projectileRect = new RectangleShape(new Vector2f(5, 20));
        private Vector2f speed = new Vector2f(0, 05f);
        
        public SpaceInvadersProjectile(float positionX, float positionY, bool playerProjectile = false)
        {
            this.playerProjectile = playerProjectile;
            Vector2f position = new Vector2f(positionX, positionY);
            projectileRect.Position = position;
        }

        public void Update()
        {
            if (playerProjectile)
            {
                projectileRect.Position -= speed;
            }
            else
            {
                projectileRect.Position += speed;
            }

            LifeSpan();
        }

        public void LifeSpan()
        {
            if (projectileRect.Position.Y < 0 && playerProjectile)
            {
                isDead = true;
            }
            else if(projectileRect.Position.Y > SpaceInvadersGame.windowSize.Y && !playerProjectile)
            {
                isDead = true;
            }
        }
    }
}