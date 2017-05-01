using QuestWar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject.Models
{
    public enum BattleResult
    {
        Continue,
        Win,
        Lose,
        Run
    }

    public class Battle
    {
        #region fields
        private Adventurer Player { get; set; }
        private List<Monster> Targets { get; set; }
        private int GainedExperience { get; set; }
        private int GainedGold { get; set; }
        #endregion

        #region private methods
        private void ShowStatus()
        {
            Console.WriteLine("Your health is at {0} Points, your mana is at {1} Points", Player.HP, Player.MP);
            Console.WriteLine();
            for (int i = 0; i < Targets.Count; i++)
            {
                Console.WriteLine("The {0} ({1})'s health is at {2} points", Targets[i].Name, i + 1, Targets[i].HP);
            }
        }

        private BattleResult GetResult()
        {
            if (Player.HP <= 0)
            {
                return BattleResult.Lose;
            }
            if (!Targets.Any() || Targets.All(t => t.HP <= 0))
            {
                return BattleResult.Win;
            }
            return BattleResult.Continue;
        }

        private int ChooseAttackType()
        {
            int result = -1;
            while (result == -1)
            {
                Console.WriteLine("Enter the number for the type of attack that you wish to perform:");
                Console.WriteLine("1. One Handed Attack");
                Console.WriteLine("2. Two Handed Attack");
                Console.WriteLine("3. Ranged Weapon Attack");
                Console.WriteLine("4. Magical Attack");
                Console.WriteLine("5. Run");
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result < 1 || result > 5)
                    {
                        result = -1;
                    }
                }
            }
            Console.WriteLine();
            return result;
        }

        private int SelectTarget()
        {
            int result = -1;
            while (result == -1)
            {
                Console.WriteLine("Choose your target...");
                for (int i = 0; i < Targets.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, Targets[i].Name);
                }
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result < 1 || result > Targets.Count)
                    {
                        Console.WriteLine("Please choose a valid target.");
                        result = -1;
                    }
                }
            }
            Console.WriteLine();
            return result;
        }

        private int PerformAttack(int attackType)
        {
            int damage = 0;
            if (attackType == 1)
            {
                Random Damage_Roll = new Random();
                int Random_Damage_Roll = Damage_Roll.Next(0, Player.OneHandedWeaponDamage);
                Random Skill_Point_Roll = new Random();
                int Skill_Point_Outcome = Skill_Point_Roll.Next(0, 11);
                if (Skill_Point_Outcome > 6 && Random_Damage_Roll > 0)
                {
                    Random_Damage_Roll = Random_Damage_Roll + Player.OneHandedWeaponSkill;
                    Console.WriteLine("You did a critical hit, and added {0} Skill points of damage", Player.OneHandedWeaponSkill);
                }
                damage = Random_Damage_Roll;
            }
            if (attackType == 2)
            {
                Random Damage_Roll = new Random();
                int Random_Damage_Roll = Damage_Roll.Next(0, Player.TwoHandedWeaponDamage);
                Random Skill_Point_Roll = new Random();
                int Skill_Point_Outcome = Skill_Point_Roll.Next(0, 11);
                if (Skill_Point_Outcome > 6 && Random_Damage_Roll > 0)
                {
                    Random_Damage_Roll = Random_Damage_Roll + Player.TwoHandedWeaponSkill;
                    Console.WriteLine("You did a critical hit, and added {0} Skill points of damage", Player.TwoHandedWeaponSkill);
                }
                damage = Random_Damage_Roll;
            }
            if (attackType == 3)
            {
                Random Damage_Roll = new Random();
                int Random_Damage_Roll = Damage_Roll.Next(0, Player.RangedWeaponDamage);
                Random Skill_Point_Roll = new Random();
                int Skill_Point_Outcome = Skill_Point_Roll.Next(0, 11);
                if (Skill_Point_Outcome > 6 && Random_Damage_Roll > 0)
                {
                    Random_Damage_Roll = Random_Damage_Roll + Player.RangedWeaponSkill;
                    Console.WriteLine("You did a critical hit, and added {0} Skill points of damage", Player.RangedWeaponSkill);
                }
                damage = Random_Damage_Roll;
            }
            if (attackType == 4)
            {
                Random Damage_Roll = new Random();
                int Random_Damage_Roll = Damage_Roll.Next(0, Player.MagicDamage);
                Random Skill_Point_Roll = new Random();
                int Skill_Point_Outcome = Skill_Point_Roll.Next(0, 11);
                if (Skill_Point_Outcome > 6 && Random_Damage_Roll > 0)
                {
                    Random_Damage_Roll = Random_Damage_Roll + Player.MagicSkill;
                    Console.WriteLine("You did a critical hit, and added {0} Skill points of damage", Player.MagicSkill);
                }
                damage = Random_Damage_Roll;
                Player.MP -= 1;
            }
            if (damage <= 0)
            {
                damage = 1; //Player always does 1 damage.
            }
            Console.WriteLine();
            return damage;
        }

        private void ProcessPlayerAttackOnMonster(int damageDone, int targetIdx)
        {
            var target = Targets[targetIdx];
            Console.WriteLine("You did {0} damage to the {1} ({2})", damageDone, target.Name, targetIdx + 1);
            target.HP -= damageDone;
            if (target.HP <= 0)
            {
                Console.WriteLine("You killed the {0} ({1})", target.Name, targetIdx + 1);
                GainedExperience += target.ExpGained;
                GainedGold += target.Gold;
                Targets.RemoveAt(targetIdx);
            }
        }
        #endregion

        public Battle(Adventurer player, List<Monster> targets)
        {
            Player = player;
            Targets = targets;
        }

        public BattleResult Start()
        {
            var result = GetResult();
            while (result == BattleResult.Continue)
            {
                Console.Clear();
                ShowStatus();
                int targetIndex = SelectTarget() - 1;
                int playerAttackType = ChooseAttackType();
                if (playerAttackType == 5)
                {
                    Random runChance = new Random();
                    if (runChance.Next(1, 4) >= 3)
                    {
                        result = BattleResult.Run;
                        Console.WriteLine("You successfully escaped!");
                        break;
                    }
                    Console.WriteLine("You failed to escape!");
                }
                else
                {
                    int playerDamage = PerformAttack(playerAttackType);
                    ProcessPlayerAttackOnMonster(playerDamage, targetIndex);
                    result = GetResult();
                    if (result == BattleResult.Win)
                    {
                        break;
                    }
                }
                foreach (var monster in Targets)
                {
                    Random Enemy_Damage_Roll = new Random();
                    int Random_Enemy_Damage_Roll = Enemy_Damage_Roll.Next(0, monster.MaxAttack);
                    Console.WriteLine("The {0} Strikes back, and deal {1} Points of Damage", monster.Name, Random_Enemy_Damage_Roll);
                    Player.HP -= Random_Enemy_Damage_Roll;
                }
                if (Player.HP <= 0)
                {
                    result = BattleResult.Lose;
                    break;
                }
                Console.WriteLine("The Battle Rages On!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            if (result == BattleResult.Win)
            {
                Console.WriteLine();
                Console.WriteLine("You gained {0} experience points and {1} gold!", GainedExperience, GainedGold);
                Player.ExperiencePoints += GainedExperience;
                Player.TotalMoney += GainedGold;
            }
            if (result == BattleResult.Lose)
            {
                Console.WriteLine();
                Console.WriteLine("You have died...");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit the battle...");
            Console.ReadKey();
            return result;
        }
    }
}
