===Daydream1===
#Center:AnxiousChan
#CenterExp:1
#Active: Center
#Name:Anxious-chan
(Oh good good! We are thinking? What to think about today?)

*[Why do I have no friends?]
    ...
    #CenterExp:2
    (WHAT KIND OF A THOUGHT IS THIS!?)
    (And and and... it's not even true! I-I have friends!)
        **[Do I really?]
            (Wha...WHAT!?)
            (Am I really questioning this? I definitely have friends!)
        **[Yes, I have friends!]
            (Yes! That's right!)
            #CenterExp:1
            ~ ChangeBarValue("HBar", 5)
            (I have friends indeed! This makes me happy!)
        --
        (I have friends who are very nice and...)
        (...cares about me...)
        #CenterExp:0
        (...and won't betray me...)
        (...and will include me in things...)
        (...)
        **[Maybe I'm just avoiding reality.]
            (Er...)
            #CenterExp:2
            (W-What do you mean!? What am I implying!?!)
                ***[I have no real friends]
                    (NOOOOO!)
                    #CenterExp:4
                    (IS THAT TRUE!?)
                    (But they are the only friends I've made all year!!!)
                    (What am I supposed to do if that's the case?)
                    ~ChangeABar(10)
                    #Name:NONE 
                    Her anxiety is increasing!
                ***[No implications here!]
                    .......
                    ....
                --- 
                #Name:NONE
                ~ ChangeBarValue("HBar", -10)
                Just considering the possibility that she has no real friends made Anxious-chan less happy.
        **[Why am I faltering!? Keep it together!]
            (Right right right.)
            #CenterExp:1
            (Exactly, exactly, if I don't stand up for my friends, no one else will!)
            (They are very nice people.)
            #Name:NONE
            Anxious-chan has chosen to believe in her friends! This gives her more courage to face the future.
            ~ ChangeSBar(5)
            ~ ChangeHBar(5)
            Her social adjustedness increases! Her happiness increases!
        
*[Why am I so unpopular?]
    #CenterExp:2
    (OMG, THESE ARE AWFUL THOUGHTS!)
    (B-But I-I-I'm not even THAT unpopular, am I!?)
        **[I'm really popular!]
            (...)
            #CenterExp:0
            (Okay, now that's just delusional.)
            (I wish I could lie to myself to that degree.)
            #Name:NONE
            ~ ChangeHBar(-5)
            ~ ChangeSBar(5)
            The thoughts led to a moment of self-awareness! Happiness down, social adjustedness up!
        **[Meh, I'm okay.]
            (Right, right, right.)
            #CenterExp:1
            (So it's not THAT bad! There's there's definitely still kids less popular than me!)
            (Hehe.)
            #Name:NONE
            ~ ChangeHBar(5)
            ~ ChangeSBar(-5)
            The thoughts led to a moment of ego-boosting! Happiness up, social adjustedness down!
        **[I'm the most unpopular kid at school...]
            (YOWCH!)
            (...Is it really, really that bad?)
            #CenterExp:4
            (Am I on the way to becoming a recluse from society!?)
            #Name:NONE
            ~ ChangeBarValue("HBar", -5)
            ~ ChangeBarValue("SBar", -5)
            ~ ChangeBarValue("ABar", 10)
            IT WAS AN AWFUL THOUGHT!
        --
        #CenterExp:0
        #Name:Anxious-chan
        (Okay, okay, okay.)
        (Now that we've established that I'm not popular... What should I do about it?)
        
        **[I want to be more popular!]
            What.
            #CenterExp:2
            BUT HOW!?
            #Name:NONE
            ~ ChangeBarValue("ABar", 10)
            Anxious-chan feels incredibly daunted by this impossible task! Her anxiety increases!
        **[Meh, this is as good as it's gonna get.]
            (Ah, welp.)
            (Yeah, maybe I shouldn't pressure myself to try.)
            #Name:NONE
            ~ ChangeBarValue("ABar", -10)
            Anxious-chan is coming to terms with settling... Her anxiety decreases.
        **[Who wants to be popular anyway?]
            (...)
            #CenterExp:3
            (Yeah! Exactly!)
            (The popular kids are all assholes anyway!)
            #CenterExp:1
            (Yeah! Screw them!)
                        #Name:NONE
            ~ ChangeBarValue("ABar", -5)
            ~ ChangeBarValue("HBar", 5)
            Anxious-chan is externalizing her own problems! She feels less anxious and happier!
        
-
#Name:NONE
At this point, Anxious-chan notices the class is nearing its end.

->->