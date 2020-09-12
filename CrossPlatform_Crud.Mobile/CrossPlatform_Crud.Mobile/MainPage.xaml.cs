using CrossPlatform_Crud.Mobile.Logic;
using System;
using Xamarin.Forms;

namespace CrossPlatform_Crud.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var model = await CustomerLogic.GetCustomers();

            customerListView.ItemsSource = model;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
