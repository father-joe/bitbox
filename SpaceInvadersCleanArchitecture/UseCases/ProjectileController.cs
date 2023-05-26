using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class ProjectileController :IProjectileController
    {
        IProjectile projectile;

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }

        private Vector2 _size = new Vector2(5, 20);
        public Vector2 size { get { return _size; } }

        private Vector2 velocity = new Vector2(0, 05f);

        public bool isPlayerProjectile {get {return projectile.PlayerProjectile;}}

        public ProjectileController() {}
        public ProjectileController(Vector2 position, bool isPlayerProjectile)
        { 
            projectile = new Projectile(position, velocity, isPlayerProjectile);
            _position = position;
        }

        public void Update()
        {
            if (projectile.PlayerProjectile)
            {
                //projectileRect.Position -= velocity;
                _position = new Vector2(_position.X, _position.Y - projectile.velocity.Y);
            }
            else
            {
                //projectileRect.Position += velocity;
                _position = new Vector2(_position.X, _position.Y + projectile.velocity.Y);
            }

            projectile.LifeSpan();
        }

        
    }
}
