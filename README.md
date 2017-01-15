数据库项目：C#与数据库练习
====

#一、运行环境
    编程语言使用C#，运行环境Microsoft visual studio 2010，数据库使用SQL sever 2008 R2。
#二、主要功能
    通过C#面向对象的编程，实现通过程序对数据库进行操作，主要操作内容有：
    （1）实现C#程序与  已有数据库的连接。
    （2）通过C#代码  创建列 。
    （3）通过C#代码  添加记录。
    （4）通过C#代码  新建查询。
    （5）通过C#代码  创建视图。
    （6）通过C#代码  查看视图。
    （7）通过C#代码  建立约束。
    （8）通过C#代码  删除约束。
    （9）通过C#代码  创建存储过程。
    （10）通过C#代码  使用存储过程。
    （11）将执行的数据库代码在程序中显示。
    （12）将查询结果在程序中显示。
#三、主要代码及注释
    介绍四个关键代码：连接数据库、点击按钮的函数、SQL指令执行函数、将查询的数据在程序中显示。
    
##（1）设置后续程序会用到的数据库参数，以及可能会调用的开启数据库函数。
```C#
        SqlCommand cmd = null;  //  数据库连接命令对象。指定执行的SQL语句
        string sql = null;   // 存放SQL语句的。
        public class Command
        {
            public static readonly string ConStr = "Data Source=USER-20142Z;Initial Catalog=数据库名;uid = sa; pwd = aaaaaaaa";
        }
        using (SqlConnection con = new SqlConnection(Command.ConStr))
        {
            con.Open(); //连接数据库
        }
```

##（2）较为具有代表性的点击函数，向表中添加数据。
```C#
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
                    cmd = new SqlCommand(sql, conn); //将指令存入cmd中
                    cmd.ExecuteNonQuery();//在SQL中执行cmd
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
```

##（3）SQL语句执行函数，及调用实例。
```C#
        private void ExecuteSQLStmt(string sql)//设置指令传来后如何执行
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
        private void button10_Click(object sender, EventArgs e) //通过将指令存储在sql中，调用ExecuteSQLStmt函数，进行查询。
        {
            sql = "CREATE UNIQUE INDEX " +"myIdx ON [2015](myName)";
            ExecuteSQLStmt(sql);
            textBox1.Text = sql;
        }
```
##（4）通过数据适配器执行指令，并通过dataGridView展示查询结果。
```C#
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
```

![image](http://p1.bqimg.com/1949/c367cd533f54e6aa.jpg)

#四、独立完成的主要工作
    （1）选定开发方向和题目，学习了怎样连接数据库（1天半）
    （2）查询各种资料设计主要功能，设计C#软件界面（1天）
    （3）实现各个功能（1天）
#五、收获
    （1）锻炼C#编程能力
    （2）熟悉了许多SQL语句的功能和应用
    （3）学会如何安装、搭建数据库
    （4）学会多种方式C#与数据库连接
    （5）学会通过各种函数执行SQL操作
    （6）将SQL执行结果在程序重输出
    
    
    
