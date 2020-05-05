# FirstStrategyPatternCore3.1

Strategy Pattern: factor is the weather in users town, strategy is the background image the user seees.

So basically the weather changes based on real-time weather in users location. 
To translate user IP to particular location MaxMinds GeoLite2 city database was used and to check weather
for that location https://openweathermap.org/ open api call is made. Based on the result of the second the background
object uses particular strategy.
