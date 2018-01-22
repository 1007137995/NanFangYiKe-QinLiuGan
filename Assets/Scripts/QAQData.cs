﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QAQData : MonoBehaviour {

    public static QAQData instance;

    public struct Que
    {
        public string que;
        public List<string> q;
        public string ans;
        public string shuoming;
    }

    public List<Que> QAQ = new List<Que>();

    private Que que = new Que();

    void Start()
    {
        instance = this;
        AddQuestion();
    }

    public void AddQuestion()
    {
        //0
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "根据乡卫生院上报，你应该怎么处理？";
        que.q[0] = "A.立刻向区预防控制中心领导反映情况";
        que.q[1] = "B.立刻向区卫生局领导报告，由卫生局指定区人民医院用专用救护车转运病人到区人民医院救治";
        que.q[2] = "C.请乡卫生院做好病人转运前的准备工作，在未被转运前做好病人的隔离";
        que.q[3] = "D.立刻向市预防控制中心上报";
        que.ans = "ABC";
        que.shuoming = "应当立刻向区预防控制中心领导反映情况；立刻向区卫生局领导报告，由卫生局指定区人民医院用专用救护车转运病人到区人民医院救治；还要请乡卫生院做好病人转运前的准备工作，在未被转运前做好病人的隔离。";
        QAQ.Add(que);
        //1
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "根据县人民医院反馈，你应该怎么处理？";
        que.q[0] = "A.立即上报区卫生局";
        que.q[1] = "B.上报市疾控预防控制中心";
        que.q[2] = "C.立即召开会议，派出专业人员到病家和区人民医院进行调查处理";
        que.q[3] = "D.立即上报市卫生局";
        que.ans = "ABC";
        que.shuoming = "应该立即上报区卫生局；上报市疾控预防控制中心；还要立即召开会议，派出专业人员到病家和区人民医院进行调查处理。";
        QAQ.Add(que);
        //2
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "县疾控中心在禽流感爆发期间的职责有哪些？";
        que.q[0] = "A.负责当地疫情及监测资料的收集、汇总分析、上报";
        que.q[1] = "B.开展现场流行病学调查处理";
        que.q[2] = "C.指导做好生活环境、物品的卫生学处理和禽流感疫情现场处置人员的个人防护";
        que.q[3] = "D.开展专业人员培训和健康教育";
        que.ans = "ABCD";
        que.shuoming = "县（区）级疾病预防控制机构承担本地区人禽流感预防控制及监测工作，负责当地疫情及监测资料的收集、汇总分析、上报，开展现场流行病学调查处理（包括人禽流感病例的流行病学调查，密切接触者追踪和医学观察，相关标本的采集和运送），指导做好生活环境、物品的卫生学处理和禽流感疫情现场处置人员的个人防护，开展专业人员培训和健康教育。";
        QAQ.Add(que);
        //3
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "县级医院在禽流感爆发期间的职责有哪些？";
        que.q[0] = "A.负责不明原因肺炎病例和人禽流感医学观察病例的筛查与报告";
        que.q[1] = "B.负责病人的诊断、转运、隔离治疗、医院内感染控制";
        que.q[2] = "C.配合疾病预防控制机构开展流行病学调查及标本采集工作";
        que.q[3] = "D.负责本机构内有关人员的培训工作";
        que.ans = "ABCD";
        que.shuoming = "县级及以上医疗机构负责不明原因肺炎病例和人禽流感医学观察病例的筛查与报告，负责病人的诊断、转运、隔离治疗、医院内感染控制，配合疾病预防控制机构开展流行病学调查及标本采集工作，负责本机构内有关人员的培训工作。";
        QAQ.Add(que);
        //4
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "禽流感疫情由哪一级的部门进行公布与通报？";
        que.q[0] = "A.市级疾病控制中心";
        que.q[1] = "B.省级疾病控制中心";
        que.q[2] = "C.县级卫生行政部门";
        que.q[3] = "D.省级卫生行政部门";
        que.ans = "D";
        que.shuoming = "卫生部负责向有关部门、国际组织、有关国家、港澳台地区通报并向社会发布人禽流感疫情信息。省级卫生行政部门经卫生部授权后，负责向社会发布本行政区域内人禽流感疫情信息。";
        QAQ.Add(que);
        //5
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "请根据当前疫情情况判断公共卫生事件等级？";
        que.q[0] = "A.重大突发公共卫生事件（Ⅱ级）";
        que.q[1] = "B.特别重大突发公共卫生事件（Ⅰ级）";
        que.q[2] = "C.突发公共卫生事件（III级）";
        que.q[3] = "D.并非突发公共卫生事件";
        que.ans = "A";
        que.shuoming = "本地出现散发或聚集性人禽流感病例，属重大突发公共卫生事件（Ⅱ级）；证实人间传播病例并出现疫情扩散状态，属特别重大突发公共卫生事件（Ⅰ级）。";
        QAQ.Add(que);
        //6
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "流行病学调查的重点区域有哪些？";
        que.q[0] = "A.接触过病、死禽（包括家禽、野生水禽和侯鸟），或其排泄物、分泌物，或其排泄物、分泌物污染的环境";
        que.q[1] = "B.与疑似或确诊病例共同生活、居住，或护理过病例";
        que.q[2] = "C.在出现异常死禽的地区居住、生活、工作过";
        que.q[3] = "D.所有区域";
        que.ans = "ABC";
        que.shuoming = "";
        QAQ.Add(que);
        //7
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "流行病学调查的重点人群有哪些？";
        que.q[0] = "A.高危职业史包括饲养、贩卖、屠宰、加工、诊治家禽的职业人员";
        que.q[1] = "B.可能暴露于动物和人感染高致病性禽流感病毒或潜在感染性材料的实验室职业人员";
        que.q[2] = "C.未采取严格的个人防护措施，处置动物高致病性禽流感疫情的人员";
        que.q[3] = "D.未采取严格的个人防护措施，接触人感染高致病性禽流感疑似或确诊病例的医务人员";
        que.ans = "ABCD";
        que.shuoming = "从事家禽养殖业者及其同地居住的家属、在发病前1周内到过家禽饲养、销售及宰杀等场所者、接触禽流感病毒感染材料的实验室工作人员、与禽流感患者有密切接触的人员为高危人群。";
        QAQ.Add(que);

        //8
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下流调对象中哪些可判定为密切接触者？";
        que.q[0] = "A.禽流感病（死）禽的密切接触者";
        que.q[1] = "B.人禽流感病例的密切接触者：与出现症状后的人禽流感疑似病例或确诊病例共同生活、居住、护理的人员或直接接触过病例呼吸道分泌物、排泄物和体液的人员";
        que.q[2] = "C.现场流行病调查人员根据调查情况确定的其他密切接触者";
        que.q[3] = "D.在没有防护措施的条件下，对可能被禽流感病毒污染的物品进行采样、处理标本、检测等实验室操作或者违反生物安全操作规程的工作人员";
        que.ans = "ABCD";
        que.shuoming = "禽流感病（死）禽的密切接触者；人禽流感病例的密切接触者；现场流行病调查人员根据调查情况确定的其他密切接触者；在没有防护措施的条件下，对可能被禽流感病毒污染的物品进行采样、处理标本、检测等实验室操作或者违反生物安全操作规程的工作人员。";
        QAQ.Add(que);
        //9
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对密切接触者的处理措施正确的是？";
        que.q[0] = "A.对密切接触者进行医学观察，观察期为15天";
        que.q[1] = "B.医学观察期间需限制医学观察对象的活动自由";
        que.q[2] = "C.医学观察期间，患者每天需自行测量体温2次并上报专业卫生人员";
        que.q[3] = "D.被观察对象如需离开疫区，必须得到当地政府的同意后方能离开疫区";
        que.ans = "BCD";
        que.shuoming = "对密切接触者进行医学观察，观察期暂定为7天；在医学观察期间不限制医学观察对象的活动，但病（死）禽密切接触者须在疫区范围（疫点周围半径3公里）内活动；医学观察期间，负责医学观察的医疗机构的专业卫生人员每日对密切接触者测试2次体温，了解其身体健康状况；被观察对象如需离开疫区，必须得到当地政府的同意后方能离开疫区。";
        QAQ.Add(que);
        //10
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下禽流感的采样标本的正确的是？";
        que.q[0] = "A.上下呼吸道标本";
        que.q[1] = "B.尸检标本";
        que.q[2] = "C.血清标本";
        que.q[3] = "D.其它标本：如果病例有腹泻症状，可在发病后采集粪便标本";
        que.ans = "ABCD";
        que.shuoming = "上呼吸道标本：包括咽拭子、鼻拭子、鼻咽抽取物、咽漱液、深咳痰液。2.下呼吸道标本：包括呼吸道抽取物、支气管灌洗液、肺组织活检标本。尸检标本：病人死亡后应依法尽早进行解剖，主要采集肺、气管组织标本，条件允许下也可采集肝、肾、脾、心脏、脑、淋巴结等组织标本。血清标本：每一病例必须采集血清标本，须采集急性期、恢复期双份血清.其它标本：如果病例有腹泻症状，可在发病后采集粪便标本；有胸水者可采集胸水标本。";
        QAQ.Add(que);
        //11
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下咽拭子的采样方法的正确的是？";
        que.q[0] = "A.用2根棉签同时擦拭双侧咽扁桃体，将拭子头浸入含3ml采样液的管中，尾部弃去，旋紧管盖";
        que.q[1] = "B.用2根聚丙烯纤维头的塑料杆拭子同时擦拭双侧咽扁桃体及咽后壁，将拭子头浸入含3ml采样液的管中，尾部弃去，旋紧管盖";
        que.q[2] = "C.用1根聚丙烯纤维头的塑料杆拭子同时擦拭双侧咽扁桃体及咽后壁，将拭子放入3ml采样液的管中旋紧管盖";
        que.q[3] = "D.用2根聚丙烯纤维头的塑料杆拭子擦拭咽后壁，将拭子头浸入含5ml采样液的管中，尾部弃去，旋紧管盖";
        que.ans = "B";
        que.shuoming = "咽拭子：用2根聚丙烯纤维头的塑料杆拭子同时擦拭双侧咽扁桃体及咽后壁，将拭子头浸入含3ml采样液的管中，尾部弃去，旋紧管盖。";
        QAQ.Add(que);
        //12
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "体温数值多少时需工作人员重点监测对象？";
        que.q[0] = "A.37.9℃";
        que.q[1] = "B.38.0℃";
        que.q[2] = "C.38.9℃";
        que.q[3] = "D.37.5℃";
        que.ans = "BC";
        que.shuoming = "根据卫计委标准:人感染高致病性禽流感应急监测对象为：监测范围内的发热（体温≥38℃）伴流感样症状病例及密切接触者。";
        QAQ.Add(que);
        //13
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "禽流感爆发期间预防宣传做法错误的是？";
        que.q[0] = "A.尽可能减少人，特别是少年儿童与禽、鸟类的不必要的接触，尤其是与病、死禽类的接触";
        que.q[1] = "B.因职业关系必须接触者，工作期间应戴口罩、穿工作服";
        que.q[2] = "C.注意饮食卫生，不喝生水，多吃禽类及蛋类等食品；勤洗手，养成良好的个人卫生习惯";
        que.q[3] = "D.接触人禽流感患者亲属时应戴口罩、戴手套、戴防护镜、穿隔离衣。接触后应洗手";
        que.ans = "C";
        que.shuoming = "注意饮食卫生，不喝生水，不吃未熟的肉类及蛋类等食品；勤洗手，养成良好的个人卫生习惯。";
        QAQ.Add(que);
        //14
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "如下现场消毒工作做法错误的是？";
        que.q[0] = "A.对禽舍包括死禽和宰杀的家禽、禽粪和墙壁地面等进行终末消毒，必要时对禽舍的空气进行消毒";
        que.q[1] = "B.对划定的动物疫点内病、死禽可能污染的物品进行终末消毒";
        que.q[2] = "C.对划定的动物疫区内的饮用水应进行消毒处理，对流动水体和较大的水体等消毒较困难者可以不消毒，但应严格进行管理";
        que.q[3] = "D.对划定的动物疫区内的密切接触者进行消毒处理";
        que.ans = "D";
        que.shuoming = "对划定的动物疫区内可能污染的物体在出封锁线时进行消毒处理。";
        QAQ.Add(que);
        //15
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "对病房、病家和禽舍的地面、墙壁等一般物体消杀做法错误的是？";
        que.q[0] = "A.使用0.1%过氧乙酸溶液或500mg/L有效氯含氯消毒剂溶液喷雾进行消杀";
        que.q[1] = "B.水泥墙、木板墙、石灰墙为100 ml/m2";
        que.q[2] = "C.地面喷药量为200 ml/m2～300ml/m2";
        que.q[3] = "D.消毒处理时间为30分钟";
        que.ans = "D";
        que.shuoming = "病房、病家和禽舍的地面、墙壁等一般物体表面 0.1%过氧乙酸溶液或500mg/L有效氯含氯消毒剂溶液喷雾。泥土墙吸液量为150 ml/ m2～300 ml / m2，水泥墙、木板墙、石灰墙为100 ml/ m2，地面喷药量为200 ml/ m2～300ml / m2。以上消毒处理，作用时间应不少于60分钟。";
        QAQ.Add(que);
        //16
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对病人隔离的处理做法错误的是？";
        que.q[0] = "A.人禽流感医学观察病例、疑似病例、临床诊断和确诊病例均设在同一隔离病房";
        que.q[1] = "B.人禽流感医学观察病例、疑似病例和临床诊断病例病区病人一人一间，房间内设卫生间";
        que.q[2] = "C.原则上禁止探视、不设陪护，与病人相关的诊疗活动尽量在病区内进行";
        que.q[3] = "D.限制病人只在病室内活动";
        que.ans = "A";
        que.shuoming = "对人禽流感医学观察病例、疑似病例、临床诊断和确诊病例应尽早采取住院隔离，确诊病例可置同一房间，其余的应置单间隔离。限制病人只在病室内活动，原则上禁止探视、不设陪护，与病人相关的诊疗活动尽量在病区内进行。";
        QAQ.Add(que);
        //17
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对禽流感确诊患者临床症状描述正确的是？";
        que.q[0] = "A.感染H9N2亚型的部分患者甚至没有任何症状";
        que.q[1] = "B.早期表现类似普通型流感。主要为发热，体温大多持续在39℃以上，可伴有流涕、鼻塞、咳嗽、咽痛、头痛、肌肉酸痛和全身不适";
        que.q[2] = "C.患者呈急性起病，早期表现类似普通型流感";
        que.q[3] = "D.重症患者可出现高热不退，病情发展迅速，几乎所有患者都有临床表现明显的肺炎，可出现急性肺损伤、急性呼吸窘迫综合征（ARDS）、肺出血、胸腔积液、全血细胞减少、多脏器功能衰竭、休克及瑞氏（Reye）综合征等多种并发症";
        que.ans = "ABCD";
        que.shuoming = "感染H9N2亚型的患者通常仅有轻微的上呼吸道感染症状；感染H7N7亚型的患者主要表现为结膜炎；重症患者一般均为H5N1亚型病毒感染。患者呈急性起病，早期表现类似普通型流感。主要为发热，体温大多持续在39℃以上，可伴有流涕、鼻塞等症状。几乎所有患者都有临床表现明显的肺炎，可出现急性肺损伤、急性呼吸窘迫综合征（ARDS）、肺出血、胸腔积液、全血细胞减少、多脏器功能衰竭、休克及瑞氏（Reye）综合征等多种并发症。可继发细菌感染，发生败血症。";
        QAQ.Add(que);
        //que.que = "请对如下病例判断确定哪些是医学观察病例、疑似病例、临床诊断病例、及确诊病例？";
        //que.a = "A.有流行病学接触史，1周内出现流感样临床表现者。对于被诊断为医学观察病例者，医疗机构应当及时报告当地疾病预防控制机构，并对其进行7天医学观察";
        //que.b = "B.有流行病学接触史和临床表现，呼吸道分泌物或相关组织标本甲型流感病毒M1或NP抗原检测阳性或编码它们的核酸检测阳性者";
        //que.c = "C.被诊断为疑似病例，但无法进一步取得临床检验标本或实验室检查证据，而与其有共同接触史的人被诊断为确诊病例，并能够排除其它诊断者";
        //que.d = "D.有流行病学接触史和临床表现，从患者呼吸道分泌物标本或相关组织标本中分离出特定病毒，或采用其它方法，禽流感病毒亚型特异抗原或核酸检查阳性，或发病初期和恢复期双份血清禽流感病毒亚型毒株抗体滴度4倍或以上升高者";
        //que.ans = "a";
        //QAQ.Add(que);
        //que.que = "请对如下对禽流感病患的治疗手段正确的是？";
        //que.q[0] = "A.应在发病48小时内试用抗流感病毒药物";
        //que.q[1] = "B.重症患者应当送入ICU病房进行救治";
        //que.q[2] = "C.13岁（含13岁）以上人员，原则上同时具备下列条件体温正常、临床症状消失、胸部X线影像检查显示病灶明显吸收，并持续7天以上即可出院";
        //que.q[3] = "D.建议儿童使用阿司匹林或含阿司匹林以及其它水杨酸制剂的药物进行治疗";
        //que.ans = "ABC";
        //que.shuoming = "";
        //QAQ.Add(que);
        
        //18
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对戴防护口罩描述正确的是？";
        que.q[0] = "A.一只手托住防护口罩，有鼻夹的一面向外，将防护口罩罩住鼻、口及下巴，鼻夹部位向上紧贴面部";
        que.q[1] = "B.用另一只手将上方头带拉至头顶，再将下方头带拉过头顶，放在颈后双耳下";
        que.q[2] = "C.双手指尖放在金属鼻夹上，从中间位置开始，用手指向内按鼻夹，并分别向两侧移动和按压，根据鼻梁的形状塑造鼻夹";
        que.q[3] = "D.进行密合性检查。检查方法为：将双手完全盖住防护口罩，快速地呼气，若鼻夹附近有漏气应按佩戴方法步骤调整鼻夹，若漏气位于四周，应调整到不漏气为止";
        que.ans = "ABCD";
        que.shuoming = "";
        QAQ.Add(que);
        //19
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对戴防护帽描述正确的是？";
        que.q[0] = "A.将脑后的长发完成发髻";
        que.q[1] = "B.将帽子由额前向脑后罩于头部";
        que.q[2] = "C.刘海向上梳理";
        que.q[3] = "D.不让头发外漏";
        que.ans = "ABCD";
        que.shuoming = "";
        QAQ.Add(que);
        //20
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对穿防护服描述正确的是？";
        que.q[0] = "A.打开防护衣后，将拉链拉至合适位置";
        que.q[1] = "B.左右手握住左右袖口的同时，抓住防护服腰部的拉链开口处";
        que.q[2] = "C.先穿下肢，后穿上肢，然后将拉链拉至胸部，再将防护帽扣至头部，将拉链完全拉上后，密封拉链口";
        que.q[3] = "D.先穿下肢，后穿上肢，然后将拉链拉至背部，将拉链完全拉上后，密封拉链口";
        que.ans = "ABCD";
        que.shuoming = "";
        QAQ.Add(que);
        //21
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对戴防护眼镜描述正确的是？";
        que.q[0] = "A.佩戴前，应检查其是否破损";
        que.q[1] = "B.佩戴装置是否松懈";
        que.q[2] = "C.采用5%的摩尔马林溶液浸泡消毒";
        que.q[3] = "D.使用专用眼镜布擦拭镜片";
        que.ans = "AB";
        que.shuoming = "";
        QAQ.Add(que);
        //22
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对穿防护鞋描述正确的是？";
        que.q[0] = "A.检查有无破损";
        que.q[1] = "B.将防护服裤脚罩于胶鞋里面";
        que.q[2] = "C.采用5%的摩尔马林溶液浸泡消毒";
        que.q[3] = "D.将防护服裤腿罩在胶鞋外面";
        que.ans = "AB";
        que.shuoming = "";
        QAQ.Add(que);
        //23
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对戴乳胶手套描述正确的是？";
        que.q[0] = "A.洗手消毒";
        que.q[1] = "B.检查有无破损（充气检查）";
        que.q[2] = "C.手套套在防护服袖口外面";
        que.q[3] = "D.将手套嵌于防护服袖口内部，用袖口盖好";
        que.ans = "BC";
        que.shuoming = "";
        QAQ.Add(que);
        //24
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对戴防护手套描述正确的是？";
        que.q[0] = "A.洗手消毒";
        que.q[1] = "B.检查有无破损（充气检查）";
        que.q[2] = "C.手套套在防护服袖口外面";
        que.q[3] = "D.将手套嵌于防护服袖口内部，用袖口盖好";
        que.ans = "BC";
        que.shuoming = "";
        QAQ.Add(que);
        //25
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对脱防护口罩描述正确的是？";
        que.q[0] = "A.用戴手套的手轻托N95防护口罩外面";
        que.q[1] = "B.用脱去手套的手松开口罩头带脱去口罩";
        que.q[2] = "C.脱去手套的手轻托N95防护口罩外面";
        que.q[3] = "D.用戴手套的手松开口罩头带脱去口罩";
        que.ans = "AB";
        que.shuoming = "";
        QAQ.Add(que);
        //26
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对脱防护帽描述正确的是？";
        que.q[0] = "A.双手由前至后卷脱一次性工作帽";
        que.q[1] = "B.未捏拿帽子的手捏住另一个手套腕部的外面";
        que.q[2] = "C.翻转，并将一次性工作帽卷入手套内";
        que.q[3] = "D.直接脱去";
        que.ans = "ABC";
        que.shuoming = "";
        QAQ.Add(que);
        //27
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对脱防护服描述正确的是？";
        que.q[0] = "A.有封口贴的要解开防护服封口贴，先拉开前颈部的拉链到底部，再脱防护服的帽子";
        que.q[1] = "B.将袖子脱出后双手抓住防护服的内面，将防护服内面朝外轻轻卷至双脚跟部，连同胶鞋一同脱下，卷包好后放入医疗废物袋中";
        que.q[2] = "C.还带着内层手套，所以不用担心被污染，可以快速脱下防护服";
        que.q[3] = "D.注意，双手尽量避免接触防护服的外表面";
        que.ans = "ABD";
        que.shuoming = "";
        QAQ.Add(que);
        //28
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对摘防护眼镜描述正确的是？";
        que.q[0] = "A.一只手按住眼罩";
        que.q[1] = "B.另一个手摘除后脑部的系带";
        que.q[2] = "C.双手脱眼罩摘下";
        que.q[3] = "D.将眼罩放入医疗废物袋中";
        que.ans = "ABD";
        que.shuoming = "";
        QAQ.Add(que);
        //29
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对脱防护鞋描述正确的是？";
        que.q[0] = "A.脱防护服时，将防护服内面朝外轻轻卷至双脚跟部，连同胶鞋一同脱下";
        que.q[1] = "B.卷包好后放入医疗废物袋中";
        que.q[2] = "C.直接用手脱去防护靴";
        que.q[3] = "D.直接用脚退去防护靴";
        que.ans = "AB";
        que.shuoming = "";
        QAQ.Add(que);
        //30
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对脱乳胶手套描述正确的是？";
        que.q[0] = "A.脱去手套的手插入另一只手套内";
        que.q[1] = "B.将其往下翻转";
        que.q[2] = "C.并将口罩卷入手套内";
        que.q[3] = "D.直接脱去";
        que.ans = "ABC";
        que.shuoming = "";
        QAQ.Add(que);
        //31
        que.q = new List<string>();
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.q.Add("");
        que.que = "以下对脱防护手套描述正确的是？";
        que.q[0] = "A.消毒防护手套";
        que.q[1] = "B.脱下的手套放入医疗废物袋中";
        que.q[2] = "C.由于已经戴手套了，所以脱完防护服没必要进行洗手";
        que.q[3] = "D.诊疗护理不同的患者之间，为了节省资源，没有必要更换手套";
        que.ans = "AB";
        que.shuoming = "";
        QAQ.Add(que);
    }
}
