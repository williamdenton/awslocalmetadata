# AWS Local Metadata Server
A simple server that emulates running in EC2/Lambda that supplies credentials to aws clients in your code

Runs on [dotnet core](https://www.microsoft.com/net/core) and requires [aws-vault](https://github.com/99designs/aws-vault) to manage the AWS secrets

## Setup
On windows the IP address needs to exist before kestrel can bind to it (needs to be run with an elevated console - aka Run as Administrator):
```
netsh interface ipv4 add address "Loopback Pseudo-Interface 1" 169.254.169.254 255.255.0.0
```


## Run With 
```
aws-vault exec <environment> -- dotnet run --configuration Release --project .\source\metadata-server\
pause
```