using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class LootBox : MonoBehaviour
{
    [SerializeField] private IngredientDatabase _database;
    [SerializeField] private IngredientFactory _factory;
    [SerializeField] private Transform[] _spawnPoints;
    
    [SerializeField] private UnityEvent _onOpenLootBox;
    
    [Button]
    public void Open() {
        Ingredient[] ingredients = new Ingredient[_spawnPoints.Length];
        for (int i=0; i < _spawnPoints.Length; i++) {
            ingredients[i] =  _factory.SpawnIngredient(_spawnPoints[i].position, GetRandomIngredient());
        }
        _onOpenLootBox?.Invoke();
    }
    
    private int GetRandomIngredient() {
        return Random.Range(0, _database.Data.Length);
    }
}
