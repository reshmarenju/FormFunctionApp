using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFunctionApp.Models
{
public class SubmittedForm
    {
        public Guid Id { get; set; }
        public Guid VesselId { get; set; }
 //       public Vessel Vessel { get; set; }
        public string IMO { get; set; }
        public string Data { get; set; }

        public string VoyageNo { get; set; }

        public string Port { get; set; }

        public DateTimeOffset Effective { get; set; }

        public DateTimeOffset Recieved { get; set; }

        public string Location { get; set; }
     //   public SubmittedFormType Type { get; set; }
      //  public AppSubmittedFormstatus Status { get; set; }
        public string Remark { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string FormIdentifier { get; set; }
    }
}
