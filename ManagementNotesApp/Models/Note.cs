using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementNotesApp.Models
{
    public class Note
    {
        /// <summary>
        /// The unique Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The note text
        /// </summary>
        public string TextNote { get; set; }
    }
}
