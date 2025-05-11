System.Environment.SetEnvironmentVariable("CONFIRM_CRIT", "1");

Console.WriteLine("Rolling 4d6: " + GameManager.RollDice(4, 6, 0, true).Total);

class GameManager
{
    public static DiceRoll RollDice(int amount, int sides, int modifier = 0, bool discardLowest = false)
    {
        List<int> rolls = [];
        for (int i = 0; i < amount; i++)
        {
            Random random = new();
            int roll = random.Next(1, sides + 1);
            Console.WriteLine($"Rolled {roll}");
            rolls.Add(roll);
        }

        if (discardLowest)
        {
            rolls.Sort();
            rolls.RemoveAt(0);
        }

        return new DiceRoll(rolls.Sum() + modifier, rolls);
    }
}

class DiceRoll(int total, List<int> rolls)
{
    public int Total { get; set; } = total;
    public List<int> Rolls { get; set; } = rolls;
}

class Character
{
    public int HitPoints { get; set; } = 0;

    public int Strength { get; set; } = 0;

    public int Dexterity { get; set; } = 0;

    public int Constitution { get; set; } = 0;

    public int Intelligence { get; set; } = 0;

    public int Wisdom { get; set; } = 0;

    public int Charisma { get; set; } = 0;

    public int StrengthModifier { get; set; } = 0;

    public int DexterityModifier { get; set; } = 0;

    public int ConstitutionModifier { get; set; } = 0;

    public int IntelligenceModifier { get; set; } = 0;

    public int WisdomModifier { get; set; } = 0;

    public int CharismaModifier { get; set; } = 0;

    /**
     * TODO: (Stuff for later)
     * - has skills
     * - can do skill and ability checks (1d20 plus mod)
     * - can attack
     * - can do critical hits (crit range)
     * - can take combat actions (standard action plus move action, two move actions, one full-round action)
     * - can have initaitive roll
     */
}

class CharacterBuilder
{
    public Character Character { get; set; } = new Character();

    private readonly List<int> _abilityScores = [];

    public void GetAbilityScores()
    {
        _abilityScores.Clear();

        for (int i = 0; i < 6; i++)
        {
            _abilityScores.Add(GameManager.RollDice(4, 6, discardLowest:true).Total);
        }
    }

    public void AssignAbilityScores()
    {
        if (_abilityScores.Count != 6)
        {
            this.GetAbilityScores();
        }

        
    }

    //chose class

    //choose race

    //assign ability scores

    //calculate modifiers

    //get the starting package (optional)

    //ratial and class features

    //select skills

    //select feats

    //description

    //equipment package or starting gold

    //hp => hit die (first one is always max) + con mod

    //armor class = 10 + armor bonus + dex mod + shield bonus + size mod

    //initiative = dex mod

    //melee attack bonus = strength mod + base attack bonus

    //ranged attack bonus = dex mod + base attack bonus

    //fortitude save = base save + con mod

    //reflex save = base save + dex mod

    //will save = base save + wis mod

    //more details (name, gender, etc.)

    //bonus spells by level (determined by character class)
}

static class GameConfiguration
{
    public static bool ConfirmCriticalHits()
    {
        return System.Environment.GetEnvironmentVariable("CONFIRM_CRIT") == "1";
    }
}