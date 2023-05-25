using System.Numerics;
//using SFML.Graphics;
//using SFML.System;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public class SBarrier : IBarrier
    {
        //public RectangleShape BarrierRect { get; private set; }
        public int BarrierPosition { get; private set; }

        public SBarrier(int position)
        {
            BarrierPosition = position;

            //BarrierRect = new RectangleShape(new Vector2f(120, 70));
            //BarrierRect.Position = new Vector2f(BarrierRect.Size.X / 2 + (BarrierRect.Size.X * 2) * position, 600);

            //Texture barrierTexture = new Texture("./Textures/barrier.png");
            //BarrierRect.Texture = barrierTexture;
        }

        public void TrackProjectile(ref List<Projectile> projectiles)
        {
            // Logik zum Verfolgen des Projektils
        }
    }
}

