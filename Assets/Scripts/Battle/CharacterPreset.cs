using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Preset")]
public class CharacterPreset : ScriptableObject {

    [Header("General")]
    [SerializeField] private Character _prefab;
    [SerializeField] private StatsSheet _baseStats;

    [Header("Graphics")]
    [SerializeField] private Sprite _avatar;
    [SerializeField] private AnimatorOverrideController _animator;

    [Header("Equipment")]
    [SerializeField] private Armor _armor;
    [SerializeField] private Weapon _weapon;

    [Header("Skill Set")]
    [SerializeField] private List<Skill> _skills;
    
    public StatsSheet BaseStats { get { return _baseStats; } }

    public Sprite Avatar { get { return _avatar; } }
    public AnimatorOverrideController AnimatorController { get { return _animator; } }

    public Weapon Weapon { get { return _weapon; } }
    public Armor Armor { get { return _armor; } }

    public List<Skill> Skills { get { return _skills; } }

    public Character Instantiate(Team team, Vector3 spawnPoint) {
        var mob = Instantiate(_prefab);
        mob.SetUp(this, team);
        mob.transform.position = spawnPoint;
        return mob;
    }

}