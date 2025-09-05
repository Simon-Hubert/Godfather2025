using System;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class LootBox : MonoBehaviour
{
    [SerializeField] private IngredientDatabase _database;
    [SerializeField] private IngredientFactory _factory;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField, ReadOnly] private Ingredient[] _ingredients = new Ingredient[5];
    
    [SerializeField] private UnityEvent _onOpenLootBox;

    [SerializeField] private float _initialVelocity;
    [SerializeField] private Vector2[] _dirs;
    public event Action OnOpenLootBox;
    
    [Button]
    public void Open() {
        DestroyAllRemainingIngredients();
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _ingredients[i] = _factory.SpawnIngredient(_spawnPoints[i].position, GetRandomIngredient());
        }
    }
    
    private int GetRandomIngredient() {
        return Random.Range(0, _database.Data.Length);
    }

    public void Open(Sickness sickness)
    {
        DestroyAllRemainingIngredients();
        _spawnPoints = _spawnPoints.OrderBy(x => Random.value).ToArray();


        SORecipe recipe = Random.Range(0, 3) switch
        {
            0 => sickness.Recipe1,
            1 => sickness.Recipe2,
            2 => sickness.Recipe3,
            _ => sickness.Recipe1
        };

        int forcedItems = recipe.ingredients.Count;

        for (int i = 0; i < forcedItems; i++)
        {
            _ingredients[i] = _factory.SpawnIngredient(_spawnPoints[i].position, recipe.ingredients[i]);
        }

        for (int i = forcedItems; i < 5; i++)
        {
            _ingredients[i] = _factory.SpawnIngredient(_spawnPoints[i].position, GetRandomIngredient());
        }
        _onOpenLootBox?.Invoke();
        OnOpenLootBox?.Invoke();
    }

    private void DestroyAllRemainingIngredients() {
        foreach (Ingredient ingredient in _ingredients) {
            if (ingredient != null) Destroy(ingredient.gameObject);
        }
    }

    public void AddInitialVelocity() {
        for (int i = 0; i < _ingredients.Length; i++) {
            
            _ingredients[i].AddInitialVelocity(_dirs[i] * _initialVelocity);
        }
    }
}
