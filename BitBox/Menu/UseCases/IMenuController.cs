namespace bitbox.Menu.UseCases
{
    public interface IMenuController
    {
        string[] menuElements { get; set; }
        int currentIndex { get; set; }

        public int moveMenuSelect(int menuInput);
        
        


    }
}
