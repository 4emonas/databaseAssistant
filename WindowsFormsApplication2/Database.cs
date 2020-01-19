using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class Database
    {
        public List<Table> tables = new List<Table>();

        public Database()
        { 
        }

        public void InitialiseDatabase(OleDbConnection conn, TextBox dbTextBox)
        {
            ReadInDatabaseTables(conn, dbTextBox);
        }

        private void ReadInDatabaseTables(OleDbConnection conn, TextBox dbTextBox) //finds the list of tables and initialises each of them
        {
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            DataTable userTables = null;
            userTables = conn.GetSchema("Tables", restrictions);//get all the tables that the database has
            
            for (int i = 0; i < userTables.Rows.Count; i++)//iterate through the tables, initialise them and add them to the list
            {
                Table tempTable = new Table(userTables.Rows[i][2].ToString());//make a Table object
                dbTextBox.Text = "Loading table: " + tempTable.tableName + "...";
                dbTextBox.Refresh();
                tempTable.InitialiseTable(conn);
                tables.Add(tempTable);//pass it to the list of Tables
            }

        }

        public Table getTableObject(string requestedTableName)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].tableName == requestedTableName)
                {
                    return tables[i];
                }
            }
            return tables[0];
        }

        //Empties the database object stored data
        public void EmptyDatabase()
        {
            this.tables.Clear();
        }
    }
}
