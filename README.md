# Asteroids-Unity

Made using Unity 2019.4.13f1

I wanted to keep the architecture simple.
The two main things that looked interesting to me were the 'hyperspace' effect where the object warps around the screen to the other side and pooling of objects.
I relied on renderer visibility to detect when a sprite goes out of screen and then also added a additional world position to viewport position check as the renderer is set to not visible when it is spawned.
Pooling has a simple implementation. If any object wants to be pooled then it can inherit from IPoolable. Pool manager maintains a dictionary of currently pooled and availale objects.

I also wanted to make applying/taking damage generic. Did that using IDoDamage and ITakeDamage.

The player space ship has SpaceShipRotate. SpaceShipMoveForward and SpaceShipWeaponFire scripts attached to them. These scripts hook to various inputs delegates to do their specific job.
Currently the space ship has simple weapon equipped but we can easily attach various weapons by implementing IWeapon.
The player ship tracks lives and respawns using ShipRespawn and ShipLives script.
The ship lives hooks to ITakeDamage's ModifyHealth delegate to decrease lives and triggers an event when remaining lives change.

PlayerProfilehandler works as a utility to access player save data. Currently only high score is saved to persistent path.

For asteroid spawning I added a circle collider and selected a random position on the edge of the cirle. An asteroid is then spawned on the selected postion and a velocity is applied to it.

I wanted to add in a IPlatform input so that we could have had the ability to create input handler based on the current platform but unfortunately I was out of time.
I also relied heavily on physics system.
