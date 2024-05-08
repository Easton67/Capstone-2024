using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class MembershipApplication
    {
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Model class for the membership application
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [DisplayName("First Name")]
        public string _firstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string _lastName { get; set; }

        [Required]
        [DisplayName("D.O.B.")]
        public string _dateOfBirth { get; set; }

        [Required]
        [DisplayName("Sex")]
        public string _sex { get; set; }

        [Required]
        [DisplayName("SSN")]
        public string _ssn { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string _phoneNumber { get; set; }

        [Required]
        [DisplayName("Email")]
        public string _emailAddress { get; set; }

        [Required]
        [DisplayName("Status")]
        public string _status { get; set; }
    }
}
