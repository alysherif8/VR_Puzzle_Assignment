using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    [Tooltip("Only objects with this tag can be snapped into this socket.")]
    public string targetTag;

    [Header("Audio")]
    public AudioSource wrongAudio;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) &&
               interactable.CompareTag(targetTag);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        if (!interactable.CompareTag(targetTag))
        {
            // Play wrong audio if assigned
            if (wrongAudio != null)
                wrongAudio.Play();

            // Reset object to original position (if it has the script)
            if (interactable.TryGetComponent(out OriginalPosition reset))
            {
                interactable.transform.position = reset.startPosition;
                interactable.transform.rotation = reset.startRotation;
            }

            return false;
        }

        return base.CanSelect(interactable);
    }
}
