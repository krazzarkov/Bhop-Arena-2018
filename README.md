# Bhop-Arena-2018
The goal of this project was to create a rough prototype arena shooter with multiplayer capabilities in which players could Bunny Hop (Bhop)
to gain speed and rocket jump to gain height. This project uses the CPMPlayer script which was ported over from Quake 3 into Unity by
WiggleWizard.

https://github.com/WiggleWizard/quake3-movement-unity3d

![Alt Text](https://media.giphy.com/media/Qa4XgGa8ZHvg69vyX5/giphy.gif)

For this project I used UNet for multiplayer to make everything work. Unfortunately, as of 2020 UNet has been depreciated and is not longer
supported. The server currently works by having one player host the game while having another player connect to it. Movement, Bhop, and
rocket jumping is synced properly in multiplayer so players can see others in realtime performing these movement abilities. 

![Alt Text](https://media.giphy.com/media/TIjmZogOK9FupRDqer/giphy.gif)
![Alt Text](https://media.giphy.com/media/JqzketYjxfjAwvn3D1/giphy.gif)

To make rocket jumping work I created a rocket prefab that is shot from the rocket launcher. The prefab creates an explosion prefab which
creates particle effects and applies an explosion force to the player which allows them to rocket jump.

![Alt Text](https://media.giphy.com/media/Q79P4FkBEoXYQaO2XM/giphy.gif)
