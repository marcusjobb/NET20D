using WebbShopAPI.Models;

namespace WebbShopAPI.Interfaces
{
    public interface ILiterature
    {
        public Author Author { get; set; }
        public Category Categories { get; set; }
    }
}
