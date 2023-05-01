===isFixed===
~ circuitIsFixed = false
Mat: My master, did you fix the broken device?
You: Yes but it looks like being punched by someone intentionally.
Mat: No worry. Now everything is alright. My master, it’s time to get resting in your room.
+ [There should be some problems. You should let me know all about the trip and the spaceship.] -> Suspicion
+ [OK. I'm going to sleep. Wake me up when we arrive.] -> SleepAgain 


===Suspicion===
~ isSuspected = true
Mat: My master, for the reasons of flight security and commercial secret, I cannot tell you everything. Please trust me. I won’t let you get in danger.
+ [You look at Mat with distrust but can do nothing.] I should go to find out the truth of that. -> DONE
+ [Alright. I should trust you. I'm going to sleep now.] -> SleepAgain


===SleepAgain===
Now you are getting back into the status of stasis, peacefully.
After countless days you wake up. You've found that you are not in AST-28, a fictional planet, but a cage. 
The guardian holding a whip shouts at you, "Go working now! Do you want me to beat you? No meal if you haven't sent the messages to at least 100 people today."
You are just one of the thousands victims in the crimes of international human trafficking.
~ isEnd = true
-> END