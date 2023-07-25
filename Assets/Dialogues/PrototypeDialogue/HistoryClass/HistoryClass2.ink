INCLUDE ExternalFunctions.ink
INCLUDE Gossip1.ink
INCLUDE Daydream1.ink
INCLUDE DozeOff1.ink

-> Class2Intro

===Class2Intro===
#Center:HistoryTeacher
#CenterExp:0
#Name:Mr. Dascalu
#Active: Center
Good afternoon.
Before we begin, I would like to explain some things.
Normally, you would not have two history lessons in a day. That being said, you may be wondering why you are today.
As it turns out, the only teacher who showed up today is myself.
The other teachers heard that this is "just a prototype", so decided it would be fine to not show up.
In fact, the entire science department resigned upon hearing about this news. 
"What kind of school has a prototype day?" They even speculated this was all a massive simulation. 
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
Last time, I described the Holy Roman Empire as being ineffective in its defense against the Ottomans.
Indeed, the Ottoman made wave after wave of successful attacks against the Germanies.
The past emperors of the Holy Roman Empire always failed to unite the Empire's feudal leaders together to fight back.
This was largely because the emperors of the Holy Roman Empire were selected by a committee of feudal leaders within the Empire.
The committee had incentive to pick weak emperors, as weaker candidates left the feudal lords in the committee with vast amounts 
of power and freedom to do whatever they fancied.
King Sigismund, however, was an exception.
He was a man of great vision, and saw the need for reforms in the Empire and the Church.
He became a force of resistance against the Ottoman invasion.
Even if partly compelled by geographic location, he did more than his predecessors and his peers in terms of territory defense.
He founded the Order of the Dragon, a crusading order for select high aristocracy and monarchs.
A side note, one of the members of the Order of the Dragon was Vlad II, voivode of Wallachia, named Dracul in honor of his membership.
Vlad II, in fact, was a hostage prince raised at King Sigismund's court, in order to keep his country Wallachia, 
which sat at the entry point to Europe for the Ottomans, loyal to the Holy Roman Empire.
You may be familiar with the name "Dracula", meaning "son of Dracul", which the sons of Vlad II were referred to as.
Anyway. Despite knowing the importance of holding his borders, King Sigismund could only delay the Turkish advance.
His crusades were also unsuccessful, but at least he attempted them.
When King Sigismund died in 1437, Sultan Murad II took the opportunity to intensify attacks in the years after.
Thus, our stage is set for the Crusade of Varna of 1443.
So, as you can see, geographic location is often an important factor in understanding events of the world.
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
Perhaps you'll keep that lesson in mind as we conclude for today. Class dismissed.

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
That was a deep, hard, thinking session today. But was it truly worth not paying attention in class for?
Anxious-chan is not sure what to make of it.
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
Anxious-chan regrets falling asleep! She could've been spending all that time overthinking! Look what you've done!
->END

->END