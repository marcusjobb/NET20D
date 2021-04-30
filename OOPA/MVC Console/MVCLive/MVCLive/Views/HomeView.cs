using System;

namespace Views
{
    internal class HomeView
    {
        internal void Display()
        {
            Console.Clear();
            Console.WriteLine(@"
            :::       ::::::::::::::::       ::::::::  :::::::: ::::    :::: ::::::::::
            :+:       :+::+:       :+:      :+:    :+::+:    :+:+:+:+: :+:+:+:+:
            +:+       +:++:+       +:+      +:+       +:+    +:++:+ +:+:+ +:++:+
            +#+  +:+  +#++#++:++#  +#+      +#+       +#+    +:++#+  +:+  +#++#++:++#
            +#+ +#+#+ +#++#+       +#+      +#+       +#+    +#++#+       +#++#+
             #+#+# #+#+# #+#       #+#      #+#    #+##+#    #+##+#       #+##+#
              ###   ###  ############################  ######## ###       #############
            ");
        }

        internal void DisplayMenu()
        {
            Console.WriteLine("[1] Show Users");
            Console.WriteLine("[2] Add User");
            Console.WriteLine("[0] Quit");
        }
    }
}