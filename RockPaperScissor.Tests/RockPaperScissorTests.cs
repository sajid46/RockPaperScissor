using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissor.RockPaperScissor.Interfaces;
using RockPaperScissor.RockPaperScissor.Service;

namespace RockPaperScissor.Tests
{
    [TestClass]
    public class RockPaperScissorTests
    {

        private readonly RockPaperScissorService _sut;
        private readonly Mock<IRockPaperScissorService> _RockPaperScissorMock = new Mock<IRockPaperScissorService>();
        enum OutcomeEnums { Player_Wins = 1, Computer_Wins, Tie,
            Wrong_Entry
        }

        public RockPaperScissorTests()
        {
            _sut = new RockPaperScissorService();
        }

        [TestMethod]
        public void IsValidEntry_Valid_When_P_Entered()
        {
            var results = _sut.PlayGame('K', 'R');
            Assert.AreEqual(OutcomeEnums.Wrong_Entry.ToString(), results);

        }

        [TestMethod]
        public void PlayGame_ItsTie_WhenPlayerEntry_R_ComputerEntry_R()
        {
            var results = _sut.PlayGame('R', 'R');
            Assert.AreEqual(OutcomeEnums.Tie.ToString(), results);
        }

        [TestMethod]
        public void PlayGame_PLayerWins_WhenPlayerEntry_P_ComputerEntry_R()
        {
            var results = _sut.PlayGame('P', 'R');
            Assert.AreEqual(OutcomeEnums.Computer_Wins.ToString(), results);
        }

        [TestMethod]
        public void PlayGame_ComputerrWins_WhenPlayerEntry_S_ComputerEntry_R()
        {
            var results = _sut.PlayGame('S', 'R');
            Assert.AreEqual(OutcomeEnums.Computer_Wins.ToString(), results);
        }

        //[TestMethod]
        //public void IsValidEntry_Valid_When_R_Entered()
        //{
        //    var results = _sut.PlayGame('K', 'R');
        //    Assert.AreEqual("wrong entry", results);
        //}

        //[TestMethod]
        //public void IsHumanWin_HumanWins_When_HumanEntered_P_ComputerEntered_R()
        //{
        //    var results = _sut.PlayGame('P', 'R');
        //    Assert.AreEqual("Human Wins", results);
        //}

        //[TestMethod]
        //public void IsHumanWin_ComputerWins_When_HumanEntered_P_ComputerEntered_S()
        //{
        //    var results = _sut.PlayGame('P', 'S');
        //    Assert.AreEqual("Computer Wins", results);
        //}

        //[TestMethod]
        //public void IsHumanWin_Ties_When_HumanEntered_P_ComputerEntered_P()
        //{
        //    var results = _sut.PlayGame('P', 'P');
        //    Assert.AreEqual("Its Tie", results);
        //}

        //[TestMethod]
        //public void IsHumanWin_WRONGENTRY_When_HumanEntered_Y_ComputerEntered_P()
        //{
        //    var results = _sut.PlayGame('Y', 'P');
        //    Assert.AreEqual("wrong entry", results);
        //}
    }
}
