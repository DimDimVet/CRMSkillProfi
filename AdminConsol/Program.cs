using AdminConsol.Models;
using System;

namespace AdminConsol
{
    class Program
    {
        private static ViewConsole _viewConsol;
        private static App _app;
        [STAThread]
        public static void Main()
        {
            Option.InitLoadTxt();
            if (Logic.ControlApi())
            {
                _viewConsol = new ViewConsole();
                _app = new App();
                _app.InitializeComponent();
                _app.Run(_viewConsol);
            }
            
        }
    }
}
