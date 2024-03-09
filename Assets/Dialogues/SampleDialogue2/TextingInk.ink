INCLUDE Utility/GlobalVars.ink
INCLUDE Utility/ExternalFunctions.ink
-> TextingViola

===TextingViola===
#Center:NONE
#Name:Anxious-chan
Okay. I'm going to do it!
I'm going to text her!
"Hi Viola!"
Okay. Now we wait.
...
...
...!
#Name:NONE
(Viola is typing...)
#Name: Viola
"Sup".
#Name: Anxious-chan
AHHH!
She responded really fast!
#Name: NONE
~ChangeABar(20)
Anxiety is increasing!
#Name: Anxious-chan
I had no plan going into this.
Okay okay. What should I say? 
I can't just go out there and ask directly about her crush, right!?
RIGHT!?
    * [SMALL TALK FIRST!]
        Yes, that's how normal peoople do things!
        ->SmallTalkChoice
    * [CAN'T DO SMALL TALK, MUST KNOW!]
        WHAT IS THIS SAVAGERY!
        ->DirectChoice


===SmallTalkChoice===
Okay okay okay. What exactly should I say?
    *"Boy it sure is cold today, huh?"
        NOOOO but this is a BORING option!
        And Viola HATES boring people!
        ->DONE
    
    *"Have you seen __(insert idol name here's)__ new mv?"
        Oh noo... I THINK THAT'S A GRAVE ERROR!
        Even though it's not classical music, Viola can talk about any kind of music for HOURS!
        I'll NEVER find out my true objective!
        ->DONE
        
    *"My toes smell kind of stinky."
        WHAT KIND OF CONVERSATION STARTER IS THIS!!?
        NOW I'VE GONE AND MESSED IT UP! AHHH!
        ->DONE
    
    *"You know how when people have a crush, their behavior changes?"
        THAT'S NOT SUBTLE AT ALL!
        IS IT?
        ->DONE

->END

===DirectChoice===

->END