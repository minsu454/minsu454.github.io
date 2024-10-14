using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerArea : AreaController
{
    [SerializeField][Range(0f, 20f)] private float npcTalkLimit = 3f;           //대화창 뜨기 위한 리미트 변슈
    [SerializeField][Range(0f, 50f)] private float npcListLimit = 20f;          //참여자 목록에 띄울 최소 범위 리미트 변수

    private Transform talkTargetTr;     //현재 대화창이 뜨는 상대방 저장 변수
    private PlayerUI playerUI;          //플레이어 UI

    private void Awake()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    protected override void Start()
    {
        areaEvent += NPCTalkAera;
        areaEvent += NPCListAera;
    }

    /// <summary>
    /// 대화가능 범위에 있는 npc찾아서 있으면 대화창 띄워주는 함수
    /// </summary>
    public void NPCTalkAera()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, npcTalkLimit, Vector2.zero, 0, LayerMasks.NPC);

        if (hits.Length == 0)
        {
            playerUI.ShowNPCTalkPopup(false);
            talkTargetTr = null;
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

        if (hitTr == talkTargetTr)
            return;

        talkTargetTr = hitTr;

        playerUI.ShowNPCTalkPopup(true);
        Managers.Event.Dispatch(GameEventType.TargetChange, talkTargetTr.GetComponent<InfoHandler>());
        
    }

    /// <summary>
    /// 범위안에있는 모든 entity를 가져오는 함수
    /// </summary>
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

    /// <summary>
    /// 기즈모로 리미트 표시
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, npcTalkLimit);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, npcListLimit);
    }
}
