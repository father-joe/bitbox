using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public interface ITextureManager
    {
        public Texture GetBarrierTexture();
        public Texture GetPlayerTexture();
        public Texture GetInvaderTextrue(int animation);
    }
}