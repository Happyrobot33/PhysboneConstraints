PhysboneConstraints V1.0

Legend:
*OldVersions - Physbone V1.O, or otherwise earlier versions. These are included as an example, but use the later ones!

*__Nothing - empty gameobject with transform zero'd out, see below for purpose.

*_PhysboneOriginConstraintV1Examples - Avatar Dynamics components set up with an empty origin reference (__Nothing), and will always be at word origin (often spawn).

*Look-AtConstraintV1Example - The gameobject will align to face toward the Target

*PositionConstraintV1Example - The gameobject will move to the target. You can have multiple targets, but only one active. CTRL+D to duplicate.

*World+YRotationConstraintV1Example - The gameobject will stay in the world, but rotate where you face.

*WorldConstraintV3Example - The gameobject will stay in the world where dropped.
This should be placed under the root (where the meshes are) for best stability.
On hips/hands/etc, this becomes jittery when moving fast. To best counter that, activate it when your hand/hips is leveled to the ground!


For an early tech demo of these concepts, check out: https://youtu.be/oXiGJHUysMU?feature=shared&t=1099

If you have any improved or new designs, feel free to DM me GirlyNPC on Discord or just make a pull request on GitHub.

Credit:
Happyrobot33 - for creating all the concepts, making this possible
GirlyNPC - recreating concepts, improving where possible
