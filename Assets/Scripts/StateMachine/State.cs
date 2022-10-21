namespace StatePattern
{
    public abstract class State
    {
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
        public virtual void Exit() { }
    }
}