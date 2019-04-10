using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTable_Test
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while(true)
            {
                if (tboxID.Text == "asdf" && tboxPW.Text == "1234")
                {
                    MessageBox.Show("로그인 되었습니다.");
                    formReg fm = new formReg();
                    fm.Show();
                    Hide();
                    break;
                }
                else
                {
                    MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.");                    
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
