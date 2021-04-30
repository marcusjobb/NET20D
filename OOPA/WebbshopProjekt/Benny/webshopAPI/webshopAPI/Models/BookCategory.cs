namespace webshopAPI.Models
{
    public class BookCategory
    {
        /// <summary>
        /// Constructor of BookCategory
        /// </summary>
        /// <param name="name"></param>
        public BookCategory(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Empty constructor of BookCategory
        /// </summary>
        public BookCategory()
        {
        }

        /// <summary>
        /// Id field of BookCategory
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name field of BookCategory
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Overrided ToString for easier debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}