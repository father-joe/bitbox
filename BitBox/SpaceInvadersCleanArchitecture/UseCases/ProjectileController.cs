using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class ProjectileController : IMovableObject
    {
        readonly IGameObject projectile;

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }

        private Vector2 _size = new Vector2();
        public Vector2 size { get { return _size; } }

        public bool isDead { get { return projectile.isDead; } }
        
        private readonly bool _isFire = false;
        public bool isFire { get { return _isFire; } }

        private Vector2 velocity = new Vector2(0, 05f);

        public bool isPlayerProjectile {get {return projectile.PlayerProjectile;}}

        public ProjectileController()
        {
            projectile = new Projectile();
            _size = projectile.size;
        }

        public ProjectileController(Vector2 position, bool isPlayerProjectile)
        { 
            projectile = new Projectile(position, velocity, isPlayerProjectile);
            _size = projectile.size;
            SetPosition(position);
        }

        public void SetPosition(Vector2 position) //TODO: einbinden, auch für ander obj.
        {
            _position = position;
        }

        public void SetIsPlayerProjectile(bool playerProjectile)
        {
            projectile.SetPlayerProjectile(playerProjectile);             
        }

        public void Update( int direction )
        {
            if (projectile.PlayerProjectile)
            {
                _position = new Vector2(_position.X, _position.Y - projectile.Velocity.Y);
            }
            else
            {
                _position = new Vector2(_position.X, _position.Y + projectile.Velocity.Y);
            }            
        }

        public void SetIsDead(bool isDead)
        {
            projectile.SetIsDead(isDead);
        }
        
        public int GetAnimation()
        {
            return 0;
        }
    }
}
