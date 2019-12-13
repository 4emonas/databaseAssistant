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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        OleDbConnection connDb1 = new OleDbConnection();
        OleDbConnection connDb2 = new OleDbConnection();
        Database Database1 = new Database();
        Database Database2 = new Database();

        List<List<List<string>>> db1Data = new List<List<List<string>>>(); 
        List<List<List<string>>> db2Data = new List<List<List<string>>>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                Database1.InitialiseDatabase(connDb1);
                openDbButton1.Text = "Opened";
                openDbButton1.ForeColor = Color.FromArgb(50, 200, 50);
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
                Database2.InitialiseDatabase(connDb2);
                openDbButton2.Text = "Opened";
                openDbButton2.ForeColor = Color.FromArgb(50, 200, 50);
            }
        }

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

        private short CompareDatabases()
        {
            List<string> db1TableNames = new List<string>();
            List<string> db2TableNames = new List<string>();
            db1TableNames = ReadDatabaseNames(connDb1);//table names
            db2TableNames = ReadDatabaseNames(connDb2);

            //@temp2dList = columns
            List<List<string>> temp2dList = new List<List<string>>(); 
            for (int loop = 0; loop < db1TableNames.Count; loop++) {  //start running through the tables
                List<string> db1Tablecolumns = GetTableColumnList(connDb1, db1TableNames[loop]); //table columns
               // db1Data.Add(db1Tablecolumns);
                for (int dataloop = 0; dataloop < db1Tablecolumns.Count; dataloop++)
                {
                    OleDbCommand command = new OleDbCommand("select "+db1Tablecolumns[dataloop]+" from " + db1TableNames[loop], connDb1);
                    OleDbDataReader reader = command.ExecuteReader();
                    List<string> values = new List<string>();
                    while (reader.Read())
                    {
                        values.Add(reader[0].ToString());
                    }
                    temp2dList.Add(values); //add the values to one column
                    db1Data.Add(temp2dList); //add the column to the db1Data
                    
                    //temp2dList.Clear(); //clear the list to accept the new values
                }

            }
            
            for (int loop = 0; loop <db2TableNames.Count; loop++)
            {
                List<string> db2Tablecolumns = GetTableColumnList(connDb2, db2TableNames[loop]);
                for (int dataloop = 0; dataloop < db2Tablecolumns.Count; dataloop++)
                {
                    //todo: read values
                }
            }
            

            return 0;
        }

        private void ShowNoOpenDatabasesErrorMessage()
        {
            String errorString = "The ";
            if (!(connDb1.State == ConnectionState.Open))
            {
                errorString += "first database is ";
                if (!(connDb2.State == ConnectionState.Open))
                {
                    //4
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
        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connDb1.State == ConnectionState.Open && connDb2.State == ConnectionState.Open)
            {
                CompareDatabases();
            }
            else
            {
                ShowNoOpenDatabasesErrorMessage();
            }

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

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("comming soon....");
        }
    }
}

