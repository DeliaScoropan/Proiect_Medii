using Proiect_Medii.Models;

namespace Proiect_Medii;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Items)BindingContext;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Items)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((Items)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Items)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Product product;
        var shopList = (Items)BindingContext;
        if (listView.SelectedItem != null)
        {
            product = listView.SelectedItem as Product;
            var listProductAll = await App.Database.GetListProducts();
            var listProduct = listProductAll.FindAll(x => x.ProductID == product.ID & x.ItemsID == shopList.ID);
            await App.Database.DeleteListProductAsync(listProduct.FirstOrDefault());
            await Navigation.PopAsync();
        }

    }
}