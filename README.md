https://unijacob.itch.io/week-3a

## Changes in the original code:
1. Created the script [SceneBorderManager](https://github.com/UniJacob/Week3a/blob/main/Assets/SceneBorderManager.cs) and the static class [SceneBorders](https://github.com/UniJacob/Week3a/blob/main/Assets/Scripts/SceneBorders.cs) which use the view point of the main camera to track and save its bounderies in world coordinates.
2. Created the script [Persistant](https://github.com/UniJacob/Week3a/blob/main/Assets/Persistant.cs) ensures the game object is not destroyed when switching scenes (used on border colliders).
3. Created the script [VerticalLooper](https://github.com/UniJacob/Week3a/blob/main/Assets/Scripts/VerticalLooper.cs) - makes the game object loop through the screen when reaching its right and left edges. Uses edge collidors (that are place on the right and left borders).
4. Edited the script [InputMover](https://github.com/UniJacob/Week3a/blob/main/Assets/Scripts/1-movers/InputMover.cs#L54) so that the game object cannot exist the screen through the upper and lower boundries (with the function EnsureInBorders()).
5. Created the script [DestroyedOutOfBounds](https://github.com/UniJacob/Week3a/blob/main/Assets/Scripts/DestroyedOutOfBounds.cs) which makes a game object destroy itself when reaching a certain distance past the scene boundries. Used for optimization - [enemy](https://github.com/UniJacob/Week3a/blob/main/Assets/Prefabs/EnemySaucerWithCollider.prefab) and [laser](https://github.com/UniJacob/Week3a/blob/main/Assets/Prefabs/LaserWithScoreAdder.prefab) objects will no longer continue to move upwards/downwards forever (and needlessly take up memory).
