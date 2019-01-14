using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Caliburn.Micro;
using WPFUI.Api;


namespace WPFUI.ViewModels
{
    public class FirstChildViewModel : Screen
    {
        private BindableCollection<Certification> _certifications = new BindableCollection<Certification>();
       

        public BindableCollection<Certification> Certifications
        {
            get => _certifications;
            set
            {
                _certifications = value;
                NotifyOfPropertyChange(() => Certifications);
            }
        }

        public FirstChildViewModel()
        {
            DisplayCertifications();
        }

        public async void DisplayCertifications()
        {
            var client = new Client("https://localhost:44367");
            //Certifications = await client.GetCertificationsAsync("") as BindableCollection<Certification>;
            var certifications = await client.GetCertificationsAsync("");
            _certifications.AddRange(certifications);
            Certifications = _certifications;
            //_certifications = certifications;
        }

        public void EditRow(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                        row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }
    }
}
