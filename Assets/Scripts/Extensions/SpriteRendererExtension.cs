using UnityEngine;
using UnityEngine.Sprites;

public static class SpriteRendererExtension {

    public static Vector4 GetPadding(this SpriteRenderer self) {
        return DataUtility.GetPadding(self.sprite) / self.sprite.pixelsPerUnit;
    }

    public static float GetMaxY(this SpriteRenderer self) {
        return self.sprite.bounds.max.y - self.GetPadding().w;
    }
    

}