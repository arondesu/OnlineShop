using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShop.Forms;

namespace OnlineShop
{
    public partial class ExtraItemForm : UserControl
    {
        public ExtraItemForm()
        {
            InitializeComponent();
            itemListData();
        }

        public void itemListData()
        {
            AddItemData addItemData = new AddItemData();
            List<AddItemData> listDatas = addItemData.itemListData();

            moreProductList.DataSource = listDatas;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bck_btn_Click(object sender, EventArgs e)
        {
            //Calling the MainShop form
            MainShop mn = new MainShop();
            mn.Show();
            this.Hide();
        }
    }
}
