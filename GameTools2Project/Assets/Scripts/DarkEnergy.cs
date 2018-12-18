using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DarkEnergy : MonoBehaviour {


    private enum NPCState { FOLLOW, WALK };
    private NPCState m_NPCState;
    private NavMeshAgent m_NavMeshAgent;
    private int m_DefaultWayPoint;
    private bool m_IsPlayerInView;

    [SerializeField] float m_FieldOfView;
    [SerializeField] float m_ThresholdDistance;
    [SerializeField] Transform[] m_WayPoints;
    [SerializeField] GameObject m_Player;

    [SerializeField] AudioClip m_audioClip;
    private AudioSource m_audioSource;

    void Start()
    {
        m_NPCState = NPCState.WALK;
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_DefaultWayPoint = 0;

        m_NavMeshAgent.updatePosition = true;
        m_NavMeshAgent.updateRotation = true;

        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckPlayer();

        m_NavMeshAgent.nextPosition = transform.position;

        switch (m_NPCState)
        {
            case NPCState.FOLLOW:
                Follow();
                break;
            case NPCState.WALK:
                Walk();
                break;
            default:
                break;
        }
    }

    void CheckPlayer()
    {
        if (m_NPCState == NPCState.WALK && m_IsPlayerInView && CheckFieldOfView() && CheckOclusion())
        {
            m_NPCState = NPCState.FOLLOW;
            return;
        }

        if (m_NPCState == NPCState.FOLLOW && CheckOclusion() == false)
        {
            m_NPCState = NPCState.WALK;
        }
    }

    void Follow()
    {
        Debug.Log("Follow");
        m_NavMeshAgent.SetDestination(m_Player.transform.position);
    }

    bool CheckFieldOfView()
    {
        Vector3 direction = m_Player.transform.position - this.transform.position;
        Vector3 angle = (Quaternion.FromToRotation(transform.forward, direction)).eulerAngles;

        if (angle.y > 180.0f) angle.y = 360.0f - angle.y;
        else if (angle.y < -180.0f) angle.y = angle.y + 360.0f;

        if (angle.y < m_FieldOfView / 2)
        {
            return true;
        }
        return false;
    }

    bool CheckOclusion()
    {
        RaycastHit hit;
        Vector3 direction = m_Player.transform.position - transform.position;
        if (Physics.Raycast(this.transform.position, direction, out hit))
        {
            if (hit.collider.gameObject == m_Player)
            {
                return true;
            }
        }
        return false;
    }

    void Walk()
    {
        CheckWaypointDistance();
        m_NavMeshAgent.SetDestination(m_WayPoints[m_DefaultWayPoint].position);
        Debug.Log("Walk");
    }

    void CheckWaypointDistance()
    {
        if (Vector3.Distance(m_WayPoints[m_DefaultWayPoint].position, this.transform.position) < m_ThresholdDistance)
        {
            m_DefaultWayPoint = (m_DefaultWayPoint + 1) % m_WayPoints.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_IsPlayerInView = true;
            PlaySound();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5.0f);

        Gizmos.color = Color.red;
        Vector3 direction = m_Player.transform.position - transform.position;
        Gizmos.DrawRay(transform.position, direction);

        Vector3 rightDirection = Quaternion.AngleAxis(m_FieldOfView / 2, Vector3.up) * transform.forward;
        Vector3 leftDirection = Quaternion.AngleAxis(-m_FieldOfView / 2, Vector3.up) * transform.forward;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, rightDirection * 4);
        Gizmos.DrawRay(transform.position, leftDirection * 4);
    }

    private void PlaySound()
    {
        Debug.Log("Sound");
        m_audioSource.PlayOneShot(m_audioClip);
    }
}
