namespace MVCConsoleDemo.Controllers
{
    using MVCConsoleDemo.GameObjects;
    using MVCConsoleDemo.Helpers;
    using MVCConsoleDemo.ScreenObjects;
    using MVCConsoleDemo.Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Helpers.Input;
    using static Helpers.Output;

    public class Start
    {
        public void PrepareGame()
        {
            Stats.MainY = 4;
            Stats.MainX = 3;
            Stats.Room = 0;
            Stats.Display = new Display();
            Stats.Display.Boxes.Add(Display.NewBox(0, 0, 79, 21, "InfoBox"));
            Stats.Display.Boxes.Add(Display.NewBox(85, 0, 30, 5, "Left1"));
            Stats.Display.Boxes.Add(Display.NewBox(85, 7, 30, 10, "Left2"));
            Stats.Display.Boxes.Add(Display.NewBox(0, 23, 115, 3, "BottomMenu"));
            Stats.Display.Boxes.Add(Display.NewBox(12, 5, 57, 10, "Popup"));
            Stats.Display.GetBox("InfoBox").NotChoosable = true;
            Stats.Display.GetBox("Popup").Visible = false;
            Stats.Display.GetBox("BottomMenu").NotChoosable = true;
            Stats.Display.GetBox("Left1").IsActive = true;

            Stats.Directions.AddRange(new List<Item>
            {
                new Item{ Room = 0, Name="In", IsVisible=true, Status=ItemStatus.Nothing,
                    Actions= new Dictionary<string,string>
                    {
                        { "DoorIsLocked","Öppna dörren" },
                        { "GoLost", "Till skogen" },
                    }
                },
            });

            Stats.Items.AddRange(new List<Item>
            {
                new Item{ Room = 0, Name="Dörr", IsVisible=true, Status=ItemStatus.Nothing,
                    Actions= new Dictionary<string,string>
                    {
                        { "DoorIsLocked","Öppna" },
                    }
                },

                new Item{ Room = 0, Name="Dörrmatta", IsVisible=true, Status=ItemStatus.Nothing,
                    Actions= new Dictionary<string,string>
                    {
                        { "ShowKey","Titta" },
                    }
                },
                new Item{ Room = 0, Name="Nyckel", IsVisible=false, Status=ItemStatus.Nothing,
                    Actions= new Dictionary<string,string>
                    {
                        { "UseKeyOnFloor","Lås upp dörr" },
                        { "PickUpKey","Plocka upp nyckeln" },
                    }
                },
            }
            );
        }

        public void ShowMenu()
        {
            ConClear();
            while (true)
            {
                Rooms.ShowRoom(Stats.Room);
                Stats.Display.ShowBoxes();
                Stats.CurrentY = 0;
                var key = ConsoleKey.D1;
                var box = Stats.Display.ActiveBox();
                do
                {
                    box = Stats.Display.ActiveBox();
                    key = GetKey();
                    if (key == ConsoleKey.UpArrow) box.MoveUp();
                    if (key == ConsoleKey.DownArrow) box.MoveDown();
                    if (key == ConsoleKey.Tab) Stats.Display.NextBox();
                } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);

                var option = box.Lines[box.MenuRow + 1].Key;
                switch (option)
                {
                    case "DoorIsLocked":
                        var hasKey = Stats.Items.FirstOrDefault(n => n.Name == "Nyckel").Status;
                        if (hasKey == ItemStatus.IsTaken)
                        {
                            Stats.Display.Info("Popup", "Du låste upp dörren");
                            RemoveActionFromItem("Dörr", "DoorIsLocked");
                            AddActionToItem("Dörr", "Gå in", "WalkIn");
                        }
                        else
                            Stats.Display.Info("Popup", "Dörren är låst");
                        break;

                    case "WalkIn":
                        Stats.Display.Info("Popup", "Du gick in i huset");
                        Stats.Room = 1;
                        break;

                    case "ShowKey":
                        Stats.Display.Info("Popup", "Det ligger en nyckel under dörrmattan");
                        Stats.Items.FirstOrDefault(n => n.Name == "Nyckel").IsVisible = true;
                        RemoveActionFromItem("Dörrmatta", "ShowKey");
                        AddActionToItem("Dörrmatta", "Titta", "LookDoorMat");
                        break;

                    case "GoLost":
                        Stats.Display.Info("Popup", "Du gick vilse i skogen", "Men ett snällt troll ledde dig hem igen");
                        Stats.Room = 0;
                        break;

                    case "UseKeyOnFloor":
                        Stats.Display.Info("Popup", "Du måste plocka upp nyckeln först");
                        break;

                    case "PickUpKey":
                        Stats.Display.Info("Popup", "Du plockade upp nyckeln");
                        Stats.Items.FirstOrDefault(n => n.Name == "Nyckel").Status = ItemStatus.IsTaken;
                        Stats.Items.FirstOrDefault(n => n.Name == "Nyckel").IsVisible = false;
                        break;

                    case "LookDoorMat":
                        Stats.Display.Info("Popup", "Det är en fin dörrmatta");
                        break;

                    default:
                        Stats.Display.Info("Popup",
                            "Jag förstod inte ditt val", option);
                        break;
                }
                Stats.Display.GetBox("Popup").Visible = true;
                Stats.Display.InfoAdd("Popup",
                    "", "", "Tryck Enter för att fortsätta");
                Pause();
                Stats.Display.GetBox("Popup").Visible = false;
            }
        }

        private void AddActionToItem(string name, string value, string key)
        {
            var obj = Stats.Items.FirstOrDefault(i => i.Name == name);
            if (obj != null)
            {
                obj.Actions.Add(key, value);
            }
        }

        private static void RemoveActionFromItem(string name, string action)
        {
            var obj = Stats.Items.FirstOrDefault(i => i.Name == name);
            if (obj != null)
            {
                var act = obj.Actions.Remove(action);
            }
        }
    }
}