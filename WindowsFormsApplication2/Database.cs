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

        //finds the list of tables and initialises each of them
        private void ReadInDatabaseTables(OleDbConnection conn) 
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

        //gets a string as an input and returns the table object with that name
        public Table getTableObject(string requestedTableName)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].tableName == requestedTableName)
                {
                    return tables[i];
                }
            }
            return tables[0]; //returns the first table in the database if an incorrect table name was passed
        }
    }
}
