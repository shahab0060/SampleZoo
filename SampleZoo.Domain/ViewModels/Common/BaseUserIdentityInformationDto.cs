﻿namespace SampleZoo.Domain.ViewModels.Common
{
    public class BaseUserIdentityInformationDto
    {
        public long? UserId { get; set; }

        public string UserIp { get; set; }

        public Guid UserIdentityKey { get; set; }
    }
}
