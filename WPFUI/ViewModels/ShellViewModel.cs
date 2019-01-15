using Caliburn.Micro;
using System.Diagnostics.CodeAnalysis;
using WPFUI.Models;
using WPFUI.Api;

namespace WPFUI.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;

        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Trym", LastName = "Test" });
            People.Add(new PersonModel { FirstName = "test", LastName = "Testesen" });
            People.Add(new PersonModel { FirstName = "Virkelig", LastName = "TEst" });
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => MiddleName);
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => MiddleName);
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => MiddleName);
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName => $"{ FirstName } {MiddleName} { LastName }";

        public BindableCollection<PersonModel> People
        {
            get => _people;
            set => _people = value;
        }

        public PersonModel SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string middleName, string lastName) => !string.IsNullOrWhiteSpace(firstName) | !string.IsNullOrWhiteSpace(middleName) | !string.IsNullOrWhiteSpace(lastName);

        public void ClearText(string firstName, string middleName, string lastName)
        {
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
        }

        
        public void DisplayCertifications()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void DisplayPeople()
        {
            ActivateItem(new SecondChildViewModel());
        }

        public void DisplayAddresses()
        {
            ActivateItem(new ThirdChildViewModel());
        }
    }
}
