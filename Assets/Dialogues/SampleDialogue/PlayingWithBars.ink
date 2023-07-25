-> Test
EXTERNAL ChangeBarValue(barName, amount)

= Test

#Center: AnxiousChan
#CenterExp:0
#Name: Anxious Chan
Urk urk.
I hear choices will now have consequences.
Makes me, er, anxious.
~ ChangeBarValue("ABar", 5)

#CenterExp:2
Oof. The bars are already rising, even though nothing happened yet.
~ ChangeBarValue("ABar", 5)

#CenterExp:2
Ok, ok, deep breaths, pleasant thoughts. Whew.
I can do this I can do this.
... Maybe.
-> END


== function ChangeBarValue(barName, amount)==
~ return
