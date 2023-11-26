namespace MotHistoryFinder.Models
{
    public class MotHistoryDto
    {
        public string registration { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string firstUsedDate { get; set; }
        public string fuelType { get; set; }
        public string primaryColour { get; set; }
        public MotTest[] motTests { get; set; }
    }

    public class MotTest
    {
        public string completedDate { get; set; }
        public string testResult { get; set; }
        public string expiryDate { get; set; }
        public string odometerValue { get; set; }
        public string odometerUnit { get; set; }
        public string motTestNumber { get; set; }
        public RfrAndcomment[] rfrAndComments { get; set; }
    }

    public class RfrAndcomment
    {
        public string text { get; set; }
        public string type { get; set; }
    }
}
