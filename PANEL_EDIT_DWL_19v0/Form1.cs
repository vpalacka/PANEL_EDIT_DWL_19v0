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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillData();
        }

        readonly List<string> list = new List<string>();
       
        

        private void fillData()
        {
            int i = 0;
            const int nrColumns = 5;
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
                if((i!=0)&&((i % nrColumns) == 0) || ((list.Count-1) == i) )
                {
                    dataGridView1.Rows.Add(row); 
                }
                i++;
            }


            /*

             
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
            

            string[] directories = Directory.GetDirectories(@"..\..\bin\Obr");
            string[] files = Directory.GetFiles(directories[0], "*.jpg");
            //Image[] images = new Image[files.Length];
            Object[] rows = new object[directories.Length];
            Object[] row = new Object[files.Length];
            for (var i = 0; i < files.Length; i++)
            {
                images[i] = Image.FromFile(files[i]);
                row.SetValue(images[i], i);
            }
            
             
            
            Image img = Image.FromFile(files[0]);
            Image img2 = Image.FromFile(files[1]);
            Image img3 = Image.FromFile(files[2]);
            Object[] row = new Object[] { img, img2, img3 };
            
            dataGridView1.Rows.Add(row);
            */
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewImageCell cell = (DataGridViewImageCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            MessageBox.Show("Hello World");
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Rekurzívne vyhľadávanie názvov súborov v podadresároch
        /// </summary>
        /// <param name="sDir"></param>
        void DirSearch(string sDir)
        {
            
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                                        
                    foreach (string f in Directory.GetFiles(d, "*.jpg" ))
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
        
    }
}

