using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new Login());
            //Application.Run(new View_Cars());
            //Application.Run(new Add_Cars());
            //Application.Run(new Add_Members()); 
            //Application.Run(new View_Members());
            //Application.Run(new Rent_Car());
            //Application.Run(new Return_Car());
            //Application.Run(new Garage());
        }
    }
}
