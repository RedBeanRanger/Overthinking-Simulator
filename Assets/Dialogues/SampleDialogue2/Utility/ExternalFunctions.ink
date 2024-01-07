// External function definitions

// bar value management
EXTERNAL ChangeBarValue(barName, amount)

// sprite actions
EXTERNAL SpriteShakeL()
EXTERNAL SpriteShakeC()
EXTERNAL SpriteShakeR()

EXTERNAL SpriteBounceL()
EXTERNAL SpriteBounceC()
EXTERNAL SpriteBounceR()

//units are in integers and time is a float
EXTERNAL SpriteMoveL(units, time)
EXTERNAL SpriteMoveC(units, time)
EXTERNAL SpriteMoveR(units, time)


// Helper function definitions
== function ChangeSBar(amount) ==
~ ChangeBarValue("SBar", amount)

== function ChangeHBar(amount) ==
~ ChangeBarValue("HBar", amount)

== function ChangePBar(amount) ==
~ ChangeBarValue("PBar", amount)

== function ChangeABar(amount) ==
~ ChangeBarValue("ABar", amount)



// Function fallbacks
== function ChangeBarValue(barName, amount)==
~ return

== function SpriteShakeL() ==
~ return

== function SpriteShakeC() ==
~ return

== function SpriteShakeR() ==
~ return

== function SpriteBounceL() ==
~ return

== function SpriteBounceC() ==
~ return

== function SpriteBounceR() ==
~ return

== function SpriteMoveL(units, time) ==
~ return

== function SpriteMoveC(units, time) ==
~ return

== function SpriteMoveR(units, time) ==
~ return