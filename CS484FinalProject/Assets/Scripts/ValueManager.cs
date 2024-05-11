using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public SceneTransitionManager sceneManager;
    [HideInInspector] public float maxEnergy = 100;
    [HideInInspector] public float maxSanity = 100;
    [HideInInspector] public float maxHunger = 100;
    [HideInInspector] public float energy = 100;
    [HideInInspector] public float sanity = 100;
    [HideInInspector] public float hunger = 100;
    [HideInInspector] public float progress = 0;
    [HideInInspector] public float timer;

    [SerializeField] public float startingTime = 300;
    [SerializeField] private float energyDecay = 1;
    [SerializeField] private float sanityDecay = 1.5f;
    [SerializeField] private float hungerDecay = 3;
    [SerializeField] private float progressRate = 1.5f;

    [HideInInspector] public bool pause = false;
    [HideInInspector] public bool increaseProgress = false; // Change this when pressing keyboard
    [HideInInspector] public bool gameOver = false;

    public BarManager barController;

    private void Start()
    {
        barController.setMax(maxEnergy, maxHunger, maxSanity);
        timer = startingTime;
    }

    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        if (!pause)
        {
            timer -= dt;
            energy -= energyDecay * dt;
            sanity -= sanityDecay * dt;
            hunger -= hungerDecay * dt;
        }
        if (increaseProgress) progress += progressRate * dt;

        if (progress >= 100)
        {
            EndGame(true);
        }

        if (timer < 0 || energy < 0 || sanity < 0 || hunger < 0)
        {
            EndGame(false);
        }

        barController.updateBar(energy, hunger, sanity);
    }

    public void EndGame(bool won)
    {
        gameOver = true;
        increaseProgress = false;
        pause = true;
        sceneManager.GoToScene(2);
    }

    public void ResetGame()
    {
        energy = 100;
        sanity = 100;
        hunger = 100;
        progress = 0;
        timer = startingTime;

        gameOver = false;
        increaseProgress = false;
        pause = false;
    }

    public string GetGrade()
    {
        string grade = progress switch
        {
            float i when i >= 90 && i <= 100 => "A",
            float i when i >= 80 && i < 90 => "B",
            float i when i >= 70 && i < 80 => "C",
            float i when i >= 60 && i < 70 => "D",
            _ => "F"
        };
        return grade;
    }

    #region In-Game Actions

    public void RebootComputer()
    {
        progress -= 10;
        if(progress < 0) progress = 0;

        sanity -= 5;
    }

    public void DrinkEnergy()
    {
        energy += 25;
        if (energy > 100) energy = 100;

        sanity -= 10;

        hunger += 5;
        if (hunger > 100) hunger = 100;
    }

    public void DrinkWater()
    {
        energy += 5;
        if (energy > 100) energy = 100;

        sanity += 10;
        if (sanity > 100) sanity = 100;

        hunger += 10;
        if (hunger > 100) hunger = 100;
    }

    public void EatFood()
    {
        energy += 15;
        if (energy > 100) energy = 100;

        sanity += 5;
        if (sanity > 100) sanity = 100;

        hunger += 25;
        if (hunger > 100) hunger = 100;
    }

    public void TouchGrass()
    {
        energy -= 5;

        sanity += 25;
        if (sanity > 100) sanity = 100;
    }

    #endregion
}
