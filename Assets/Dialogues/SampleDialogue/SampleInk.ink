INCLUDE Weedy1.ink
-> Part1
//-> Part2
//-> Part3

=== Part1 ===

#Left:NPC #Center:NPC #Right:NPC
#Name:DEBUG
#Active:Left #Active:Right #Active:Center
Dialogue Starts Now:

#Center:AnxiousChan
#CenterExp:0
#Name:Anxious-chan
Hello world hello world. Lemme see if this works yes yes now as you can see here this long, lengthy, blabbering sentence will wrap and truncate.

#CenterExp:1
#Name:Happy-Chan?
......Ehe. Don't mind my name. I'm still the same ol' me.
...As you can see, my pose doesn't change until you specify it to change

#CenterExp:0
#Name:Anxious-chan
Ahem! Anyway, this is a test! I repeat! This is a test!!! <br>It's a very serious test, indeed. But... but... // use <br> for a line break in the same dialogue

#CenterExp:2
B-b-b-but NOBODY EVER TOLD ME ABOUT THE CHOICES!!
-> Choice1


= Choice1
// Last assigned expression, character placement, and active position carries through
AHHHH w-w-w-what do I do what do I do what do I do!???

    * [This is the Good Choice]
        #CenterExp:1
        Omg, yes yes yes.
        #CenterExp:1
        This is very good.
        I... I... Am I dreaming? You chose a good choice?
        In that case, I will move on with life!
        -> Part2
        
    * [This is the Bad Choice]
    
        WHAT! ARE YOU SURE YOU WANNA PICK THIS???
        
            * * [Yes]
                #CenterExp:4
                NOOOO!
                #CenterExp:4
                WHY WOULD YOU EVER DO THAT!
                
    + This is a Sticky Choice  with sticky words
        #CenterExp:3
        Omg, I repeated what you said back at you... <br>That was truly a sticky choice for a sticky situation.
        You may also notice that this choice is so sticky that it won't be gone even if we go back.
        Let's go try the other choices now.
        
    - Here, also have some converging dialogue. You deserve it for choosing the Bad or the Sticky.
    -> Choice1