INCLUDE Utility/GlobalVars.ink

-> SCENE0

===SCENE0===
#Center:AnxiousChan
#CenterExp:0
#Name:Anxious-chan
#Active:Center
Okay okay okay.
We are going to test some fun fun functionality.
External, persisting global variables.
Ohoh! Here comes the choice.
    * [Go to Scene 1]
        Nice.
        ~isFunScene1 = false
        ->END
    * [Go to Scene 1 with some additional fancy schmancy things]
        Cool.
        ~isFunScene1 = true
        ->END
    * [Go to Scene 2]
        Alright.
        ~willMeetJae = true
        ->END
