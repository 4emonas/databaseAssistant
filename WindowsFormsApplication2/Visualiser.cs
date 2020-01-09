using System.Data;
using System.Data.OleDb;
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
        public void ShowTables(ListView listview, Database db)
        {
            listview.Clear();
            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Tables";


            listview.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listview.FullRowSelect = true;
            listview.GridLines = true;
            listview.View = View.Details;
            for (int i = 0; i < db.tables.Count; i++)
            {
                listview.Items.Add(db.tables[i].tableName);
            }
            listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
