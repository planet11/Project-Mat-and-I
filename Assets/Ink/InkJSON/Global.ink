EXTERNAL SetScrewdriver(setScrewdriver)
~ SetScrewdriver(false)
EXTERNAL SetHammer(setHammer)
~ SetHammer(false)
EXTERNAL MatIsHit(matIsHit)
~ MatIsHit(false)

VAR firstTalk = true
VAR isSuspected = false

VAR hasScrewdriver = false
VAR hasHammer = false

VAR circuitIsFixed = false

VAR photoIsChecked = false
VAR pillowIsChecked = false

VAR turnOn = false

VAR isEnd = false