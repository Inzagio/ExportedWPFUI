using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;


namespace WPFUI.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }


        public string FullInfo => $"{FirstName} {LastName} ({EmailAddress})";

        //public Action<TaskResult> blablabal()
        //{
        //    var client = new Client("localhost");
        //    client.GetCertificationAsync(Guid.Empty);
        //}
    }
}
