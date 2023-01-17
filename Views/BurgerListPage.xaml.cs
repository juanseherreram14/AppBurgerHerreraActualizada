using App1Burger.Models;
using System.Collections.Generic;

namespace App1Burger.Views;

public partial class BurgerListPage : ContentPage
{
    public BurgerListPage()
    {
        InitializeComponent();
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage));
        await Navigation.PushAsync(new BurgerItemPage());

    }

    private void refreshBurger(object sender, EventArgs e)
    {
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }

    private async void changeSeleccion(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var hamburguesa = (Models.Burger)e.CurrentSelection[0];
            await Shell.Current.GoToAsync($"{nameof(BurgerItemPage)}?{nameof(BurgerItemPage.ItemId)}={hamburguesa.Id}");
            burgerList.SelectedItem = null;
        }
    }
}