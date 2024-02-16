using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas_DOMAIN.DTOs
{
    public class GuestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string DocumentNumber { get; set; }

    }
}
