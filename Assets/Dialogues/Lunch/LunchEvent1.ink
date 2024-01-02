INCLUDE ExternalFunctions/ExternalFunctions.ink

->Lunchroom1Intro
===Lunchroom1Intro===
#Center:NONE
#Name:NONE
#Active:NONE
The bell goes off! It is now lunchtime.
Phew! You survived to midday.

#Center:AnxiousChan
You are feeling ravenous today.

#Active:Center
#Name:Anxious-chan
How could one possibly satiate such beastly urges to consume?
I would need a sandwich and a drink, at least.

#Name:NONE
#Active:NONE
However, beside you, a beast of starvation looms.

#Active:Right
#Left:AnxiousChan
#Right:BlondeFriend
#Name:Blonde-san
Ah, it's lunchtime already~~ 
Too bad I'm not that hungry!
Let's just get a drink and chat with Nicole, Anxious-chan!
I heard that she went out with Darren!

#Active:Left
#Name:Anxious-chan
#LeftExp:2
(JUST A DRINK!?)
(Oh, but I am hungry!)
    * ["O-Oh, that would be fun, but actually I'm kinda hungry..."]
        O-Oh, that would be fun, but actually I'm kinda hungry...
        -> ObnoxiousBlonde
    * ["Oh, sure... ok...."]
        Oh, sure... ok....
        ->GetDrinksWithBlonde
    * ["Oh, you can go by yourself... I'm actually quite hungry."]
        Oh, you can go by yourself... I'm actually quite hungry.
        ->EatingByYourself
        
===ObnoxiousBlonde===
#Active:Right
#Name:Blonde-san
Ohhhh come on, you can't be THAT hungry~~
You can just get a big drink and then we can go hang out!

#Active:Left
#LeftExp:2
#Name:Anxious-chan
(...)
    * ["Ok...sure..."]
        "Ok...sure..."
        -> DONE
    * ["But I AM THAT hungry!!!"]
        "But I AM THAT hungry!!!"
        #Active:Right
        #Name:Blonde-san
        #RightExp:1
        ...To be honest, I'm also hungry.
        But I really have to lose some of the chub-chub.
        #RightExp:0
        No, no, don't worry about me!
        I got plenty left to lose!
        #Active:Left
        #Name:Anxious-chan
        (...)
            ** ["Oh... fair, I need to lose weight too..."]
                Oh... fair, I need to lose weight too...
                ->GetDrinksWithBlonde
            ** ["But...you don't need to lose weight, right?"]
                But...you don't need to lose weight, right?
                ->ObnoxiousBlondePersuasion

===ObnoxiousBlondePersuasion===
#Active:Right
#Name:Blonde-san
Oh, you don't have to say that~
You know, SOME people look good when they are chubby,
#RightExp:4
but I can't pull it off. Ehehe~!
#RightExp:0
Aw, but just come along with me! It'll be fun!
#Active:Left
#Name:Anxious-chan
    * ["Okay... Let's go then..."]
        Okay... Let's go then...
        ->GetDrinksWithBlonde
    * ["Oh, good luck then... I'll still buy something because I'm really hungry..."]
        Oh, good luck then... I'll still buy something because I'm really hungry...
        ->EscapeFromBlonde

===GetDrinksWithBlonde===
#Active:Right
#Name:Blonde-san
Yayy~~! Let's go get drinks~!

// TODO MAKE ANOTHER SCENE FOR THIS PART
// TRANSITION TO LUNCH ROOM PROPER (PREVIOUS PARTS HAPPEN
// IN A HALLWAY)


#Center:AnxiousChan
#Left:BlondeFriend
#Right:StudentNPC
#RightExp:5
#Active:Left
#Name:Blonde-san
Omggg, I still can't believe Darren asked you out! This is so exciting! I'm so happy for you, Nicky~
#Active:Center
#Name:Anxious-chan
(...ohhhh I'm still hungry...)

#Active:Right
#Name:Nicole
Oh, I didn't think he'd ask me out in front of everyone, but I'm glad he did!

#Active:Left
#Name:Blonde-san
Do you like, LIKE like him? Or are you just giving him a chance?

#Active:Right
#Name:Nicole
We're just seeing how it goes.

#Active:Left
#Name:Blonde-san
Have you guys like, kissed?
...Or MORE?

#Active:Right
#Name:Nicole
Haha, that's silly.
It's too early for that, Lolo.

#Active:Left
#Name:Blonde-san
Ehehe, are you guys playing the long game?

#Active:Right
#Name:Nicole
Haha, I don't think we have long term plans. We won't see each other over summer, anyway.

#Active:Center
#Name:Anxious-chan
(...ohhhh... so hungry... so hungry for a long time...)

#Active:Left
#Name:Blonde-san
Well, if it doesn't work out, I'll set you up with Connor!




//TODO
->DONE

===EscapeFromBlonde===
#Active:Right
#Name:Blonde-san
Awwww, you're going to eat without me?
Fine, see you later~

#Center:AnxiousChan
#CenterExp:0
#Active:Center
#Name:Anxious-chan
Ah, she is GONE.



//Go to cafe - how much money you will spend
    // TODO make a separate ink file for that
//Sneak in lunchroom (you can hear blonde-san chatting it up behind you, but you dare not look)



-> DONE

===EatingByYourself===


->DONE




