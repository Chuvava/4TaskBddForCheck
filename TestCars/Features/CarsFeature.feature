Feature: CarsFeature

@TestCarsComparing
Scenario: Comparing cars and their characteristics
	Given Navigate to Main Page of Cars.com

	When  Navigate to Research Page
	And   Select the firstCar Car by random values
	And   Click button Search
	And   Click on trim comparison link of firstCar Page
	And   Save firstCar characteristics(Engine and Transmission) from base complectation

	Given Navigate to Main Page of Cars.com
	When  Navigate to Research Page
	And   Select the secondCar Car by random values
	And   Click button Search
	And   Click on trim comparison link of secondCar Page
	And   Save secondCar characteristics(Engine and Transmission) from base complectation

	When  Navigate to Research Page
	And   Navigate To Compare Page
	And   Select the firstCar Car for comparing
    And   Select another secondCar Car for comparing
	And   Copy car's characteristics (Engine, Transmission) for first Car: 0 and second Car: 1

	Then  Assert the characteristics with data from trim pages for firstCar and secondCar
