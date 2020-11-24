using System;
using System.Collections;
using System.Collections.Generic;

public class Organization : IOrganization
{
    Dictionary<string, List<Person>> personsByName;
    List<Person> indexedPersons;
    public Organization()
    {
        personsByName = new Dictionary<string, List<Person>>();
        indexedPersons = new List<Person>();
        Count = 0;
    }
    public IEnumerator<Person> GetEnumerator()
    {
        foreach(var person in indexedPersons)
        {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count { get; private set; }
    public bool Contains(Person person)
    {
        //return (personsByName.ContainsKey(person.Name));
        return indexedPersons.Contains(person);
    }

    public bool ContainsByName(string name)
    {
        return (personsByName.ContainsKey(name));
    }

    public void Add(Person person)
    {
        if(!personsByName.ContainsKey(person.Name))
        {
            //!!!
            //personsByName.Add(person.Name, new List<Person>());
            personsByName[person.Name] = new List<Person>();
        }
        personsByName[person.Name].Add(person);
        indexedPersons.Add(person);
        Count++;
    }

    public Person GetAtIndex(int index)
    {
        if(index < 0 || index >= indexedPersons.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return indexedPersons[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        List<Person> people = new List<Person>();

        if(personsByName.ContainsKey(name))
        {
            people = personsByName[name];
        }

        return people;
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        List<Person> people = new List<Person>();

        for(int i = 0; i < count && i < indexedPersons.Count; i++)
        {
            people.Add(indexedPersons[i]);
        }
        return people;
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        List<Person> people = new List<Person>();

        foreach(var person in personsByName)
        {
            if(person.Key.Length >= minLength && person.Key.Length <= maxLength)
            {
                people.AddRange(person.Value);
            }
        }
        return people;
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        List<Person> people = new List<Person>();

        foreach(var person in personsByName)
        {
            if(person.Key.Length == length)
            {
                people.AddRange(person.Value);
            }
        }
        if(people.Count == 0)
        {
            throw new ArgumentException();
        }
        return people;
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        foreach(var person in indexedPersons)
        {
            yield return person;
        }
    }
}