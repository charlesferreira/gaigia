using System;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterAnimations : MonoBehaviour {

    private Animator anim;
    private Dictionary<Direction, int> layerIndices;
    private CharacterAnimationState currentState;

    public void Face(Vector2 towards) {
        var direction = GetDirection(towards);
        foreach (var index in layerIndices)
            anim.SetLayerWeight(index.Value, index.Key == direction ? 1 : 0);
    }

    public void SetState(CharacterAnimationState newState) {
        if (currentState != newState) {
            print(newState.ToString());
            anim.SetTrigger(newState.ToString());
        }
        currentState = newState;
    }

    public void SetSpeed(float speed) {
        anim.speed = speed;
    }

    private Direction GetDirection(Vector2 vec) {
        return Mathf.Abs(vec.x) > Mathf.Abs(vec.y)
                    ? (vec.x > 0 ? Direction.Left : Direction.Right)
                    : (vec.y > 0 ? Direction.Up : Direction.Down);
    }

    private void Awake() {
        anim = GetComponent<Animator>();
        layerIndices = new Dictionary<Direction, int>();
        foreach (Direction direction in Enum.GetValues(typeof(Direction))) {
            layerIndices[direction] = anim.GetLayerIndex(direction.ToString());
        }
        SetState(CharacterAnimationState.Idle);
    }
}
