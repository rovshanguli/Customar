﻿using Domain.Common;

namespace Domain.Entities.AppealTypeModels
{
    public class AppealTypeTranslate : BaseEntity
    {
        public int AppealTypeId { get; set; }
        public string LangCode { get; set; }
        public string Name { get; set; }

    }
}
