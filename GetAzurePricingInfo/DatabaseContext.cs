using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace GetAzurePricingInfo
{
    public class AzurePricingContext : DbContext
    {

        public AzurePricingContext(DbContextOptions<AzurePricingContext> options)
            :base(options) {}

        public DbSet<PricingItem> PricingItems { get; set; }
    }


    public class PricingItem
    {
        [Key]
        public int PricingId { get; set; }
        public string skuId { get; set; }
        public string currencyCode { get; set; }
        public float retailPrice { get; set; }
        public string location { get; set; }
        public string armRegionName { get; set; }
        public string meterName { get; set; }
        public string skuName { get; set; }
        public string Pricingtype { get; set; }
        public string armSkuName { get; set; }
        public string reservationTerm { get; set; }
    }


}

/*
 * SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PricingItems](
	[PricingId] [int] NOT NULL PRIMARY KEY,
	[skuId] [nvarchar](max) NULL,
	[currencyCode] [nvarchar](max) NULL,
	[retailPrice] [real] NULL,
	[location] [nvarchar](max) NULL,
	[armRegionName] [nvarchar](max) NULL,
	[meterName] [nvarchar](max) NULL,
	[skuName] [nvarchar](max) NULL,
	[Pricingtype] [nvarchar](max) NULL,
	[armSkuName] [nvarchar](max) NULL,
	[reservationTerm] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
*/


