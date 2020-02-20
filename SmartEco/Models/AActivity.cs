﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEco.Models
{
    public class AActivity
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "Target")]
        public Target Target { get; set; }
        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "Target")]
        public int TargetId { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "TargetTerritory")]
        public TargetTerritory TargetTerritory { get; set; }
        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "TargetTerritory")]
        public int TargetTerritoryId { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "Event")]
        public Event Event { get; set; }
        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "Event")]
        public int EventId { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "Year")]
        [Range(Constants.YearMin, Constants.YearMax, ErrorMessageResourceType = typeof(Resources.Controllers.SharedResources), ErrorMessageResourceName = "ErrorNumberRangeMustBe")]
        public int Year { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "ActivityType")]
        public bool ActivityType { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "ActivityType")]
        public string ActivityTypeName
        {
            get
            {
                string language = new RequestLocalizationOptions().DefaultRequestCulture.Culture.Name,
                    ActivityTypeName = "";
                if (ActivityType)
                {
                    ActivityTypeName = Resources.Controllers.SharedResources.Actual;
                }
                if (!ActivityType)
                {
                    ActivityTypeName = Resources.Controllers.SharedResources.Planned;
                }
                return ActivityTypeName;
            }
        }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "ImplementationPercentage")]
        [Range(0, 100, ErrorMessageResourceType = typeof(Resources.Controllers.SharedResources), ErrorMessageResourceName = "ErrorNumberRangeMustBe")]
        public decimal? ImplementationPercentage { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "AdditionalInformationKK")]
        public string AdditionalInformationKK { get; set; }

        [Display(ResourceType = typeof(Resources.Controllers.SharedResources), Name = "AdditionalInformationRU")]
        public string AdditionalInformationRU { get; set; }
    }
}
