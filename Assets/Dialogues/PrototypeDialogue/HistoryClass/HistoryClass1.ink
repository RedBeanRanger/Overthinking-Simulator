INCLUDE ExternalFunctions.ink
INCLUDE Gossip1.ink
INCLUDE Daydream1.ink
INCLUDE DozeOff1.ink

-> Class1Intro
===Class1Intro===
#Center:NONE
#Name:NONE
The first class today is history.

#Center:HistoryTeacher
#CenterExp:0
#Active: Center
This is the history teacher, Mircea Dascalu.
Mr. Dascalu is notorious for giving incredibly long lectures with no student interaction.
In his words: "How could you trust children to govern themselves, when not even adults could be trusted to do so?"
"The weak and foolish will always question the authority if given the opportunity. Therefore, the authority must not provide opportunity."

#Center:AnxiousChan
#CenterExp:0
#Active: Center
#Name:NONE
Knowing the teacher's reputation, Anxious-chan seriously doubts she can concentrate in class.
What should Anxious-chan do?

    * (PayAttention)[Pay attention]
        Anxious-chan decided to steel her nerves and listen to the class.
        -> Class1
    * [Don't pay attention]
        -> NotPayingAttention


=== Class1 ===

#Center:HistoryTeacher
#CenterExp:0
#Name:Mr. Dascalu
#Active: Center
Good morning. Class has begun.
We will be continuing our discussion of the crusades from last time.
This week, we will be discussing the Crusade of Varna.
The Crusade of Varna occurred during 1443-1444, prompted by Ottoman expansion into central Europe.
Much like the other crusades, it was ultimately a failure.
Before we get into the details, we shall examine the context of the situation.
In 1443-1444, Europe was in the middle of the Renaissance.
This was a time of cultural, intellectual, and economic flourishing, and advancement towards modernity.
Anyway. This was also a time of moral indifference towards the Ottoman conquest occuring at the eastern European front.
Prior to the Crusade of Varna, the western powers had failed to defend their eastern territories to such a large degree 
that the Ottoman Sultan, Murad II, was able to bring his Turkish forces all the way into the Balkans.
Originally, the catholic church had planned for a crusade long before 1443.
However, the papacy controlling Rome was severely weakened at the time after experiencing the Papal Schism, 
which was a conflict where two popes vied for supremacy.
Having lost influence in Europe, the papacy had no means to rally the major European powers to participate in crusades.
So it fell to the eastern European kingdoms, states and free cities to defend themselves, mostly unsuccessfully, from the Ottomans.
The other major European powers were also too busy being engrossed in their own ventures to participate in crusading.
In France, Charles the VII and Louis XI were fighting with the dukes of Burgundy for supremacy over France.
England was teetering on the edge of civil war because of the houses of York and Lancaster.
Spain and Portugal were busy sailing westward for expansion and discovery.
Only the Catalan Company of Aragon of the Kingdom of Spain engaged in crusades, as Aragon faced eastward.
The Holy Roman Empire encompassed hundreds of tiny kingdoms, states, free cities in the Germanies, and was most directly 
affected by the Ottoman threat.
Yet, the Empire didn't take substantial action to oppose the Ottomans before Sigismund of Luxembourg was crowned emperor.
Thus, we can see the importance of strong governing body in regards to military affairs.
Truly, you cannot count on other nations to protect your country's borders for you.
-> HistoryClassOutro


===NotPayingAttention===
Anxious-chan decided not to pay attention.
#CenterExp:1
Indeed, there are other things you can do in class if you do not pay attention.

-> NotPayingAttentionChoice


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

{Class1Intro.PayAttention: ->PayingAttentionOutro}
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
What kind of a monster lecture was that!?
#CenterExp:4
Anxious-chan is almost certain she won't remember anything for the finals!
~ ChangeBarValue("HBar", -10)
Her happiness decreases!
#CenterExp:2
And what if the other kids noticed she listened for the whole class? Wouldn't they think she is a nerd??
~ ChangeBarValue("ABar", 15)
Her anxiety increases!
Anxious-chan regrets paying attention!!
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

