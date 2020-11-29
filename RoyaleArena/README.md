Royale Arena

You have been invited by the blue king himself. He is in a huge need for an application to help him fight in the glorious Royale Arena. As one of the top players on the arena, he has a reputation to maintain, therefore he cannot afford to lose. The application must be able to keep and query all the cards that exist within the game. Each card has its own specifics. The trick is that the intervals between the battles are so small, that the application must be fast in order to help the king.
Battlecard will hold:
+	int Id – unique card id
+	CardType Type – enumeration of battlecard
+	string Name – the name of the card
+	int Damage – the damage of the card
+	int Swag – the swag of the card

You need to support the following operations (and they should be fast):
+	Add() – Add a battle card to the arena. You will need to implement the Contains() methods as well.
+	Contains(Battlecard) – checks if a given battlecard is present in the arena.
+	Count – returns the number of cards in the arena
+	ChangeCardType(id, type) – changes the status of the battlecard with the given id or throws ArgumentException if no such card exists. 
+	GetById(id) – return the card with the given id. If such card doesn't exist, throw InvalidOperationException.
+	RemoveById(id) – Removes the card with the given id, otherwise throws InvalidOperationException
+	GetByCardType(type) – Returns the cards with the given card type ordered by damage descending then by id. If there are no cards with the given type, throw InvalidOperationException
+	GetByTypeAndDamageRangeOrderedByDamageThenById(type, lo, hi) – returns all cards with particular card type ordered by damage descending (exclusive), then by id ascending. If there are no such types throw InvalidOperationException
+	GetByCardTypeAndMaximumDamage(type, damage) – returns all cards with given type and damage less or equal to a maximum allowed amount ordered by damage descending, then by id. Throws an InvalidOperationException if such cards were not found.
+	GetByNameOrderedBySwagDescending(name) – search for all cards with a specific name and return them ordered by swag descending then by id. If there are no such cards throw InvalidOperationException
+	GetByNameAndSwagRange(name, lo, hi) – returns all cards with given name and swag between lo (inclusive) and hi (exclusive) ordered by swag descending then by id. If there are no such cards throw InvalidOperationException.
GetAllByNameAndSwag() – Returns the most swaggish card for each name. Throws InvalidOperationException/IllegalOperationException if none were found
+	FindFirstLeastSwag(n) – Returns the first n cards with least swag. If there are two identical swags, order by id. If the argument passed exceeds the count of the arena, 
Throw InvalidOperationException/IllegalOperationException
+	GetAllInSwagRange(lo, hi) – returns all cards within a range ordered by swag(the range is inclusive). Returns an empty collection if no such cards were found.
+	GetEnumerator() – Iterate the arena by insertion order 
