using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using SFML.Window;
using System.Diagnostics;
using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class PlayerController : IMovableObject
    {
        private IGameObject player;
        private IGameWindow window;

        public Vector2 velocity = new Vector2(0, 0);

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }
        private Vector2 _size = new Vector2();
        public Vector2 size { get { return _size; } }
        
        public bool isDead { get { return player.isDead; } }

        private bool _isFire;
        public bool isFire { get { return _isFire; } }

        public bool isPlayerProjectile { get; }

        public PlayerController()
        {
            this.window = new Entitys.GameWindow();
            this.player = new Player(velocity);
            _size = player.size;            
            _position = new Vector2(_position.X + window.width/2 - _size.X/2, window.height - (int)(_size.Y*2));
            Console.WriteLine("Player Pos: " + _position);
        }       

        public void Update (int direction)
        {
            if(direction == 1)
            {
                velocity.X = 3;
            }
            else if (direction == 2)
            {
                velocity.X = -3;
            }
            else
            {
                velocity.X = 0;
            }

            PlayerMovement();
        }

        public void PlayerMovement()
        {           
            if (!(_position.X < 0 && velocity.X < 0) &&
                !((_position.X + _size.X) > window.width && velocity.X > 0)) //Window bounds
            {
                _position = new Vector2(_position.X + velocity.X, _position.Y + velocity.Y); //Sets the players position
            }            
        }

        public int GetAnimation()
        {
            return 0;
        }

        public void SetIsDead(bool isDead)
        {
            player.SetIsDead(isDead);
        }
        
    }
}