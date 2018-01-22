using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class XmlRead : MonoBehaviour
{
    [Tooltip("Name of Xml")]
    public string _XmlName = "Date";
    //Information of xmlread
    public Dictionary<string, DateSave> _IntroduceList = new Dictionary<string, DateSave>();

    public string[] _Content;
    void Start()
    {
        _Content = new[]
        {
            "县疾控中心接到报告，立即打电话向县医院医务科再次核实情况，在确认情况属实后，立即对网上的报告卡进行审核", "县CDC带班领导核实情况后立即将应急队伍分成两组：",
            "李四：前往隔离病房，准备对病人及其家属进行流行病学调查。王五：前往病家确认密切接触者对象并对密切接触者进行流调及病人家中消毒"
        };
        ReadXML();
    }
    private void ReadXML()
    {
        TextAsset _XmlFile = Resources.Load(_XmlName) as TextAsset;

        XmlDocument _Xdoc = new XmlDocument();

        _Xdoc.LoadXml(_XmlFile.text);

        XmlNodeList _NodeList = _Xdoc.SelectSingleNode("root").ChildNodes;

        foreach (var _Item in _NodeList)
        {
            DateSave _Date = new DateSave();

            _Date.SetDate(_Item as XmlElement);

            _IntroduceList.Add(_Date._NAME, _Date);
        }
    }
}
/// <summary>
/// save xml date class
/// </summary>
public class DateSave
{
    public string _NAME;
    public string _Describe;
    public string _Name;
    public float _Age;
    public string _Job;
    public string _Sex;
    /// <summary>
    /// Set date
    /// </summary>
    /// <param name="_Element"></param>
    public void SetDate(XmlElement _Element)
    {
        _NAME = _Element.GetAttribute("NAME");
        _Describe = _Element.GetAttribute("Describe");
        _Name = _Element.GetAttribute("Name");
        _Age = float.Parse(_Element.GetAttribute("Age"));
        _Job = _Element.GetAttribute("Job");
        _Sex = _Element.GetAttribute("Sex");
    }
}
