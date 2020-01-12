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
        private List<List<string>> tableData = new List<List<string>>();

        public List<List<string>> GetTableData(){ return tableData;}

        //private variables
        private List<string> fields = new List<string>(); //the field names of the table
        public List<string> GetFields(){ return fields;}
        public int GetFieldsNumber() { return fields.Count; }

        private int tableRecordNumbers; //number of records each table has
        public int GetTableRecordNumbers() { return tableRecordNumbers; }

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
            ReadInTableData(conn);      //get the table data
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

        //gets the data of each table
        //THE WAY IT WORKS is: read all the lines from each field and then insert the field to the tableData
        private void ReadInTableData(OleDbConnection conn)
        {
            OleDbCommand command = new OleDbCommand();//important to initialise it outside the for (prevents crashing, increases performance)
            for (int fieldsLoop = 0; fieldsLoop < fields.Count; fieldsLoop++)
            {// go through the fields

                command.CommandText = "select [" + fields[fieldsLoop] + "] from [" + tableName + "]"; //make the sql query 
                command.Connection = conn;

                OleDbDataReader reader = command.ExecuteReader();

                List<string> currentFieldvalues = new List<string>(); //temp field
                while (reader.Read()) //add the values to the temp field
                {
                    currentFieldvalues.Add(reader[0].ToString());
                }
                tableData.Add(currentFieldvalues); //add the temp field to the tableData

                reader.Close(); //reset the reader
            }
        }
    }

}
