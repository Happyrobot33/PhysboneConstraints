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

https://github.com/Happyrobot33/PhysboneConstraints/assets/144646911/3b57ffee-0566-4d0a-8509-a77910c407ef

Someone make a better vid and tell me how to scale it!

## How to Install:

You can add PhysboneConstraints directly via VCC, by pressing [here!](https://www.matthewherber.com/PhysboneConstraints/).

Not using VCC or having troubles? You can also grab the packages from [Releases](https://github.com/Happyrobot33/PhysboneConstraints/releases)!<br> 

## Setup Example:

This release includes several PhysboneConstraint variants, this shows the Physbone Position Constraint.<br>
From that, you should get a clear idea of how to set up the rest. </br>
But check out Q&A/Useful Info section for more info!

*Due to how Unity animations work, you'll have to set it up on your own. This is really quick!*

- ### Setting up the Physbone Position Constraint

Here's an example of setting up Physbone Position Constraint.

https://github.com/Happyrobot33/PhysboneConstraints/assets/144646911/8a12f687-c477-4c0e-bc76-f29d53aaab7b

*Note:*
- Reset When Disabled was turned on here, due to how I set up the toggle. Depending on what you're doing, you might not need this.
- Also zeroed out the values in the transform position, so it would be at the hand.

## Q&A/Useful Info
- You might have to tweak settings! Like I did above with Reset When Disabled. Changing the gravity slider can help stability in some cases. In others, rotating the entire physbone or the container might help.
- These are Physbones 1.1, so don't add them to any of the humanoid parts (chest, left leg, wrist). While doing so can be fine, it can also not! Add it under instead, to a new gamobject.
- World constraint gets jittery if it's added somewhere that moves. Like a hand, like a head. For best stability, add it under the armature. But certainly, experiment! It also helps to spawn it when it's held leveled.
- If you add World Constraint's physbone to your armature, you can world-drop your avatar and walk away from it. This is ToS compliant invisibility because your nameplate and hitbox still follows!
- Cameras can sometimes see constraints, at least World Constraint, as extra jittery.
- Late-sync isn't much tested. But if it doesn't show automatically for late joiners, try to reset the Physbone

## License

MIT License.

## Credits:

[HappyRobot33](https://github.com/HappyRobot33). For [creating the concepts](https://youtu.be/oXiGJHUysMU?feature=shared&t=1105), making the repo available on VCC.

[GirlyNPC](https://github.com/GirlyNPC). For recreating the work based on the concepts, solving world constraint, the #readme.

[Reverseuh](https://media.discordapp.net/stickers/1165089074869186580.webp?size=160). For helping GirlyNPC test VCC.


## Contact:
You can DM GirlyNPC on Discord for any questions, or if you want to contribute. If you need help with your setup, it's better to ask in VRChat's discord in the Avatar-Help channel. Feel free to ping me
