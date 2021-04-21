using Pages;
using System.Collections.Generic;

namespace Controllers
{
    internal class PageController
    {
        private List<Page> pages;

        #region Internal methods

        internal PageController()
        {
            SetupPages();
        }

        /// <summary>
        /// Gets the Page requested by PageType
        /// </summary>
        /// <param name="type"></param>
        /// <returns>A Page Object</returns>
        internal Page GetPage(PageType type)
        {
            Page pageToSend = null;
            foreach (Page p in pages)
            {
                if (p.Type == type)
                {
                    pageToSend = p;
                }
            }
            return pageToSend;
        }

        /// <summary>
        /// Initilizes all the pages in the list "pages".
        /// Sets values for all the pages in the list
        /// </summary>
        private void SetupPages()
        {
            pages = new List<Page>()
            {
                new Page
                {
                    Type = PageType.None,
                    Message = $@"This is pagetype none. No msg will show"
                },
                new Page
                {
                    Type = PageType.LoginMenu,
                    Message =@"---Login Menu---
1. Login
2. Register",
                    NrOfMenuOptions = 2
                },
                new Page
                {
                    Type = PageType.UserMenu,
                    Message = @"---Menu---
1. Show all categories
2. Search for a specific category
3. List all books in category
4. Show avaible books in category
5. Get information about a book
6. Search for books by name
7. Search for Authors name to get their written books
8. Buy a book.
9. Exit user Menu",
                    NrOfMenuOptions = 9,
                },
                new Page
                {
                    Type = PageType.AdminMenu,
                    Message = @"-----Admin Menu-----
1. Add a book
2. Set Book Amount
3. List all Users
4. Find specific user
5. Update a book
6. Delete a book
7. Add a category
8. Add a book to a category
9. Update a category
10. Delete a category
11. Add a user
12. Show sold items
13. Show Money earned
14. Show best customer
15. Promote a user to admin
16. Demote a user from admin
17. Activate a user (Set user active)
18. Deactivate a user(Set user to inactive)
19. Run User Menu",
                    NrOfMenuOptions = 19,
                },
                new Page
                {
                    Type = PageType.Data,
                    Message = "No data parsed yet",
                },
                new Page
                {
                    Type = PageType.Welcome,
                    Message = @".* ,*/.*..,./,..*..,//..*...//,..**.*../*...,,,./,,./.*,...*../..,,...///.,,..*,
 * .,*,*..,./...,...(/..,..,(/,..,/,*../*..*.,..#...*.*,...,..(..,,.../*/.,,..*.
 *  ,*,*..../.*.,..,((..,..,(/..../,*../*..,...,*...*./,....../. .,.../*/ ....,.
 * .,(., .../.. ,. ./(  ,  ,(/.  ./,*. **. ,,,......( *.   ,../  .,.../*/ ......
 / .,*.,  . *,. ..  #(  ,  .//.  .%,(  /#  .........* /.   .. (  .....(,(   ...,
 * .,/.,   .* . .. ./*  ,  .(*.  .%,,  **  ....  .. ( /.   .. #  .,.../,*   . .,
 * .,*.*   .*.( ..  *(  ,  ./*.  .%,,  ,*   ...  ..., *.   .  /  .. ../,*   .  .
 * .,/.,   .(..  .  ,/  ,   /*   ./.,  ,%  ,,... ..,, /.   .  /  .. ../*/   .
 ( ../ ,   .*..    .*(  ,  .**   ,,,,  ,&  .,...  . , *.   .  /  .. ../**    .
 , .,/.,   .*.*  .  /*  .   /%    .,*  .,   .. .    , *.      /  .. . /,*    .
 * ..*./   .*.*    .#/  .  .*,.  . .*  ..  ,..     ., *.   .  /  .. . /**
 ,  ./.*   ./.     ,(,  .  ./*   . .*  .   ,.  .    ( /*      /  .... /./
 # . *,*   .*       (,  ,  ,/(.  . .*       .       . *,   .  /  ,..  (./
 / . /.,   .(      .#*  .   /(.    ,,  .   ,.      .. /   ..  /  ...  *./    .
 (   , ,    (.      **     .(,.    ./       .  .    . #    .  /   ..  /(#
 ,   ( .    *       ,(     .#,.    ..  .    .. .    . *    .  #   .   *,%
     (      . .     ./     .%,.    ,.      ... .   ., (   ..  ,   .   *(/
     *        .      /     .#,     ,.       ..      . *       .   .   %/.
     (        .      %     .*,     .        ..        (           .   */
     *        (      /      (,              ,.      . /           ..  %(
     *        (      *     .*.     .        .      .. ,           ..  (,
     %        *      #     .,,              .       . .           .   *.
     *        .      .     ..,              .       .             .   .
     /               .                              .             .   .

      ___       __   __         ___
|  | |__  |    /  ` /  \  |\/| |__
|/\| |___ |___ \__, \__/  |  | |___
___  __     ___       ___
 |  /  \     |  |__| |__
 |  \__/     |  |  | |___
___       ___     __   __   __           __        __   __
 |  |__| |__     |__) /  \ /  \ |__/    /__` |__| /  \ |__)
 |  |  | |___    |__) \__/ \__/ |  \    .__/ |  | \__/ |
"
                }
            };
        }

        #endregion Internal methods
    }
}