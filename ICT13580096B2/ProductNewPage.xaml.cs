using System;
using System.Collections.Generic;
using ICT13580096B2.Models;
using Xamarin.Forms;

namespace ICT13580096B2
{
	public partial class ProductNewPage : ContentPage
	{

        Product product;

        public ProductNewPage(Product product = null)
		{
			InitializeComponent();

            this.product = product;

			yes.Clicked += Yes_Clicked;
			not.Clicked += Can_Clicked;
			catigory.Items.Add("เสื้อ");
			catigory.Items.Add("กางเกง");
			catigory.Items.Add("ถุงเท้า");

            if (product != null)
            {
                titleLabel.Text = "แก้ไขข้อมูลสินค้า";
                name.Text = product.Name;
                ditel.Text = product.Descriptions;
                catigory.SelectedItem = product.Category;
                sellproduct.Text = product.ProductPrice.ToString();
                sell.Text = product.sellPrice.ToString();
                num.Text = product.Strock.ToString();
            }

		}

		async void Yes_Clicked(object sender, EventArgs e)
		{
			var isYes = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
			if (isYes)
			{
                if (product == null)
                {
                    product = new Product();
                    product.Name = name.Text;
                    product.Descriptions = ditel.Text;
                    product.Category = catigory.SelectedItem.ToString();
                    product.ProductPrice = decimal.Parse(sellproduct.Text);
                    product.sellPrice = decimal.Parse(sell.Text);
                    product.Strock = int.Parse(num.Text);
                    var Id = App.DbHelper.AddProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + Id, "ตกลง");

                }
                else
                {
					product.Name = name.Text;
					product.Descriptions = ditel.Text;
					product.Category = catigory.SelectedItem.ToString();
					product.ProductPrice = decimal.Parse(sellproduct.Text);
					product.sellPrice = decimal.Parse(sell.Text);
					product.Strock = int.Parse(num.Text);
                    var Id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย" + Id, "ตกลง");
                }
                await Navigation.PopModalAsync();
			}
		}

		void Can_Clicked(object sender, EventArgs e)
		{
            Navigation.PopModalAsync();
		}
	}
}
