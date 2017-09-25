using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetaServerServer.Controllers
{
	[Route("latest/dynamic")]
	public class AwsDynamicController : Controller
	{
		readonly ILogger _logger;

		public AwsDynamicController(ILogger<AwsMetaDataController> logger)
		{
			_logger = logger;
		}

		[HttpGet("instance-identity/document")]
		public string IdentityDocument()
		{
			_logger.LogInformation("IdentityDocument requested");
			return @"
{
    ""devpayProductCodes"" : null,
    ""availabilityZone"" : ""us-west-2b"",
    ""privateIp"" : ""10.158.112.84"",
    ""version"" : ""2010-08-31"",
    ""instanceId"" : ""i-LOCALHOST"",
    ""billingProducts"" : null,
    ""instanceType"" : ""t2.micro"",
    ""accountId"" : ""123456789012"",
    ""imageId"" : ""ami-123456"",
    ""pendingTime"" : ""2016-11-19T16:32:11Z"",
    ""architecture"" : ""x86_64"",
    ""kernelId"" : null,
    ""ramdiskId"" : null,
    ""region"" : ""us-west-2""
}";
		}

	}


}



