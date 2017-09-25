# AWS Local Metadata Server
A simple server that emulates running in EC2/Lambda that supplies credentials to aws clients in your code

Requires aws-vault to be in the path

## Setup
On windows the IP address needs to exist before kestrel can bind to it:
```
netsh interface ipv4 add address "Loopback Pseudo-Interface 1" 169.254.169.254 255.255.0.0
```


## Run With 
```
aws-vault exec <environment> -- dotnet run --configuration Release --project .\source\metadata-server\
pause
```