INCLUDE Global.ink

{ !turnOn: Maybe there is something secret in the computer.} 
~ turnOn = true

{ circuitIsFixed: ENTER THE PASSCODE: _ _ _ _ (Hints: Interact with the persol items in the bedroom)}

{photoIsChecked && pillowIsChecked: 
+ [I have the passcode] -> Access
-else:
-> DONE
}

===Access===
Passcode: _ _ _ _

* [S-T-A-R] -> STAR
* [T-R-I-P] -> TRIP
* [H-O-M-E] -> HOME
* [F-A-M-E] -> FAME

===STAR===
You typed S-T-A-R.

INVALID INPUT!
-> Access

===TRIP===
You typed T-R-I-P.

INVALID INPUT!
-> Access

===FAME===
You typed F-A-M-E.

INVALID INPUT!
-> Access


===HOME===
You typed H-O-M-E.

<Lot5023 - Sophia Lenison
Origin:Mars;    Destination:Ganya Casino, TP-28;  
Breeding:6 months;    Final Bid:$11,000;
Sex:F;    Age:25;    Height:168cm;    Weight:42kg;   Language:English>

What is that? A bid? $11,000? 

Oh no! They're selling me to the casino. It's a cheat. Damn how foolish I'm! I gave up my home and career for my dream of space traveling - now a nightmare.

Okay. Calm down. Now I've to find a way out, and also stop Mat the cheater! 

Let's grab something to crack him down. (Find something in the bedroom)
~ SetHammer(true)

->DONE
