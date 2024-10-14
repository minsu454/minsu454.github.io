using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerArea : AreaController
{
    [SerializeField][Range(0f, 20f)] private float npcTalkLimit = 3f;
    [SerializeField][Range(0f, 50f)] private float npcListLimit = 20f;

    private Transform targetTr;
    private PlayerUI playerUI;

    private void Awake()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    protected override void Start()
    {
        areaEvent += NPCTalkAera;
        areaEvent += NPCListAera;
    }

    public void NPCTalkAera()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, npcTalkLimit, Vector2.zero, 0, LayerMasks.NPC);

        if (hits.Length == 0)
        {
            targetTr = null;
            return;
        }
        
        Transform hitTr = null;
        float bestDis = float.MaxValue;

        foreach (var hit in hits)
        {
            float dis = Vector2.Distance(hit.transform.position, transform.position);

            if (bestDis > dis)
            {
                hitTr = hit.transform;
                bestDis = dis;
            }
        }

        if (hitTr == targetTr)
            return;

        targetTr = hitTr;

        //Managers.Event.Dispatch();

        playerUI.ShowNPCTalkPopup();
        //Debug.Log(hitTr.gameObject.name);
    }

    public void NPCListAera()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, npcListLimit, Vector2.zero, 0, LayerMasks.NPC);

        if (hits.Length == 0)
            return;

        HashSet<string> npcNames = new HashSet<string>();

        foreach (var hit in hits)
        {
            npcNames.Add(hit.collider.name);
        }

        if (!Managers.Data.InAreaEntityNames.SequenceEqual(npcNames))
        {
            Managers.Event.Dispatch(GameEventType.InAreaEntity, npcNames);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, npcTalkLimit);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, npcListLimit);
    }
}
