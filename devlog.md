# 07/06/2022

## Bugs To Fix

Animation - prédateur 
Map - 
Better - Control
Occlusion - hierarchy of visibility 
Collision
Lag - doesn't start moving until the the tree is loaded 

## Main menu
Unlink useless scripts from GameObjects (MainMenu doesn't have Start, so it's useless to link it to PlayButton)
Add MenuManager in order to initiate scene and manage scene in a robust way

Created a global class for global variables (personnage & maybe other save data)

## DebugManager
Reactivate stuff when awaken, which allows me to hide things and not worried about reactivate them

Also I turned off Day&Night mechanism

## GameObjectPointer
Il me semble 'GameObject.Find' est une fonction très lourde. J'ai créé un objet 'GameObjectPointer' qui contient les GameObjects statiques. Cela me permet de lier une fois pour chaque GameObject dans Inspector et de remplacer 500+ 'GameObject.Find' dans le code. J'espère que cela optimise un peu l'execution

## Walk animation 
Speed up walking animation

## Keyboard controller
Added keyboard control

# 08/06/2022
Added Wolf sprite and linked animation
Sorting layer : chamois show behind and in front of trees and bushes correctly

# 09/06/2022
Wrong player collision with the map
- [x] Separate colliders by zone
- [x] Slide on slopes
Correct zone by zone
- [x] zone 1 - 6 & 11

# 10/06/2022
Finish colliders correction of the rest of zones
Little fix to Achievements UI

# 13/06/2022
Adapt for hunter

Menu 
Button auto spacing
Changer structure: all buttons now belong to Menu
Switch perso
Better Pause
Save pos of each perso

# 14/06/2022 - 15/06/2022
## Update the percentage of fog faster:
When updating the percentage (after clicking on the button), the game freezes.
I started looking into running the game in parallel. Options: coroutine, async, multithread, job system (ECS)
I tried coroutine and async and got coroutine to work.
The calculation runs in background but it takes 30 seconds to run.

### Optimisation
I've decided to separate the map into 24 zones (36 - empty zones), and each time the player quits an zone, the game only calculates the percentage of that zone. The percentages are stored in a dictionary for each zone, and we calculate the total percentage after each calculations.

Other optimization could be to replace counting pixels (341x341 / 2048 x 2048 pixels)

### Problem
At first the zones didn't work, I thought it was because the placement of the zones and the maps and the shade aren't of the same scale. Basically the objects in the scene have really weird root and positions, it gets on my nerve. So I took a long time to recenter everything, and I broke the FogOfWar mechanism. I had to find the tutorial video and learn how it was made in order to fix it.

The aftermath of the rescaling is that some objects on the maps are misplaced, which is fine since there aren't that many of them. Also I deleted a lot of repeated objects for each character.

In the end I managed to fix most of the displacement and found out the calculation didn't work was because the equation wasn't right, but I guess I'll never know if the rescaling everything actually helped the calculation of the percentage

## VisualNovel
Did a marquette of the VisualNovel system
Now I need to add a button on the top of the person to start conversation and change Image and text. A typing animation of the text would be nice. Also I need to think of some story lines

# 16/06/2022

## Fog of War Optimisation
For the Fog Of War to work even faster, I reduced the pixels to count at 100x100 as we only need the Fog Texture to be precise visually, but not when counting.

## Reorganizing panels
There are too many canvas component gathered together on the same place (can't separate canvas), so I've decided to keep only one for most Menu related interface and put each interface on a panel, which allows me to move it to anywhere

## Ency
Stuck on ency: too many repetitive elements (buttons, interface, submenu, etc.), but there're closely linked with a repetitive code and not-so-automated buttons

# 17/06/2022
Fix encyclopedia
Stuck in RPGM, trying to understand how their library works
Couldn't redirect GameModel's Dialog to my VisualNovel class (few weeks later I found out there's a GameModel object somewhere hidden in the scene which links stuffs), but I cheated and made a getter of my VN class

# 20/06/2022
Calls with prof
Finished redirect StartConversation to VisualNovel
Enchanced VN

# 21/06/2022
Typewriter animation in VN
3 lines max
Change images

JSON WTF!
Remade strucutre of json files, remade a reader of json files with loops (the old ones import them manually which has 2000+ lines of code)

# 22/06/2022
Finished re-implementation of json files for hiker
RandoManager to manage hikes better
NPCController inherits from InteractableController

# 23/06/2022
Finished re-implementation of json files for hunter, chamois and ency 
Unified loader and attributer of conversations from json

# 24/06/2022
achievements from json
Started looking into path-finding

# 27/06/2022
Path-finding with help of CodeMonkey
construct grid and load bitmap from box-casting colliders

# 28/06/2022
Path-finding in JOBS
prebake bitmaps

# 06/07/2022
Export to Android, problems with Mac and WebGL
Enhance Path-finding performance: smaller csv, restricted loops, smaller maps

# 07/07/2022
Export to Android and Mac, given up on WebGL

# 08/07/2022
Started GDD

# 11/07/2022
Read documents, tried to represent the 3 axis of colloque, but couldn't

# 12/07/2022
A bit lost in the game design after doing more research
Decided to focus on development instead

Started looking into async for path-finding

Replaced the guide of the huntress by conversation with his dad in VN

# 13/07/2022
Replaced the guide of the hiker by conversation with a human guide for hikers in VN

Succeeded in async path-finding

# 15/07/2022
Reread documents from previous students
Stuck Save & Load the texture of FogOfWar

# 18/07/2022
Succeeded in saving and loading the texture of FogOfWar after several heavy translations

Save & Load the entry conversation node of NPCs

Used async everywhere

Tested on Android, save&load of FogOfWar slows down loading and saving time

# 19/07/2022
Made the map permanent in the game (no reloading map)
Created a loading screen with progress percentage

Added Save&Load for Ency and Achievements

Used Instance (Singleton) for some classes, which replaces some GOPoointer

# 20/07/2022
Looked into how WebGL works on iOS, seemed really not optimized for mobile

Tried to use Shader Graph on the tint of the game according to the current character

# 21/07/2022
The FogOfWar doesn't works with URP which is needed for Shader Graph. So I've decided to use the old pipeline for the FogOfWar and made the map and characters B&W manually

# 22/07/2022
Restructured DataStorer (serializable to save&load)

Sorting layers works for other characters (got around some bugs in layers)

Updated to 2021.3.6, fixed to bug to export to Android

# 25/07/2022
Created my own class for quests and QuestManager
Created first quest for hunter and hiker

commande to change first node can be made in the json file

Separate quest UI from Ency
Created new UI for quests (Title, description, hint, if finished)

# 26/07/2022
Show image in ency

Made the first quest of chamois

3 types of quest: killQuest, zoneQuest, randoQuest

Better passage of time

The endgame screen launches correctly, but the calculation of score has been fixed