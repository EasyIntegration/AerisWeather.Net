[![Build Status](https://dev.azure.com/kullenwilliams13/K23/_apis/build/status/Weather/GitHub%20EasyIntegration%20AerisWeather?repoName=EasyIntegration%2FAerisWeather.Net&branchName=main)](https://dev.azure.com/kullenwilliams13/K23/_build/latest?definitionId=4&repoName=EasyIntegration%2FAerisWeather.Net&branchName=main)

# AerisWeather.Net


## GOAL

spend less time integrating and more time solving problems

## CONFIGURE

Add Aeris URL, ClientID, and Client Secret to your configurations

{
  "AerisBaseUrl": "https://api.aerisapi.com",
  "AerisClientId": "YOUR_ID",
  "AerisClientSecret": "YOUR_SECRET"
}

register Serivce in StartUp or program file.  by adding  services.RegisterAerisWeather(ICONFIGURATION)


