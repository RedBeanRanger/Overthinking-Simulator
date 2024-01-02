-> PostEvent1


===PostEvent1===

// After Event1
// Anxious chan reflects on how much blonde san hates her
// Count the number of times she loops and then increase anxiety after 2 loops

Oh, I'm glad I got to eat!
Yum yum yum...
(Sigh) But I wonder if I did the right thing...
Does she hate me now? 
Maybe this IS how you get fat!
-> PostEvent1Choice1

===PostEvent1Choice1===

    + [I think she might hate me...]
        Surely not for something so small!!!
        ++ [I think she does hate me...]
        Noooooo that can't be!
            +++ (DeathLoop)[But I did nothing wrong!]
                Yeah! Exactly!
                I'm right to get food for myself!
                It's not like I NEED to be sitting with my friends during lunch!
                Even though she really wanted me to, it seems...
                And it was in her time of need...
                Come to think of it, I don't think I comforted her when she said she was losing weight...
                I don't think I smiled enough during our conversation, either!
                Maybe that's why she got so serious!
                ->PostEvent1Choice1
            
            ->PostEvent1Choice1
            +++ [I HAVE SINNED!]
                I need to PROFUSELY apologize!
                ...Oh, but that's true! I could just apologize!
                Yes yes, it will be fine if I just say sorry...
                -> DONE
        
        ++ {DeathLoop} [I wouldn't like it if my friend did that to me.]
            //Somehow she thinks her way into: FRIENDSHIP IS IRREPARABLE!!
        ->DONE

        
    + [Nah she wouldn't care]
    But did I respond well!?
        ++ ["She had good intentions!"]
        I shouldn't have brushed her good intentions away!
            +++ ["Maybe she DOES hate me!"]
                That would be AWFUL!
                ->PostEvent1Choice1
    