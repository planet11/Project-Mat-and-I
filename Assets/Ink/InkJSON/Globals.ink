EXTERNAL setItem(item)
EXTERNAL hasScrewdriver(hasScrewdriver)
EXTERNAL hasHammer(hasHammer)
EXTERNAL gameState(isEnded)
EXTERNAL matState(isHit)
~gameState(false)
~matState(false)
~setItem("")
~hasScrewdriver(false)
~hasHammer(false)

VAR powerIsFixed = false
VAR isSuspected = false
VAR matTalk = 1