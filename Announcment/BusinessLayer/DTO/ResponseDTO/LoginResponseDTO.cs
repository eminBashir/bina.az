using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.ResponseDTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
