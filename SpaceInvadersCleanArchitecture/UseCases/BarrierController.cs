using System.Numerics;
using SFML.Graphics;
using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class BarrierController :IBarrierController
    {
        private IBarrier barrier;
        private List<Projectile> projectiles;

        private RectangleShape _barrierRect = new RectangleShape(new Vector2f(120, 70));

        public RectangleShape barrierRect {get {return _barrierRect;}}

        public BarrierController(int position)
        {
            barrier = new SBarrier(position);
            projectiles = new List<Projectile>();
            _barrierRect.Position = new Vector2f(_barrierRect.Size.X/2 + (_barrierRect.Size.X*2) * barrier.BarrierPosition, 600);
            // Weitere Initialisierungen
        }
    }
}

