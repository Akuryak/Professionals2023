namespace Tests
{
    public class UnitTest5
    {
        [Fact]
        public void TooLateFirstStartTime()
        {
            Assert.Equal(new string[] { "11:00-11:30", "15:00-15:10", "15:30-15:40", "16:50-17:30"}, SF2022User_NN_Lib.AvailablePeriods.GetAvailablePeriods(new TimeSpan[] { new TimeSpan(8, 00, 00), new TimeSpan(11, 00, 00), new TimeSpan(15, 00, 00), new TimeSpan(15, 30, 00), new TimeSpan(16, 50, 00) }, new int[] { 60, 30, 10, 10, 40 }, new TimeSpan(8, 00, 00), new TimeSpan(18, 00, 00), 30));
        }
    }
}