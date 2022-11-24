/***************************************************
**
** Playerclass for the Space Invaders Game
**
***************************************************/
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace bitbox
{
    class SpaceInvadersPlayer
    {
        public Vector2f playerSpeed = new Vector2f(0, 0);
        public RectangleShape playerRect = new RectangleShape(new Vector2f(100, 50));
        public bool isDead = false;

        public SpaceInvadersPlayer()
        {

        }
    }
}