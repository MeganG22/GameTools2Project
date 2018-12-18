using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DarkEnergy : MonoBehaviour {

    //Enemy's NavMesh Movement & Player Dectection Variables
    private enum NPCState { FOLLOW, WALK };
    private NPCState m_NPCState;
    private NavMeshAgent m_NavMeshAgent;
    private int m_DefaultWayPoint;
    private bool m_IsPlayerInView;
             //Publics of these Variables to Edit in Unity
    [SerializeField] float m_FieldOfView;
    [SerializeField] float m_ThresholdDistance;
    [SerializeField] Transform[] m_WayPoints;
    [SerializeField] GameObject m_Player;

    //Enemy's Audio Source & Clip
    [SerializeField] AudioClip m_audioClip;
    private AudioSource m_audioSource;

    void Start()
    {
        //Enemy's NavMesh Agent is Instansiated, Walk state & other variables set
        m_NPCState = NPCState.WALK;
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_DefaultWayPoint = 0;
        m_NavMeshAgent.updatePosition = true;
        m_NavMeshAgent.updateRotation = true;

        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Checking Player Function is Called Contantly
        CheckPlayer();

        //Enemy Always(expept exceptions) moving to next WayPoint
        m_NavMeshAgent.nextPosition = transform.position;

        //Check When to change Enemy's state
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
        //If Enemy walking and sees Player in line of sight
        if (m_NPCState == NPCState.WALK && m_IsPlayerInView && CheckFieldOfView() && CheckOclusion())
        {
            //Switch to Follow state
            m_NPCState = NPCState.FOLLOW;
            return;
        }

        //Else
        if (m_NPCState == NPCState.FOLLOW && CheckOclusion() == false)
        {
            //Continue to Walk state
            m_NPCState = NPCState.WALK;
        }
    }

    void Follow()
    {
        //If in Follow State; Enemy moves towards Player's position
        Debug.Log("Follow");
        m_NavMeshAgent.SetDestination(m_Player.transform.position);
    }

    bool CheckFieldOfView()
    {
        //Setting up Enemy's Field of View
        Vector3 direction = m_Player.transform.position - this.transform.position;
        Vector3 angle = (Quaternion.FromToRotation(transform.forward, direction)).eulerAngles;

        //Angle Creation
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
        //If Player hits the Enemy's line of sight
        RaycastHit hit;
        Vector3 direction = m_Player.transform.position - transform.position;
        if (Physics.Raycast(this.transform.position, direction, out hit))
        {
            //And if hit Player
            if (hit.collider.gameObject == m_Player)
            {
                return true;
            }
        }
        return false;
    }

    void Walk()
    {
        //If in Walk State; Enemy continues walking through WayPoints
        CheckWaypointDistance();
        m_NavMeshAgent.SetDestination(m_WayPoints[m_DefaultWayPoint].position);
        Debug.Log("Walk");
    }

    void CheckWaypointDistance()
    {
        //Enemy Identifying where the next WayPoint is
        if (Vector3.Distance(m_WayPoints[m_DefaultWayPoint].position, this.transform.position) < m_ThresholdDistance)
        {
            m_DefaultWayPoint = (m_DefaultWayPoint + 1) % m_WayPoints.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If Player hit Enemy's Collider/Field of View
        if (other.tag == "Player")
        {
            //The Player is set to be in view
            m_IsPlayerInView = true;

            //The horror sound plays to warn Player
            PlaySound();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Player Dies (scene reload) when hit Enemies Collider 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDrawGizmos()   //Gizmos drawn in Unity to Help Developer See Enemy's Collider, Player Line & Field of View (angle)
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 5.0f);

        Gizmos.color = Color.red;
        Vector3 direction = m_Player.transform.position - transform.position;
        Gizmos.DrawRay(transform.position, direction);

        Vector3 rightDirection = Quaternion.AngleAxis(m_FieldOfView / 2, Vector3.up) * transform.forward;
        Vector3 leftDirection = Quaternion.AngleAxis(-m_FieldOfView / 2, Vector3.up) * transform.forward;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, rightDirection * 4);
        Gizmos.DrawRay(transform.position, leftDirection * 4);
    }

    private void PlaySound()
    {
        //Playing the Enemy Scare sound
        Debug.Log("Sound");
        m_audioSource.PlayOneShot(m_audioClip);
    }
}
