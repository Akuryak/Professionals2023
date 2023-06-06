namespace Tests
{
    public class UnitTest4
    {
        [Fact]
        public void TooEarlyEndWorkingTime()
        {
            Assert.Equal(new string[] { "10:00-11:00", "11:00-11:30", "15:00-15:10", "15:30-15:40", "15:40-16:20"}, SF2022User_NN_Lib.AvailablePeriods.GetAvailablePeriods(new TimeSpan[] { new TimeSpan(10, 00, 00), new TimeSpan(11, 00, 00), new TimeSpan(15, 00, 00), new TimeSpan(15, 30, 00), new TimeSpan(16, 50, 00) }, new int[] { 60, 30, 10, 10, 40 }, new TimeSpan(8, 00, 00), new TimeSpan(16, 50, 00), 30));
        }
    }
}