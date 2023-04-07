# Chessn't

You can find the Start Document [here](documents/startDocument.md).

**Subject:** C#2

**Date:** 31.02.2023

**Group members:** Robin Michael Visser, Levente Stieber, Tung Do Xuan, Sander Siimann

# Quick start

**When starting a game on a PC, please use the following root to start the C# application: NHL-Advanced-Chess\sourceCode\Chessnt\bin\Debug\net6.0-windows10.0.22621.0**

**To start the game, double-click the 'Chessnt.exe' file.**

# Scrum rules

Development board have 5 states to move tasks between in Trello.

Those states are:

1. Grooming - Every Monday team meets to discuss the difficulty of tasks. If possible to do then the task moves to
2. To Do - Storing all the tasks that is possible to do.
3. In progress - Task that is currently developed.
4. Review - Every Friday team meets to verify if the task is up to standards.
5. Done - Task is completed.

Also Task has 4 different types (task names are same with tasks in Trello board):

1. feature/TT-<number of the task>: task title  - Method/Feature of the application
2. development - regular pushes from feature branches
3. release/week<number of the week> - every Friday pushing from dev branch
4. main - final push

# Chessn't Game Rules

### Rules

Chess is a two-player strategy game that is played on a square board consisting of 64 squares, alternating between light and dark colors. The game is played with 16 pieces, each player having one king, one queen, two rooks, two knights, two bishops, and eight pawns. There are countless possible moves and combinations of moves.

The objective of the game is to checkmate the opponent's king, which means to place it under attack in such a way that it has no legal move to escape capture. The player who achieves checkmate wins the game.

Each piece moves in a specific way:

- The king moves one square in any direction.
- The queen can move any number of squares diagonally, horizontally, or vertically.
- The rook can move any number of squares horizontally or vertically.
- The bishop can move any number of squares diagonally.
- The knight moves to any of the squares immediately adjacent to it, then one square in a perpendicular direction.
- The pawn moves forward one square, but captures diagonally one square forward on either side.

There are also some special moves in chess:

- Castling is a move in which the king and one of the rooks move simultaneously. Castling can only be done if neither the king nor the rook has moved previously, and if there are no pieces between them. The king is moved two squares towards the rook, and the rook is placed on the square over which the king crossed.
- En passant is a move that can be made by a pawn that has just moved two squares from its starting position, and is threatened by an enemy pawn on an adjacent file. The attacking pawn can capture the moved pawn "en passant" (in passing), moving to the square on which the captured pawn would have landed.

The game begins with the white player making the first move, and then the players take turns moving their pieces. A player may not make any move that puts or leaves their own king in check. If a player's king is in check, they must make a move that gets their king out of check. If the player cannot get their king out of check, the game is over and the player loses.

The game can end in a draw if:

- The players agree to a draw.
- There is a stalemate, which occurs when the player whose turn it is to move has no legal move but is not in check.
- The players do not have sufficient material to force checkmate (for example, if both players have only a king left on the board).

**Special Rules:**

The Game further boasts of rules, which impart an element of unpredictability, thus distinguishing it from the conventional chess game. To introduce an element of chance, a dice is employed at the beginning of each player's turn to determine the randomness of the game. The newly implemented rules are outlined as follows:

- Player's piece turns into another piece. Versions of this:
  - Pawn to Queen
  - Pawn to Bishop
  - Pawn to Knight
  - Pawn to Rook
  - Queen to Pawn
  - Bishop to Pawn
  - Knight to Pawn
  - Rook to Pawn
- Player loses a random piece
- Player's opponent loses a random piece
- Player loses their turn

### Voice Command

The Chessn't application offers a distinctive functionality, whereby players can relocate pieces on the game board through the utilization of voice commands. To accomplish this, players are required to use the Nato Phonetic alphabet, which ensures that the system can accurately identify and interpret the player's spoken commands. It should be noted that the technology employed by the Monogame platform to process voice signals is not infallible, and there is a possibility of misinterpretation of commands. For instance, the system might erroneously identify the spoken command 'E2' as '82.' Therefore, to specify a particular tile on the chess board, players are advised to enunciate the corresponding phonetic alphabet, such as 'Echo 2', which will be accurately recognized by the system as 'E2'. It is worth mentioning that the application developers encountered some difficulty in identifying a suitable verbal command for moving the 'E4' tile. As a result, players who wish to move the 'E4' tile must articulate the name of the tile a second time to ensure accurate recognition by the system.

The following table can be used to help player to enunciate letters:

<img src="https://i.imgur.com/iZLkJIL.png" alt="image-20230407111504931" style="zoom:80%;" />



# Troubleshoot

If there are issues with the launch, you must run the project in VS 2023, as detailed below:

1. Add extension if Monogame doesn't load:

   ![addExtension](D:\Github\NHL-Advanced-Chess\documents\addExtension.png)

2. Check Content tool: Content->Content.mgcb and click it. See if you have all those fonts and images:

   ![graph](D:\Github\NHL-Advanced-Chess\documents\graph.png)

   Also make sure you click build to make sure that images and fonts are built successfully!
