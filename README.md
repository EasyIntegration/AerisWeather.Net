[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

 | development / PR | main |
 | -----------------| -----|
 |[![Build Status](https://dev.azure.com/kullenwilliams13/K23/_apis/build/status/EasyIntegrationAerisWeather/PR%20-%20EasyIntegration%20AerisWeather?branchName=development)](https://dev.azure.com/kullenwilliams13/K23/_build/latest?definitionId=5&branchName=development) | [![Build Status](https://dev.azure.com/kullenwilliams13/K23/_apis/build/status/EasyIntegrationAerisWeather/GitHub%20EasyIntegration%20AerisWeather?repoName=EasyIntegration%2FAerisWeather.Net&branchName=main)](https://dev.azure.com/kullenwilliams13/K23/_build/latest?definitionId=4&repoName=EasyIntegration%2FAerisWeather.Net&branchName=main)


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
