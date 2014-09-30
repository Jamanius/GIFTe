using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClientSideApp.Models
{
   public partial class Gift
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

        public void CloneValues(Gift gift)
        {
            this.title = gift.title;
            this.comments = gift.comments;
            this.description = gift.description;
            this.gift_type = gift.gift_type;
            this.image = gift.image;
            this.location = gift.location;
            this.Latitude = gift.Latitude;
            this.Longitude = gift.Longitude;
            this.status = gift.status;
        }
    }
}