﻿namespace ExtremeClassified.WebApi.Dtos.Identity
{
    public class UserRegionDto : BaseDto
    {
        public int RegionId { get; set; }
        public string UserId {  get; set; }
        public string Region { get; set; }
        public string TimeStamp { get; set; }
    }
}
