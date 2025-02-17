using BusinessLayer.DTO.RequestDTO;
using BusinessLayer.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateAdmin();
        Task AssignRole();
        Task CreateUser(CreateUserDTO createUserDTO);
        Task<LoginResponseDTO> AdminLogin(AdminLoginDTO adminLoginDTO);
        Task<LoginResponseDTO> UserLogin(UserLoginDTO userLoginDTO);
    }
}
