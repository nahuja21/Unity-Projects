### IDENTIFYING INFORMATION

Gabriel Davidson > 2338642 > gadavidson@chapman.edu

Colton Reiher > 2398791 > reiher@chapman.edu

Nikhil Ahuja > 2404567 > nahuja@chapman.edu

Jesse Arevalo Baez > 2399233 > arevalobaez@chapman.edu

...

CPSC-245-02 > Final Project: Chap-Man Game

### SOURCE FILES

##### Managers
- GameManager.cs
- GameTimer.cs
- LevelManager.cs
- SceneChangeManager.cs
- AudioManager.cs

- GameUIManager.cs
- QuitCommand.cs

- Singleton.cs

##### Audio (In addition to AudioManager.cs)
- AudioPlayer.cs

##### Nodes
- Node.cs
- BasicNode.cs
- FruitNode.cs
- PowerupNode.cs

##### Pacman
- Pacman.cs
- PacmanMovementController.cs

##### Enemy
- Enemy.cs
- EnemyController.cs
- EnemyMovementController.cs

##### State System
- BaseState.cs

- EnemyStateMachine.cs
- EnemyState.cs
- EnemyNormalState.cs
- EnemyVulnerableState.cs

- GameStateMachine.cs
- GameState.cs
- GameMainMenuState.cs
- GamePlayingState.cs
- GamePausedState.cs

- PacmanStateMachine.cs
- PacmanState.cs
- PacmanMoveState.cs
- PacmanMoveRightState.cs
- PacmanMoveLeftState.cs
- PacmanMoveDownState.cs
- PacmanMoveUpState.cs

##### Statics
- GameParameters.cs
- PlayerMetrics.cs

##### Other
- DontDestroy.cs

### COMPILE OR RUNTIME ERRORS, CODE LIMITATIONS, DEVIATIONS FROM ASSIGNMENT SPECIFICATIONS
- Ghosts will stack on top of each other
- Ghosts kinda suck at running away when vulnerable
- Pacman only has 1 life

### INSTRUCTIONS
1) Download project files
2) Run executable file (.exe)

##### In-Game
1) Press Play (or navigate to Credits/Quit)
2) Collect all nodes (including fruit) in a level to progress
3) Complete all **4** levels to complete the game

### Miro Program Graph
https://miro.com/app/board/uXjVNMbkcCQ=/?share_link_id=997755515699
