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
