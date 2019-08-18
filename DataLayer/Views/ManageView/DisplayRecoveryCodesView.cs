using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.ManageView
{
    public class DisplayRecoveryCodesView
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }

    }
}
