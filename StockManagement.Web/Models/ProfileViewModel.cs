using StockManagement.DTO.DTO;

namespace StockManagement.Web.Models
{
    public class ProfileViewModel
    {
        public UserInformationDTO UserInformation { get; set; }
        public ChangePasswordDTO ChangePassword { get; set; }
    }
}
