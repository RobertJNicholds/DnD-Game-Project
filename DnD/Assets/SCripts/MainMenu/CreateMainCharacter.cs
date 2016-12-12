using UnityEngine;
using DG.Tweening;

public class CreateMainCharacter : MonoBehaviour {


    float centreY = 0, distanceToTravel, bottomX = 0, transferTime = 1;
    

    [SerializeField]
    Transform one, two, three, four, five;

    Vector3 bottom, top;
    float distance;

    void Start()
    {
        centreY = one.position.y;
        two.position += new Vector3(0,Screen.height,0);
       /* level.position = topAnchor.position;
        _class.position = topAnchor.position;
        paragonPath.position = topAnchor.position;
        epicDestiny.position = topAnchor.position;
        race.position = topAnchor.position;
        size.position = topAnchor.position;
        age.position = topAnchor.position;
        gender.position = topAnchor.position;
        height.position = topAnchor.position;
        weight.position = topAnchor.position;
        alignment.position = topAnchor.position;
        diety.position = topAnchor.position;
        adventuringCompantAffiliation.position = topAnchor.position;
        abilityScores.position = topAnchor.position;
        defenses.position = topAnchor.position;
        movement.position = topAnchor.position;
        senses.position = topAnchor.position;
        hitpoints.position = topAnchor.position;
        actionPoints.position = topAnchor.position;
        skills.position = topAnchor.position;*/
    }

    public void initiateCreation()
    {
        one.DOMoveY(centreY - Screen.height , transferTime, false);
        two.DOMoveY(centreY, transferTime, false);
    }

    public void BackToInitial()
    {
        one.DOMoveY(centreY, transferTime, false);
        two.DOMoveY(centreY+ Screen.height, transferTime, false);
    }
}
