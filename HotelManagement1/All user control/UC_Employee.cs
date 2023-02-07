using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace HotelManagement1.All_user_control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        String query;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        private void txtRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmailID.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmailID.Text;
                String username = txtUserName.Text;
                String pass = txtPassword.Text;

                query = "insert into employee (ename,mobile,gender,emailid,username,pass) values ('"+name+"',"
                    +mobile+",'"+gender+"','"+email+"','"+username+"','"+pass+"')";
                fn.setData(query,"Employee Registered.");

                clearAll();
                getMaxID();

            }
            else
            {
                MessageBox.Show("fill all the fields","warning...!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                setEmployee(guna2DataGridView1);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView2); ;
            }
        }

        public void getMaxID()
        {
            query = "select sex(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();

            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedItem = -1;
            txtEmailID.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        public void setEmployee(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Are you sure?","Confirmation..!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes) ;

                {
                    query = "delete  from employee where eid=" + txtID.Text + "";
                    fn.setData(query, "Record Deleted");
                    tabControl1_SelectedIndexChanged(this, null);
                }
            }
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
