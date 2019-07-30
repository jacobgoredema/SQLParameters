using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLParameters
{
    public partial class frmSqlParameter : Form
    {
        public frmSqlParameter()
        {
            InitializeComponent();
        }

        private void frmSqlParameter_Load(object sender, EventArgs e)
        {

        }

        SqlConnection conn;
        SqlCommand comm;

        string connectionString = "database=student;server=JHB-JACOBGOREDE\\SQLEXPRESS;Trusted_Connection=True;";

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            comm = new SqlCommand();
            comm.Connection = conn;

            // creating instance of SqlParameter
            SqlParameter PmtrRollNo = new SqlParameter();
            PmtrRollNo.ParameterName = "@rn"; //defining name
            PmtrRollNo.SqlDbType = SqlDbType.Int; //defining datatype
            PmtrRollNo.Direction = ParameterDirection.Input; // setting the direction

            //Creating instance of SqlParameter
            SqlParameter PmtrName = new SqlParameter();
            PmtrName.ParameterName = "@nm"; //defining Name
            PmtrName.SqlDbType = SqlDbType.VarChar; // defining datatype
            PmtrName.Direction = ParameterDirection.Input; // setting the direction

            //creating instance of SqlParameter
            SqlParameter PmrtCity = new SqlParameter();

            PmrtCity.ParameterName = "@ct"; //defining name
            PmrtCity.SqlDbType = SqlDbType.VarChar; //defining datatype
            PmrtCity.Direction = ParameterDirection.Input; //setting the direction

            //Adding Parameter instances to SqlCommand
            comm.Parameters.Add(PmtrRollNo);
            comm.Parameters.Add(PmtrName);
            comm.Parameters.Add(PmrtCity);

            // setting values of Parameter
            PmtrRollNo.Value = Convert.ToInt32(txtRollNumber.Text);
            PmtrName.Value = txtName.Text;
            PmrtCity.Value = txtCity.Text;

            comm.CommandText = "INSERT INTO studentDetails VALUES(@rn,@nm,@ct)";

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Record Saved");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Not Saved");
            }
            finally
            {
                conn.Close();
            }




        }
    }
}
