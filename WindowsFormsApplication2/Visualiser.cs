using System.Collections.Generic;
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
            //listview.GridLines = true;
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

        public void CompareDatabases(Database dbLeft,Database dbRight, ListView listViewLeft, ListView listViewRight)
        {
            List<string> commonTables = new List<string>();
            
            for (int tableCount = 0; tableCount<dbLeft.tables.Count; tableCount++)
            {// go through all the tables on the first database
                for(int i = 0; i < dbRight.tables.Count; i++)
                {//and check if a table on the left, exists on the right
                    if(dbLeft.tables[tableCount].tableName == dbRight.tables[i].tableName)
                    {//found same tables
                        commonTables.Add(dbLeft.tables[tableCount].tableName);
                        break;
                    }
                }
            }
            
            ShowDifferentTables(dbLeft, dbRight, commonTables, listViewLeft, listViewRight);
        }

        private void ShowDifferentTables(Database dbLeft, Database dbRight, List<string> commonTables, ListView listViewLeft, ListView listViewRight) 
        {
            int maxItteration = 0;

            maxItteration = (dbLeft.tables.Count >= dbRight.tables.Count) ? dbLeft.tables.Count : dbRight.tables.Count;

            for (int i = 0; i < maxItteration; i++)
            {
                if (i < dbLeft.tables.Count)
                {
                    if (!commonTables.Contains(dbLeft.tables[i].tableName))
                    {
                        ChangeListItemColour(listViewLeft, i);
                    }
                }

                if (i < dbRight.tables.Count)
                {
                    if (!commonTables.Contains(dbRight.tables[i].tableName))
                    {
                        ChangeListItemColour(listViewRight, i);
                    }
                }                
            }
        }

        private void ChangeListItemColour(ListView listView, int tableIndex)
        {
            listView.Items[tableIndex].BackColor = System.Drawing.Color.Green;
        }

        public void ClearData(ListView listview, DataGridView datagridview, Database database)
        {
            database.EmptyDatabase(); //clear the data

            ClearListData(listview);
            ClearDatagridData(datagridview);
        }

        private void ClearListData(ListView listview)
        {
            listview.Clear();
            listview.Items.Clear();
            listview.Update(); // In case there is databinding
            listview.Refresh(); // Redraw items
        }

        private void ClearDatagridData(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            dataGridView.Update(); // In case there is databinding
            dataGridView.Refresh(); // Redraw items
        }
    }
}
