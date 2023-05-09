using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser
    {
        // in C# we use pascal casing
        [Key]
        public int Id { get; set; }
        // in C# int are not optional that's why we have to provide value to the int
        public string UserName { get; set; }
        // while in string it can be optional means string can be null aswell
        //currently we disabled the nullable

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}