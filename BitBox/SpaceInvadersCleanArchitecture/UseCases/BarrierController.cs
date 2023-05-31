using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.Domain;
using Barrier = bitbox.SpaceInvadersCleanArchitecture.Domain.Barrier; //TODO: Was das?

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class BarrierController :IBarrierController
    {
        private IGameObject barrier;

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }

        private Vector2 _size = new Vector2();
        public Vector2 size { get { return _size; } }

        public BarrierController()
        {
            barrier = new Barrier();
            _size = barrier.size;
        }
        public BarrierController(int number)
        {
            barrier = new Barrier(number);
            _size = barrier.size;
            _position = new Vector2(_size.X/2 + (_size.X*2) * barrier.Number, 600);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }
    }
}

