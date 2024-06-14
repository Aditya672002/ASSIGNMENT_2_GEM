# Gem Hunters Game


Gem Hunters is an elementary terminal game in which two players sequentially take moves and make attempts to capture as many gems as possible on an 6x6 board.

-How to Play

1. Setup:
   - It is assumed that the player which is designated as P1 is located in the upper left corner of the field.
   - Player 2 (P2) begins his moves from the bottom right of the board according to standard conventions.
   - Gems (G) and obstacles (O) are distributed over the board space and not necessarily in the 3x3 squares.
   - The gaps between neighbouring elements are shown with “-. ”

2. Gameplay:
   - The objective of the game is that players move in sequence. P1 goes first.
   - On your turn, enter a move:- On your turn, enter a move:
     - The action are represented by the letters:  ‘U’ to move up.
     - `D` Option to select ‘down’ to differentiate it from ‘Down’.
     - symbol used to move left: `L
     - Turning the key clockwise from the neutral position is equivalent to pressing the `R` button to move right.
   - You cannot jump over others; you can only make a single move at definite squares on the checkerboard.
   - Indeed, it is impossible to perform an Appendix D on obstacles (O).

3. Collecting Gems:
   - The gem (G) is collected if you get to a square with a gem on it, where you move to.
   - The symbol "-" appears after the letter “S” to denote that the gem have been collected and the square thus becomes empty.

4. Winning the Game:
   - The goal of this game is to get to be played until both players take 15 turns (30 turns total) each.
   - Scored gems also called points are added up, and the player who has the most gems is declared the winner.
   - It means if both the players have collected same gem, then the situation becomes a draw.

- Running the Game

1. Download and Open the Project:Download and Open the Project:
   - Create a copy of the project or download from the repository if it was created there.
   - To do this, go to the File menu and select ‘Open Folder,’ then navigate to the folder where you placed the files and open it in Visual Studio.

2. Run the Game:
   - To start the game, press the keys on the keyboard with the combination ‘Ctrl + F5’.

3. Follow the Prompts:
   - The game will simulate the chess board and wait for you to input your move to be made.
   - To control the player, type ‘U’ for Up, ‘D’ for Down, ‘L’ for Left and ‘R for Right.


- Code Structure

 Position Class
- Stands for the run on the y-axis and the column on the x-axis of the board.

 Player Class
- A list or a none list to store a player, his position, and the number of gems collected.

 Cell Class
- Is an object that can be on the board: it can be vacancies, gems, obstacles or one of the players.

 Board Class
- Is responsible for running the actual game and initializing and displaying the game area.

 Game Class
- He is mainly responsible for the overall look of the game and for calculating whose turn is how and deciding who won.

 Program Class
- Introduces the game and serves as a platform from where the user is supposed to begin the game.



