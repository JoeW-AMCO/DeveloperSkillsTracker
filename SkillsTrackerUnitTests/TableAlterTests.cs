using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperSkillsTracker;
using DeveloperSkillsTracker.Database;
using Spectre.Console.Testing;
using Spectre.Console;

namespace SkillsTrackerUnitTests
{
    [TestClass]
    public class TableAlterTests
    {
        private StringReader _input;
        private StringWriter _output;
        private MyDbContext _context;
        private string username = "t";
        private int userId = 2;
        private string attributeChoice = "Skills"; //"Skills", "Experiences", "Certifications", "Exit"
        private string changeChoice = "Add"; //"Add", "Delete", "Edit", "Back"

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize common test setup
            _context = new MyDbContext();
            _output = new StringWriter();
            Console.SetOut(_output);
        }

        [TestMethod]
        public void AddingAttributeToTable()
        {
            // Arrange
            _input = new StringReader("Test Skill Name\nTest Skill Description\n");
            Console.SetIn(_input);
            UserProfile profile = new UserProfile(username, userId);

            // Act
            Menus.AddMenu(_context, profile, attributeChoice, changeChoice);            

            // Assert            
            DimSkill lastSkill = _context.Skills.OrderBy(s => s.Skill_ID).Last();
            Assert.AreEqual("Test Skill Name", lastSkill.Skill_Name);
            Assert.AreEqual("Test Skill Description", lastSkill.Skill_Description);
        }

        [TestMethod]
        public void EditingAttributeInTable()
        {
            // Arrange           
            string testSkillName = "Changed Test Skill Name";
            string testSkillDescription = "Changed Test Skill Description";            
            UserProfile profile = new UserProfile(username, userId);
            DimSkill lastSkill = _context.Skills.OrderBy(s => s.Skill_ID).Last();
            int lastSkillID = lastSkill.Skill_ID;

            // Act           
            DimSkill.ChangeUserAttribute(profile.UserId, lastSkillID, testSkillName, testSkillDescription, _context);

            // Assert            
            Assert.AreEqual("Changed Test Skill Name", lastSkill.Skill_Name);
            Assert.AreEqual("Changed Test Skill Description", lastSkill.Skill_Description);
        }

        [TestMethod]
        public void DeletingAttributeFromTable()
        {
            // Arrange
            UserProfile profile = new UserProfile(username, userId);
            DimSkill lastSkill = _context.Skills.OrderBy(s => s.Skill_ID).Last();    
            int lastSkillID = lastSkill.Skill_ID;

            // Act           
            lastSkill.DeleteUserAttribute(_context);
            DimSkill newLastSkill = _context.Skills.OrderBy(s => s.Skill_ID).Last();
            int newLastSkillID = newLastSkill.Skill_ID;

            // Assert            
            Assert.AreNotEqual(lastSkillID, newLastSkillID);
        }        
    }
}