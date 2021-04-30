using WebbShop.Models;
using WebbutikFrontend.Views.Shared;
using static WebbutikFrontend.Utils.Helper;

namespace WebbutikFrontend.Controllers
{
    public class CategoriesController
    {
        /// <summary>
        /// Shows a special <see cref="BookCategory"/>
        /// menu for the <paramref name="adminId"/>.
        /// </summary>
        /// <param name="adminId"></param>
        public void Index(int adminId)
        {
            while (true)
            {
                Message.Ping(adminId);
                Views.CategoryMenu.Index.View();
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            AddCategory(adminId);
                            break;

                        case 2:
                            SearchCategory(adminId);
                            break;

                        case 3:
                            ListAllCategories(adminId);
                            break;

                        case 4:
                            return;

                        default:
                            Message.Error();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> add a <see cref="Book"/>
        /// to the specified <paramref name="category"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="category"></param>
        private void AddBookToCategory(int adminId, BookCategory category)
        {
            var title = Get.Text("title", "\n\t");
            var books = API.GetBooks(title);
            if (books.Count > 0)
            {
                var ctr = Display.Books(books, "to edit");
                bool exit;
                do
                {
                    exit = true;
                    var choice = Get.Choice();
                    if (choice > 0 && choice < ctr)
                    {
                        var book = books[choice - 1];
                        if (API.AddBookToCategory(adminId, book.Id, category.Id))
                        {
                            Message.Success($"{book.Title} was added to {category.Name}!");
                        }
                        else
                        {
                            Message.Error("Something went wrong.");
                        }
                    }
                    else if (choice != ctr)
                    {
                        Message.Error();
                        exit = false;
                    }

                } while (!exit);
            }
            else
            {
                Message.Error("There are no books available that match your search.");
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> add a new
        /// <see cref="BookCategory"/> to the database.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddCategory(int adminId)
        {
            var categoryName = Get.Text("name of category", "\n\t");
            if (categoryName.Length != 0)
            {
                if (API.AddCategory(adminId, categoryName))
                {
                    Message.Success($"{categoryName} was successfully added!");
                }
                else
                {
                    Message.Error("Something went wrong.");
                }
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> remove a
        /// <paramref name="category"/> from the database.
        /// The <paramref name="category"/> will only be
        /// removed if there are no books connected to it.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="category"></param>
        private bool DeleteCategory(int adminId, BookCategory category)
        {
            var books = API.GetCategory(category.Id);
            if (API.DeleteCategory(adminId, category.Id))
            {
                Message.Success($"{category.Name} was successfully deleted!");
                return true;
            }
            else if (books.Count > 0)
            {
                Message.Error($"{category.Name} cannot be deleted since there" +
                    $" are {books.Count} connected to the category.");
            }
            else
            {
                Message.Error("Something went wrong.");
            }

            return false;
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> list all book
        /// categories in the database and select a specific one.
        /// </summary>
        /// <param name="adminId"></param>
        private void ListAllCategories(int adminId)
        {
            var categories = API.GetCategories();
            if (categories.Count > 0)
            {
                var ctr = Display.Categories(categories);
                bool exit;
                do
                {
                    exit = true;
                    var choice = Get.Choice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        SelectedCategory(adminId, category);
                    }
                    else if (choice != ctr)
                    {
                        Message.Error();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                Message.Error("There are no categories available!");
            }
        }

        /// <summary>
        /// Lets the admin search for categories based on a name
        /// and then select a specific category.
        /// </summary>
        /// <param name="adminId"></param>
        private void SearchCategory(int adminId)
        {
            var categoryName = Get.Text("category name", "\n\t");
            var categories = API.GetCategories(categoryName);
            if (categories.Count > 0)
            {
                var ctr = Display.Categories(categories);
                bool exit;
                do
                {
                    exit = true;
                    var choice = Get.Choice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        SelectedCategory(adminId, category);
                    }
                    else if (choice != ctr)
                    {
                        Message.Error();
                        exit = false;
                    }

                } while (!exit);
            }
            else
            {
                Message.Error("There are no categories available that match your search.");
            }
        }

        /// <summary>
        /// Shows a menu for the <paramref name="adminId"/> and
        /// lets him or her choose different things to do with
        /// the specified <paramref name="category"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="category"></param>
        private void SelectedCategory(int adminId, BookCategory category)
        {
            var outerExit = false;
            while (!outerExit)
            {
                Message.Ping(adminId);
                Views.SelectedCategory.SelectedCategory.View(category);
                bool innerExit;
                do
                {
                    innerExit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            AddBookToCategory(adminId, category);
                            break;

                        case 2:
                            UpdateCategory(adminId, category);
                            break;

                        case 3:
                            outerExit = DeleteCategory(adminId, category);
                            break;

                        case 4:
                            outerExit = true;
                            break;

                        default:
                            Message.Error();
                            innerExit = false;
                            break;
                    }
                } while (!innerExit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> update the name
        /// of the specified <paramref name="category"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="category"></param>
        private void UpdateCategory(int adminId, BookCategory category)
        {
            var oldName = category.Name;
            var newName = Get.Text($"new name for {category.Name}", "\n\t");
            if (API.UpdateCategory(adminId, category.Id, newName))
            {
                Message.Success($"{oldName} was successfully updated into {newName}!");
            }
            else
            {
                Message.Error("Something went wrong.");
            }
        }
    }
}
