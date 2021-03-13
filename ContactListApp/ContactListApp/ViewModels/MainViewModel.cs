using ContactListApp;
using ContactListApp.Models;
using ContactListApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactListApp.ViewModels
{
    public class MainViewModel
    {

        public ICommand CommandStart { get; }

        

        public MainViewModel()
        {

            CommandStart = new Command(OnStart);



        }

        private async void OnStart()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
        }

        
    }
}
