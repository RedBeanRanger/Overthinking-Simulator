INCLUDE ExternalFunctions.ink

-> BlondeFriendEvent

===BlondeFriendEvent===
#Center:NONE
#Name:NONE
On your way to school, you see a familiar face.

#Center:AnxiousChan
#CenterExp:0
#Active:Center
#Name:Anxious-chan
...Huh?

#CenterExp:2
OH CRAP.
That's that's that's Blonde-san. Oh help oh help oh help...

~ ChangeABar(10)
#Name:NONE
Anxiety is rising!

#Name:Anxious-chan
#CenterExp:0
Wait. Why am I panicking. She's my friend.
...In theory.
...
#CenterExp:2
...
Do I... say hi? Am I... obligated to say hi?

* [Say hi]
    ...
    ~ ChangeABar(15)
    Anxiety is rising!
    #Left:AnxiousChan #Right:BlondeFriend
    #LeftExp:0 #RightExp:0
    #Active:Left
    #Name:Anxious-chan
    (Sigh.) Okay, fine.
    #LeftExp:1
    Hi, Blonde-san.
    #Active:Right
    #Name:Blond-san
    Oh! It's Anxious-chan!
    Ehe, good morning! 
    #LeftExp:0 #RightExp:2
    Also, huh? Are you still calling me Blonde-san?
    #RightExp:4
    How many times do I have to tell you? You can call me Blonde-chan instead!
    #Active:Left
    #Name:Anxious-chan
    Oh. Yeah. Right. I forgot. Blonde-s...chan. I meant to say Blonde-chan. Yes.
    #Active: Right
    #RightExp:0
    #Name:Blonde-chan
    That's more like it!
    #RightExp:4
    Ehehe, you're so funny Anxious-chan!
    Haven't we been friends for two years now? 
    I can't believe you're still embarrassed about calling me Blonde-chan!
    #Active:Left
    #Name:Anxious-chan
    .......Am I?
    #Active: Right
    #RightExp:0
    #Name:Blonde-chan
    Alright, that's enough chitchat! Hurry up slowpoke! You're going to make us both late!
    #Active:Left
    #Name:Anxious-chan
    .......I am?
    #Name:NONE
    Surprisingly, Blonde-chan did nothing else annoying for the rest of the walk to school.
    ~ChangeSBar(10)
    ~ChangeHBar(-5)
    By not avoiding social interaction, Anxious-chan exchanged some happiness for more social adjustedness.
    The two of you get to school together with no problem.
    ->END
* [Goodbye]
    (Shhh... she doesn't know I'm here.)
    #Name:NONE
    Anxious-chan decided to hide and wait for her friend to go on ahead.
    #Left:AnxiousChan
    #LeftExp:2
    #Active:NONE
    ...
    #Left:AnxiousChan #Right:BlondeFriend
    ...
    #Left:AnxiousChan #Center:BlondeFriend
    #CenterExp:0
    ...
    #Left:AnxiousChan
    ...
    #Center:AnxiousChan
    #CenterExp:1
    #Active:Center
    ...Phew. She left.
    Anxious-chan got to school with no problem.
    ->END