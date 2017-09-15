using UnityEngine;

[CreateAssetMenu(menuName = "Character/Party")]
public class Party : ScriptableObject {

    [SerializeField] private Team team;
    [SerializeField] private PartyMember[] members;

    public PartyMember[] Members { get { return members; } }

    public Character[] CreateCharacters() {
        var characters = new Character[members.Length];
        for (int i = 0; i < members.Length; i++)
            characters[i] = members[i].Instantiate(team);
        return characters;
    }

}
