# **GRID**

### 9x9 grid sandbox with (currently) a Move Mode and a Draw Mode.
---
#### This is just a pastime to practice and see how far I can take this grid with my current knowledge. To switch modes I just change the <StartupObject> in grid.csproj

## Grid.cs

>The grid class where most of the functions are implemented, including player movement, point spawning and grid display.

## PlayerMove.cs

>The interface that gets player input to move the player.
>
>This Main() is the "Move Mode" of the grid.
>>Move Mode lets you move your player char with WASD and spawns random point chars to collect.

## Program.cs

>User interface that asks for coordinates and a char to then add to the grid. Essentially letting you draw on the grid.
>
>This Main() is the "Draw Mode" of the grid.
