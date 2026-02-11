using UnityEngine.Events;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] private UnityEvent<int> _onChangeLifeBar;

    // Start is called before the first frame update

    public int GetHp() => _hp;

    public void SetHp(int hp) => _hp = hp;

    public bool IsAlive()
    {
        return _hp > 0;
    }
    public void TakeDamage(int damage)
    {

        _hp = Mathf.Max(0, _hp - damage);

        _onChangeLifeBar.Invoke((_hp));

        if (!IsAlive())
        {
            Destroy(gameObject);
        }
    }
}

