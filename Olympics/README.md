Olympics

You have to implement a structure that keeps track of the Olympic scores in Tokyo 2020. Your structure will have to support the following functionalities:
+	AddCompetitor(competitorName, competitorId) – you have to register a new competitor. If there is already a competitor with that id, return ArgumentException
+	AddCompetition(compoetitionName, competitionId, score) – you have to register a new competition. If there is already a competition with that id, return ArgumentException 
+	Compete(competitorId, competitionId, score) – search for the given competitor and the given competition and add the competitor with his score to the given competition. 
If there are no such competitor or competition throw ArgumentException
+	Disqualify(competitionId, competitorId) – search for the given competitor in the given competition and remove him from the competition. Reduce the competitor's total points by the amount he lost by being disqualified. 
If there are no such competitor or competition throw ArgumentException 
+	GetByName(name) – return all competitors with the provided name ordered by their id’s. If there is no competitor with the given name return ArgumentException
+	FindCompetitorsInRange(start, end) – find all competitors which have total score between the given start exclusive and end inclusive.
+	SearchWithNameSize(int, int) – Returns all competitions that have name lengths between the 2 parameters inclusive and order them by id. If there aren’t any return empty collection.
+	Contains(competitionId, Competitor) – Checks if a competitor is present in the competition.
+	GetCompetition(id) – return the competition with the given id. If there is no such throw AgumentException 
+	CompetitorsCount() – return count of registered competitors
+	CompetitionsCount() – return count of competitions

Feel free to override Equals() and GetHashCode() if necessary.
