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

        #region VALID ENTRY TESTS
        [TestMethod]
        public void IsValidEntry_Valid_When_P_Entered()
        {
            string results = _sut.PlayGame('K', 'R');
            Assert.AreEqual(OutcomeEnums.Wrong_Entry.ToString(), results);

        }
        public void IsValidEntry_NotValid_When_P_Entered()
        {
            string results = _sut.PlayGame('M', 'R');
            Assert.AreEqual(OutcomeEnums.Wrong_Entry.ToString(), results);

        }
        #endregion

        #region TIE TESTS
        [TestMethod]
        public void PlayGame_ItsTie_WhenPlayerEntry_R_ComputerEntry_R()
        {
            string results = _sut.PlayGame('R', 'R');
            Assert.AreEqual(OutcomeEnums.Tie.ToString(), results);
        }

        [TestMethod]
        public void PlayGame_ItsTie_WhenPlayerEntry_P_ComputerEntry_P()
        {
            string results = _sut.PlayGame('P', 'P');
            Assert.AreEqual(OutcomeEnums.Tie.ToString(), results);
        }

        [TestMethod]
        public void PlayGame_ItsTie_WhenPlayerEntry_S_ComputerEntry_S()
        {
            string results = _sut.PlayGame('S', 'S');
            Assert.AreEqual(OutcomeEnums.Tie.ToString(), results);
        }

        #endregion

        #region PLAYER WINS TESTS
        [TestMethod]
        public void PlayGame_PlayerWins_WhenPlayerEntry_R_ComputerEntry_S()
        {
            string results = _sut.PlayGame('R', 'S');
            Assert.AreEqual(OutcomeEnums.Player_Wins.ToString(), results);
        }

        [TestMethod]
        public void PlayGame_PlayerWins_WhenPlayerEntry_S_ComputerEntry_P()
        {
            string results = _sut.PlayGame('S', 'P');
            Assert.AreEqual(OutcomeEnums.Player_Wins.ToString(), results);
        }

        public void PlayGame_PlayerWins_WhenPlayerEntry_P_ComputerEntry_R()
        {
            string results = _sut.PlayGame('P', 'R');
            Assert.AreEqual(OutcomeEnums.Player_Wins.ToString(), results);
        }
        #endregion

        #region COMPUTER WINS TESTS
        [TestMethod]
        public void PlayGame_ComputerWins_WhenPlayerEntry_S_ComputerEntry_R()
        {
            string results = _sut.PlayGame('S', 'R');
            Assert.AreEqual(OutcomeEnums.Computer_Wins.ToString(), results);
        }

        [TestMethod]
        public void PlayGame_ComputerWins_WhenPlayerEntry_R_ComputerEntry_S()
        {
            string results = _sut.PlayGame('R', 'P');
            Assert.AreEqual(OutcomeEnums.Computer_Wins.ToString(), results);
        }

        public void PlayGame_ComputerWins_WhenPlayerEntry_P_ComputerEntry_R()
        {
            string results = _sut.PlayGame('P', 'S');
            Assert.AreEqual(OutcomeEnums.Computer_Wins.ToString(), results);
        }
        #endregion

    }
}
