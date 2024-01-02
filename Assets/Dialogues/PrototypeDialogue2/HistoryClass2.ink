INCLUDE ExternalFunctions/ExternalFunctions.ink
INCLUDE Gossip1.ink
INCLUDE Daydream1.ink
INCLUDE DozeOff1.ink

-> Class2Intro

===Class2Intro===
#Center:HistoryTeacher
#CenterExp:0
#Name:Mr. Dascalu
#Active:Center
Good afternoon.

#Active:NONE
#Name:Students
(All groan in chorus.)
#Name:A Loud Student
NOT HISTORY AGAIN!

#Name:Mr. Dascalu
#Active:Center
Settle down now. We are about to begin.
Allow me to explain the situation. Normally, you would not have two history lessons in a day. However, you will today.
This is because the only teacher who showed up today is myself.
The other teachers heard that this is "just a prototype", so they've decided their attendance is optional.
In fact, the entire science department resigned upon hearing this news. 
"What kind of school has a prototype day?" they said. They even speculated this was all a massive simulation. 
While that may be the case, I, personally, see no reason to work less whatsoever.
Men who tread the roads of least resistance can never become powerful kings, and simulated power is still power.
All of you will LEARN. I shall skewer knowledge and discipline into your brains, such that one day you may become great.
Now then, let us commence the lesson.
-> Class2Choice

===Class2Choice===
#Center:AnxiousChan
#CenterExp:0
#Active: Center
#Name:NONE
Mr. Dascalu had just declared that all students "will LEARN".
But will Anxious-chan really learn?

    * (PayAttention)[YES! Respect the man!]
        Anxious-chan decided to steel her nerves and listen to the class.
        -> Class2
    * [NO! My mind, my choice!]
        -> NotPayingAttentionChoice

===Class2===
#Center:HistoryTeacher
#CenterExp:0
#Name:Mr. Dascalu
#Active: Center
Last time, I described Europe as being indifferent towards Ottoman invasions in the Balkans during the 1400s-1500s.
Holy Roman Emperor Sigismund of Luxembourg was the notable exception,
attmpting to organize counterattacks against the Ottoman army in his lifetime unlike the rest of Europe.
Now this brings us to 1437, after King Sigismund's death.
Sigismund has a successor, Albert of Habsburg, married to Sigismund's daughter Elizabeth of Luxembourg.
Albert was never elected Emperor and ruled for only two years before passing away in 1439.
Albert had a son, Ladislas, who was born after Albert's death and thusly nicknamed Ladislas Posthumus.
Ladislas Posthumus was heir to Austria, Bohemia, Hungary, but clearly he could not rule as an infant.
This created a power vacuum after Albert's death, which caused Hungary to fall into civil war, with many nobles 
wanting to take advantage of the situation to gain power for themselves.
Meanwhile, Sultan Murad II continued his attacks.
In the end, where the power truly went was into the hands of John Hunyadi, viceroy of Hungary and voivode of Transylvania.
He was considered the best warrior in all of southern Hungary, who could repel continuous attacks from the Turks 
with a mere 50-100 men in his district of Severin even when other districts fell. After, he rapidly climbed the military ranks.
John Hunyadi became the chief authority on all matters anti-Ottoman, but neither he nor the man that he supported
for election, King Wladyslaw III of Poland, were named Emperor of Hungary.
Instead, the title went to Fredrick III of Habsburg, who spent most of his time trying to convince everyone
that he was the legitimate King of Hungary, rather than Hunyadi's son Matthias Corvinus.
In 1443, finally, an organized attempt to stop Ottoman advancement was made under the call of Pope Eugene IV.
Aside from John Hunyadi, Vladyslav III of Poland and Philip the Good of Burgundy participated in leading the campaign.
Hunyadi's troops of 30,000 men broke through the Sultan's power in Bosnia, Hercegovina, Serbia, Bulgaria, Albania, 
before being forced to retreat from the cold winter frost and lack of supplies.
Truly, a remarkable and unprecendented success against the Turkish army by the Europeans.
In fact, it was so remarkable that the Ottoman even agreed to sign a truce treaty with generous terms.
However, King Wladyslaw III eventually broke the truce at the request of papal legate Cesarini in 1444.
The Christians wanted to ride the wave of their success, and continue pushing the Ottomans back while morale was high.
But this sort of optimism led to the final, disastrous battle near Varna in eastern Bulgaria, in November 10, 1444.
The Christians broke their vow, emboldened by their previous success.
This time, their army was only sized at 15,000 men, half of the original number of forces.
At this point, John Hunyadi makes a special appeal to the voivode of Wallachia, hoping to be assisted.
Up until now, the voivode of Wallachia, Vlad Dracul, had been ambivalent towards the Crusade due to pressure from both sides.
Previously, John Hunyadi had been threatening to replace Vlad Dracul with the other candidate to the throne of Wallachia,
Dan II, if Vlad II dared show signs of disloyalty to the Hungarians.
However, Vlad II was also faced with the overwhelming military power of the Ottoman Sultan building on the other side of his border,
as such he could not openly support either side of the conflict, lest he be beseiged on all fronts.
Dracul's younger sons, Vlad III and Radu II, were also kept in Murad's court as hostages to keep him from supporting Christian forces.
Not daring to make rash moves, Vlad Dracul had previously allowed the Ottoman bey of Rumelia and his army 
to cross through Wallachia and attack Hunyadi's lands in Transylvania.
Vlad Dracul did not have much faith in the Christians, but in order to maintain neutrality with the Christians after aiding the Turks,
he sent his eldest son Mircea II and a small army of 4,000 men to join the Crusade.
Vlad II knew this choice would be a breach of contract with the Sultan, and would result in the death of his other sons,
but such was the ruthless world of warfare and politics, where country and power were more important than family.
Thankfully, the hostage princes were spared, as the Ottoman Sultan saw value in continuing to use them as pawns.
At the Battle of Varna, John Hunyadi and Wladyslaw III led armies into battle together with Mircea II Dracula.
They fought valiantly. But, a fatal flaw in the execution of battle ultimately led to their failure.
The Pope was supposed to have sent Venetian fleets as backup, which would block Ottoman reinforcements from reaching the Sultan.
However, there had been a failure in communication, and the Ottoman fleets were not intercepted as according to plan.
The European army found themselves facing a far superior size of the Ottoman army than anticipated.
The Christian armies were severely underprepared. Though Hunyadi commanded for the men to fall back, to not chase the Sultan too deep,
King Wladyslaw III of Poland made one last, desperate charge, penetrating deep into the enemy forces in an attempt to capture Sultan Murad.
He was slain, and the Ottomans displayed his head on a pike.
The crusaders suffered an enormous loss that they'd never be able to properly recover from.
Poland would have no king for three years, and the Ottomans had no more major western troops to worry about.
Ottoman expansion extended to the Peloponnese, and set the stage for Mehmed II, the next Sultan and son of Murad II, 
to conquer Constantinople in 1453.
As you can see, military affairs have lasting consequences. Successful campaigns become fuel to greater and greater ambitions.
So pick your battles, and accumulate your victories, until you become great.
->HistoryClassOutro

===NotPayingAttentionChoice===
#CenterExp:0
What would Anxious-chan like to do?
    *(Gossip)[Listen to students in the back gossiping]
        Whispers are abound at the back of the room. The backseaters are exchanging (presumably) valuable information.
        Anxious-chan decided to listen in.
        -> Gossip1 -> 
        -> HistoryClassOutro
    *(Daydream)[Daydream]
        "I think, therefore I am. If I think MORE, then naturally I am MORE." Or something like that.
        Anxious-chan decided to spend the class being absorbed in her own thoughts.
        -> Daydream1 ->
        -> HistoryClassOutro
    *(DozeOff)[Doze off]
        The room is quite warm. Plus, Mr. Dascalu is providing unintentional ASMR. Perfect for a nap.
        Anxious-chan decided to doze off.
        -> DozeOff1 ->
        -> HistoryClassOutro


===HistoryClassOutro===
#Center:HistoryTeacher
#CenterExp:0
#Name:Mr. Dascalu
#Active: Center
And that is where we shall conclude for today. Class dismissed.

{Class2Choice.PayAttention: ->PayingAttentionOutro}
{NotPayingAttentionChoice.Gossip: ->GossipOutro}
{NotPayingAttentionChoice.Daydream: ->DaydreamOutro}
{NotPayingAttentionChoice.DozeOff: ->DozeOffOutro}

->DONE//fallback

===PayingAttentionOutro===
#Center:AnxiousChan
#CenterExp:2
#Active: Center
#Name:NONE
IT'S FINALLY OVER!
Anxious-chan feels that she has built some endurance for lengthy lectures.
#CenterExp:4
Still, she is not confident about remembering anything!
~ ChangeBarValue("HBar", -5)
Her happiness decreases!
#CenterExp:2
Anxious-chan is also still concerned about being perceived as a nerd.
~ ChangeBarValue("ABar", 8)
Her anxiety increases!
That wasn't not so bad...
->END

===GossipOutro===
#Center:AnxiousChan
#CenterExp:0
#Active: Center
#Name:NONE
The class seemed to fly by.
By listening in on the conversation, Anxious-chan thinks she now understands her peers a bit better.
~ ChangeBarValue("SBar", 5)
Her social adjustedness increases!
However, Anxious-chan feels isolated and disillusioned hearing about things she's not apart of.
~ ChangeBarValue("HBar", -5)
Her happiness decreases!
Anxious-chan has mixed feelings about not paying attention to class today.
->END

===DaydreamOutro===
#Center:AnxiousChan
#CenterExp:0
#Active: Center
#Name:NONE
That was a deep, hard, thinking session today. But was it truly worth not paying attention in class for? Who knows!
->END

===DozeOffOutro===
#Center:AnxiousChan
#CenterExp:0
#Active: Center
#Name:NONE
Wow, by dozing off, it's as if she entered a time machine!
Anxious-chan contemplates whether or not it was truly the best use of her time.
#CenterExp:2
...And decides it was not.
~ ChangeBarValue("ABar", 5)
Her anxiety increases!
#CenterExp:4
Anxious-chan regrets falling asleep! 
What if she missed out on something important? She could've been overthinking! Look what you've done!
->END

->END