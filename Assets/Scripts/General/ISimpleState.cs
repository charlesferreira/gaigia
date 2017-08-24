public interface ISimpleState<T> where T : SimpleStateMachine<T> {

    void OnStateEnter(T ssm);

    void OnStateExit(T ssm);

    void Update(T ssm);
}