using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StepManager : MonoBehaviour
{

    public Text step_text;

    public Button sceneBtn;

    //当前已执行步骤
    public static int nowStep;
    //当前要步骤
    public static int willStep;
    //所有步骤
    public int allStep;

    //开始实验
    public void BeginExperiment()
    {
        if (nowStep != willStep && willStep <= allStep)
        {
            switch (willStep)
            {
                //第1步
                case 1: step_text.text = "　　点击桌子上的电话开始进行通话。";
                    Phone.phone_state = Phone.Phone_State.On;
                    break;
                //第2步
                case 2: step_text.text = "　　点击桌子上的联系本查看联系人，选择要联络的联系人确定专家小组名单。";
                    Phone.phone_state = Phone.Phone_State.Off;
                    Note.note_state = Note.Note_State.On;
                    break;
                //第3步
                case 3: step_text.text = "　　点击电脑整理所需物资文档发送县疾病预防控制中心。"; 
                    Note.note_state = Note.Note_State.Off;
                    Computer.computer_state = Computer.Computer_State.OnOne;
                    break;
                //第4步
                case 4: step_text.text = "　　点击电脑填写疫情报告和通报发送县疾病预防控制中心。"; 
                    Computer.computer_state = Computer.Computer_State.OnTwo;
                    break;
                //第5步
                case 5: step_text.text = "　　应急响应结束，点击按钮回到场景选择画面。"; 
                    Computer.computer_state = Computer.Computer_State.Off;
                    sceneBtn.gameObject.SetActive(true);
                    break;
            }
            nowStep = willStep;
        }
        else
        {
            
        }
    }

    void Start()
    {
        nowStep = 0;
        willStep = 0;
    }

    void Update()
    {
        BeginExperiment();
    }

    

}
