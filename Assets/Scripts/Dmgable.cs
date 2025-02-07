using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Dmgable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;
    public UnityEvent dmgableDeath;
    public UnityEvent<int, int> healthChanged;
    Animator animator;
    public static string lastScene1;

    [SerializeField]
    public string enemyName = "MT";
 

    [SerializeField]
    private int _maxHealth = 100;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
    [SerializeField]
    public int _health = 100;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);
            if (_health <= 0)
            {
                if ( CompareTag("Player") )
                {
                    IsAlive = false;
                    lastScene1 = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene("LoseScene");
                }
                else
                {
                    IsAlive = false;
                }
            }
            if (_health <= 0)
            {
                if (CompareTag("DemonLorrrd"))
                {
                    IsAlive = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    IsAlive = false;
                }
            }
            if (_health <= 0)
            {
                if (CompareTag("Demonnnn"))
                {
                    _health = 0;
                    IsAlive = false;
                }
                else
                {
                    IsAlive = false;
                }
            }
        }
    }
    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;

    [SerializeField]
    private bool _isDefend = true;

    private float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;


    public bool IsDefend
    {
        get
        {
            return _isDefend;
        }
        set
        {
            _isDefend = value;
            animator.SetBool(AnimationStrings.isDefend, value);
            Debug.Log("IsDefend set" + value);
        }
    }
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set" + value);

            if(value == false)
            {
                dmgableDeath.Invoke();
            }
        }
    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInvincible)
        {
            if(timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }

    public bool Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvincible && !IsDefend)
        {
            
            Health -= damage;
            isInvincible = true;

            animator.SetTrigger(AnimationStrings.hitTrigger);
            LockVelocity = true;
            damageableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);

            return true; 
        }
        return false;
    }
    public bool descHit(int damage, Vector2 knockback)
    {
        if (IsAlive && IsDefend)
        {
            Health -= damage;
            LockVelocity = true;
            animator.SetTrigger(AnimationStrings.hitTrigger);
            damageableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);

            return true;
        }
        return false;
    }
    public bool Heal(int healthRestore)
    {
        if(IsAlive && Health < MaxHealth)
        {
            int maxHeal = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxHeal, healthRestore);
            Health += actualHeal;
            CharacterEvents.characterHealed(gameObject, actualHeal);
            return true;
        }
        return false;
    }
   
}
