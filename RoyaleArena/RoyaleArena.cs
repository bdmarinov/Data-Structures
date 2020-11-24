using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class RoyaleArena : IArena
{
    Dictionary<int, Battlecard> cardsById;
    //List<Battlecard> indexedCards;
    public RoyaleArena()
    {
        cardsById = new Dictionary<int, Battlecard>();
        //indexedCards = new List<Battlecard>();
        Count = 0;
    }
    public int Count
    {
        get;
        private set;
    }

    public void Add(Battlecard card)
    {
        if(cardsById.ContainsKey(card.Id))
        {
            throw new ArgumentException();
        }
        cardsById[card.Id] = card;
        //indexedCards.Add(card);
        Count++;
    }

    public void ChangeCardType(int id, CardType type)
    {
        if(!cardsById.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        cardsById[id].Type = type;
    }

    public bool Contains(Battlecard card)
    {
        return cardsById.ContainsKey(card.Id);
    }

    public IEnumerable<Battlecard> FindFirstLeastSwag(int n)
    {
        if(n < 0 || n >= cardsById.Count)
        {
            throw new InvalidOperationException();
        }
        //List<Battlecard> battlecards = cardsById.Values.ToList().OrderBy(x => x.Id).OrderBy(x => x.Swag).ToList().GetRange(0,n);
        return cardsById.Values.OrderBy(x => x.Id).OrderBy(x => x.Swag).ToList().GetRange(0,n);
    }

    public IEnumerable<Battlecard> GetAllByNameAndSwag()
    {
        List<Battlecard> battlecards = cardsById.Values.GroupBy(x => x.Name).Select(x => x.OrderByDescending(y => y.Swag).First()).ToList();
        
        return battlecards;
    }

    public IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi)
    {
        /*List<Battlecard> battlecards = new List<Battlecard>();

        foreach(var card in indexedCards)
        {
            if(card.Swag >= lo && card.Swag <= hi)
            {
                battlecards.Add(card);
            }
        }
        return battlecards;
        */
        return cardsById.Values.Where(x => (x.Swag >= lo && x.Swag <= hi)).OrderBy(x => x.Swag);
        //return indexedCards.Where(x => (x.Swag >= lo && x.Swag <= hi));
        
        //List<Battlecard> battlecards = cardsById.Values.ToList().Where(x => x.Swag >= lo).Where(x => x.Swag <= hi).ToList();
        //return battlecards;
    }

    public IEnumerable<Battlecard> GetByCardType(CardType type)
    {
        List < Battlecard > battlecards = cardsById.Values.ToList().Where(x => x.Type == type).OrderBy(x => x.Id).OrderByDescending(x => x.Damage).ToList();
        if(battlecards.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return battlecards;
    }

    public IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
    {
        List <Battlecard> battlecards = cardsById.Values.ToList().Where(x => x.Type == type).Where(x => x.Damage <= damage).OrderBy(x => x.Id).OrderByDescending(x => x.Damage).ToList();
        if(battlecards.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return battlecards;
    }

    public Battlecard GetById(int id)
    {
        if(!cardsById.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        return cardsById[id];
    }

    public IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi)
    {
        //List<Battlecard> battlecards = indexedCards.Where(x => (x.Name == name && (x.Swag >= lo && x.Swag < hi))).OrderBy(x => x.Id).OrderByDescending(x => x.Swag).ToList();
        List<Battlecard> battlecards = cardsById.Values.Where(x => (x.Name == name && (x.Swag >= lo && x.Swag < hi))).OrderBy(x => x.Id).OrderByDescending(x => x.Swag).ToList();

        if (battlecards.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return battlecards;
    }

    public IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name)
    {
        List<Battlecard> battlecards = cardsById.Values.ToList().Where(x => x.Name == name).OrderBy(x => x.Id).OrderByDescending(x => x.Swag).ToList();
        if(battlecards.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return battlecards;
    }

    public IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
    {
        //List<Battlecard> battlecards = indexedCards.Where(x => (x.Type == type && (x.Damage >= lo && x.Damage <= hi))).OrderBy(x => x.Id).OrderByDescending(x => x.Damage).ToList();
        List<Battlecard> battlecards = cardsById.Values.Where(x => (x.Type == type && (x.Damage >= lo && x.Damage <= hi))).OrderBy(x => x.Id).OrderByDescending(x => x.Damage).ToList();

        if (battlecards.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return battlecards;
    }

    public IEnumerator<Battlecard> GetEnumerator()
    {
        //foreach(var card in indexedCards)
        foreach(var card in cardsById)
        {
            //yield return card;
            yield return card.Value;
        }
    }

    public void RemoveById(int id)
    {
        if(!cardsById.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        Count--;
        //indexedCards.Remove(cardsById[id]);
        cardsById.Remove(id);      
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
