INCLUDE Global.ink
INCLUDE Mat_Talk02.ink
INCLUDE Mat_Talk03.ink

{ firstTalk:

Mat: Good day, my master. You should stay stasis now. We are still on the way to the planet AST-28.
You: Did you realize the shake? Did our spaceship crash?
Mat: According to the flight recorder, it didn't crash on anything.
You: Wired. I woke up because of that. Can you investigate what's happened?
Mat: Yes, my master. Besides, it is reported that the voltage of the spaceship is not quite stable. May I ask for your help to check any breakdown of the circuit breaker?
You: But I don't know how to do.
Mat: My master, you're the clevest girl I have even seen. I believe you can fix the problem.
Mat: Just don't forget to take the screwdriver. The circuit breaker is at the corridor.
You: Okay. I'll go for it.
~ firstTalk = false
~ setScrewdriver = true
-> DONE

- else: 
{ circuitIsFixed: -> isFixed | Mat: My master, what can I help you?}

{ isSuspected: -> Quest }

}