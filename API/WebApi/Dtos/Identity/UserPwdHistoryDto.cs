namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserPwdHistoryDto:BaseDto
    {
        public string UserId {  get; set; }
        public string Password { get; set; }
        public DateTime ChangeDate {  get; set; }
    }
}
