using BusinessLayer.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.JWT_Helper.Interface
{
    public interface IJWT_Service
    {
        Task<LoginResponseDTO> CreateToken(string email, List<string> roles);

    }
}
