using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication2 
{

    class Visualiser
    {
        
        public Visualiser()
        {

        }

        //shows a list of tables
        public void ShowTables(ListView listview, Database db)
        {
            listview.Clear();
            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Tables";
            
            listview.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listview.FullRowSelect = true;
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

        //Main functionality of the app. Compares two databases together
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

            ShowTablesWithFieldDifferences(dbLeft, dbRight, commonTables, listViewLeft, listViewRight);
            ShowDifferentTables(dbLeft, dbRight, commonTables, listViewLeft, listViewRight);
            ShowTablesWithRecordsDifferences(dbLeft, dbRight, commonTables, listViewLeft, listViewRight);

        }

        //flags the tables that have got differences with record numbers
        private void ShowTablesWithRecordsDifferences(Database dbLeft, Database dbRight, List<string> commonTables, ListView listViewLeft, ListView listViewRight)
        {
            for (int i = 0; i < commonTables.Count; i++)
            {
                if (dbLeft.getTableObject(commonTables[i]).GetTableRecordNumbers() != dbRight.getTableObject(commonTables[i]).GetTableRecordNumbers())
                {// if they dont have the same record numbers

                    for (int j = 0; j < listViewLeft.Items.Count; j++)
                    {//find the table with this specific name in the list
                        if (listViewLeft.Items[j].Text == commonTables[i])
                        {//find the table with this specific name in the list
                            ChangeListItemColour(listViewLeft, j, "blue");
                            break;
                        }
                    }

                    for (int j = 0; j < listViewRight.Items.Count; j++)
                    {//find the table with this specific name in the list
                        if (listViewRight.Items[j].Text == commonTables[i])
                        {//find the table with this specific name in the list
                            ChangeListItemColour(listViewRight, j, "blue");
                            break;
                        }
                    }

                }
            }
        }

        //flags the tables that are not common between the databases
        private void ShowDifferentTables(Database dbLeft, Database dbRight, List<string> commonTables, ListView listViewLeft, ListView listViewRight) 
        {
            int maxItteration = 0;

            maxItteration = (dbLeft.tables.Count >= dbRight.tables.Count) ? dbLeft.tables.Count : dbRight.tables.Count;

            for (int i = 0; i < maxItteration; i++)
            {
                if (i < dbLeft.tables.Count)
                {//out of bounds protection
                    if (!commonTables.Contains(dbLeft.tables[i].tableName))
                    {//if the table name exists in the commonTables
                        ChangeListItemColour(listViewLeft, i, "red");
                    }
                }

                if (i < dbRight.tables.Count)
                {//out of bounds protection
                    if (!commonTables.Contains(dbRight.tables[i].tableName))
                    {//if the table name exists in the commonTables
                        ChangeListItemColour(listViewRight, i, "red");
                    }
                }                
            }
        }

        //flags the tables that dont have the same amount of fields
        private void ShowTablesWithFieldDifferences(Database dbLeft, Database dbRight, List<string> commonTables, ListView listViewLeft, ListView listViewRight)
        {
            for (int i = 0; i< commonTables.Count; i++)
            {
                var lefttNotRight = dbLeft.getTableObject(commonTables[i]).GetFields().Except(dbRight.getTableObject(commonTables[i]).GetFields()).ToList();
                var rightNotLeft = dbRight.getTableObject(commonTables[i]).GetFields().Except(dbLeft.getTableObject(commonTables[i]).GetFields()).ToList();

                if ((lefttNotRight.Count > 0) || (rightNotLeft.Count > 0))
                {//if there are differences in the fields
                    for (int j = 0; j < listViewLeft.Items.Count; j++)
                    {//find the table with this specific name in the list
                        if (listViewLeft.Items[j].Text == commonTables[i])
                        {
                            ChangeListItemColour(listViewLeft, j, "blue");
                            break;
                        }
                    }

                    for (int j = 0; j < listViewRight.Items.Count; j++)
                    {//find the table with this specific name in the list
                        if (listViewRight.Items[j].Text == commonTables[i])
                        {
                            ChangeListItemColour(listViewRight, j, "blue");
                            break;
                        }
                    }
                }

            }
        }

        //changes the background colour of the tables list
        private void ChangeListItemColour(ListView listView, int tableIndex, string colour)
        {
            listView.Items[tableIndex].BackColor  = ColourPicker(colour);
        }

        //resets the background colours in the lists
        public void ResetComparisonColours(ListView listviewLeft, ListView listviewRight)
        {
            int maxIteration = 0;

            maxIteration = (listviewLeft.Items.Count >= listviewRight.Items.Count) ? listviewLeft.Items.Count : listviewRight.Items.Count;

            for (int i = 0; i < maxIteration; i++)
            {
                if (i < listviewLeft.Items.Count) //out of bounds protection
                {
                    ChangeListItemColour(listviewLeft, i, "white");
                }

                if (i < listviewRight.Items.Count) //out of bounds protection
                {
                    ChangeListItemColour(listviewRight, i, "white");
                }
            }
        }

        //shows the differences that exist between the tables
        public void ShowTableDifferences(string tableName, DataGridView dgvLeft, DataGridView dgvRight, Database dbLeft, Database dbRight)
        {
            ShowExtraRowsInTable(tableName, dgvLeft, dgvRight, dbLeft, dbRight);
            ShowExtraColumnsInTable(tableName, dgvLeft, dgvRight, dbLeft, dbRight);
        }

        private void ShowExtraColumnsInTable(string tableName, DataGridView dgvLeft, DataGridView dgvRight, Database dbLeft, Database dbRight)
        {

            for (int i = 0; i < dbLeft.getTableObject(tableName).GetFieldsNumber(); i++)
            {
                string tempColumnName = dbLeft.getTableObject(tableName).GetFields()[i];
                if (!dbRight.getTableObject(tableName).ColumnExists(tempColumnName))
                {
                    HighlightDataGridViewColumn(dgvLeft, i, "orange");
                }
            }

            for (int i = 0; i < dbRight.getTableObject(tableName).GetFieldsNumber(); i++)
            {
                string tempColumnName = dbRight.getTableObject(tableName).GetFields()[i];
                if (!dbLeft.getTableObject(tableName).ColumnExists(tempColumnName))
                {
                    HighlightDataGridViewColumn(dgvRight, i, "orange");
                }
            }

        }
        //Highlights the extra columns
        private void HighlightDataGridViewColumn(DataGridView dgv, int y, string colour)
        {
            try
            {//error handling in case of a dummy table
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[y].Style.BackColor = ColourPicker(colour);
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
        }


        private void ShowExtraRowsInTable(string tableName, DataGridView dgvLeft, DataGridView dgvRight, Database dbLeft, Database dbRight)
        {
            int tableLeftRecordNumbers = dbLeft.getTableObject(tableName).GetTableRecordNumbers();
            int tableRightRecordNumbers = dbRight.getTableObject(tableName).GetTableRecordNumbers();

            if (tableLeftRecordNumbers > tableRightRecordNumbers)
            {
                for (int i = tableRightRecordNumbers; i < tableRightRecordNumbers + (tableLeftRecordNumbers - tableRightRecordNumbers); i++)
                {
                    HighlightDataGridViewRow(dgvLeft, i, "yellow");
                }
            }
            else if (tableRightRecordNumbers > tableLeftRecordNumbers)
            {
                for (int i = tableLeftRecordNumbers; i < tableLeftRecordNumbers + (tableRightRecordNumbers - tableLeftRecordNumbers); i++)
                {
                    HighlightDataGridViewRow(dgvRight, i, "yellow");
                }
            }
        }
        
        private void HighlightDataGridViewRow(DataGridView dgv, int x, string colour)
        {
            try
            {//error handling in case of a dummy table
                for (int j = 0; j < dgv.Rows[x].Cells.Count; j++)
                {
                    dgv.Rows[x].Cells[j].Style.BackColor = ColourPicker(colour);
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void HighlightDataGridViewCell(DataGridView dgv, int x, int y, string colour)
        {
            dgv.Rows[x].Cells[y].Style.BackColor = ColourPicker(colour);
        }

        //Makes the ListViews and the DataGridViews empty
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

        private System.Drawing.Color ColourPicker(string colour)
        {
            if (colour == "red")
            {
                return System.Drawing.Color.Red;
            }
            else if (colour == "green")
            {
                return System.Drawing.Color.Green;
            }
            else if (colour == "blue")
            {
                return System.Drawing.Color.Teal;
            }
            else if (colour == "white")
            {
                return System.Drawing.Color.White;
            }
            else if (colour == "pink")
            {
                return System.Drawing.Color.Pink;
            }
            else if (colour == "yellow")
            {
                return System.Drawing.Color.Yellow;
            }
            else if (colour == "orange")
            {
                return System.Drawing.Color.Orange;
            }
            else if (colour == "purple")
            {
                return System.Drawing.Color.Purple;
            }
            else
            {
                return System.Drawing.Color.White;
            }
        }
    }
}
