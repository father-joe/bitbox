using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace bitbox;

public class Highscores
{
    public void Show(RenderWindow window)
    {
        // Löschen des Bildschirms
        window.Clear();

        // Erstellen des Rechtecks
        RectangleShape rectangle = new RectangleShape(new Vector2f(100, 100));
        rectangle.Position = new Vector2f(window.Size.X / 2 - 50, window.Size.Y / 2 - 50);
        rectangle.FillColor = Color.Red;

        // Zeichnen des Rechtecks auf dem Bildschirm
        window.Draw(rectangle);

        // Anzeigen des Inhalts
        window.Display();
    }
}