using UnityEngine;

[CreateAssetMenu(fileName ="Collection", menuName ="Collection/Diamond")]
public class Collection : ScriptableObject
{
    public int diamods;

    public void AddDiamond(int num) => diamods += num;
}
