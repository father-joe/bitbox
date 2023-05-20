namespace bitbox
{
    public interface IDisplay
    {
        void Init();
        void OnClose(object sender, EventArgs e);
        void Close();
        void Clear();
        void Update();
    }
}