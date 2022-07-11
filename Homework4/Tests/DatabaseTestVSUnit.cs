using CognizantSoftvision.Maqs.BaseDatabaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Tests test class with VSUnit
    /// </summary>
    [TestClass]
    public class DatabaseTestVSUnit : BaseDatabaseTest
    {
        /// <summary>
        /// Get record using stored procedure
        /// </summary>
        [TestMethod]
        public void GetRecordTest()
        {

            //Select
            IEnumerable<dynamic> users = this.DatabaseDriver.Query("SELECT * from users");
            Assert.AreEqual(10, users.Count(), "Expected 10 rows");

            List<User> table = this.DatabaseDriver.Query<User>("SELECT * from users").ToList();
            Assert.AreEqual("Bob", table[0].FirstName, "Wrong First Name of user");


            //Insert
            User userInsert = new User
            {
                Id = 11,
                FirstName = "Derrick",
                LastName = "Pua",

            };

            long id = this.DatabaseDriver.Insert(userInsert);
            Assert.AreEqual(11, DatabaseDriver.Query<User>("SELECT * from users").ToList().Count);
            Assert.AreEqual(userInsert.Id, id);

            List<User> insert = this.DatabaseDriver.Query<User>($"SELECT FirstName from users where Id = '{userInsert.Id}'").ToList();
            Assert.AreEqual(userInsert.FirstName, insert[0].FirstName);


            //Update
            User userUpdate = new User
            {
                Id = 11,
                FirstName = "Derrick1",
                LastName = "Pua1",

            };

            bool updated = this.DatabaseDriver.Update(userUpdate);
            Assert.AreEqual(true, updated);
            List<User> update = this.DatabaseDriver.Query<User>($"SELECT FirstName from users where Id = '{userUpdate.Id}'").ToList();
            Assert.AreEqual(userUpdate.FirstName, update[0].FirstName);


            //Delete
            int numDeleted = this.DatabaseDriver.Execute($"delete from users where FirstName = '{userUpdate.FirstName}'");
            Assert.AreEqual(1, numDeleted);
            Assert.AreEqual(10, DatabaseDriver.Query<User>("SELECT * from users").ToList().Count);
            
        }
    }
}