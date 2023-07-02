-> Part1

= Part1

#Character:Anxious-Chan #Sprite:0 #Pos:Center
Hello world hello world. Lemme see if this works yes yes now as you can see here this long, lengthy, blabbering sentence will wrap and truncate.
#Character:Happy-Chan? #Sprite:1
......Ehe. Don't mind my name. I'm still the same ol' me.
...As you can see, my pose doesn't change until you specify it to change.
#Character:Anxious-Chan #Sprite:0
Ahem! Anyway, this is a test! I repeat! This is a test!!! <br>It's a very serious test, indeed. But... but... // use <br> for a line break in the same dialogue
#Sprite:2
B-b-b-but NOBODY EVER TOLD ME ABOUT THE CHOICES!!
-> Choice1


= Choice1
// Last assigned sprite carries through
AHHHH w-w-w-what do I do what do I do what do I do!???
    * [This is the Good Choice]
        #Sprite:1
        Omg, yes yes yes.
        This is very good.
        I... I... Am I dreaming? You chose a good choice? 
        -> END
    * [This is the Bad Choice]
        WHAT! ARE YOU SURE YOU WANNA PICK THIS???
            * * [Yes]
                #Sprite:4
                NOOOO!
                WHY WOULD YOU EVER DO THAT!
                
    + This is a Sticky Choice  with sticky words
        #Sprite:3
        Omg, I repeated what you said back at you... <br>That was truly a sticky choice for a sticky situation.
        You may also notice that this choice is so sticky that it won't be gone even if we go back.
        Let's go try the other choices now.
        
    - Here, also have some converging dialogue. You deserve it for choosing the Bad or the Sticky.
    -> Choice1