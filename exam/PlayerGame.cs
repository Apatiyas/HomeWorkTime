using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseCard;
using BattlefieldClass;

namespace PlayerGame
{
    internal class Player
    {
         public const int MAX_MANA = 10;
         public const int MIN_MANA = 0;
        public const int MAX_MANA_SPELLS = 3;
        public const int MIN_MANA_SPELLS = 0;
        public const int MAX_HITPOINT = 20;
        public const int MIN_HITPOINT = 0;
        public const int MAX_DECK = 40;
        public const int MIN_DECK = 0;
        public const int MAX_HAND = 10;
        public const int MIN_HAND = 0;
        public const int MAX_BOARD = 6;
        public const int MIN_BOARD = 0;

        private int _mana;
        private int _manaSpells;
        private int _hitPoints;
        private int _maxMana = 1;

        private List<Card> _cardInDeck = new List<Card>();
        private List<Card> _cardInHand = new List<Card>();
        private List<Entity> _cardInBoard = new List<Entity>();
        private List<Card> _cardGraveyard = new List<Card>();

        public int mana
        {
            get=>_mana;
            set=>_mana = Math.Min(Math.Max(value, MIN_MANA),MAX_MANA); 
        }
        public int manaSpells
        {
            get => _manaSpells;
            set => _manaSpells = Math.Min(Math.Max(value, MIN_MANA_SPELLS), MAX_MANA_SPELLS);
        }
        public int hitPoints
        {
            get => _hitPoints;
            set => _hitPoints = Math.Min(Math.Max(value, MIN_HITPOINT), MAX_HITPOINT);
        }
        public List<Card> cardInDeck => _cardInDeck;  //0-40
        public List<Card> cardInHand => _cardInHand; //0-10
        public  List<Entity> cardInBoard => _cardInBoard; //0-6
        public List<Card> cardGraveyard => _cardGraveyard;
        public Battlefield Field { get; private set; }
        public Player()
        {
            _hitPoints = MAX_HITPOINT;
            _mana = 0;
            _manaSpells = 0;
            _maxMana = 1;
            Field = new Battlefield(this);  
        }

        public void StartTurn()
        {
            if(_maxMana < MAX_MANA)
            {
                _maxMana++;
            }
            mana = _maxMana;
        }
        public void EndTurn()
        {
            manaSpells += mana;
            mana = 0;
        }
        public bool CanPlayCard(Card card)
        {
            if ((mana + manaSpells) >= card.manaCost) {
                return true;
            }

            return false;

        }
        public void SpendManaForCard(Card card)
        {
            if (manaSpells >= card.manaCost)
            {
               manaSpells -= card.manaCost;
            }
            else
            {
                mana = mana - (card.manaCost - manaSpells);
                manaSpells = 0;
            }
        }
        public void DrawCards(int count)
        {
            for (int i = 0; i < count && _cardInDeck.Count > 0; i++)
            {
                if (AddToHand(_cardInDeck[0])) { _cardInDeck.RemoveAt(0); }
                else { break; }
                
            }
        }
        public bool AddToHand(Card card)
        {
            if (_cardInHand.Count < MAX_HAND)
            {
                _cardInHand.Add(card);
                return true;
            }
            return false;
        }
        public bool AddToBoard(Entity entity)
        {
            if(_cardInBoard.Count < MAX_BOARD)
            {
                _cardInBoard.Add(entity);
                return true;
            }
            return false;
        }
        public void RemoveFromBoard(Entity entity)
        {
            _cardInBoard.Remove(entity);
        }
        public void RemoveFromHand(Card card)
        {
            _cardInHand.Remove(card);
        }
        public void AddToGraveyard(Card card)
        {
            _cardGraveyard.Add(card);
        }


    }
}
