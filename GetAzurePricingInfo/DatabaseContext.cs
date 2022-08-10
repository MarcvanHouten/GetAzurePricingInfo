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

        public DbSet<Item> PricingItems { get; set; }
    }


    public class PricingItem
    {
        [Key]
        public int Id { get; set; }
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
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
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
)
GO


CREATE TABLE [dbo].[PricingItems](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
    [currencyCode] [nvarchar](max) NULL,
	[tierMinimumUnits] [float] NULL,
    [retailPrice] [float] NULL,
	[unitPrice] [float] NULL,
    [armRegionName] [nvarchar](max) NULL,
	[location] [nvarchar](max) NULL,
	[effectiveStartDate] [datetime] NULL,
    [meterId] [nvarchar](max) NULL,
    [meterName] [nvarchar](max) NULL,
	[productId] [nvarchar](max) NULL,
    [skuId] [nvarchar](max) NULL,
    [productName] [nvarchar](max) NULL,
    [skuName] [nvarchar](max) NULL,
    [serviceName] [nvarchar](max) NULL,
    [serviceId] [nvarchar](max) NULL,
    [serviceFamily] [nvarchar](max) NULL,
    [unitOfMeasure] [nvarchar](max) NULL,
    [type] [nvarchar](max) NULL, 	
    [isPrimaryMeterRegion] [bit] NULL,
    [armSkuName] [nvarchar](max) NULL,
	[reservationTerm] [nvarchar](max) NULL
)
GO

 
 */


