using System.
    Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blockButton;
    public GameObject attackButton;
    public GameObject gameText;
    public string name;
    public TitleScreenManager TitleManager;
    Player p1;
    Entity currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        blockButton = GameObject.Find("Block Button");
        attackButton = GameObject.Find("Attack Button");
        gameText = GameObject.Find("Game Manager/Canvas/Game Text");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        gameText.SetActive(true);
        name = TitleManager.name;
        p1 = new Player(name, 20, 8);
        NewEntity();
    }
    public void NewEntity()
    {
        int random = Random.Range(0, 10);
        currentEnemy = new Entity(random);
        gameText.GetComponent<TMPro.TextMeshProUGUI>().text = name + " comes across an enemy "+currentEnemy.GetName()+ " in the woods.\n Your HP: "+ p1.GetHp()+ "\nEnemy HP: " + currentEnemy.GetHp() + "\nEnemy Attack Damage: " + currentEnemy.GetDamage()+"\nStreak: "+p1.GetStreak();
    }
    public void ClickBlock()
    {
            p1.Block(currentEnemy);
        currentEnemy.IncrementTurn(p1);
        CheckHealth();
    }
    public void ClickAttack()
    {
        currentEnemy.IncrementTurn(p1);
            p1.Attack(currentEnemy);
        CheckHealth();
    }
    public void CheckHealth()
    {
        gameText.GetComponent<TMPro.TextMeshProUGUI>().text = name + " comes across an enemy " + currentEnemy.GetName() + " in the woods.\n Your HP: " + p1.GetHp() + "\nEnemy HP: " + currentEnemy.GetHp() + "\nEnemy Attack Damage: " + currentEnemy.GetDamage()+ "\nStreak: " + p1.GetStreak();
        if (p1.GetHp() <= 0)
        {
            EndGame();
        }
        else
        {
            if (currentEnemy.GetHp() <= 0)
            {
                NewEntity();
                p1.IncreaseStreak();
            }
        }
    }
        public void EndGame()
        {
        gameText.GetComponent<TMPro.TextMeshProUGUI>().text = p1.GetName() + " met their fate after conquering " + p1.GetStreak() + " enemies.";
        blockButton.SetActive(false);
        attackButton.SetActive(false);
        }

    public class Entity
    {
        private int hp;
        private string entityName;
        private int damage;
        private int entityType;
        private int numTurns;

        public Entity(int type)
        {
            entityType = type;
            hp = 4 * entityType;
            if (hp == 0)
            {
                hp = 1;
            }
            damage = entityType;
            if (entityType == 0)
            {
                entityName = "Harmless Critter";
                numTurns = 1;

            }
            if (entityType < 5)
            {
                entityName = "Creature";
                numTurns = 3;
            }
            if (entityType >= 5)
            {
                entityName = "Human";
                numTurns = 1;
            }

        }
        public Entity(string name, int health, int dmg)
        {
            entityType = -1;
            hp = health;
            damage = dmg;
            numTurns = 1;
            entityName = name;
        }
            public int GetHp()
            {
                return hp;
            }
            public int GetDamage()
            {
                return damage;
            }
            public string GetName()
            {
                return entityName;
            }
        public int GetNumTurns()
        {
            return numTurns;
        }
        public void SetHealth(int newHp)
        {
            hp = newHp;
        }
        public void SetAttack(int newAttack)
        {
            damage = newAttack;
        }
        public void IncrementTurn(Entity a)
        {
            if (numTurns > 0)
            {
                numTurns--;
            }
            else
            {
                this.Attack(a);
                if (entityType < 5)
                {
                    numTurns = 3;
                }
                else
                {
                    numTurns = 1;
                }
            }
        }
                public void Attack(Entity a)
                {
            a.SetHealth(a.GetHp() - damage);
                }

            }
    public class Player : Entity
    {
        int streak;
        public Player(string name, int health, int dmg) :base(name, health, dmg)
        {
            streak = 0;
        }
        public void IncreaseStreak()
        {
            streak++;
        }
        public int GetStreak()
        {
            return streak;
        }
        public void Block(Entity a)
        {
            if (a.GetNumTurns() == 0)
            {
                this.SetHealth(this.GetHp() + a.GetDamage());
            }
        }
    }
        }
