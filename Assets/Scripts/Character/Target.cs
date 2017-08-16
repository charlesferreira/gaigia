public enum TargetFlag {
    Self  = 1 << 0,
    Ally  = 1 << 1,
    Enemy = 1 << 2,
}

public static class TargetFlagExtension {

    public static bool Match(this TargetFlag self, TargetFlag other) {
        return (self & other) != 0;
    }

}