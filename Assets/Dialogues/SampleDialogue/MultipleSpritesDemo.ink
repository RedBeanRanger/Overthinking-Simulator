//-> Part3
=== Part3 ===

VAR isAware = false

#Name:NONE
And so, with a tentative determination, Anxious-chan set off for school.

#Left:NPC #Right:NPC 
#Active:Left 
#Name:???
Hey, Rude-chan?

#Left:NPC #Right:NPC
#Active:Right 
#Name:Rude-chan
Nani, Rude-kun?

#Left:NPC #Center:NPC #Right:AnxiousChan
#RightExp:1
#Active:Left 
#Name:Rude-kun
Do you see that girl coming our way?

#Active:Center 
#Name:Rude-chan
Yeah? What about her?

#LeftExp:1 #RightExp:0
#Active: Left
#Name:Rude-kun
Teeheeheehee... what do you think about her hair?

#CenterExp:1
#Active:Center
#Name: Rude-chan
Hey, don't be rude, Rude-kun! What if she hears us?

#Active:Left
#Name:Rude-kun
Eh, but you agree with me right?

#RightExp:2
#Active:Center #Active:Left 
#Name:Rude Blobs
THEEHEEHEEHEE! It's BUZZY!

#Active:Center
#CenterExp:0
#Name:Rude-chan
...Although we wouldn't have known that if we didn't look at the ink file, Rude-kun. It's kind of an abuse of power.

#Active:Left
#LeftExp:0
#Name:Rude-kun
Aw, come on, don't say it like that Rude-chan, you make us sound like bullies! That's not fun anymore!

#Active:Right
#Name:Anxious-chan
......

#Active:Center #Active:Left
#Name:Rude Blobs
SHE'S LOOKING THIS WAY! RUN!

#Center:AnxiousChan
#CenterExp:2
#Name: Anxious-chan
...
#CenterExp:4
...THOSE TWO JUST NOW WERE DEFINITELY LAUGHING AT ME, WEREN'T THEY?

    * [Yup, definitely]
        ~ isAware = true
        ...
        #CenterExp:0
        ...(sigh.) I knew it...
        Ah, welp. That killed all my motivation. Might as well skip school while I'm at it.
    * [Nah, it's just my imagination.]
        #CenterExp:1
        ...
        #CenterExp:1
        Yeah, I probably imagined it... 
        #CenterExp:4
        NOT!
        They definitely laughed at me! I'm going home, I hate this!


- #Name:NONE
After such discouragement from those strangers, Anxious-chan didn't have the heart to go to school anymore.

#CenterExp:3
{isAware: Because she faced reality head-on, Anxious-chan ended up feeling especially spicy the whole day.}


{isAware: She even worked up the spiciness to kick a can in the middle of the road!}


#CenterExp:4
{isAware: However, she missed and stubbed her toe!}

{isAware: What an AWFUL day!}

Could things still turn around for our Anxious MC!? Stay tuned next week to find out!

-> END
