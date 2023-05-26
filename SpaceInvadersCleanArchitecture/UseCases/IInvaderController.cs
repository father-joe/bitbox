using SFML.Graphics;
using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public interface IInvaderController
    {
        //public RectangleShape invaderRect { get; }

        public Vector2 position { get; }
        public Vector2 size { get; }

        public bool isFire { get; }
        public int GetAnimation();
        public void Update();
    }
}