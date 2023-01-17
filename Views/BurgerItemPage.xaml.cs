using App1Burger.Data;
using App1Burger.Models;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace App1Burger.Views;

public partial class BurgerItemPage : ContentPage
{
  
    Burger Item = new Burger();
    Burger auxiliar = new Burger();
    bool _flag;
      public int ItemId
    {
        set { getBurger(value); }
    }

    private void getBurger(int id)
    {
        Burger burger = new Burger();
        burger = App.BurgerRepo.GetById(id);
        auxiliar = burger;
        BindingContext = burger;
    }
    public BurgerItemPage()
    {
        InitializeComponent();
    }

  

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            Item.Name = name.Text;
            Item.Description = desc.Text;
            Item.WithExtraCheese = _flag;
            int error = App.BurgerRepo.AddNewBurger(Item);
            if (error == 100)
            {
                await DisplayAlert("Alerta", "ya se ha ingresado una hamburguesa con ese nombre", "OK");
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        else
        {
            App.BurgerRepo.updateBurger(auxiliar.Id, auxiliar.Name, auxiliar.Description, auxiliar.WithExtraCheese);
            await Shell.Current.GoToAsync("..");
        }
    }
    
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void OnCheckBoxCheckedChanged(object sender,
   CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        App.BurgerRepo.deleteBurger(auxiliar.Id);
        await Shell.Current.GoToAsync("..");
    }

   

}
