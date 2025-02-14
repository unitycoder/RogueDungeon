using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSpell : Spell
{
    private MousePositionTracker _mousePositionTracker;

    private void Start()
    {
        _mousePositionTracker =
            GameObject.FindWithTag("MousePositionTracker").GetComponent<MousePositionTracker>();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Cast(NavMeshAgent navMeshAgent, Animator animator,
        PlayerInventory playerInventory, PlayerMana playerMana)
    {
        if (!IsOnCooldown() && playerMana.CurrentMana >= data.manaCost)
        {
            IsCastingSpell = true;
            PlayerAiming playerAiming = navMeshAgent.GetComponent<PlayerAiming>();
            playerAiming.StartAiming(
                FinishAimingCallback(navMeshAgent, animator, playerInventory, playerMana),
                CancelAimingCallback(),
                data);
        }
    }

    private Action CancelAimingCallback()
    {
        return () => IsCastingSpell = false;
    }

    private Action FinishAimingCallback(NavMeshAgent navMeshAgent, Animator animator,
        PlayerInventory playerInventory, PlayerMana playerMana)
    {
        return () =>
        {
            playerMana.UseMana(data.manaCost);
            navMeshAgent.gameObject.transform.LookAt(_mousePositionTracker.MousePos());
            base.Cast(navMeshAgent, animator, playerInventory);
        };
    }

    protected override void ApplyEffectsToSpell(GameObject spellPrefab, PlayerInventory playerInventory)
    {
        data.spellTraits.ForEach(trait => trait.ApplyEffects(spellPrefab, true));
        playerInventory.Items.ForEach(item => item.ApplyEffects(spellPrefab));
    }
}