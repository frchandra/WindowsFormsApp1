using System.Data.OleDb;


namespace WindowsFormsApp1.Models
{
    class MyModel
    {
        protected static readonly OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

        public virtual void push()
        {

        }

        public virtual void pullById(int id)
        {

        }

        public virtual void update()
        {

        }

        public virtual void deleteById(int id)
        {

        }
    }
}
