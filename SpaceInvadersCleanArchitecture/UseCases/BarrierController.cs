using System.Numerics;
//using SFML.Graphics;
//using SFML.System;
//using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class BarrierController :IBarrierController
    {
        private IBarrier barrier;
        private List<Projectile> projectiles;

        //private RectangleShape _barrierRect = new RectangleShape(new Vector2f(120, 70));

        //public RectangleShape barrierRect {get {return _barrierRect;}}

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }
        private Vector2 _size = new Vector2(120, 70);
        public Vector2 size { get { return _size; } }

        public BarrierController() { }
        public BarrierController(int position2)
        {
            barrier = new SBarrier(position2);
            projectiles = new List<Projectile>();
            //_barrierRect.Position = new Vector2f(_barrierRect.Size.X/2 + (_barrierRect.Size.X*2) * barrier.BarrierPosition, 600);
            _position = new Vector2(_size.X/2 + (_size.X*2) * barrier.BarrierPosition, 600);
            // Weitere Initialisierungen
        }
    }
}

