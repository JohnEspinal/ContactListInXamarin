using ContactListApp.Models;
using ContactListApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactListApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        public EditContactPage(ContactData contact)
        {
            
            InitializeComponent();

            nameEntry.Text = contact.Name;
            phoneNumberEntry.Text = contact.PhoneNumber;
            BindingContext = new MainViewModel();
        }

    }
}