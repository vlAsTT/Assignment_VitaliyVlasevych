# Snake 3D
 -------------------------
 
The game's purpose is to build a 2D or 3D snake game! The snake grows by a length of 1 every time it eats a food on the map. 1 food spawns on the map at the start of the game and every time the snake eats the food - a new food piece gets spawned somewhere else on the map. The game is over when the snake collides with the edge of the map or itself.

------------------------------------
# Demo
------------------------------------
Demo is available via [this link](https://youtu.be/wBjK547qC50).

**P.S.** To run it in the Editor - start from \_BootLoader Scene or MainMenu

------------------------------------
# Code Overview
------------------------------------

### Movement
Movement is implemented via translating snake's head position and moving other body parts following it. Decision in favor of this approach was made to deliver a smooth movement & have no grid or snapping-like movement.

### Input
For the input - new Unity Input System was used. Not only it's more optimized, doesn't require to check for Input Update every frame, but also allows for an easy implementation for multi-platforms and multiple devices. Currently it supports WASD or Arrows on the Keyboard (input device) as inputs, but a support for mobile devices or any other type of device can be added easily.

### Items & JSON
Items are stored in JSON file that is being parsed when Game Scene is loaded. Items are designed to support easy expandability if needed. Parsed items are stored in ItemManager that calls JSON parse method when game scene is loaded. If it's needed to support items discovery progress across multiple levels (e.g: at Level 1 there are 3 items that can be spawned and there are 2 more added to the pool every level) - it can be easily done as it requires only few tweaks into ItemManager to support multiple JSON files selection.

In more details about the possible implementation of supporting multi-levels and multi-files load can be read at Line 143 in ItemManager.cs

![Item Structure](https://i.imgur.com/WMt7s25.png)

### Item Delegates
As there are have several scripts that have certain actions to do everytime we have an item being destroyed - I decided that using delegate will maintain good structure & not lead to any possible errors in the future. Whenever item is destroyed, all subscribers are doing their appropriate action:
- ItemManager - spawns new item
- MovementController - spawns new tail part

### Multi-Scenes Workflow
Additive Scenes are a great workflow tool that makes collaboration between different departments way easier and allow to avoid many merge conflicts, so assuming that it's a project that teams from different departments (Audio, Level Design, Programming) can work concurrently - I thought it's a good approach to add them as well.

List of Additive Scenes:
- BootLoader - contains a simple placeholder image that can be replaced with splash screen/video when game is booted.
- Core - contain Core Managers that are required to run the game correctly, such as GameManager, ItemManager, UI Manager

### XML & Comments
As I was approaching it as if there were several people working on it - I have added appropriate XML tags to all variables, methods & classes to support auto-generation of documentation and all hints in the IDE. To avoid any missunderstandings in the code - I also added some comments that explain some moments.

### Audio
I have added two small SFX for the better user responsiveness as it's a pretty small chunks of code - I did not separate them into AudioManager scripts, but if there is an expansion on the Audio side - it will be better to refactor this functionality to keep the task separations between scripts and better architecture generally.

## Overview
In the core of my approach was an ability to easily expand the code & modify it for new needs if needed as well as deliver flawless & fast workflow for all possible teams working on the project.

------------------------------------
# Assets
------------------------------------
- [Low Poly Ultimate Pack by polyperfect](https://assetstore.unity.com/packages/3d/props/low-poly-ultimate-pack-54733)
- [Simple Fantasy UI ](https://assetstore.unity.com/packages/2d/gui/icons/simple-fantasy-ui-140925)
- [Interface and Item Sounds](https://assetstore.unity.com/packages/audio/sound-fx/interface-and-item-sounds-89646)
