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
        public void DrawEntities( IMovableObject player,  IMovableObject[,] invaders, int animation,  IBarrierController[] barriers,  List<IMovableObject> projectiles);
        public void DrawPlayer( IMovableObject player);
        public void DrawInvaders( IMovableObject[,] invaders, int animation);
        public void DrawBarriers( IBarrierController[] barriers);
        public void DrawProjectiles( List<IMovableObject> projectiles);
        public void CheckForEvents();
        public bool IsOpen();
    }
}