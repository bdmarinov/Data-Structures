using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

/// <summary>
/// The ThreadExecutor is the concrete implementation of the IScheduler.
/// You can send any class to the judge system as long as it implements
/// the IScheduler interface. The Tests do not contain any <e>Reflection</e>!
/// </summary>
public class ThreadExecutor : IScheduler
{

    Dictionary<int, Task> tasksById;
    List<Task> indexedTasks;
  
    public ThreadExecutor()
    {
        tasksById = new Dictionary<int, Task>();
        indexedTasks = new List<Task>();
        Count = 0;
    }

    public int Count
    {
        get;
        private set;
    }


    public void ChangePriority(int id, Priority newPriority)
    {
        if(!tasksById.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        tasksById[id].TaskPriority = newPriority;
    }

    public bool Contains(Task task)
    {
        return tasksById.ContainsKey(task.Id);
    }

    public int Cycle(int cycles)
    {
        if(tasksById.Count == 0)
        {
            throw new InvalidOperationException();
        }

        int completed = 0;
        foreach(var task in tasksById.Values.ToList())
        {
            if(cycles >= 0)
            {
                task.CurrentConsumption -= cycles;
            }
            if(task.CurrentConsumption <= 0)
            {
                int id = task.Id;
                indexedTasks.Remove(task);
                tasksById.Remove(id);
                completed++;
                Count--;
            }
            
        }
        return completed;
    }

    public void Execute(Task task)
    {
		if(tasksById.ContainsKey(task.Id))
        {
            throw new ArgumentException();
        }
        tasksById.Add(task.Id, task);
        indexedTasks.Add(task);
        Count++;
    }

    public IEnumerable<Task> GetByConsumptionRange(int lo, int hi, bool inclusive)
    {
        /*LinkedList<Task> tasks = new LinkedList<Task>();

        foreach(var task in tasksById)
        {
            if(inclusive == true)
            {
                if(task.Value.Consumption >= lo && task.Value.Consumption <= hi)
                {
                    tasks.AddLast(task.Value);
                }
            }
            else
            {
                if (task.Value.Consumption > lo && task.Value.Consumption < hi)
                {
                    tasks.AddLast(task.Value);
                }
            }
        }
        
        return tasks.OrderByDescending(x => x.TaskPriority).OrderBy(x => x.Consumption);
        */
        if(inclusive == true)
        {
            return tasksById.Values.Where(x => (x.Consumption >= lo && x.Consumption <= hi)).OrderByDescending(x => x.TaskPriority).OrderBy(x => x.Consumption);
        }
        else
        {
            return tasksById.Values.Where(x => (x.Consumption > lo && x.Consumption < hi)).OrderByDescending(x => x.TaskPriority).OrderBy(x => x.Consumption);
        }
    }

    public Task GetById(int id)
    {
        if(!tasksById.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        return tasksById[id];
    }

    public Task GetByIndex(int index)
    {
        if(index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }
        return indexedTasks[index];
    }

    public IEnumerable<Task> GetByPriority(Priority type)
    {
        LinkedList<Task> tasks = new LinkedList<Task>();

        foreach(var task in tasksById)
        {
            if(task.Value.TaskPriority == type)
            {
                tasks.AddLast(task.Value);
            }
        }

        if(tasks.Count == 0)
        {
            return tasks;
        }

        return tasks.OrderByDescending(x => x.Id);
    }

    public IEnumerable<Task> GetByPriorityAndMinimumConsumption(Priority priority, int lo)
    {
        /*LinkedList<Task> tasks = new LinkedList<Task>();

        foreach(var task in tasksById)
        {
            if(task.Value.TaskPriority == priority && task.Value.Consumption >= lo)
            {
                tasks.AddLast(task.Value);
            }
        }
        
       
        return tasks.OrderByDescending(x => x.Id);
        */

        return tasksById.Values.Where(x => (x.TaskPriority == priority && x.Consumption >= lo)).OrderByDescending(x => x.Id);
    }


    public IEnumerator<Task> GetEnumerator()
    {
        foreach(var task in indexedTasks)
        {
            yield return task;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
