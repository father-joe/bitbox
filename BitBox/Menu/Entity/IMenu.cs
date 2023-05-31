namespace bitbox.Menu.Entitys
{
    public interface IMenu
    {
        uint height { get; }
        uint width { get; }

        int numberItems { get; }

        string name { get; }
    }
}
