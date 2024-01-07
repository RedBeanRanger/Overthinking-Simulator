INCLUDE Utility/ExternalFunctions.ink

->SpriteActionsTestKnot

===SpriteActionsTestKnot===
#Right:AnxiousChan
#RightExp:2
#Name:Anxious-chan
#Active:Right
~SpriteShakeR()
Good morning.
~SpriteShakeR()
Just testing the shakes.
~SpriteShakeR()
Don't worry about it.

#Center:AnxiousChan
#CenterExp:2
#Name:Anxious-chan
#Active:Center
~SpriteShakeC()
If this goes well...
~SpriteShakeC()
I can even shake in the middle...

#Left:AnxiousChan
#LeftExp:2
#Name:Anxious-chan
#Active:Left
~SpriteShakeL()
Or on the left...
~SpriteShakeL()
H-Ha, haha... Man, I sure feel silly...
#Left:AnxiousChan #Right:BlondeFriend
#LeftExp:2 #RightExp:0
#Name:Anxious-chan
#Active:Left
~SpriteShakeL()
~SpriteShakeR()
Can Melody possibly shake with me as well?
It turns out she can.
~SpriteShakeR()
And she can shake by herself.
How fascinatinig how fascinating.
~SpriteBounceR()
I do think a bounce is more in her character though.
~SpriteBounceR()
Look at that.

#Active: Right
#Name:Melody
Hey Anxious-chan~ why are you talking to yourself?

#Active: Left
#Name:Anxious-chan
This would be a good time to start leaving.
~SpriteMoveL(-3, 0.5)
Here goes.

~SpriteBounceR()
#RightExp:4
#Active: Right
#Name:Melody
Hey hey! Did you hear me?
~SpriteMoveL(-10, 0.5)
~SpriteMoveR(-3, 0.5)
Heyyy~ Where are you goin'?
~SpriteMoveL(-200, 0.5)
~SpriteMoveR(-50, 0.3)
Wait for me!
->END