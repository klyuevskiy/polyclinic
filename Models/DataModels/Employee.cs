using System.ComponentModel.DataAnnotations;

namespace Models.DataModels
{
    public class Employee : BaseModel
    {
        [Required]
        public string Login { get; set; } = "";

        [Required]
        public string Password { get; set; }

        [Required]
        public string FIO { get; set; } = "";

        public override string ToString()
        {
            return FIO;
        }
    }
}
