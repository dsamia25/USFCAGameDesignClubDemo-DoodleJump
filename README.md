*****HIERARCHY*****
- Camera
    - Has a "CameraMovement" script that makes it move up as the player does.
- Background
    - A white image to make the background.
    - Is a child of the Camera so that it will always be in view.
    - Is in a "Background" sorting layer to always be behind the player and platforms.
- Player
    - The player always starts at the point (0,0).
- GameManager
    - Has a "GameManager" script that manages starting the level.
        - Starting the level includes:
            - Generating the platforms.
            - Moving the player to the origin.

*****FOLDERS*****
- Added a "Scripts" folder to save scripts in.
- Added a "Prefabs" folder to save prefabs in.

*****SCENES*****
- Renamed the default scene from "SampleScene" to "GameScene"
- Planning on adding a second scene for the main menu to start the game called "MenuScene"

*****LAYERS*****
- Added a "Player" layer for the player.
- Added a "Ground" layer for the player.
    - This layer will allow the player to check if they have interacted with something safe.
- Added an "Obstacle" layer.
    - This layer will allow the player to check if they have interacted with something that will cause the game to end.
    - Will be used to check if the player has touched something deadly in the Player script.
    
*****SORTING LAYERS*****
- Added a "Background" sorting layer.
    - Moved the sorting layer to be behind the "Default" layer so that it's always in the background.
    
*****TAGS*****
- Added a "Ground" tag for organization.

*****Prefabs*****
- Created a "Player" prefab.
    - Has a SpriteRenderer with a sprite of a blue square.
    - Has a Rigidbody2D for movement.
        - Will be used to move the player in the Player script.
        - *Optional* Lock Z rotation.
    - Has a BoxCollider2D to check for collisions.
        - Will be used to interact with the ground.
        - Will be used to check if the player has touched something deadly in the Player script.
- Created a "Platform" prefab.
    - Has a SpriteRenderer with a sprite of a black box.
    - Has a Rigidbody2D to enable collisions.
        - Set to "Static" so that it will not move.
    - Has a BoxCollider2D to check for collision.
    
*****TODO*****
- *Create "DeathBox" prefab.
    - This should be an object that will kill the player on touch.
    - It should be a child of the camera and sit just below the screen so that it will move up with the camera and kill the player as they fall off the screen.
    - Should create an event that will cause the GameManager to reload the scene.
- *Create a reload scene function on the GameManger.
- *Make player only jump when hitting the top of platforms.
- Create a MenuScene that has a play button.
- Add a pause button to the game that has a menu button and a reload button.
- Add moving platforms.
- Add obstacles that can spawn on certain platforms that will kill the player on touch.
- Add platforms that disappear a second after being used once.
