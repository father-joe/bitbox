using System.Numerics;

namespace bitbox.SpaceInvadersCleanArchitecture.Entitys.alt
{
    public interface IBarrier
    {
        int BarrierPosition { get; }
        Vector2 size { get;  }
    }
}