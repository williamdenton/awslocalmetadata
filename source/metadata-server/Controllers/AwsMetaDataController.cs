using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetaServerServer.Controllers
{
	[Route("latest/meta-data")]
	public class AwsMetaDataController : Controller
	{
		readonly ILogger _logger;

		public AwsMetaDataController(ILogger<AwsMetaDataController> logger)
		{
			_logger = logger;
		}

		[HttpGet("iam/security-credentials")]
		public string SecurityCredentials()
		{
			_logger.LogInformation("Credentials requested");
			return "development-credential";
		}

		[HttpGet("iam/info")]
		public string Info()
		{
			_logger.LogInformation("Credentials requested");
			return @"
{
    ""LastUpdated"" : ""2016-11-19T16:32:11Z"",
    ""InstanceProfileArn"" : ""123"",
    ""InstanceProfileId"" : ""456""
}";
		}

		[HttpGet("iam/security-credentials/{credentialId}")]
		public SecurityCredential SecurityCredentials(string credentialId)
		{
			_logger.LogInformation($"Credentials supplied for {credentialId}");
			return new SecurityCredential
			{
				Code = "Success",
				LastUpdated = DateTime.UtcNow.AddHours(-1),
				Type = "AWS-HMAC",
				AccessKeyId = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID"),
				SecretAccessKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY"),
				Token = Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN"),
				Expiration = DateTime.UtcNow.AddHours(1),
			};
		}
	}

	public class SecurityCredential
	{
		public string Code { get; set; }
		public DateTime LastUpdated { get; set; }
		public string Type { get; set; }
		public string AccessKeyId { get; set; }
		public string SecretAccessKey { get; set; }
		public string Token { get; set; }
		public DateTime Expiration { get; set; }
	}

}



