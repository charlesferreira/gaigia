using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Party")]
public class Party : ScriptableObject {

    [SerializeField] private List<Character> members;

    public IList<Character> Members { get { return members.AsReadOnly(); } }
}
