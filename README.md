[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

![commits](https://img.shields.io/github/commit-activity/m/EasyIntegration/AerisWeather.Net)

 | os | development / PR | main |
 |----| -----------------| -----|
 | linux | [![Build Status](https://dev.azure.com/kullenwilliams13/K23/_apis/build/status/EasyIntegrationAerisWeather/PR%20-%20EasyIntegration%20AerisWeather?branchName=development)](https://dev.azure.com/kullenwilliams13/K23/_build/latest?definitionId=5&branchName=development) | [![Build status](https://dev.azure.com/kullenwilliams13/EasyIntegration/_apis/build/status/AerisWeather/AerisWeather-Linux)](https://dev.azure.com/kullenwilliams13/EasyIntegration/_build/latest?definitionId=8)
 |windows |  | [![Build status](https://dev.azure.com/kullenwilliams13/EasyIntegration/_apis/build/status/AerisWeather/AerisWeather-Windows)](https://dev.azure.com/kullenwilliams13/EasyIntegration/_build/latest?definitionId=9)
 |mac | |[![Build status](https://dev.azure.com/kullenwilliams13/EasyIntegration/_apis/build/status/AerisWeather/AerisWeather-Mac)](https://dev.azure.com/kullenwilliams13/EasyIntegration/_build/latest?definitionId=10)
code coverage| ![coverage](https://img.shields.io/azure-devops/coverage/kullenwilliams13/EasyIntegration/11)| ![coverage](https://img.shields.io/azure-devops/coverage/kullenwilliams13/EasyIntegration/8)


# AerisWeather.Net


## GOAL

spend less time integrating and more time solving problems

## CONFIGURE / How To Use

For use in your .Net5 projects.  Just add a reference to your startUp class and good to go

Add Aeris URL, ClientID, and Client Secret to your configurations

{
  "AerisBaseUrl": "https://api.aerisapi.com",
  "AerisClientId": "YOUR_ID",
  "AerisClientSecret": "YOUR_SECRET"
}

register Serivce in StartUp or program file.  by adding  services.RegisterAerisWeather(ICONFIGURATION)




## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant
to clarify expected behavior in our community.

For more information, see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).


## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.  
