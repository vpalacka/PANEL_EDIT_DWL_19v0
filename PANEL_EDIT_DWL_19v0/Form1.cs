using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PANEL_EDIT_DWL_19v0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillData();
        }

        private void fillData()
        {
            //Construct columns
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Značky";
            imgCol.Name = "Znacky";
            dataGridView1.Columns.Add(imgCol);

            DataGridViewImageColumn imgCol2 = new DataGridViewImageColumn();
            imgCol.HeaderText = "";
            imgCol.Name = "Col2";
            dataGridView1.Columns.Add(imgCol2);

            DataGridViewImageColumn imgCol3 = new DataGridViewImageColumn();
            imgCol.HeaderText = "";
            imgCol.Name = "Col3";
            dataGridView1.Columns.Add(imgCol3);

            Image img = Image.FromFile(@"c:\Users\palacka.SAEAUTOM2\Source\Repos\PANEL_EDIT_DWL_19v0\PANEL_EDIT_DWL_19v0\bin\zn1.jpg");
            Image img2 = Image.FromFile(@"c:\Users\palacka.SAEAUTOM2\Source\Repos\PANEL_EDIT_DWL_19v0\PANEL_EDIT_DWL_19v0\bin\zn1.jpg");
            Image img3 = Image.FromFile(@"c:\Users\palacka.SAEAUTOM2\Source\Repos\PANEL_EDIT_DWL_19v0\PANEL_EDIT_DWL_19v0\bin\zn1.jpg");
            Object[] row = new Object[] { img, img2, img3 };
            dataGridView1.Rows.Add(row);

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
