-> Part2

=== Part2 ===


#Character:Anxious-Chan #Sprite:2 #Pos:Center
H-h-h-here we we we have a new change

A new editor version

#Character:Anxious-Chan #Sprite:5 #Pos:Center
Truly daunting

-> Choose_hair

= Choose_hair
#Sprite:0
This morning, I'm feeling
* "Floofy. "
    Yes. I am feeling floofy indeed. -> Choice2
    
* "Buzzy. " -> Buzzy


* "Ninkle. "
Alas, I choose to be ninkle today. -> Choice2

= Buzzy
Ah. I am feeling buzzy unfortunately. -
-> Choice2

= Choice2
#Character:Anxious-Chan #Sprite:0 #Pos:Center
Ok, so we have to go to class today...

Or DO WE?
* [Go to class]
    #Sprite:2
    What an AWFUL choice, I didn't want to go!
    
* [Don't go to class]
    #Sprite:2
    But what will they think! When I don't show up! And I will fall behind too!!
* { Buzzy } [I will push through today as well!]
    #Sprite:2
    Yes, why I've gotten this far!
    #Sprite:1
    I will survive this. -> END
* 	->

    You thought for too long, long and hard. Alas, you missed your class. Now you have nothing
    
    #Sprite:4
    "I should have made a good decision"
    -> END


- #Sprite:4 
Look what you've done

-> Choice2