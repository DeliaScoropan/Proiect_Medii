using Proiect_Medii.Models;
using Proiect_Medii.Database;
namespace Proiect_Medii;

public partial class ProductPage : ContentPage
{
    Items sl;
	public ProductPage(Items slist)
	{
		InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        await App.Database.SaveProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        await App.Database.DeleteProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Product p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Product;
            var lp = new ProductList()
            {
                ItemsID = sl.ID,
                ProductID = p.ID
            };
            await App.Database.SaveListProductAsync(lp);
            p.ProductLists = new List<ProductList> { lp };
            await Navigation.PopAsync();
        }
    }
}