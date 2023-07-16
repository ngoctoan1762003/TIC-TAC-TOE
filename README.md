This project is a tic-tac-toe game, I started making this project because I want to learn how to do a game with AI

I completed this project by myself. This project took me almost 1 week to learn and understand the algorithm and apply it to the project 

This project use alpha-beta pruning algorithm

The alpha-beta pruning algorithm is extremely important when programming games such as chess or chess, when the state spaces of these games are highly complex. Alpha-beta pruning will help remove unnecessary state spaces and support the optimization of the Minimax search algorithm.

This algorithm is often used in conjunction with the Minimax search algorithm to help reduce the state space in the game tree, helping the Minimax algorithm to search deeper and faster. The alpha-beta pruning algorithm has a simple principle: "If it is known that the case is bad, there is no need to consider it further".

In this project, this algorithm will maximize the likelihood of winning of AI and minimize the player's chances of winning 

![Game-tree-for-Tic-Tac-Toe-game-using-MiniMax-algorithm](https://github.com/ngoctoan1762003/TIC-TAC-TOE/assets/54841155/e62b33f0-2e63-40d8-874c-a43f27369901)

This algorithm bears little resemblance to the greedy algorithm. It will execute until the results are returned

If player win, it will return value -1
If AI win, it will return value 1
If the result is tie, it will return 0

Then the upper node of the result will return value based on whose turn it is.
If it is player's turn, it will get the minimum value of its child
If it is AI's turn, it will get the maximum value of its child
Thus, this algorithm will maximize the likelihood of winning of AI and minimize the player's chances of winning 

But this algorithm is better than greedy algorithm at one point that it will cut the node and its node

<img width="646" alt="Screenshot 2023-07-16 195842" src="https://github.com/ngoctoan1762003/TIC-TAC-TOE/assets/54841155/4350ff57-9a6d-434d-8358-0b6cab84803c">

If the node already have a maximum or a minimum value, it will cutoff the others because it does not need to visit all the leaf anymore, then it will reduce the complexity of the algorithm a lot

Here is the link you can try: https://will176.itch.io/undefeatable-tic-tac-toe
