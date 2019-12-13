using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Table : Database
    {
        //public variables
        public string tableName;

        //private variables
        private List<string> fields = new List<string>(); //the field names of the table
        private int tableRecordNumbers; //number of records each table has
        
        //========== public functions ============//

        public Table()
        {
            tableName = "";
            tableRecordNumbers = 0;
        }
        
        public Table(string tableName)
        {
            this.tableName = tableName;
        }

        public void InitialiseTable(OleDbConnection conn)
        {
            ReadInTableRecords(conn);   //get the table records
            ReadInTableFields(conn);    //get the table field names
        }



        //========== private functions ===========//

        //gets the number of records in each table
        private void ReadInTableRecords(OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand("select count(*) from [" + tableName + "]", conn);
            tableRecordNumbers = (int)cmd.ExecuteScalar();
        }

        //gets all the field names of the table
        private void ReadInTableFields(OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from [" + tableName + "]", conn);
            OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
            {
                DataTable table = reader.GetSchemaTable();
                var nameCol = table.Columns["ColumnName"];
                foreach (DataRow row in table.Rows)
                {
                    fields.Add(row[nameCol].ToString()); //adds the field name to the fields list
                }
            }
        }

    }
}
