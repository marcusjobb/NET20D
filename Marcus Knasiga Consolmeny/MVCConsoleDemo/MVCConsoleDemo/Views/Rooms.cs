namespace MVCConsoleDemo.Views
{
    using MVCConsoleDemo.GameObjects;
    using MVCConsoleDemo.Helpers;
    using System.Collections.Generic;
    using System.Linq;

    public static class Rooms
    {
        public static void ShowRoom(int room)
        {
            switch (room)
            {
                case 0:
                    Stats.Display.Info("InfoBox",
                            "Du står utanför ett sött litet grönt hus med bruna takpannor.",
                            "Framför dig ser du en dörr och under dörren finns en dörrmatta");

                    Stats.Display.Info("InfoBox",
                        "Du står utanför ett sött litet grönt hus med bruna takpannor.",
                        "Framför dig ser du en dörr och under dörren finns en dörrmatta");

                    ShowList("Left1", "Riktningar du kan gå", Stats.Directions.Where(s => s.Room == room && s.IsVisible).ToList());
                    ShowList("Left2", "Saker", Stats.Items.Where(s => s.Room == room && s.IsVisible));

                    Stats.Display.Info("BottomMenu",
                        "Använd pil upp/ner för att styra. Byt fönster med Tab. Välj med ENTER.");
                    break;

                default:
                    Stats.Display.Info("Popup",
                        "Du har gått vilse!",
                        "Jag teleporterar dig tillbaka hem");
                    Stats.Room = 0;
                    break;
            }
            Stats.Display.ShowBoxes();
        }

        private static void ShowList(string boxname, string caption, IEnumerable<Item> list)
        {
            var box = Stats.Display.GetBox(boxname);
            box.Cls();
            box.Print("- " + caption);
            foreach (var thing in list)
            {
                box.Print(thing.Name);
                foreach (var action in thing.Actions)
                {
                    box.Print("   * " + action.Value, action.Key);
                }
            }
            box.MenuRow = -1;
            box.MoveDown();
        }
    }
}