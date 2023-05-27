using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class BarrierController :IBarrierController
    {
        private IBarrier barrier;

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }

        private Vector2 _size = new Vector2();
        public Vector2 size { get { return _size; } }

        public BarrierController()
        {
            barrier = new SBarrier();
            _size = barrier.size;
        }
        public BarrierController(int number)
        {
            barrier = new SBarrier(number); //TODO: Rename
            _size = barrier.size;
            _position = new Vector2(_size.X/2 + (_size.X*2) * barrier.BarrierPosition, 600);
        }
    }
}

