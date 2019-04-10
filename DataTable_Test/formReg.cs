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
    public partial class formReg : Form
    {
        DataSet ds = new DataSet();

        public formReg()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {   
            // DataTable이 없다면 boolean은 False로 테이블 생성
            bool IsTableAvailable = false;

            // Datatable이 있다면 ture로 기존 테이블을 사용
            if (ds.Tables.Contains(cboxRegClass.Text))
            {
                IsTableAvailable = true;
            }

            DataTable dt = null;

            // DataTable이 없다면 테이블을 생성
            if (!IsTableAvailable)
            {
                dt = new DataTable(cboxRegClass.Text);

                // initial Conlumn에 들어갈 값을 생성
                DataColumn colName = new DataColumn("NAME", typeof(string));
                DataColumn colSex = new DataColumn("SEX", typeof(string));
                DataColumn colRef = new DataColumn("REF", typeof(string));

                dt.Columns.Add(colName);
                dt.Columns.Add(colSex);
                dt.Columns.Add(colRef);
            }

            // DataTable이 있으면 DataSet의 테이블을 현재 테이블에 입력시킨다.            
            else
            {
                dt = ds.Tables[cboxRegClass.Text];
            }

            // Row에 들어갈 값을 생성
            DataRow row = dt.NewRow();

            row["NAME"] = tboxRegName.Text;

            if (rdoRegSexMale.Checked)
            {
                row["SEX"] = "남자";
            }
            else if (rdoRegSexFemale.Checked)
            {
                row["SEX"] = "여자";
            }

            row["REF"] = tboxRegRef.Text;
            
            //새로 입력되는 Row의 값을 기존 테이블에 추가시킨다.
            if (IsTableAvailable)
            {
                ds.Tables[cboxRegClass.Text].Rows.Add(row);
            }
            //Table이 없다면 새로운 Table에 Initail Column 추가, DataSet에 Table 추가
            else
            {
                dt.Rows.Add(row);
                ds.Tables.Add(dt);
            }

            // HeaderCell에 Index 숫자를 입력
            cboxViewClass_SelectedIndexChanged(this, null);
        }

        private void btnViewDataDel_Click(object sender, EventArgs e)
        {
            // 선택된 Row을 삭제버튼으로 지워준다.
            int iSelectRow = dgViewInfo.SelectedRows[0].Index;
            ds.Tables[cboxViewClass.Text].Rows.RemoveAt(iSelectRow);

            // 삭제된 Row로 인해 생긴 Index를 다시 재정렬해준다.
            cboxViewClass_SelectedIndexChanged(this, null);
        }

        private void cboxViewClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 선택된 클래스를 보여준다.
            dgViewInfo.DataSource = ds.Tables[cboxViewClass.Text];

            // HeaderCell의 Index값을 재정렬 시켜준다.
            foreach (DataGridViewRow oRow in dgViewInfo.Rows)
            {
                oRow.HeaderCell.Value = oRow.Index.ToString();
            }
            dgViewInfo.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form2의 Application 종료 시 
            Application.Exit();
        }
    }
}
