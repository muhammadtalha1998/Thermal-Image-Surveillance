using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace SignUpDemo
{
    public partial class MaintLd : Form
    {
        public MaintLd()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MaintLd_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String WOmain = @"C:\Users\Talha PC\Desktop\a.xlsx";
            string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\t-jjtabije\\Desktop\\TestExcelUpdater\\TestUnoREFARM.xlsx;Extended Properties='Excel 12.0 Xml;IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text'";
         //   string filePath = Path.GetFullPath(WOmain);
           // string extension = Path.GetExtension(filePath);
            string conStr, sheetName;
            conStr = string.Empty;
            using (OleDbConnection con = new OleDbConnection(Excel07ConString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        DataTable dt = new DataTable();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                        //con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dt);
                        con.Close();
                        //Populate DataGridView.
                        dataGridView1.DataSource = dt;
                  
                        
                    }
                }
            }

}
        }
    }

