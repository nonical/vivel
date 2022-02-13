namespace Vivel.Model.Dto
{
    public class DriveDetailsDTO : DriveDTO
    {
        public int PendingCount { get; set; }
        public int ScheduledCount { get; set; }
        public int AmountLeft { get; set; }
    }
}
