INCLUDE Utility/GlobalVars.ink
INCLUDE Utility/ExternalFunctions.ink
-> Scene1

===Scene1===
#Center:AnxiousChan
#CenterExp:0
#Name:Anxious-chan
#Active:Center
Here is a fun fun Scene 1.
{isFunScene1: -> FunScene1}
And now it ends here.
->END

===FunScene1===

#CenterExp:2
Wait, could it be... EXTRA FUN!?
#Right:AnxiousChan #Left:Club
#RightExp:2 #LeftExp:0
#Active:Left
#Name:Mysterious Girl
~SpriteMoveL(20, 0.5)
One two three four, five six seven eight...
~SpriteMoveL(-20, 0.5)
Two two three four, five six seven eight...
~SpriteMoveL(20, 0.5)
Three two three four, five six seven eight...
~SpriteMoveL(-20, 0.5)
Four two three four, five six seven eight...
~SpriteMoveL(10, 0.5)
(huff... huff...)
~SpriteMoveL(-200, 4)
Okay, onto the next rep...
#Center:AnxiousChan
#CenterExp:2
#Name:NONE
#Active:Center
It seems the mysterious girl is gone.
You vaguely recall seeing her before but you cannot recall her name.
It seems if she spotted you she would likely ask you to join her her exercise.
That... That was a close call!
->END