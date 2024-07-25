using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Ques.Visualization
{
    class GenericDraw
    {
        public void CreateApp()
        {
            Thread thread = new Thread(() =>
            {
                Application app = new Application();

                Window window = new Window
                {
                    Height = 200
                };
            }
            );
        }
    }
}
