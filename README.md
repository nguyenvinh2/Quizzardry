# Quizzardry

# Introduction

Quizzardry is meant to be a fun and engaging game designed to foster collaboration between people. It provides entertainment in order to ease user stress.

# Scope (In/Out)

**In** - This is a game meant to be hosted on one screen but allowing for multiple players to interact with it on their own screens. The most obvious example of this would be to have the game presented on a television screen or computer monitor with players using their phones or other smart-devices to play. This will be a multiple-choice trivia game. The game is called Quizzardry as it will feature a loose wizard theme (perhaps players will get to choose from a number of wizard avatars when they start the game.)

To win the game, the player must have a higher score than all of the other players at the end of a set number of rounds. Every question is worth a number of points. Answering a question correctly will net that player the number of points the question was worth. However, if a player gets a question wrong, they are turned into a toad. Toads CAN NOT win the game.

The final question will see the non-transformed players wagering a number of points not exceeding their current score. The player with the most points after that round wins the game.

**Out** - This will be a web application and will not be ported to any other platforms.

## User Stories

* As a developer, I want to integrate Signal R as the framework for the game to allow real-time simultaneous communications between multiple users and the game.
* As a developer, I want to have a pool of questions and answers to retrieve and display to the users to automatic the trivia game process
* As a developer, I want to have a historical record of winners from each game to present to users.
* As a developer, I want the website to track multiple users in order to calculate the scores of each user.
* As a User, I want to see the winner of the game and the scores as the game progresses.
* As a User, I want the ability to seamlessly join and play the game from different types of platforms.
* As a User, I want to have fun and answer interesting questions.

## MVP

* Players will be able to join the game via their mobile devices.
* Players will be able to answer questions presented on the host screen by choosing one of the four possible answers presented to them on their devices.
* Players can earn points or be eliminated depending on whether or not they answer a question correctly.
* The final round will have the players wagering up to their entire score to win the game.
* The player will earn or lose the amount of points wagered depending on their answer.
* The player with the highest score will win the game.
* There will be enough questions to run one or two demos without repeating questions.

## Stretch

#### Stretch goals (Priority)

* Players with the “transformed” status will not be eliminated right away. And will still be allowed to answer questions and earn points.
* There will be one round near the end of the game in which the playing field will be split up into two teams: toads (players who have missed at least one question) and wizards (players who have not gotten a question wrong up to this point.)
* If a higher percentage of toads answer the question correctly than the percentage of wizards, then all of the wizards will become toads and all of the toads will turn back into wizards.
* After this round, toads will be unable to win.

#### Stretch goals (Excessed)

* Ability to have multiple games hosted simultaneously
* Even more questions (from API)
* Wizard avatars that players can select.


# Functional Requirements

* User can access (join or create) the game
* Users will be able to answer questions for score.
* Users will see scores and questions in real-time.
* Game will tally up final score to display winner.
* Game will end after 6 questions.

# Non-Functional Requirements

* This data transmitted to and from this applicaiton will be secured.
* CRUD operations tested.
* Clean UI for easy user navigatibility 

# Wire Frame

![Wire Frame](assets/GameStart.png)

# Database Schema

![DB](assets/GameDB.png)

# Data Flow

User will visit the web application and create a temp name. First User will initialize a game and a Game Entry will be created in the Database and invite others to join.
Once ready, user will initialize the start of the game, which will signal the host application to retrieve questions from the Questions Table and render to user.
Every user will simultaneously send the answer data to be processed by the host application. Host application will calculate the score
and track it. At the end of the game, the host application will calculate the winner and save the data in the Game Table. 
