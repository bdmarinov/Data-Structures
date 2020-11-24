using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Board : IBoard
{
    Dictionary<string, Card> cardsByName;
    List<Card> dead;
    int count;
    public Board()
    {
        cardsByName = new Dictionary<string, Card>();
        dead = new List<Card>();
        count = 0;
    }
    public bool Contains(string name)
    {
        return cardsByName.ContainsKey(name);
    }

    public int Count()
    {
        return count;
    }

    public void Draw(Card card)
    {
        if(cardsByName.ContainsKey(card.Name))
        {
            throw new ArgumentException();
        }
        cardsByName.Add(card.Name, card);
        count++;
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        return cardsByName.Values.Where(x => (x.Score >= start && x.Score <= end)).OrderByDescending(x => x.Level);
    }

    public void Heal(int health)
    {
        int min = cardsByName.Values.Min(x => x.Health);
        List<Card> worst = cardsByName.Values.Where(x => x.Health == min).ToList();
        foreach(var card in worst)
        {
            cardsByName[card.Name].Health += health;
        }
    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        //return cardsByName.Values.Where(x => x.Name.StartsWith(prefix)).OrderBy(x => x.Level).OrderBy(x => x.Name.ToCharArray().Reverse().ToArray());
        return cardsByName.Values.Where(v => v.Name.StartsWith(prefix)).OrderBy(v => new string(v.Name.ToCharArray().Reverse().ToArray())).ThenBy(v => v.Level);  
    }

    public void Play(string attackerCardName, string attackedCardName)
    {
        if(!cardsByName.ContainsKey(attackerCardName) || !cardsByName.ContainsKey(attackedCardName) || (cardsByName[attackerCardName].Level != cardsByName[attackedCardName].Level))
        {
            throw new ArgumentException();
        }
        if(cardsByName[attackerCardName].Health <= 0 || cardsByName[attackedCardName]. Health <= 0)
        {
            return;
        }
        cardsByName[attackedCardName].Health -= cardsByName[attackerCardName].Damage;
        if(cardsByName[attackedCardName].Health <= 0)
        {
            cardsByName[attackerCardName].Score += cardsByName[attackedCardName].Level;
        }
    }

    public void Remove(string name)
    {
        if(!cardsByName.ContainsKey(name))
        {
            throw new ArgumentException();
        }
        cardsByName.Remove(name);
        count--;
    }

    public void RemoveDeath()
    {
        var dead = cardsByName.Values.Where(x => x.Health <= 0).ToList();
        foreach(var card in dead)
        {
            cardsByName.Remove(card.Name);
            count--;
        }
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        return cardsByName.Values.Where(x => x.Level == level).OrderByDescending(x => x.Score);
    }
}