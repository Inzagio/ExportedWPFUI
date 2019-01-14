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
            set => _certifications = value;
        }

        public FirstChildViewModel()
        {
            DisplayCertifications();
        }

        public async void DisplayCertifications()
        {
            var client = new Client("https://localhost:44367");
             Certifications = await client.GetCertificationsAsync("") as BindableCollection<Certification>;
            //_certifications = certifications;
        }
    }
}
