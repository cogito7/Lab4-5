using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    //public variables to be available in the inspector
    public string characterName;
    public string characterClass;
    public int characterLevel;
    public int characterCon;
    public bool isHillDwarf = false;
    public bool hasToughFeat = false;
    public bool isRolledHP = false;

    //private List<int> hitDice = new List<int>() { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };
    public string[] classList = {"Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock"};

    //Dictionary for Character Class and hit dice for each for lookup
    private Dictionary<string, int> characterIndex = new Dictionary<string, int>()
    {
        {"Artificer", 8 },
        {"Barbarian", 12 },
        {"Bard", 8 },
        {"Cleric", 8 },
        {"Druid", 8 },
        {"Fighter", 10 },
        {"Monk", 8 },
        {"Ranger", 10 },
        {"Rogue", 8 },
        {"Paladin", 10 },
        {"Sorcerer", 6 },
        {"Wizard", 6 },
        {"Warlock", 8 },
    };

    //Table with ability score range (min, max) and modifier value
    private List<int[]> conModifiers = new List<int[]>()
    {
        new int[] {1, 1, -5},  
        new int[] {2, 3, -4},  
        new int[] {4, 5, -3}, 
        new int[] {6, 7, -2},
        new int[] {8, 9, -1},
        new int[] {10, 11, +0},
        new int[] {12, 13, +1},
        new int[] {14, 15, +2},
        new int[] {16, 17, +3},
        new int[] {18, 19, +4},
        new int[] {20, 21, +5},
        new int[] {22, 23, +6},
        new int[] {24, 25, +7},
        new int[] {26, 27, +8},
        new int[] {28, 29, +9},
        new int[] {30, 30, +10},
    };



    // Start is called before the first frame update
    void Start()
    {
        CalculateScore();
    }

    void CalculateScore()
    {
        if (!IsValidCharacter()) return;  
        int hitDie = GetHitDie();          
        int baseHP = CalculateBaseHP(hitDie); 
        int toughBonus = CalculateToughBonus(); 
        int hillDwarfBonus = CalculateHillDwarfBonus(); 
        int conModifier = GetConstitutionModifier(characterCon); 
        int characterHp = baseHP + toughBonus + hillDwarfBonus + conModifier * characterLevel; 


        // Output to console
        Debug.Log(
        $"My character {characterName} is a level {characterLevel} {characterClass} with a CON score of {characterCon} \n" +
        $"and {HillDwarfText()} a Hill Dwarf and {ToughFeatText()} the Tough feat. I want the HP {HpTypeText()}."
        );
        Debug.Log($"HP: {baseHP}");
    }

    bool IsValidCharacter()
    {
        if (characterLevel <= 0 || characterCon <= 0)
        {
            Debug.Log("Please provide a valid character level and Constitution score.");
            return false;
        }

        if (!characterIndex.ContainsKey(characterClass))
        {
            Debug.Log("Invalid character class! Please check your spelling!");
            Debug.Log("Here are the available classes: ");
            /*for (int i = 0; i < classList.Length; i++)
            {
                Debug.Log(classList[i]);
                return false;
            }*/
        }

        return true; // Class is valid
    }

    int GetHitDie()
    {
        return characterIndex[characterClass]; // Get the appropriate hit die for the selected class
    }

    string HpTypeText()
    {
        if (isRolledHP)
        {
            return "rolled";
        }
        else
        {
            return "averaged";
        }
    }

    int CalculateBaseHP(int hitDie)
    {
        int baseHP = 0;
        int modifier = GetConstitutionModifier(characterCon);
        if (isHillDwarf)
        {
            modifier += 1;
        }
        if (hasToughFeat)
        {
            modifier += 2;
        }

        if (isRolledHP)
        {

            // Roll for each additional level HP
            for (int i = 0; i < characterLevel; i++)
            {
                baseHP += Random.Range(1, hitDie + 1); // Add the rolled value for each level
                baseHP += modifier; // Add the constitution modifier
            }
        }
        else
        {
            // Average HP calculation
            double average = (hitDie - 1.0) / 2.0 + 1;
            baseHP = (int) (characterLevel * (average + modifier));
        }

        return baseHP; // Return the final calculated HP
    }

    string ToughFeatText()
    {
        if (hasToughFeat)
        {
            return "has";
        }
        else
        {
            return "has not";
        }
    }

    int CalculateToughBonus()
    {
        return hasToughFeat ? characterLevel * 2 : 0; // Tough feat gives +2 HP per level
    }

    string HillDwarfText()
    {
        if (isHillDwarf)
        {
            return "is";
        }
        else
        {
            return "is not";
        }
    }

    int CalculateHillDwarfBonus()
    {
        return isHillDwarf ? characterLevel * 1 : 0; // Hill Dwarf gives +1 HP per level
    }

    int GetConstitutionModifier(int score)
    {
        foreach (var range in conModifiers)
        {
            if (score >= range[0] && score <= range[1])
            {
                return range[2];
            }
        }
        throw new System.Exception("Invalid Constitution score! Please check your input."); // in case of an invalid Constitution score is entered
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
