namespace bitbox.Interfaces
{
    public interface IDisplay
    {
        void Init();
        void OnClose(object sender, EventArgs e);
        void Close();
        void Clear();
        void Update();
        //void DrawPlayer(ref Player player);
        //void DrawInvaders(ref Invader[,] invaders);
        //void DrawBarriers(ref Barrier[] barriers);
        void CheckForEvents();
        bool IsOpen();
    }
}