using Caliburn.Micro;
using System;
using System.Windows;
using WPFUI.Api;

namespace WPFUI.ViewModels
{
    public class SecondChildViewModel : Screen
    {
        private string _firstName;

        private string _middleName;

        private string _lastName;

        private BindableCollection<Person> _people = new BindableCollection<Person>();

        private Client client = new Client("https://localhost:44367");

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => MiddleName);
                NotifyOfPropertyChange(() => LastName);
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
            }
        }

        public string FullName => $"{ FirstName } {MiddleName} { LastName }";

        public BindableCollection<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                NotifyOfPropertyChange(() => People);
            }
        }

        public SecondChildViewModel()
        {
            DisplayPeople();
        }

        public async void DisplayPeople()
        {

            var people = await client.GetPeopleAsync("");
            _people.AddRange(people);
            People = _people;
           
        }

        public async void SaveUpdate()
        {
            //var client = new Client("https://localhost:44367");
            //var getPerson = client.GetPersonAsync();
            //var test = await client.PutPersonAsync();
        }

        public async void SaveNewPerson()
        {
            var personAddress = new Address { CityName = "Larvik", Country = "Norway", CountyName = "Vestfold", PostalCode = "3265", StreetName = "Torget10", Id = new Guid() };
            var personCertifications = new Certification
            { Description = "Most valuable programmer", Name = "MVP", Id = new Guid() };
            var personQualification = new Qualification { Description = "A Part of the Microsoft technology stack", Name = "C#", Id = new Guid() };
            var person = new Person
            {
                Address = personAddress,
                Certification = personCertifications,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                FullName = FullName,
                Id = new Guid(),
                Qualification = personQualification,
                YearOfBirth = 1945
            };
            try
            {
                await client.PostPersonAsync(person);
                NotifyOfPropertyChange(() => People);
            }
            catch (Exception e)
            {
                //string messageBoxText = $"Missing property: {e}";
                //string caption = "Programmers CV";
                //MessageBoxButton button = MessageBoxButton.OK;
                //MessageBoxImage icon = MessageBoxImage.Warning;
                //MessageBox.Show(messageBoxText, caption, button, icon);
                
            }
          
        }


    }
}
