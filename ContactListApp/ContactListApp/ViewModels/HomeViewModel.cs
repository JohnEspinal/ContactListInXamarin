using ContactListApp;
using ContactListApp.Models;
using ContactListApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactListApp.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<ContactData> Contacts { get; }

        private ICommand SelectedContactCommand { get; }

        public ICommand AddCommand { get; }

        public ICommand DeleteCommand { get; }

        public ICommand MoreCommand { get; }


        private ContactData _contact;
        public ContactData SelectedContact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;

                if (_contact != null)
                {

                    SelectedContactCommand.Execute(_contact);
                }
            }
        }

        public HomeViewModel()
        {

            SelectedContactCommand = new Command<ContactData>(OnContactSelected);
            AddCommand = new Command(OnAddContact);
            DeleteCommand = new Command<ContactData>(OnDeleteContact);
            MoreCommand = new Command<ContactData>(OnContactMore);

            Contacts = new ObservableCollection<ContactData>();
            
        }

        private async void OnContactMore(ContactData contact)
        {
            Console.WriteLine(contact.PhoneNumber);
            var selection = await App.Current.MainPage.DisplayActionSheet(null, "Cancel", null, new string[] { $"Call +{contact.PhoneNumber}", "Edit"});

            if (selection.Contains("Call"))
            {
                PhoneDialer.Open(contact.PhoneNumber);
            }
            
            if(selection == "Edit")
            {
                await App.Current.MainPage.Navigation.PushAsync(new EditContactPage(new ContactData("", "")));
            }
        }

        private void OnDeleteContact(ContactData contact)
        {
            Contacts.Remove(contact);
        }

        private async void OnAddContact()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Add contact", "Type your contact name", "Ok");
            var phoneNumber = await App.Current.MainPage.DisplayPromptAsync("Add contact", "Type your contact number", "Ok");



            Contacts.Add(new ContactData(name, phoneNumber));

        }

        private async void OnContactSelected(ContactData contact)
        {
            await App.Current.MainPage.DisplayAlert(contact.Name, contact.PhoneNumber, "Ok");
        }
    }
}
