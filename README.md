# Just A Spoonful

A Calming hidden object experience about the Spoon Theory. 
Created in Unity Engine. 
Task: Create a 2D point-and-click experience.

This Project has 3 complete Code refactors behind it and is sometimes taken for exhibiting by me at Events like Talk and Play. 

Release date: 06.07.2022

# How To Run
Simplest Way
An instant run WebGL embed is available at itch.io: https://sillysealstudio.itch.io/just-a-spoonful

# Requirements
Unity Version: 6000.0.58f2

## Packages: 
- [Deadcows Mybox](https://github.com/Deadcows/MyBox.git) (Editor Utils and Handy Extension Methods)
- Cinemachine
- "New" Input System

## Code Examples
The Systems provided utilize the [Event Trigger Component](https://docs.unity3d.com/Packages/com.unity.ugui@2.5/manual/script-EventTrigger.html) and are the core of this project's mechanics.

<div align="center">

  
  System | Script | Purpose | 
  --- | --- | --- | 
  Pickupable | [Read here](https://github.com/TomGrzembke/JustASpoonful/blob/main/Assets/%2B%2B%2Bworkdata/scripts/InteractLifecycle/Pickupable.cs) | "Picks up" an object and activates the provided UI Object used in Comination with the Interactables.|
  Interactable | [Take a glance](https://github.com/TomGrzembke/JustASpoonful/blob/main/Assets/%2B%2B%2Bworkdata/scripts/InteractLifecycle/Interactable.cs) | Utility for a UnityEvent-based workflow for objects that should simply dispatch OnClick or even require items to be solved with.| 
  Movable | [Flip Through](https://github.com/TomGrzembke/JustASpoonful/blob/main/Assets/%2B%2B%2Bworkdata/scripts/Drawer/Movable.cs) | Allows moving objects to solve sorting riddles.| 

</div>
