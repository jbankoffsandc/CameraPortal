using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace jQueryDatatableServerSideNetCore.Models.DatabaseModels
{
    public class Camera
    {
        public int camera_id { get; set; }

        public string department { get; set; }

        public string location { get; set; }
       // [DefaultValue("Click here")]
      //  [Ignore]
      //  public string hyperlink { get; set; } = "Click here";
        public string serial_no { get; set; }

        public string mac_address { get; set; }

        public string ip_address { get; set; }

       
    }
}
