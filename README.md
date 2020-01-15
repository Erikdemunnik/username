# The Dawn Of Dystinxion scripts
Name and description of every csharp script used in The Dawn Of Dystinxion by [username] © 2020.
Please click on a script to open it.

BleacherPersonAnim.cs     = Animation script for cheering crowd

CamHorizonTracker.cs      = Camera lookAt tracks a distant fixed point on the Z axis instead of an infinite horizon point.

CameraLock.cs             = Camera pivot tracks a center point between the two active players.

CollisionDamage.cs        = Checks damage between collider and players, their character class and team. Then applies a damage value and sends it to the healthAndScore script.

DroneController.cs        = Drone flying script with smoothing for realistic hover flight. Tracks the objective Octa.

EmissionIntensity.cs      = A script that changes the intensity of the Emission (glow) of a material by a simple sine wave function.

HealthAndScore.cs         = Controls the health of every character to be used in the UI, and the score when the objective is held. Will also end the game when max points is achieved.

HudText.cs                = Hud text that appears when Battle scene is loaded. Had a countdown until game starts and shows game controls.

LampFlicker.cs            = Changes light intensity by a simple sine wave function.

MainMenu.cs               = Changes scene on button press.

ObjectiveGrab.cs          = (Obsolete) Pickup script for the objective Octa.

ObjectiveOcta.cs          = Rotation, hover and glow effects for the objective Octa.

ObjectiveRelease.cs       = Objective Octa is held in the air before game start and then drops.

PlatformHover.cs          = (Obsolete) Physical up and down movement of platform. Player often clips into the platform because of poor physics simulation.

PlayerSpawn.cs            = Controls the generation of player prefab. After a set time, the player prefab will be instantiated 6 times and character classes and teams will be assigned in the process.

Playermovement.cs         = Controls the player prefab. Has functions for player1, player2 and AI with their own movement controls. PlayerSpawn script assigns these when player is spawned.

Propellor.cs              = propellor rotation script for the drone prefab.

RotateY.cs                = Rotation script for the objective Octa. Makes it slowly rotate around the Y axis like a top.

ScrollingTexture.cs       = Texture of hologram crowd model translates across the UV. Gives it a holographic scan look.

SpotlightFocus.cs         = The currently selected players of both teams are highlighted with an arrow and player tag above their heads. (Previously a spotlight)

TextFade.cs               = Changes transparency intensity of text by a simple sine wave function.

killPlane.cs              = When a player falls off the map they will land into the killplane trigger and receive lethal damage.
