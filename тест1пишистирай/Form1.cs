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

namespace тест1пишистирай
{
    public partial class Authorization : Form
    {
        DataTable Table = new DataTable();
        public Authorization()
        {
            InitializeComponent();
            SqlDataAdapter Adapter = new SqlDataAdapter("Select UserLogin, UserPassword, UserRole From [User]", DataBank.Connection);
            Adapter.Fill(Table);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Table.Rows.Count; i++)
            {
                if (Table.Rows[i][0].ToString() == tbLogin.Text)
                {
                    if (Table.Rows[i][1].ToString() == tbPassword.Text)
                    {
                        if(Table.Rows[i][2].ToString() == "3")
                        {
                            Main main = new Main();
                            Hide();
                            main.Show();
                            break;
                        }
                        else if (Table.Rows[i][2].ToString() == "2")
                        {
                            MessageBox.Show("Менеджер");
                            break;
                        }
                        else if (Table.Rows[i][2].ToString() == "1")
                        {
                            MessageBox.Show("Клиент");
                            break;
                        }
                    }
                    else if (Table.Rows[i][1].ToString() != tbPassword.Text)
                    {
                        MessageBox.Show("Неверный пароль");
                        break;
                    }
                }
                else if (tbLogin.Text == "")
                {
                    MessageBox.Show("Поля не должны быть пустыми");
                    break;
                }
            }
        }
    }
}
