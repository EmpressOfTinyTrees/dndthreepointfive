System.Environment.SetEnvironmentVariable("CONFIRM_CRIT", "1");

Console.WriteLine("Rolling 20d6 + 3: " + GameManager.RollDice(20, 6, 3).Total);

class GameManager
{
    public static DiceRoll RollDice(int amount, int sides, int modifier = 0)
    {
        List<int> rolls = [];
        for (int i = 0; i < amount; i++)
        {
            Random random = new();
            int roll = random.Next(1, sides + 1);
            rolls.Add(roll);
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

    /**
     * TODO: (Stuff for later)
     * - has skills and abilities
     * - can do skill and ability checks (1d20 plus mod)
     * - can attack
     * - can do critical hits (crit range)
     * - can take combat actions (standard action plus move action, two move actions, one full-round action)
     * - can have initaitive
     */
}

static class GameConfiguration
{
    public static bool ConfirmCriticalHits()
    {
        return System.Environment.GetEnvironmentVariable("CONFIRM_CRIT") == "1";
    }
}