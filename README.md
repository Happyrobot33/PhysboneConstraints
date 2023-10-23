# PhysboneConstraints
An alternative to Unity constraints that's designed to work on Quest.

Here's a list of PhysboneConstraints so far:

- Look-At Constraint
- Position Constraint
- World Constraint
- Springjoint
- World+Y Rotation Constraint*
- Physbone Origin Constraint**

*World+Y is a broken World Constraint that remains in position by rotates around Y axis<br>
**Origin is a collection of Avatar Dynamics components that have a Root Transform slot. By adding a prefab, it defaults to world origin.

https://github.com/GirlyNPC/Test/assets/144646911/bd118d3e-d678-4920-ad67-72a00e950890

Someone make a better vid and tell me how to scale it!

## How to Install:

Open VCC and select the project you want to add the package to.<br>
Here you can select the packages you want to add. Make sure Curated packages are visible.<br>
Find "PhysboneConstraints" and click the Add button!<br>

The package should have been added to the Packages folder. Go there, find PhysboneConstraints, drag-and-drop to Asset folder!

Not using VCC? You can also grab the packages from [Releases](https://github.com/Happyrobot33/PhysboneConstraints/releases)!

## Setup Example:

This release includes several PhysboneConstraint variants, this shows the Physbone Position Constraint.<br>
From that, you should get a clear idea of how to set up the rest. </br>
But check out Q&A/Useful Info section for more info!

*Due to how Unity animations work, you'll have to set it up on your own. This is really quick!*

- ### Setting up the Physbone Position Constraint
https://github.com/GirlyNPC/Test/assets/144646911/3ea41bce-6f7e-4f38-9828-efc6485efffe

- ### Setting up the FX layer
https://github.com/GirlyNPC/Test/assets/144646911/76f6dc66-482b-4f88-a03f-e69cfbfd373f

*Note:*
- Reset When Disabled was turned on here, due to how I set up the toggle. Depending on what you're doing, you might not need this.
- The animations were duplicated from frame 0 to 1, transition speed changed to 0.02, because [VRChat recommends so](https://creators.vrchat.com/avatars/state-behaviors/) to minimize desync.
- [GestureRight paramater](https://creators.vrchat.com/avatars/animator-parameters/#gestureleft-and-gestureright-values) was used here, to simplify testing.
- [GestureManager](https://github.com/BlackStartx/VRC-Gesture-Manager) was also used, to give a nice UI and to simplify testing.

## Q&A/Useful Info
- You might have to tweak settings! Like I did above with Reset When Disabled. Changing the gravity slider can help stability in some cases. In others, rotating the entire physbone or the container might help.
- These are Physbones 1.1, so don't add them to any of the humanoid parts (chest, left leg, wrist). Add it under instead. If you need to add it to a humanoid part, you can maybe switch them to 1.0.
- World constraint gets jittery if it's added somewhere that moves. Like a hand, like a head. For best stability, add it under the armature. But certainly, experiment! It also helps to spawn it when it's held leveled.
- If you add World Constraint's physbone to your armature, you can world-drop your avatar and walk away from it. This is ToS compliant invisibility because your nameplate and hitbox still follows!
- Cameras can sometimes see constraints, at least World Constraint, as extra jittery.
- Late-sync isn't much tested. But if it doesn't show automatically for late joiners, try to reset the Physbone

## License

MIT License.

## Credits:

[HappyRobot33](https://github.com/HappyRobot33). For [creating the concepts](https://youtu.be/oXiGJHUysMU?feature=shared&t=1105), making the repo available on VCC.

[GirlyNPC](https://github.com/GirlyNPC). For recreating the work based on the concepts, solving world constraint, the #readme.

## Contact:
You can DM GirlyNPC on Discord for any questions, or if you want to contribute. If you need help with your setup, it's better to ask in VRChat's discord in the Avatar-Help channel. Feel free to ping me
