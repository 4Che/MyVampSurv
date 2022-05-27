using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int level = 1;
    private int experience = 0;
    [SerializeField] private ExperienceBar _experienceBar;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        _experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        _experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        _experienceBar.SetLevelText(level);
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            _experienceBar.SetLevelText(level);
        }
    }
}
