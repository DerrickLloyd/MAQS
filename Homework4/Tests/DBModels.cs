using Dapper.Contrib.Extensions;

namespace Tests
{
    /// <summary>
    /// Class representing the user table.
    /// </summary>
    [Table("users")]
    public class User
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
    }

    /// <summary>
    /// Class representing the product table.
    /// </summary>
    [Table("products")]
    public class Product
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string ProductName { get; set; }
    }
}
