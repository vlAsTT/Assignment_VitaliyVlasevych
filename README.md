# Snake 3D
 -------------------------
 
The game's purpose is to build a 2D or 3D snake game! The snake grows by a length of 1 every time it eats a food on the map. 1 food spawns on the map at the start of the game and every time the snake eats the food - a new food piece gets spawned somewhere else on the map. The game is over when the snake collides with the edge of the map or itself.

### Requirements
<ul>
 <li><strong>Date of submission:</strong> 22/07 Thursday 10 AM</li>
 <li>Only my code allowed</li>
 <li>Third party utilities are allowed (ie: XML loading library)</li>
 <li>Use Latest available Unity version</li> 
</ul>

------------------------------------
# Demo
------------------------------------
Demo is available via [this link](https://youtu.be/wBjK547qC50).

**P.S.** To run it in the Editor - start from \_BootLoader Scene

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

## Overview
In the core of my approach was an ability to easily expand the code & modify it for new needs if needed as well as deliver flawless & fast workflow for all possible teams working on the project. I have used a various set of techniques & patterns and looking at the stability of the build as well as its performance (with almost no optimization) I believe it's a great showcase of my knowledge.

I will be glad to answer any of your questions & looking forward for your reply!

------------------------------------
# Assets
------------------------------------
- [Low Poly Ultimate Pack by polyperfect](https://assetstore.unity.com/packages/3d/props/low-poly-ultimate-pack-54733) - I would do just a simpler level, but as visuals are always important - I decided to use this great low poly pack for the level design
- [Simple Fantasy UI ](https://assetstore.unity.com/packages/2d/gui/icons/simple-fantasy-ui-140925) - Originally I had more simple design, same as to the other asset pack used, as it's only for the visuals - I would find a replacement for it.
- - [Interface and Item Sounds](https://assetstore.unity.com/packages/audio/sound-fx/interface-and-item-sounds-89646) - Audio always improves user experience, so I thought of adding at least some click & item spawn SFXs. However, in case if I couldn't use this asset - I would rather find a replacement for it or record my own.
