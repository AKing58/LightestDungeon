using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// https://www.youtube.com/watch?v=uPmorHLPwnk&ab_channel=inScopeStudios
/// </summary>
public class MoveToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text moveNameTxt;
    private Text targetTxt;
    private Text attModTxt;
    private Text damModTxt;
    private Text statusTxt;
    private Text descTxt;

    public CharacterInfoPanelScript thisPanel;
    private Entity.MoveDesc thisMoveDesc;


    // Start is called before the first frame update
    void Start()
    {
        thisMoveDesc = thisPanel.thisEntity.md1;
        moveNameTxt = thisPanel.transform.Find("Tooltip/MoveNameTxt").GetComponent<Text>();
        targetTxt = thisPanel.transform.Find("Tooltip/TargetTxt").GetComponent<Text>();
        attModTxt = thisPanel.transform.Find("Tooltip/AttackModTxt").GetComponent<Text>();
        damModTxt = thisPanel.transform.Find("Tooltip/DamModTxt").GetComponent<Text>();
        statusTxt = thisPanel.transform.Find("Tooltip/StatusTxt").GetComponent<Text>();
        descTxt = thisPanel.transform.Find("Tooltip/Description/DescTxt").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Grabs the description of the button from mousing over the button
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(gameObject.name=="SkillBtn1");
        switch (gameObject.name)
        {
            case "SkillBtn1":
                thisMoveDesc = thisPanel.thisEntity.md1;
                break;
            case "SkillBtn2":
                thisMoveDesc = thisPanel.thisEntity.md2;
                break;
            case "SkillBtn3":
                thisMoveDesc = thisPanel.thisEntity.md3;
                break;
            case "SkillBtn4":
                thisMoveDesc = thisPanel.thisEntity.md4;
                break;
            case "SkillBtn5":
                thisMoveDesc = thisPanel.thisEntity.md5;
                break;
        }
        Debug.Log(thisMoveDesc.Name);

        moveNameTxt.text = thisMoveDesc.Name;
        targetTxt.text = "Target: " + thisMoveDesc.Target;
        attModTxt.text = "AttMod: " + thisMoveDesc.AttMod;
        damModTxt.text = "DamMod: " + thisMoveDesc.DamMod;
        statusTxt.text = "Status: " + thisMoveDesc.Status;
        descTxt.text = thisMoveDesc.Desc;

        thisPanel.transform.Find("Tooltip").gameObject.SetActive(true);
    }

    /// <summary>
    /// Closes the tooltip when the mouse cursor leaves the button
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit " + thisMoveDesc.Name);
        thisPanel.transform.Find("Tooltip").gameObject.SetActive(false);
    }
}
