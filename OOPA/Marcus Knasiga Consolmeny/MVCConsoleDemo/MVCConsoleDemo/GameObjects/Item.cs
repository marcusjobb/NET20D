using System.Collections.Generic;

namespace MVCConsoleDemo.GameObjects
{
    public class Item
    {
        public string Name { get; set; }
        public bool IsVisible { get; set; }
        public ItemStatus Status { get; set; }
        public int Room { get; set; }
        public Dictionary<string, string> Actions { get; set; }
    }
}