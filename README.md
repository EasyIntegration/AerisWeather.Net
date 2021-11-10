[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

![commits](https://img.shields.io/github/commit-activity/m/EasyIntegration/AerisWeather.Net)

 | | development / PR | main |
 |----| -----------------| -----|
 | | ![commits](https://img.shields.io/github/commit-activity/m/EasyIntegration/AerisWeather.Net/development) | ![commits](https://img.shields.io/github/commit-activity/m/EasyIntegration/AerisWeather.Net/main)|
 | linux | [![Build Status](https://dev.azure.com/kullenwilliams13/EasyIntegration/_apis/build/status/AerisWeather/PR-AerisWeather-Linux?branchName=refs%2Fpull%2F5%2Fmerge)](https://dev.azure.com/kullenwilliams13/EasyIntegration/_build/latest?definitionId=11&branchName=refs%2Fpull%2F5%2Fmerge)| [![Build status](https://dev.azure.com/kullenwilliams13/EasyIntegration/_apis/build/status/AerisWeather/AerisWeather-Linux)](https://dev.azure.com/kullenwilliams13/EasyIntegration/_build/latest?definitionId=8)
 |windows | NA | [![Build status](https://dev.azure.com/kullenwilliams13/EasyIntegration/_apis/build/status/AerisWeather/AerisWeather-Windows)](https://dev.azure.com/kullenwilliams13/EasyIntegration/_build/latest?definitionId=9)
 |mac |  NA |[![Build status](https://dev.azure.com/kullenwilliams13/EasyIntegration/_apis/build/status/AerisWeather/AerisWeather-Mac)](https://dev.azure.com/kullenwilliams13/EasyIntegration/_build/latest?definitionId=10)
 | tests | ![tests](https://img.shields.io/azure-devops/tests/kullenwilliams13/EasyIntegration/11) | ![test](https://img.shields.io/azure-devops/tests/kullenwilliams13/EasyIntegration/8)
| code coverage| ![coverage](https://img.shields.io/azure-devops/coverage/kullenwilliams13/EasyIntegration/11)| ![coverage](https://img.shields.io/azure-devops/coverage/kullenwilliams13/EasyIntegration/8)


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
