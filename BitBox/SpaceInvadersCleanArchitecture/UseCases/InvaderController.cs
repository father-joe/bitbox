using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using System.Diagnostics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class InvaderController : IMovableObject
    {
        private readonly IGameObject invader;
        private readonly IWindowController window = new WindowController();

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }

        private Vector2 _size;
        public Vector2 size { get { return _size; } }

        public bool isDead { get { return invader.isDead; } }

        private bool _isFire;
        public bool isFire { get { return _isFire; } }

        private int _animation = 0;
        public int GetAnimation() { return _animation;}

        private int hight = 1;
        private readonly int speed = 8;       

        private readonly Stopwatch watch = new Stopwatch();
        private bool watchOff = true;
        public long duration;

        private readonly Random rand = new Random();
        
        public bool isPlayerProjectile { get; }

        public InvaderController()
        {
            invader = new Invader();
            _size = invader.size;
            Console.WriteLine("Invader Size: " + invader.size);
        }

        public InvaderController(Vector2 position, Vector2 velocity, int gridX, int gridY)
        {            
            invader = new Invader(position, velocity);
            _size = invader.size;
            UpdateInvaderLevel();
            _position = new Vector2(_size.X * 2 + (window.GetWindowWidth() / _size.X * 3) * invader.Position.X, _position.Y);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public void Update( int direction )
        {
            if(watchOff)
            {
                watch.Start();
                watchOff = false;
            }
            _isFire = false;

            duration = watch.ElapsedMilliseconds;          

            MoveInvader(speed);

            if (invader.Position.Y == 4)
            {
                Fire();
            }
        }

        private void Fire()
        {
             int randShoot = rand.Next(0, 300);
            if (randShoot < 1)
            {                
                _isFire = true;
            }
        }

        public void MoveInvader(int speed)
        {
            
            if (!(_position.X < 0 && invader.Velocity.X < 0) &&
                !((_position.X + _size.X) > window.GetWindowWidth() && invader.Velocity.X > 0))
            {

                if (duration > 1000 / (long)speed)
                {
                    _position = new Vector2(_position.X + invader.Velocity.X, _position.Y + invader.Velocity.Y);

                    if (_animation == 0)
                    {
                        _animation = 1;
                    }
                    else if (_animation == 1)
                    {
                        _animation = 0;
                    }
                                                          
                    watch.Restart();
                }
            }
            else
            {                
                invader.ChangeDirektion();
                hight++;
                UpdateInvaderLevel();
            }
         
        }

        public void UpdateInvaderLevel()
        {
            _position = new Vector2(_position.X, ((window.GetWindowHight() / _size.Y * 3) * invader.Position.Y) + 33 * hight);
        }

        public void SetIsDead(bool isDead)
        {
            invader.SetIsDead(isDead);
        }

        public void SetIsPlayerProjectile(bool playerProjectile)
        {
            throw new NotImplementedException();
        }

    }
}

