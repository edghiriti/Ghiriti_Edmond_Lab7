namespace Ghiriti_Edmond_Lab7;
using Ghiriti_Edmond_Lab7.Models;

public partial class ListPage : ContentPage
{
    Product selProduct;
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext; // Retrieve the bound ShopList
        slist.Date = DateTime.UtcNow; // Update the Date property with the current UTC time
        await App.Database.SaveShopListAsync(slist); // Save the ShopList to the database
        await Navigation.PopAsync(); // Pop the current page from the navigation stack
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext; // Retrieve the bound ShopList
        await App.Database.DeleteShopListAsync(slist); // Delete the ShopList from the database
        await Navigation.PopAsync(); // Pop the current page from the navigation stack
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext)
        {
            BindingContext = new Product()
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var shopl = (ShopList)BindingContext;

        // Set the ItemsSource of the listView to the result of GetListProductsAsync
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }


    async void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteProductFromListAsync(slist, selProduct);
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e) 
    {
       selProduct = e.SelectedItem as Product;
    }
}