using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys
{
    public class Barrier : IGameObject
    {
        public int Number { get; private set; }
        private Vector2 _size = new Vector2(120, 70);
        public Vector2 size { get; private set; }
        public Vector2 Velocity { get; private set; }

        public bool PlayerProjectile { get; }
        public bool isDead { get; }
        public Vector2 Position { get; private set; }

        public Barrier()
        {
            size = _size;
        }

        public Barrier(int number)
        {
            Number = number;
            size = _size;
        }

        public void SetPlayerProjectile(bool isPlayerProjectile)
        {
            throw new NotImplementedException();
        }

        public void ChangeDirektion(){ throw new NotImplementedException();  }

        public void SetIsDead(bool isDead) { throw new NotImplementedException(); }

        public bool GetIsDead()
        {
            return false;
        }
    }
}




