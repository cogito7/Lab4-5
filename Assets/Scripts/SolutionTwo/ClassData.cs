using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassData : MonoBehaviour
{
    public int AssignHitDie(string className, int hitDie)
    {
        switch (className)
        {
            case ("Artificer"):
                hitDie = Artificer.hitDie;
                break;
            case ("Barbarian"):
                hitDie = Barbarian.hitDie;
                break;
            case ("Bard"):
                hitDie = Bard.hitDie;
                break;
            case ("Cleric"):
                hitDie = Cleric.hitDie;
                break;
            case ("Druid"):
                hitDie = Druid.hitDie;
                break;
            case ("Fighter"):
                hitDie = Fighter.hitDie;
                break;
            case ("Monk"):
                hitDie = Monk.hitDie;
                break;
            case ("Ranger"):
                hitDie = Ranger.hitDie;
                break;
            case ("Rogue"):
                hitDie = Rogue.hitDie;
                break;
            case ("Paladin"):
                hitDie = Paladin.hitDie;
                break;
            case ("Sorcerer"):
                hitDie = Sorcerer.hitDie;
                break;
            case ("Wizard"):
                hitDie = Wizard.hitDie;
                break;
            case ("Warlock"):
                hitDie = Warlock.hitDie;
                break;
        }
        return hitDie;
    }
    

    class Artificer
    {
        public static int hitDie = 8;
    }
    class Barbarian
    {
        public static int hitDie = 12;
    }
    class Bard
    {
        public static int hitDie = 8;
    }
    class Cleric
    {
        public static int hitDie = 8;
    }
    class Druid
    {
        public static int hitDie = 8;
    }
    class Fighter
    {
        public static int hitDie = 10;
    }
    class Monk
    {
        public static int hitDie = 8;
    }
    class Ranger
    {
        public static int hitDie = 10;
    }
    class Rogue
    {
        public static int hitDie = 8;
    }
    class Paladin
    {
        public static int hitDie = 10;
    }
    class Sorcerer
    {
        public static int hitDie = 6;
    }
    class Warlock
    {
        public static int hitDie = 8;
    }
    class Wizard
    {
        public static int hitDie = 6;
    }
}
