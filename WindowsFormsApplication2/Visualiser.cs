using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    class Visualiser
    {

        public Visualiser()
        {

        }

        //shows a list of tables
        //tableform: LEFT or RIGHT (from constants.cs)
        public void ShowTables(int tableForm, Database db)
        {
            if ((tableForm != Constants.LEFT) || (tableForm != Constants.RIGHT)) return; //error handling


        }

        //shows all the table data
        public void ShowTableData(Table tb, DataGridView dgv, OleDbConnection conn)
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [" + tb.tableName + "]", conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
        }

        public void CompareDatabases(Database dbLeft,Database dbRight)
        {

        }
    }
}
