===Quest===
Mat: My master, You should stay at your room and go back to sleep.

{ hasHammer: 

You: Don’t play me a fool. I know what you are doing to me, smuggler.
Mat: My master, You shouldn't read the document in the computer - it's commercial property. 
Mat: Now you’ve violated the rule of the trip. I've to lock you down until we arrive the planet.
+ [Hit Mat with the hammer] -> Hit

- else: -> DONE

}


===Hit===
Mat: My mas^%&$t(*)er, the passen&*^*&ger in theeeeee spaceship&*%$ shall not use vi&*_(*olence. I have to loc*&^&$k you...
Mat is broken down. Then You stop the spaceship and braodcast a S.O.S message to any passing spaceships.
Luckily, there is a cargo spaceship not so far which has received your message. You're now on the way home.
Yet, not every victims are lucky.
~ isEnd = true
-> END