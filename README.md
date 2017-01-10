# XeroSnake

## Introduction

This is a Windows console based .Net game application. It will run on a local machine.

Game inspired by [Slither.Io](www.slither.io)

## Features
### Required Features

* Single Player
* 2 Player
* Score Board
* Persistant Leader Score
* Game screen/maze

### Additional Features

* AI Snake
* Diffirent levels
* Different game modes
* Different types of food 
* Enemies
* Different game screens/mazes
* Game speed

## Game Rules

* A snake eats food to grow in length
* Each snake has 3 lives
* A snake looses a life if it runs into the other snake, enemy or wall
* If a snake dies, it respawns with its initial length
* Points earned when:
  * Snake eats food
  * Different food has different points
  * Other snake looses its life by hitting said snake (will not earn points if other snake looses life by bumping into enemies/wall)
* Points lost when snake runs into other snake 
* Snake will not run into itself. It will pass through its own body.

## Win Conditions

Single Player: High Score

2 Player (AI/Human): Game ends once a player looses all 3 lives. Winner is the player with highest score.
