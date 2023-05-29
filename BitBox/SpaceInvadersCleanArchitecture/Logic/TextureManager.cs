using SFML.Graphics;

namespace bitbox.SpaceInvadersCleanArchitecture.Logic
{
    public class TextureManager : ITextureManager
    {
        private Texture _barrierTexture;
        private Texture _playerTexture;
        private Texture[] _invaderTexture = new Texture[2];

        public TextureManager()
        {
            _barrierTexture = new Texture("./Textures/barrier.png");
            _playerTexture = new Texture("./Textures/player.png");
            SetInvaderTexture();          
        }

        private void SetInvaderTexture()
        {
            _invaderTexture[0] = new Texture("./Textures/invader1.png");
            _invaderTexture[1] = new Texture("./Textures/invader2.png");
        }

        public Texture GetBarrierTexture()
        {
            return _barrierTexture;
        }

        public Texture GetPlayerTexture()
        {
            return _playerTexture;
        }

        public Texture GetInvaderTextrue(int animation)
        {
            return _invaderTexture[animation];
        }

    }
}