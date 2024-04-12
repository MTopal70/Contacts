using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Salutation { get; set; }

        [Required, MinLength(3)]
        public string Firstname { get; set; }

        [Required, MinLength(3)]
        public string Lastname { get; set; }

        private string _displayname;
        public string Displayname
        {
            get
            {
                if (string.IsNullOrEmpty(_displayname))
                {
                    return $"{Salutation} {Firstname} {Lastname}";
                }
                else
                {
                    return _displayname;
                }
            }
            set
            {
                _displayname = value;
            }
        }

        public DateTime? Birthdate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTimestamp { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime LastChangeTimestamp { get; set; }

        public bool NotifyHasBirthdaySoon { get; private set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
