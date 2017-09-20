using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Party))]
public class PartyInspector : Editor {

    private const int PreviewUnits = 15;
    private const float Aspect = 1.0f;

    private int closestMemberIndex;
    private Rect preview;

    private Vector2 Scale { get { return preview.size / (2 * PreviewUnits); } }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Preview");
        EditorGUI.DrawRect(GUILayoutUtility.GetAspectRect(Aspect), Color.white);

        preview = GUILayoutUtility.GetLastRect();
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.MiddleCenter;

        var party = (Party)target;
        ProcessMouseEvents(party);

        var members = party.Members;
        var tmpRect = preview;
        PartyMember member;
        Vector2 scaledPosition;
        Rect bullet = new Rect(0, 0, 10, 10);
        for (int i = 0; i < members.Length; i++) {
            member = members[i];
            scaledPosition.x = Scale.x * member.spawnPoint.x;
            scaledPosition.y = -Scale.y * member.spawnPoint.z;
            tmpRect.position = preview.position + scaledPosition;
            bullet.position = tmpRect.position + (preview.size - bullet.size) / 2;
            EditorGUI.DrawRect(bullet, party.Team == Team.Computer ? Color.red : Color.green);
            tmpRect.position += Vector2.up * bullet.size.y * 1.5f;
            EditorGUI.LabelField(tmpRect, member.preset.name, centeredStyle);
        }
    }

    private void ProcessMouseEvents(Party party) {
        switch (Event.current.type) {
            case EventType.MouseDown:
                SelectClosestMember(party);
                break;

            case EventType.MouseDrag:
                MoveClosestMember(party);
                break;
        }
    }

    private void SelectClosestMember(Party party) {
        if (!preview.Contains(Event.current.mousePosition))
            return;

        var members = party.Members;
        var minSqrDistance = float.PositiveInfinity;
        var mousePosition = Event.current.mousePosition - preview.center;
        mousePosition.x /= Scale.x;
        mousePosition.y /= Scale.y;

        Vector2 memberPosition;
        PartyMember member;
        float sqrDistance;

        for (int i = 0; i < members.Length; i++) {
            member = members[i];
            memberPosition.x = member.spawnPoint.x;
            memberPosition.y = -member.spawnPoint.z;
            sqrDistance = (memberPosition - mousePosition).sqrMagnitude;
            if (minSqrDistance > sqrDistance) {
                minSqrDistance = sqrDistance;
                closestMemberIndex = i;
            }
        }
    }

    private void MoveClosestMember(Party party) {
        if (!preview.Contains(Event.current.mousePosition))
            return;

        var clickPoint = Event.current.mousePosition - preview.center;
        party.Members[closestMemberIndex].spawnPoint.x = clickPoint.x / Scale.x;
        party.Members[closestMemberIndex].spawnPoint.z = -clickPoint.y / Scale.y;
    }
}
