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
Wolf animation
Sorting layer

# 09/06/2022
Wrong player collision with the map
- [x] Separate colliders by zone
- [x] Slide on slopes
Correct zone by zone
- [x] zone 1 - 6 & 11

# 10/06/2022
Rest of zones
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

In the end I managed to fix most of the displacement and found out the calculation didn't work was because the equation wasn't right, but I guess I'll never know if the rescaling everything actually helped the calculation of the percentage 🤷🏻‍♂️ 

At it satisfied my OCD

## VisualNovel
Did a lil marquette of the VisualNovel system
Now I need to add a button on the top of the person to start conversation and change Image and text. A typing animation of the text would be nice. Also I need to think of some story lines

17/06/2022
Stuck in RPGM

20/06/2022
Calls with prof
Enchanced VN

21/06/2022
Typewriter animation in VN
3 lines max
Change images


Contrast de chamois
Encyclopedia, larger button
Zoom map
Food
First quest, find group