// External function definitions
EXTERNAL ChangeBarValue(barName, amount)

// Other function definitions
== function ChangeSBar(amount) ==
~ ChangeBarValue("SBar", amount)

== function ChangeHBar(amount) ==
~ ChangeBarValue("HBar", amount)

== function ChangePBar(amount) ==
~ ChangeBarValue("PBar", amount)

== function ChangeABar(amount) ==
~ ChangeBarValue("ABar", amount)

// Function fallbacks
== function ChangeBarValue(barName, amount)==
~ return