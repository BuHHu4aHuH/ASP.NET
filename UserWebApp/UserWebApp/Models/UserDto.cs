namespace UserWebApp.Models
{

    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The user dto.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets user dateOfBithday.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime dateOfBirthday { get; set; }
    }
}
