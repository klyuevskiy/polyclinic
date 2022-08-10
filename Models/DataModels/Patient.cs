using System.ComponentModel.DataAnnotations;

namespace Models.DataModels
{
    public class Patient : BaseModel
    {
        [Required]
        public string FIO { get; set; } = "";

        [Required]
        public string PhoneNumber { get; set; } = "";

        public override string ToString()
        {
            return FIO;
        }
    }
}
