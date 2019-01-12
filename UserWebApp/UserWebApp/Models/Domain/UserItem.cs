namespace UserWebApp.Models.Domain
{
    using System;

    /// <summary>
    /// The user item.
    /// </summary>
    public class UserItem
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthday date.
        /// </summary>
        public DateTime birthdayData { get; set; }
    }
}
