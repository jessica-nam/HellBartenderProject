using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] string id;
	public string ID { get { return id; } }
	public string ItemName;
	public Sprite Icon;

    // protected virtual void OnValidate()
	// {
	// 	string path = AssetDatabase.GetAssetPath(this);
	// 	id = AssetDatabase.AssetPathToGUID(path);
	// }
}
