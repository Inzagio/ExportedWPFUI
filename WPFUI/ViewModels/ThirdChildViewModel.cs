using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WPFUI.Api;

namespace WPFUI.ViewModels
{
    public class ThirdChildViewModel : Screen
    {
        private BindableCollection<Address> _addresses = new BindableCollection<Address>();


        public BindableCollection<Address> Addresses
        {
            get => _addresses;
            set
            {
                _addresses = value;
                NotifyOfPropertyChange(() => Addresses);
            }
        }

        public ThirdChildViewModel()
        {
            DisplayAddresses();
        }

        public async void DisplayAddresses()
        {
            var client = new Client("https://localhost:44367");
            var addresses = await client.GetAddressesAsync("");
            _addresses.AddRange(addresses);
            Addresses = _addresses;
        }
    }
}
