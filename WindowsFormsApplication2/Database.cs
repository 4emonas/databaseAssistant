using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    class Database
    {
        public List<Table> tables = new List<Table>();

        public Database()
        { 
        }

        public void InitialiseDatabase(OleDbConnection conn)
        {
            ReadInDatabaseTables(conn);
        }

        private void ReadInDatabaseTables(OleDbConnection conn) //finds the list of tables and initialises each of them
        {

            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            DataTable userTables = null;
            userTables = conn.GetSchema("Tables", restrictions);//get all the tables that the database has

            for (int i = 0; i < userTables.Rows.Count; i++)//iterate through the tables, initialise them and add them to the list
            {
                Table tempTable = new Table(userTables.Rows[i][2].ToString());//make a Table object
                tempTable.InitialiseTable(conn);
                tables.Add(tempTable);//pass it to the list of Tables
            }

        }
    }
}
