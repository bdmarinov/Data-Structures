using System;
using System.Collections.Generic;
using System.Linq;

public class Judge : IJudge
{
    Dictionary<int, Submission> submissionsById;
    //Dictionary<int, int> usersById;
    //Dictionary<int, int> contestsById;
    SortedSet<int> usersById;
    SortedSet<int> contestsById;
    public Judge()
    {
        submissionsById = new Dictionary<int, Submission>();
        usersById = new SortedSet<int>();
        contestsById = new SortedSet<int>();
    }
    public void AddContest(int contestId)
    {
        if(!contestsById.Contains(contestId))
        {
            contestsById.Add(contestId);  
        }
    }

    public void AddSubmission(Submission submission)
    {
        if(!contestsById.Contains(submission.ContestId) || !usersById.Contains(submission.UserId))
        {
            throw new InvalidOperationException();
        }
        if(!submissionsById.ContainsKey(submission.Id))
        {
            submissionsById.Add(submission.Id, submission);
            //throw new InvalidOperationException();
        } 
    }

    public void AddUser(int userId)
    {
        if(!usersById.Contains(userId))
        {
            usersById.Add(userId);
        }
    }

    public void DeleteSubmission(int submissionId)
    {
        if(!submissionsById.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }
        submissionsById.Remove(submissionId);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return submissionsById.Values.OrderBy(x => x.Id);
    }

    public IEnumerable<int> GetUsers()
    {
        return usersById;
    }

    public IEnumerable<int> GetContests()
    {
        return contestsById;
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        return submissionsById.Values.Where(x => x.Type == submissionType && (x.Points >= minPoints && x.Points <= maxPoints));
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        return submissionsById.Values.Where(x => x.UserId == userId).GroupBy(x => x.ContestId).Select(x => x.OrderByDescending(s => s.Points).ThenBy(s => s.Id).First()).OrderByDescending(x => x.Points).ThenBy(x => x.Id).Select(x => x.ContestId);
        //return submissionsById.Values.Where(x => x.UserId == userId).OrderBy(x => x.Id).OrderByDescending(x => x.Points).Select(x => x.ContestId);
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {

        List<Submission> submissions = submissionsById.Values.Where(x => (x.Points == points && x.ContestId == contestId && x.UserId == userId)).ToList();
        if(submissions.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return submissions;
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        return submissionsById.Values.Where(x => x.Type == submissionType).Select(x => x.ContestId);
    }
}
