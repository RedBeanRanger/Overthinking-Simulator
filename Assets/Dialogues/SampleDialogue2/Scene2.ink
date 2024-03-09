INCLUDE Utility/GlobalVars.ink
INCLUDE Utility/ExternalFunctions.ink
-> Scene2
===Scene2===
//we can also do temporary variables
VAR knowJaeName = false

#Center:AnxiousChan
#CenterExp:0
#Name:NONE
#Active:Center
As you walk down the hallway, you suddenly spot someone in front of you at the other end of the hall.
#Center:Club
#CenterExp:4
#Active:NONE
It appears to be a mysterious boy.
He is facing the wall intently, and does not appear to notice you just yet.

{SBAR_VAL >= 35: 
    ~knowJaeName = true
}

{knowJaeName:
#Center:AnxiousChan
#CenterExp:0
#Active:Center
You can recall this mysterious boy's identity due to having seen numerous waves of fans and haters surrounding him before.

#Center:Club
#CenterExp:4
#Active:NONE
This is Jae, the leader of the school Theater Club.
It seems he has somehow sneaked in here unnoticed, judging by the clear lack of paparazzi.
}

#Center:AnxiousChan
#CenterExp:0
#Active:Center
You have stumbled across him by accident. Perhaps it is a good idea to leave him alone.
#CenterExp:2
Or, maybe it's a good chance to strike up a conversation! Provided you are bold enough.

{knowJaeName:
#Center:Club
#CenterExp:4
#Name:Jae
}

{knowJaeName != true:
#Center:Club
#CenterExp:4
#Name:Mysterious Boy
}
Ahem... ahem... ah-h-hem...


#Center:AnxiousChan
#CenterExp:2
#Name:NONE
Before you could do anything though, {knowJaeName:Jae|the mysterious boy} suddenly begins to speak loudly!

{knowJaeName:
#Center:Club
#CenterExp:4
#Name:Jae
}

{knowJaeName != true:
#Center:Club
#CenterExp:4
#Name:Mysterious Boy
}

Sweet Clementia! Spare me!
Though thou I dost lovest so, I cannot kill. For once I'll choose to die upon a hill.
What else must thou demand of me to do!? I'm not some storied hero born anew.
No Delphic words for this mere son of man. My 'morrow's fixed by glorious design
into a role of meek dominion; a prince subject to fleet opinion.
What grounds have I to slay my better kin? What grounds have I to bring this kingdom ruin?
What patricide would be admissible? Wouldst thou delight to love a criminal?
No, I could not, Clementia! Not even for you!
For though I know my father's reign is grave, a murderer would not this kingdom save!
Hmmm... 
(mumble mumble) this line here... (mumble mumble)... could be better... 
(mumble mumble) interesting tragedy...
Maybe I should cast Ark as the prince (mumble mumble mumble)...


#Center:AnxiousChan
#CenterExp:2
#Name:NONE
The mumbles fade away as {knowJaeName:Jae|the mysterious boy} walked down the opposite direction.
#CenterExp:0
It seems he was looking over the lines of a play. He seems to be puzzling over difficult leadership decisions.
Although it is too late to try to talk to {knowJaeName:Jae|the mysterious boy} now, you have briefly glimpsed into his life.
Turns out, even those at the top have their own problems to deal with. ...Or not?
Who really knows!
~ChangeSBar(10)
Social Adjustedness is increasing!


->END