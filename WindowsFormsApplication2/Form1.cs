using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        OleDbConnection connDb1 = new OleDbConnection();
        OleDbConnection connDb2 = new OleDbConnection();
        Database Database1 = new Database();
        Database Database2 = new Database();
        Visualiser visio = new Visualiser();

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (databasePath1.Text != "")
            {
                try
                {
                    connDb1.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            if (databasePath2.Text != "")
            {
                try
                {
                    connDb2.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        //dupplicate code with openDbButton2_Click. Need a function to take inputs and do w/e this function does.
        private void openDbButton1_Click(object sender, EventArgs e)
        {
            //dialog to find database
            using (OpenFileDialog openFileDialogDatabase1 = new OpenFileDialog())
            {
                if (openFileDialogDatabase1.ShowDialog() == DialogResult.OK)
                {
                    databasePath1.Text = openFileDialogDatabase1.FileName;
                }
            }

            String conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath1.Text + ";Persist Security Info=False";
            try
            {
                connDb1 = new OleDbConnection(conn_string);
                connDb1.Open();
                //please work
            }
            catch (Exception)
            {
                String errorMsg = "";
                if (databasePath1.Text == "")
                    errorMsg = "Please provide database path";
                else
                    errorMsg = "Unable to open the database in path " + databasePath1.Text;

                MessageBox.Show(errorMsg);
            }

            if (connDb1.State == ConnectionState.Open)
            {
                visio.ClearData(listView1, dataGridView1, Database1);

                Database1.InitialiseDatabase(connDb1);
                openDbButton1.Text = "Opened";
                openDbButton1.ForeColor = Color.FromArgb(50, 200, 50);
                
                visio.ShowTables(listView1, Database1);
            }
        }

        //TODO: same as above
        private void openDbButton2_Click(object sender, EventArgs e)
        {
            //dialog to find database
            using (OpenFileDialog openFileDialogDatabase2 = new OpenFileDialog())
            {
                if (openFileDialogDatabase2.ShowDialog() == DialogResult.OK)
                {
                    databasePath2.Text = openFileDialogDatabase2.FileName;
                }
            }

            String conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath2.Text + ";Persist Security Info=False";
            try
            {
                connDb2 = new OleDbConnection(conn_string);
                connDb2.Open();
            }
            catch (Exception)
            {
                String errorMsg = "";
                if (databasePath1.Text == "")
                    errorMsg = "Please provide database path";
                else
                    errorMsg = "Unable to open the database in path " + databasePath1.Text;

                MessageBox.Show(errorMsg);
            }

            if (connDb2.State == ConnectionState.Open)
            {
                visio.ClearData(listView2, dataGridView1, Database2);

                Database2.InitialiseDatabase(connDb2);
                openDbButton2.Text = "Opened";
                openDbButton2.ForeColor = Color.FromArgb(50, 200, 50);
                                
                visio.ShowTables(listView2, Database2);
            }
        }

        //needs change
        private List<string> ReadDatabaseNames(OleDbConnection conn)
        {
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            DataTable userTables = null;
            userTables = conn.GetSchema("Tables", restrictions);
            List<string> TableNames = new List<string>();
            for (int i = 0; i < userTables.Rows.Count; i++)
                TableNames.Add(userTables.Rows[i][2].ToString());

            return TableNames;
        }

        //needs change 
        private List<string> GetTableColumnList(OleDbConnection connDb1, string tableName)
        {
            List<string> db1ColumnList = new List<string>();
            OleDbCommand cmd = new OleDbCommand("select * from " + tableName, connDb1);
            OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
            {
                DataTable table = reader.GetSchemaTable();
                var nameCol = table.Columns["ColumnName"];
                foreach (DataRow row in table.Rows)
                {
                    //Console.WriteLine(row[nameCol]);
                    db1ColumnList.Add(row[nameCol].ToString());
                }
            }

            return db1ColumnList;
        }

        //needs to be done TODO
        private short CompareDatabases() //keeping this function for testing
        {
            visio.CompareDatabases(Database1, Database2,listView1,listView2);
           
                return 0;
        }

        //i think is ok
        private void ShowNoOpenDatabasesErrorMessage()
        {
            String errorString = "The ";
            if (!(connDb1.State == ConnectionState.Open))
            {
                errorString += "first database is ";
                if (!(connDb2.State == ConnectionState.Open))
                {
                    errorString = "the databases are ";
                }
            }


            if (!(connDb2.State == ConnectionState.Open) && !(errorString.Contains("are")))
            {
                errorString += "second database is ";
            }

            errorString += "not open";
            MessageBox.Show(errorString);
        }

        private void database1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connDb1.Close();
            openDbButton1.Text = "Open";
            openDbButton1.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void database2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connDb2.Close();
            openDbButton2.Text = "Open";
            openDbButton2.ForeColor = Color.FromArgb(0, 0, 0);
        }

        //needs to be done TODO
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("comming soon....");
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void listView2_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listView2.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            visio.ShowTableData(Database1.getTableObject(e.Item.Text), dataGridView1, connDb1);

            if ((e.Item.BackColor != Color.White)&&(e.Item.BackColor != Color.Red))
            {
                visio.ShowTableDifferences(e.Item.Text, dataGridView1, Database1, Database2);
            }

        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            visio.ShowTableData(Database2.getTableObject(e.Item.Text), dataGridView2, connDb2);

            if ((e.Item.BackColor != Color.White) && (e.Item.BackColor != Color.Red))
            {
                visio.ShowTableDifferences(e.Item.Text, dataGridView2, Database1, Database2);
            }
        }

        private void compareDatabasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visio.ResetComparisonColours(listView1, listView2);

            if (connDb1.State == ConnectionState.Open && connDb2.State == ConnectionState.Open)
            {
                CompareDatabases();
            }
            else
            {
                ShowNoOpenDatabasesErrorMessage();
            }

        }
    }
}

