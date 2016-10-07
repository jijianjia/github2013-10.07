using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //操作数据库类
            //连接Connection->SqliteConnection
            //命令Command
            //适配器DataAdapter
            //DataReader
            //DataSet,DataTable

            //从数据库表(ManagerInfo)中查询数据
            //0、构造接收数据集合
            List<sd> list = new List<sd>();
            //1、连接字符串
            string connStr = @"data source=C:\Users\Administrator\Desktop\build\test.db;version=3;";

            //2、创建连接对象
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //3、创建Command对象
                SQLiteCommand cmd = new SQLiteCommand("select*from sd", conn);
                //4、打开链接
                conn.Open();
                //5、执行命令
                SQLiteDataReader reader = cmd.ExecuteReader();
                //6、读取
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new sd()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            age = Convert.ToInt32(reader["age"])
                        });
                    }
                }
                //7、将显示到DataGridView上
                dataGridView1.DataSource = list;
            }

        }

        
    }
}
