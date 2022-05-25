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
    public partial class Main : Form
    {
        string querry = $"Select Product.*, ProductCategory.Title, ProductSupplier.Title, ProductManufacturer.Title, ProductTitle.Title From Product Inner join ProductCategory On Product.ProductCategory = ProductCategory.CategoryID inner join ProductSupplier On Product.ProductSupplier=ProductSupplier.SupplierID inner join ProductManufacturer On Product.ProductManufacturer = ProductManufacturer.ManufacturerID inner join ProductTitle On Product.ProductName = ProductTitle.ProductNameID";
        public Main()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dgvProducts.Rows.Clear();
            DataBank.Connection.Open();

            SqlCommand sqlCommand = new SqlCommand(querry, DataBank.Connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (sqlDataReader.Read())
            {
                data.Add(new string[17]);

                data[data.Count - 1][0] = sqlDataReader[0].ToString();
                data[data.Count - 1][1] = sqlDataReader[1].ToString();
                data[data.Count - 1][2] = sqlDataReader[2].ToString();
                data[data.Count - 1][3] = sqlDataReader[3].ToString();
                data[data.Count - 1][4] = sqlDataReader[4].ToString();
                data[data.Count - 1][5] = sqlDataReader[5].ToString();
                data[data.Count - 1][6] = sqlDataReader[6].ToString();
                data[data.Count - 1][7] = sqlDataReader[7].ToString();
                data[data.Count - 1][8] = sqlDataReader[8].ToString();
                data[data.Count - 1][9] = sqlDataReader[9].ToString();
                data[data.Count - 1][10] = sqlDataReader[10].ToString();
                data[data.Count - 1][11] = sqlDataReader[11].ToString();
                data[data.Count - 1][12] = sqlDataReader[12].ToString();
                data[data.Count - 1][13] = sqlDataReader[13].ToString();
                data[data.Count - 1][14] = sqlDataReader[14].ToString();
                data[data.Count - 1][15] = sqlDataReader[15].ToString();
                data[data.Count - 1][16] = sqlDataReader[16].ToString();
            }

            sqlDataReader.Close();
            DataBank.Connection.Close();

            foreach (string[] s in data)
            {
                dgvProducts.Rows.Add(s);
            }
            PopulatesItems();
        }

        void PopulatesItems()
        {
            flpProducts.Controls.Clear();
            CustomElement[] customElements = new CustomElement[dgvProducts.Rows.Count];

            for (int i = 0; i < customElements.Length; i++)
            {
                customElements[i] = new CustomElement();

                customElements[i].PName = dgvProducts.Rows[i].Cells[13].Value.ToString();
                customElements[i].Description = dgvProducts.Rows[i].Cells[10].Value.ToString();
                customElements[i].Manufacturer = dgvProducts.Rows[i].Cells[14].Value.ToString();
                customElements[i].Cost = "Цена: " + dgvProducts.Rows[i].Cells[3].Value.ToString();
                customElements[i].Discount = dgvProducts.Rows[i].Cells[8].Value.ToString() + "%";

                if (dgvProducts.Rows[i].Cells[11].Value.ToString().Length >= 10)
                {
                    customElements[i].Image = Image.FromFile("../../Resources/" + dgvProducts.Rows[i].Cells[11].Value.ToString());
                }
                else if (dgvProducts.Rows[i].Cells[11].Value.ToString().Length < 10 || dgvProducts.Rows[i].Cells[11].Value.ToString() == "" || dgvProducts.Rows[i].Cells[11].Value == null)
                {
                    customElements[i].Image = Image.FromFile("../../Resources/picture.png");
                }
                flpProducts.Controls.Add(customElements[i]);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (rbWithout.Checked)
            {
                if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And  ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%'";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 15";
                    LoadData();
                    querry = querryout;
                }
                else
                    LoadData();
            }
            if (rbAscending.Checked)
            {
                if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 15 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else
                {
                    string querryout = querry;
                    querry += $" order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
            }
            else if (rbDescending.Checked)
            {
                if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 15 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else
                {
                    string querryout = querry;
                    querry += $" order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
            }
            //if (tbSearch.Text == "")
            //{
            //    LoadData();
            //}
            //else if (cbSort.SelectedIndex == 1)
            //{
            //    string querryout = querry;
            //    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99";
            //    LoadData();
            //    querry = querryout;
            //}
            //else if (cbSort.SelectedIndex == 2)
            //{
            //    string querryout = querry;
            //    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99";
            //    LoadData();
            //    querry = querryout;
            //}
            //else if (cbSort.SelectedIndex == 3)
            //{
            //    string querryout = querry;
            //    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15";
            //    LoadData();
            //    querry = querryout;
            //}
            //else
            //{
            //    string querryout = querry;
            //    querry += $" Where ProductDescription Like '%{tbSearch.Text}%'";
            //    LoadData();
            //    querry = querryout;
            //}
        }


        private void rbWithout_CheckedChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%'";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 15";
                LoadData();
                querry = querryout;
            }
            else
            LoadData();
        }

        private void rbAscending_CheckedChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15 order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 15 order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }
            else
            {
                string querryout = querry;
                querry += $" order by ProductCost Asc";
                LoadData();
                querry = querryout;
            }

            //dgvProducts.Rows.Clear();
            //DataBank.Connection.Open();

            //SqlCommand sqlCommand = new SqlCommand(querry, DataBank.Connection);
            ////$"Select Product.*, ProductCategory.Title, ProductSupplier.Title, ProductManufacturer.Title, ProductTitle.Title From Product Inner join ProductCategory On Product.ProductCategory = ProductCategory.CategoryID inner join ProductSupplier On Product.ProductSupplier=ProductSupplier.SupplierID inner join ProductManufacturer On Product.ProductManufacturer = ProductManufacturer.ManufacturerID inner join ProductTitle On Product.ProductName = ProductTitle.ProductNameID order by ProductCost Asc"
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //List<string[]> data = new List<string[]>();

            //while (sqlDataReader.Read())
            //{
            //    data.Add(new string[17]);

            //    data[data.Count - 1][0] = sqlDataReader[0].ToString();
            //    data[data.Count - 1][1] = sqlDataReader[1].ToString();
            //    data[data.Count - 1][2] = sqlDataReader[2].ToString();
            //    data[data.Count - 1][3] = sqlDataReader[3].ToString();
            //    data[data.Count - 1][4] = sqlDataReader[4].ToString();
            //    data[data.Count - 1][5] = sqlDataReader[5].ToString();
            //    data[data.Count - 1][6] = sqlDataReader[6].ToString();
            //    data[data.Count - 1][7] = sqlDataReader[7].ToString();
            //    data[data.Count - 1][8] = sqlDataReader[8].ToString();
            //    data[data.Count - 1][9] = sqlDataReader[9].ToString();
            //    data[data.Count - 1][10] = sqlDataReader[10].ToString();
            //    data[data.Count - 1][11] = sqlDataReader[11].ToString();
            //    data[data.Count - 1][12] = sqlDataReader[12].ToString();
            //    data[data.Count - 1][13] = sqlDataReader[13].ToString();
            //    data[data.Count - 1][14] = sqlDataReader[14].ToString();
            //    data[data.Count - 1][15] = sqlDataReader[15].ToString();
            //    data[data.Count - 1][16] = sqlDataReader[16].ToString();
            //}

            //sqlDataReader.Close();
            //DataBank.Connection.Close();

            //foreach (string[] s in data)
            //{
            //    dgvProducts.Rows.Add(s);
            //}
            //PopulatesItems();
        }

        private void rbDescending_CheckedChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15 order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
            {
                string querryout = querry;
                querry += $" Where ProductDescription Like '%{tbSearch.Text}%' order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
            else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
            {
                string querryout = querry;
                querry += $" Where ProductDiscountAmount >= 15 order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
            else
            {
                string querryout = querry;
                querry += $" order by ProductCost Desc";
                LoadData();
                querry = querryout;
            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbWithout.Checked)
            {
                if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And  ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%'";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 15";
                    LoadData();
                    querry = querryout;
                }
                else
                    LoadData();
            }
            if (rbAscending.Checked)
            {
                if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 15 order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
                else
                {
                    string querryout = querry;
                    querry += $" order by ProductCost Asc";
                    LoadData();
                    querry = querryout;
                }
            }
            else if (rbDescending.Checked)
            {
                if (tbSearch.Text != "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' And ProductDiscountAmount >= 15 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text != "" && cbSort.SelectedIndex == 0)
                {
                    string querryout = querry;
                    querry += $" Where ProductDescription Like '%{tbSearch.Text}%' order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 1)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99 order order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 2)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else if (tbSearch.Text == "" && cbSort.SelectedIndex == 3)
                {
                    string querryout = querry;
                    querry += $" Where ProductDiscountAmount >= 15 order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
                else
                {
                    string querryout = querry;
                    querry += $" order by ProductCost Desc";
                    LoadData();
                    querry = querryout;
                }
            }
            //else if (cbSort.SelectedIndex == 1)
            //{
            //    dgvProducts.Rows.Clear();
            //    DataBank.Connection.Open();

            //    SqlCommand sqlCommand = new SqlCommand(querry, DataBank.Connection);
            //    // $"Select Product.*, ProductCategory.Title, ProductSupplier.Title, ProductManufacturer.Title, ProductTitle.Title From Product Inner join ProductCategory On Product.ProductCategory = ProductCategory.CategoryID inner join ProductSupplier On Product.ProductSupplier=ProductSupplier.SupplierID inner join ProductManufacturer On Product.ProductManufacturer = ProductManufacturer.ManufacturerID inner join ProductTitle On Product.ProductName = ProductTitle.ProductNameID Where ProductDiscountAmount >= 0 And ProductDiscountAmount <= 9.99"
            //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //    List<string[]> data = new List<string[]>();

            //    while (sqlDataReader.Read())
            //    {
            //        data.Add(new string[17]);

            //        data[data.Count - 1][0] = sqlDataReader[0].ToString();
            //        data[data.Count - 1][1] = sqlDataReader[1].ToString();
            //        data[data.Count - 1][2] = sqlDataReader[2].ToString();
            //        data[data.Count - 1][3] = sqlDataReader[3].ToString();
            //        data[data.Count - 1][4] = sqlDataReader[4].ToString();
            //        data[data.Count - 1][5] = sqlDataReader[5].ToString();
            //        data[data.Count - 1][6] = sqlDataReader[6].ToString();
            //        data[data.Count - 1][7] = sqlDataReader[7].ToString();
            //        data[data.Count - 1][8] = sqlDataReader[8].ToString();
            //        data[data.Count - 1][9] = sqlDataReader[9].ToString();
            //        data[data.Count - 1][10] = sqlDataReader[10].ToString();
            //        data[data.Count - 1][11] = sqlDataReader[11].ToString();
            //        data[data.Count - 1][12] = sqlDataReader[12].ToString();
            //        data[data.Count - 1][13] = sqlDataReader[13].ToString();
            //        data[data.Count - 1][14] = sqlDataReader[14].ToString();
            //        data[data.Count - 1][15] = sqlDataReader[15].ToString();
            //        data[data.Count - 1][16] = sqlDataReader[16].ToString();
            //    }

            //    sqlDataReader.Close();
            //    DataBank.Connection.Close();

            //    foreach (string[] s in data)
            //    {
            //        dgvProducts.Rows.Add(s);
            //    }
            //    PopulatesItems();
            //}
            //else if (cbSort.SelectedIndex == 2)
            //{
            //    dgvProducts.Rows.Clear();
            //    DataBank.Connection.Open();

            //    SqlCommand sqlCommand = new SqlCommand(querry, DataBank.Connection);
            //    // $"Select Product.*, ProductCategory.Title, ProductSupplier.Title, ProductManufacturer.Title, ProductTitle.Title From Product Inner join ProductCategory On Product.ProductCategory = ProductCategory.CategoryID inner join ProductSupplier On Product.ProductSupplier=ProductSupplier.SupplierID inner join ProductManufacturer On Product.ProductManufacturer = ProductManufacturer.ManufacturerID inner join ProductTitle On Product.ProductName = ProductTitle.ProductNameID Where ProductDiscountAmount >= 10 And ProductDiscountAmount <= 14.99"
            //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //    List<string[]> data = new List<string[]>();

            //    while (sqlDataReader.Read())
            //    {
            //        data.Add(new string[17]);

            //        data[data.Count - 1][0] = sqlDataReader[0].ToString();
            //        data[data.Count - 1][1] = sqlDataReader[1].ToString();
            //        data[data.Count - 1][2] = sqlDataReader[2].ToString();
            //        data[data.Count - 1][3] = sqlDataReader[3].ToString();
            //        data[data.Count - 1][4] = sqlDataReader[4].ToString();
            //        data[data.Count - 1][5] = sqlDataReader[5].ToString();
            //        data[data.Count - 1][6] = sqlDataReader[6].ToString();
            //        data[data.Count - 1][7] = sqlDataReader[7].ToString();
            //        data[data.Count - 1][8] = sqlDataReader[8].ToString();
            //        data[data.Count - 1][9] = sqlDataReader[9].ToString();
            //        data[data.Count - 1][10] = sqlDataReader[10].ToString();
            //        data[data.Count - 1][11] = sqlDataReader[11].ToString();
            //        data[data.Count - 1][12] = sqlDataReader[12].ToString();
            //        data[data.Count - 1][13] = sqlDataReader[13].ToString();
            //        data[data.Count - 1][14] = sqlDataReader[14].ToString();
            //        data[data.Count - 1][15] = sqlDataReader[15].ToString();
            //        data[data.Count - 1][16] = sqlDataReader[16].ToString();
            //    }

            //    sqlDataReader.Close();
            //    DataBank.Connection.Close();

            //    foreach (string[] s in data)
            //    {
            //        dgvProducts.Rows.Add(s);
            //    }
            //    PopulatesItems();
            //}
            //else if (cbSort.SelectedIndex == 3)
            //{
            //    dgvProducts.Rows.Clear();
            //    DataBank.Connection.Open();

            //    SqlCommand sqlCommand = new SqlCommand(querry, DataBank.Connection);
            //    // $"Select Product.*, ProductCategory.Title, ProductSupplier.Title, ProductManufacturer.Title, ProductTitle.Title From Product Inner join ProductCategory On Product.ProductCategory = ProductCategory.CategoryID inner join ProductSupplier On Product.ProductSupplier=ProductSupplier.SupplierID inner join ProductManufacturer On Product.ProductManufacturer = ProductManufacturer.ManufacturerID inner join ProductTitle On Product.ProductName = ProductTitle.ProductNameID Where ProductDiscountAmount >= 15"
            //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //    List<string[]> data = new List<string[]>();

            //    while (sqlDataReader.Read())
            //    {
            //        data.Add(new string[17]);

            //        data[data.Count - 1][0] = sqlDataReader[0].ToString();
            //        data[data.Count - 1][1] = sqlDataReader[1].ToString();
            //        data[data.Count - 1][2] = sqlDataReader[2].ToString();
            //        data[data.Count - 1][3] = sqlDataReader[3].ToString();
            //        data[data.Count - 1][4] = sqlDataReader[4].ToString();
            //        data[data.Count - 1][5] = sqlDataReader[5].ToString();
            //        data[data.Count - 1][6] = sqlDataReader[6].ToString();
            //        data[data.Count - 1][7] = sqlDataReader[7].ToString();
            //        data[data.Count - 1][8] = sqlDataReader[8].ToString();
            //        data[data.Count - 1][9] = sqlDataReader[9].ToString();
            //        data[data.Count - 1][10] = sqlDataReader[10].ToString();
            //        data[data.Count - 1][11] = sqlDataReader[11].ToString();
            //        data[data.Count - 1][12] = sqlDataReader[12].ToString();
            //        data[data.Count - 1][13] = sqlDataReader[13].ToString();
            //        data[data.Count - 1][14] = sqlDataReader[14].ToString();
            //        data[data.Count - 1][15] = sqlDataReader[15].ToString();
            //        data[data.Count - 1][16] = sqlDataReader[16].ToString();
            //    }

            //    sqlDataReader.Close();
            //    DataBank.Connection.Close();

            //    foreach (string[] s in data)
            //    {
            //        dgvProducts.Rows.Add(s);
            //    }
            //    PopulatesItems();
            //}
        }
    }
}
