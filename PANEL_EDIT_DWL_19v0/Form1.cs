using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PANEL_EDIT_DWL_19v0
{
    /// <summary>
    /// Form - picture grid 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            fillData();
        }

        #region Fields
        /// <summary>
        /// List of all files with paths from subdirectories
        /// </summary>
        readonly List<string> list = new List<string>();
        /// <summary>
        /// Number of collumns in grid
        /// </summary>
        const int nrColumns = 5;
        #endregion

        #region Helper functions
        /// <summary>
        /// fill datagrid with pictures from subdirectories
        /// </summary>
        private void fillData()
        {
            int i = 0;
            Object[] row = new Object[nrColumns];
            
            DataGridViewImageColumn[] columns = new DataGridViewImageColumn[nrColumns];

            //create DataGridViewImageColumn objects and 

            for (var j = 0; j < nrColumns; j++)
            {
                columns[j] = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(columns[j]);
            }
            
            //Looking for complete files paths in subdirectories and saving them in var list
            DirSearch(@"..\..\bin\Obr");

            foreach (string s in list)
            {
                row.SetValue(Image.FromFile(s), i % nrColumns);
                //if the last value in row is created add row to grid
                if ((i != 0) && (((i + 1) % nrColumns) == 0) || ((list.Count - 1) == i))
                {
                    dataGridView1.Rows.Add(row);
                    row = new Object[nrColumns];
                }
                i++;
            }
  
        }

        /// <summary>
        /// Recursive srearch in subdirectories for "*.jpg" files
        /// </summary>
        /// <param name="sDir"></param>
        void DirSearch(string sDir)
        {

            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {

                    foreach (string f in Directory.GetFiles(d, "*.jpg"))
                    {
                        list.Add(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
        #endregion

        #region Event handlers
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind;
            DataGridViewImageCell cell = (DataGridViewImageCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            ind = cell.RowIndex * nrColumns + cell.ColumnIndex;
            if (ind < list.Count)
            {

                MessageBox.Show(list[ind]);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

    }
}

