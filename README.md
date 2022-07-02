# MidairRatioFinder
Find 1x1 ratios by entering cannon debug data from the first gametick of travel.

## How to use:
- Download zip file under releases
- Extracet and run MidairRatioFinder.exe
- Enter Following Data:
- Velocity: paste cannon debug velocity in first gametick of travel
- Position: paste cannon debug positiony in first gametick of travel
- Power: how much power you used
- Direction: if you are shooting x or z (default x) (diagonal is currently not supported)
- Max Gameticks: for how many more gameticks the entity is allowed to travel
- Min Power: minimum amount of power you want to use
- Max Power: maximum amount if power you want to use
- Min Distance: minimum amount of blocks the entity has to travel in the x/z direction
- Min Height: minimum amount of blocks the entity has to travel in the y direction
- Max Distance: maximum amount of blocks the entity is allowed to travel in the x/z direction
- Max Height: maximum amount of blocks the entity is allowed to travel in the y direction

## Interpreting the Results:
A Ratio will look somewhat like this
> Power: 40      Gametick: 16     Distance: (110.481, 105.549)      Position: (111.481, 106.549)
Power: how much power you need to use
Gametick: how many gameticks after the data you entered it will be in a 1x1
Distance: how far is will have moved (x/z, y)
Position: what coordinates it will be at (x/z, y)
