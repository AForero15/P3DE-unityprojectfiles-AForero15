using UnityEngine;

public class PlaySoundOnProximity : MonoBehaviour
{
    public AudioClip soundClip;  // The sound clip to play
    public float playDistance = 3.0f;  // Distance within which the player can trigger the sound

    private Transform player;  // Player's transform
    private AudioSource audioSource;  // AudioSource component

    void Start()
    {
        // Find the player in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found.");
        }

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the object.");
        }
        else
        {
            audioSource.clip = soundClip;
            Debug.Log("AudioSource volume: " + audioSource.volume);
            Debug.Log("AudioSource mute: " + audioSource.mute);
            Debug.Log("AudioSource clip: " + audioSource.clip);
            audioSource.Play();
        }
    }

    void Update()
    {
        if (player == null || audioSource == null) return;  // Exit if the player or AudioSource is not found

        // Check the distance between the player and the object
        float distance = Vector3.Distance(player.position, transform.position);

        // If within play distance and the sound is not already playing
        if (distance <= playDistance && !audioSource.isPlaying && Input.GetKeyDown(KeyCode.F))
        {
            // Play the sound
            audioSource.Play();
            Debug.Log("PlayingAudio");
        }
        // If out of play distance and the sound is playing, stop it
        else if (distance > playDistance && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Optional: visualize the play distance in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playDistance);
    }
}
