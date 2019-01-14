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
    }
}
