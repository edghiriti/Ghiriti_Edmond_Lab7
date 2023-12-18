namespace Ghiriti_Edmond_Lab7;
using Ghiriti_Edmond_Lab7.Models;

public partial class ListPage : ContentPage
{
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

}