using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        string strName;
        SqlCommand cmd = null;  //  数据库连接命令对象。指定执行的SQL语句
        string sql = null;   // 存放SQL语句的。
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public class Command
        {
            public static readonly string ConStr = "Data Source=USER-20141002ZO;Initial Catalog=KTV点歌;uid = sa; pwd = w2aghyc";
        }


        #region 开启数据库
        private void button14_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Command.ConStr))
            {
                con.Open();
                textBox1.Text = Command.ConStr;
                //strName = "Data Source=USER-20141002ZO;Initial Catalog=KTV点歌;uid = sa; pwd = w2aghyc";
                //textBox1.Text = strName;

            }
        }
        #endregion

        #region 创建表
        private void button2_Click(object sender, EventArgs e)
        {
            // 打开数据库连接
            using (SqlConnection conn = new SqlConnection(Command.ConStr))
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                sql = "CREATE TABLE [2015](myId INTEGER CONSTRAINT PKeyMyId PRIMARY KEY,myName CHAR(50) NOT Null, myTable CHAR(255), myValues FLOAT)";
                textBox1.Text = sql;
            }
        }
        #endregion

        #region 添加记录
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Command.ConStr))
            {
                conn.Open();
                SqlCommand cmd = null;  //  数据库连接命令对象。指定执行的SQL语句
                string sql = null;   // 存放SQL语句的。
                cmd = new SqlCommand(sql, conn);
                try
                {
                    // 向表中添加记录
                    sql = "INSERT INTO [2015](myId, myName,myAddress,myValues) " + "VALUES (1001, 'Puneet Nehra', 'A 449 Sect 19, DELHI', 23.98 ) ";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    textBox1.Text = sql;
                    sql = "INSERT INTO [2015](myId, myName,myAddress, myValues) " + "VALUES (1002, 'Anoop Singh', 'Lodi Road, DELHI', 353.64) ";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = "INSERT INTO [2015](myId, myName, myAddress, myValues) " + "VALUES (1003, 'Rakesh M', 'Nag Chowk, Jabalpur M.P.', 43.43) ";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = "INSERT INTO [2015](myId, myName, myAddress, myValues) " + "VALUES (1004, 'Madan Kesh', '4th Street, Lane 3, DELHI', 23.00) ";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ae)
                {
                    MessageBox.Show(ae.Message.ToString());
                }
            }
        }
        #endregion


        #region 执行函数
        private void ExecuteSQLStmt(string sql)
        {
            using (SqlConnection conn = new SqlConnection(Command.ConStr))
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ae)
                {
                    MessageBox.Show(ae.Message.ToString());
                }
            }
        }
        #endregion


        #region 添加存储过程
        private void button8_Click(object sender, EventArgs e)
        {
            sql = "CREATE PROCEDURE myProc AS" + " SELECT myName, myAddress FROM [2015] GO";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
        #endregion

        #region 添加视图
        private void button11_Click(object sender, EventArgs e)
        {
            sql = "CREATE VIEW myView AS SELECT myName FROM [2015]";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
        #endregion


        #region 新建查询
        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Command.ConStr))
            {
                conn.Open();
                // 创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [2015]", conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                DataSet ds = new DataSet("[2015]");
                da.Fill(ds, "[2015]");
                dataGridView1.DataSource = ds.Tables["[2015]"].DefaultView;
                textBox1.Text = "SELECT * FROM [2015]";
            }

        }
        #endregion

        #region 调用存储过程查询
        private void button9_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Command.ConStr))
            {
                // 创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter("myProc", conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                DataSet ds = new DataSet("[2015]");
                da.Fill(ds, "[2015]");
                dataGridView1.DataSource = ds.Tables["[2015]"].DefaultView;
                textBox1.Text = "调用存储过程myProc";
            }

        }
        #endregion

        #region 查询视图
        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Command.ConStr))
            {
                // 创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM myView", conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                textBox1.Text = "SELECT * FROM myView";
            }
        }
        #endregion

        #region 创建删除约束
        private void button3_Click(object sender, EventArgs e)
        {
            sql = "CREATE RULE myRule " + "AS @myBalance >= 32 AND @myBalance < 60";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sql = "DROP RULE myRule";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
        #endregion


        #region 索引
        private void button10_Click(object sender, EventArgs e)
        {
            sql = "CREATE UNIQUE INDEX " +"myIdx ON [2015](myName)";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
        #endregion

        #region ALTER添加删除字段
        private void button5_Click(object sender, EventArgs e)
        {
            sql = "ALTER TABLE [2015] ADD " +  "newCol TIMESTAMP";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            sql = "ALTER TABLE [2015] DROP " + "column newCol";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
        #endregion

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
