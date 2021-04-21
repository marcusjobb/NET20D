using System;

namespace WebbShopAPI.Interfaces
{
    public interface IDateAndTimeable
    {
        public DateTime SessionTimer { get; set; }
        public DateTime LastLogIn { get; set; }
    }
}
