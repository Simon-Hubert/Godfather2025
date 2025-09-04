using NaughtyAttributes;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    [SerializeField] private int _ItemCount = 3;
    [SerializeField] private IngredientDatabase _database;
    
    [Button]
    public void Spin() {
        for(int i=0; i < _ItemCount; i++) {
            IngredientData data = _database.Data[Random.Range(0, _database.Data.Length)];
            Debug.Log(data.Name);
        }
    }
}
