using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace тест1пишистирай
{
    public partial class CustomElement : UserControl
    {
        private string _name;
        private string _description;
        private string _manufacturer;
        private string _cost;
        private string _discount;
        private Image _iamge;

        public Image Image
        {
            get { return _iamge; }
            set { _iamge = value; pbImage.Image = value; }
        }
        public string Discount
        {
            get { return _discount; }
            set { _discount = value; lDiscount.Text += $" {value}"; }
        }
        public string Cost
        {
            get { return _cost; }
            set { _cost = value; lCost.Text = value; }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; lManufacturer.Text += $" {value}"; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; lDescription.Text += $" {value}"; }
        }
        public string PName
        {
            get { return _name; }
            set { _name = value; lName.Text = value; }
        }
        public CustomElement()
        {
            InitializeComponent();
        }
    }
}
