using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Weapons
{
    public class Weapon
    {

        // Base damage dealt by this type of weapon
        protected int Base_Damage { get; set; }

        // Chance to crit (0.0 - 1.0)
        protected float Base_CritChance { get; set; }

        // Percentage of armor to ignore (0.0 - 1.0)
        protected float Base_ArmorPierce { get; set; }

        public void AttackWithThisWeapon(Pal attacker, Pal defender)
        {

            TypesOfHit typeOfHit = Calculate_TypeOfHit();
            float DamageBeforeArmor = Calculate_DamageBeforeArmor(Base_Damage, typeOfHit);
            float ArmorReductionAmnt = Calculate_ArmorReductionAmnt(DamageBeforeArmor);
            float armorReduc_AfterPiercing = Apply_ArmorPiercing(ArmorReductionAmnt);
            float finalDamage = Calculate_FinalDamage(DamageBeforeArmor, armorReduc_AfterPiercing);

            Apply_FinalDamageToDefender(defender, (int)finalDamage);



            //_______________________________
            // --- INTERNAL FUNCTIONS ---


            // Get type of hit : | Critical Hit | Normal Hit | Glancing Hit | Miss |
            TypesOfHit Calculate_TypeOfHit()
            {

                // Int diff in speed stats
                int speedDiff = attacker.Speed - defender.Speed;

                // Each point of speed difference changes chance to hit by 10% (higher chance to hit if attacker is faster, lower chance if defender is faster)

                float hitThreshold = (float)(1 + (speedDiff * .1));
                float hitChanceRoll = (float)(myRand.Next(0, 101) / 100);



                if (hitThreshold >= hitChanceRoll)
                {
                    // Crit or Standard Hit
                    if ((float)(myRand.Next(1, 101) / 100) > (1 - Base_CritChance))
                    { return TypesOfHit.Critical; }
                    else { return TypesOfHit.Standard; }
                }
                else
                {
                    // Glancing Blow or Complete Miss
                    if (hitThreshold - hitChanceRoll > .2f)
                    { return TypesOfHit.Glancing; }
                    else { return TypesOfHit.Miss; }
                }
            }

            // Get the damage of the hit, if any, before considering armor
            float Calculate_DamageBeforeArmor(int _BaseDamage, TypesOfHit _typeOfHit)
            {
                switch (_typeOfHit)
                {
                    case TypesOfHit.Miss:
                        return 0;

                    case TypesOfHit.Glancing:
                        return (float)(_BaseDamage * .2);

                    case TypesOfHit.Critical:
                        return (_BaseDamage * 1.5f);

                    case TypesOfHit.Standard:
                    default:
                        return _BaseDamage;
                }
            }

            // Amount of damage the defender's armor will reduce
            float Calculate_ArmorReductionAmnt(float _DamageBeforeArmor)
            {
                float returnAmount = defender.Get_Armor_DamageReductionAmnt(_DamageBeforeArmor);
                if (returnAmount >= 0)
                { return returnAmount; }
                else { return 0; }
            }

            // Apply armor piercing to the reduction amount
            float Apply_ArmorPiercing(float _ArmorReductionAmnt)
            {
                float returnAmount = _ArmorReductionAmnt * (1 - Base_ArmorPierce);
                if (returnAmount >= 0)
                { return returnAmount; }
                else { return 0; }
            }

            // Calculate the damage including reduction from armor, etc.
            int Calculate_FinalDamage(float _Base_Damage, float _ArmorReductionAmnt)
            {
                float returnAmount = _Base_Damage - _ArmorReductionAmnt;
                if (returnAmount >= 1)
                { return (int)returnAmount; }
                else { return 1; }
            }

            // Apply the final damage to the target
            void Apply_FinalDamageToDefender(Pal _defender, int _finalDamage)
            {
                _defender.ReduceHealth(_finalDamage);
            }
        }
        enum TypesOfHit
        {
            Critical,
            Standard,
            Glancing,
            Miss
        }

        readonly Random myRand = new Random();

        enum WeaponTypes
        {
            Unarmed,
            Sword,
            Axe,
            Hammer
        }
    }
}
