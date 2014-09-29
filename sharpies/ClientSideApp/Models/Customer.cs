using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClientSideApp.Models
{
    public partial class Customer
    {
        [DataMember]
        public DateTime created_at
        {
            get { return this.CreatedOn; }
        }

        [DataMember]
        public DateTime updated_at
        {
            get { return this.UpdatedOn; }
        }

        public void CloneValues(Customer customer)
        {
            this.Email = customer.Email;
            this.Phone_number = customer.Phone_number;
            this.Name = customer.Name;
        }
    }
}