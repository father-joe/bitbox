using bitbox.SpaceInvadersCleanArchitecture.UseCases;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public interface IDisplay
    {
        public void Init();
        public void OnClose(object sender, EventArgs e);
        public void Close();
        public void Clear();
        public void Update();
        public void DrawEntities(ref IMovableObject player, ref IMovableObject[,] invaders, int animation, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles);
        public void DrawPlayer(ref IMovableObject player);
        public void DrawInvaders(ref IMovableObject[,] invaders, int animation);
        public void DrawBarriers(ref IBarrierController[] barriers);
        public void DrawProjectiles(ref List<ProjectileController> projectiles);
        public void CheckForEvents();
        public bool IsOpen();
    }
}