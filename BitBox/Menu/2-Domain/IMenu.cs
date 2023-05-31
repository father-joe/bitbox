namespace bitbox.Menu.Domain
{
    public interface IMenu
    {
        uint height { get; }
        uint width { get; }

        int numberItems { get; }

        string name { get; }
    }
}
