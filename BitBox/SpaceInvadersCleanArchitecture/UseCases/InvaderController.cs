using System.Numerics;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using System.Diagnostics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class InvaderController : IMovableObject
    {
        private IGameObject invader;
        private IWindowController window = new WindowController(); //TODO warum geht nicht IWindow

        private Vector2 grid;
        private float invaderPositionInGrid;

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }

        private Vector2 _size = new Vector2();
        public Vector2 size { get { return _size; } }

        public bool isDead { get { return invader.isDead; } }

        private bool _isFire;
        public bool isFire { get { return _isFire; } }

        private int _animation = 0;
        public int GetAnimation() { return _animation;}

        private int hight = 1;
        private int speed = 0;       

        private Stopwatch watch = new Stopwatch();
        private bool watchOff = true;
        private long duration;

        private Random rand = new Random();
        private int randShoot;
        
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
            grid = new Vector2(gridX, gridY);
            UpdateInvaderLevel();
            _position = new Vector2(_size.X * 2 + ((1920 / 2) / _size.X * 3) * invader.Position.X, _position.Y); //TODO: Windowsizeentity verwednen
        }

        public void SetPosition(Vector2 position) //TODO: einbinden, auch für ander obj.
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
            speed = 8;
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
            randShoot = rand.Next(0, 300);
            if (randShoot < 1)
            {                
                _isFire = true;
            }
        }

        private void MoveInvader(int speed)
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

        private void UpdateInvaderLevel()
        {
            _position = new Vector2(_position.X, ((window.GetWindowHight() / _size.Y * 3) * invader.Position.Y) + 33 * hight);
        }

        public void SetIsDead(bool isDead)
        {
            invader.SetIsDead(isDead);
        }

        public void SetIsPlayerProjectile(bool playerProjectile)
        {
            
        }

    }
}

