﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;

#pragma warning disable IDE1006

namespace HandSchool.JLU.JsonObject
{
    class RootObject<T>
    {
        public string id { get; set; }
        public int status { get; set; }
        public T[] value { get; set; }
        public string resName { get; set; }
        public string msg { get; set; }
        public string data { get; set; }
    }

    class ErrorMsg
    {
        public int status { get; set; }
        public string msg { get; set; }
    }

    class GPAValue
    {
        public float avgScoreBest { get; set; }
        public float avgScoreFirst { get; set; }
        public float gpaFirst { get; set; }
        public float gpaBest { get; set; }
    }

    class TeachClassMaster
    {
        public string maxStudCnt { get; set; }
        public LessonSchedule[] lessonSchedules { get; set; }
        public string studCnt { get; set; }
        public LessonTeacher[] lessonTeachers { get; set; }
        public string name { get; set; }
        public string tcmId { get; set; }
        public LessonSegment lessonSegment { get; set; }
    }

    class ScheduleValue
    {
        public TeachClassMaster teachClassMaster { get; set; }
        public string tcsId { get; set; }
        public object student { get; set; }
        public DateTime dateAccept { get; set; }
    }

    class ArchiveScoreValue
    {
        public string xkkh { get; set; }
        public TeachingTerm teachingTerm { get; set; }
        public string score { get; set; }
        public DateTime dateScore { get; set; }
        public object planDetail { get; set; }
        public string isPass { get; set; }
        public string classHour { get; set; }
        public Course course { get; set; }
        public string isReselect { get; set; }
        public string scoreNum { get; set; }
        public Student student { get; set; }
        public string asId { get; set; }
        public string type5 { get; set; }
        public string gpoint { get; set; }
        public string credit { get; set; }
        public object notes { get; set; }
        public string selectType { get; set; }
    }

    class LessonSegment
    {
        public string lssgId { get; set; }
        public Lesson lesson { get; set; }
        public string fullName { get; set; }
    }

    class Lesson
    {
        public CourseInfo courseInfo { get; set; }
    }

    class CourseInfo
    {
        public string courName { get; set; }
    }

    class Course
    {
        public string englishName { get; set; }
        public string courType3 { get; set; }
        public string adviceHour { get; set; }
        public string batch { get; set; }
        public string activeStatus { get; set; }
        public string type5 { get; set; }
        public string extCourseNo { get; set; }
        public string courName { get; set; }
        public string courseId { get; set; }
        public string courType1 { get; set; }
        public string adviceCredit { get; set; }
        public string courType2 { get; set; }
        public string isPe { get; set; }
        public string isCore { get; set; }
    }

    class LessonSchedule
    {
        public Classroom classroom { get; set; }
        public TimeBlock timeBlock { get; set; }
        public string lsschId { get; set; }
    }

    class Classroom
    {
        public string roomId { get; set; }
        public string fullName { get; set; }
    }

    class TimeBlock
    {
        public string classSet { get; set; }
        public string name { get; set; }
        public string endWeek { get; set; }
        public string beginWeek { get; set; }
        public string tmbId { get; set; }
        public string dayOfWeek { get; set; }
        public string weekOddEven { get; set; }
    }

    class LessonTeacher
    {
        public Teacher teacher { get; set; }
    }

    class Teacher
    {
        public string name { get; set; }
        public string teacherId { get; set; }
    }

    class TeachingTerm
    {
        public string termName { get; set; }
        public DateTime startDate { get; set; }
        public string termSeq { get; set; }
        public DateTime examDate { get; set; }
        public string activeStage { get; set; }
        public string year { get; set; }
        public DateTime vacationDate { get; set; }
        public string weeks { get; set; }
        public string termId { get; set; }
        public string egrade { get; set; }
    }

    class Student
    {
        public string studId { get; set; }
        public string name { get; set; }
        public AdminClass adminClass { get; set; }
        public string admissionYear { get; set; }
        public string studStatus { get; set; }
        public string studNo { get; set; }
        public string egrade { get; set; }
    }

    class AdminClass
    {
        public string adcId { get; set; }
        public string formalStudCnt { get; set; }
        public string graduateYear { get; set; }
        public string classNo { get; set; }
        public string studCnt { get; set; }
        public string className { get; set; }
        public string admissionYear { get; set; }
        public string campus { get; set; }
    }

    class MessageBox
    {
        public int count { get; set; }
        public int errno { get; set; }
        public string identifier { get; set; }
        public MessagePiece[] items { get; set; }
        public string label { get; set; }
        public string msg { get; set; }
        public int status { get; set; }
    }

    class MessagePiece
    {
        public MessageMain message { get; set; }
        public string msgInboxId { get; set; }
        public MessageReceiver receiver { get; set; }
        public object dateRead { get; set; }
        public string activeStatus { get; set; }
        public string hasReaded { get; set; }
        public object dateReceive { get; set; }
    }

    class MessageMain
    {
        public MessageSender sender { get; set; }
        public string body { get; set; }
        public string title { get; set; }
        public DateTime dateExpire { get; set; }
        public string messageId { get; set; }
        public DateTime dateCreate { get; set; }
    }

    class MessageReceiver
    {
        public MessageSchool school { get; set; }
        public string name { get; set; }
    }

    class MessageSchool
    {
        public string schoolName { get; set; }
    }

    class MessageSender
    {
        public string name { get; set; }
    }

    class CollegeInfo
    {
        public string schoolName { get; set; }
        public string website { get; set; }
        public string activeStatus { get; set; }
        public string abbr { get; set; }
        public object departments { get; set; }
        public string extSchNo { get; set; }
        public string schoolType { get; set; }
        public string englishName { get; set; }
        public Staff staff { get; set; }
        public string division { get; set; }
        public string schId { get; set; }
        public AdminClass[] adminClasses { get; set; }
        public string telephone { get; set; }
        public string introduction { get; set; }
        public string xscNo { get; set; }
        public string campus { get; set; }
    }
    
    class Staff
    {
        public string staffId { get; set; }
        public string staffStatus { get; set; }
        public string name { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }
        public string workerId { get; set; }
    }

    class LoginValue
    {
        public string loginMethod { get; set; }
        public CacheUpdate cacheUpdate { get; set; }
        public string[] menusFile { get; set; }
        public int trulySch { get; set; }
        public GroupsInfo[] groupsInfo { get; set; }
        public string firstLogin { get; set; }
        public DefRes defRes { get; set; }
        public string userType { get; set; }
        public DateTime sysTime { get; set; }
        public string nickName { get; set; }
        public int userId { get; set; }
        public string welcome { get; set; }
        public string loginName { get; set; }

        public class CacheUpdate
        {
            public long sysDict { get; set; }
            public long code { get; set; }
        }

        public class DefRes
        {
            public int adcId { get; set; }
            public int term_l { get; set; }
            public int university { get; set; }
            public int teachingTerm { get; set; }
            public int school { get; set; }
            public int department { get; set; }
            public int term_a { get; set; }
            public int schType { get; set; }
            public int personId { get; set; }
            public int year { get; set; }
            public int term_s { get; set; }
            public int campus { get; set; }
        }

        public class GroupsInfo
        {
            public int groupId { get; set; }
            public string groupName { get; set; }
            public string menuFile { get; set; }
        }
    }

    class AlreadyKnownThings
    {
        public static NameValueCollection Division { get; } = new NameValueCollection
        {
            { "1420", "人文学部" },
            { "1421", "社会科学学部" },
            { "1422", "理学部" },
            { "1423", "工学部" },
            { "1424", "信息科学学部" },
            { "1425", "地球科学学部" },
            { "1426", "白求恩医学部" },
            { "1428", "农学部" }
        };

        public static NameValueCollection Campus { get; } = new NameValueCollection
        {
            { "1401", "前卫校区" },
            { "1402", "南岭校区" },
            { "1403", "新民校区" },
            { "1404", "朝阳校区" },
            { "1405", "南湖校区" },
            { "1406", "和平校区" }
        };

        public static List<CollegeOverview> Colleges { get; } = new List<CollegeOverview>
        {
            new CollegeOverview("哲学社会学院", "1401", "1420", "174"),
            new CollegeOverview("文学院", "1401", "1420", "175"),
            new CollegeOverview("外国语学院", "1401", "1420", "104"),
            new CollegeOverview("艺术学院", "1401", "1420", "105"),
            new CollegeOverview("体育学院", "1401", "1420", "106"),
            new CollegeOverview("新闻与传播学院", "1401", "1420", "182"),
            new CollegeOverview("经济学院", "1401", "1421", "107"),
            new CollegeOverview("法学院", "1401", "1421", "108"),
            new CollegeOverview("行政学院", "1401", "1421", "109"),
            new CollegeOverview("商学院", "1401", "1421", "110"),
            new CollegeOverview("马克思主义学院", "1405", "1421", "111"),
            new CollegeOverview("金融学院", "1401", "1421", "102"),
            new CollegeOverview("公共外交学院", "1401", "1421", "181"),
            new CollegeOverview("数学学院", "1401", "1422", "112"),
            new CollegeOverview("物理学院", "1401", "1422", "113"),
            new CollegeOverview("化学学院", "1401", "1422", "114"),
            new CollegeOverview("生命科学学院", "1401", "1422", "115"),
            new CollegeOverview("机械科学与工程学院", "1402", "1423", "116"),
            new CollegeOverview("汽车工程学院", "1402", "1423", "117"),
            new CollegeOverview("材料科学与工程学院", "1402", "1423", "118"),
            new CollegeOverview("交通学院", "1402", "1423", "119"),
            new CollegeOverview("生物与农业工程学院", "1402", "1423", "120"),
            new CollegeOverview("管理学院", "1402", "1423", "121"),
            new CollegeOverview("工程训练中心", null, null, "183"),
            new CollegeOverview("电子科学与工程学院", "1401", "1424", "122"),
            new CollegeOverview("通信工程学院", "1405", "1424", "123"),
            new CollegeOverview("计算机科学与技术学院", "1401", "1424", "100"),
            new CollegeOverview("软件学院", "1401", "1424", "101"),
            new CollegeOverview("地球科学学院", "1404", "1425", "124"),
            new CollegeOverview("地球探测科学与技术学院", "1404", "1425", "125"),
            new CollegeOverview("建设工程学院", "1404", "1425", "126"),
            new CollegeOverview("环境与资源学院", "1404", "1425", "127"),
            new CollegeOverview("仪器科学与电气工程学院", "1404", "1425", "128"),
            new CollegeOverview("白求恩医学院", "1403", "1426", "103"),
            new CollegeOverview("基础医学院", "1403", "1426", "129"),
            new CollegeOverview("公共卫生学院", "1403", "1426", "130"),
            new CollegeOverview("药学院", "1403", "1426", "131"),
            new CollegeOverview("护理学院", "1403", "1426", "132"),
            new CollegeOverview("第一临床医学院", "1403", "1426", "133"),
            new CollegeOverview("第二临床医学院", "1403", "1426", "134"),
            new CollegeOverview("第三临床医学院", "1403", "1426", "135"),
            new CollegeOverview("口腔医学院", "1403", "1426", "136"),
            new CollegeOverview("临床医学院", "1403", "1426", "176"),
            new CollegeOverview("畜牧兽医学院", "1406", "1428", "137"),
            new CollegeOverview("植物科学学院", "1406", "1428", "138"),
            new CollegeOverview("军需科技学院", "1406", "1428", "139"),
            new CollegeOverview("农学部公共教学中心", null, "1428", "149"),
            new CollegeOverview("动物科学学院", "1406", "1428", "177"),
            new CollegeOverview("动物医学学院", "1406", "1428", "178"),
            new CollegeOverview("食品科学与工程学院", "1406", "1423", "187"),
            new CollegeOverview("应用技术学院", "1405", null, "168"),
            new CollegeOverview("公共外语教育学院", null, null, "141"),
            new CollegeOverview("公共体育教学与研究中心", null, null, "142"),
            new CollegeOverview("公共数学教学与研究中心", null, null, "143"),
            new CollegeOverview("公共物理教学与研究中心", null, null, "144"),
            new CollegeOverview("公共化学教学与研究中心", null, null, "145"),
            new CollegeOverview("公共计算机教学与研究中心", null, null, "146"),
            new CollegeOverview("机械基础教学与研究中心", null, "1423", "147"),
            new CollegeOverview("艺术教学与研究中心", null, null, "148"),
            new CollegeOverview("古生物与地学研究中心", null, null, "150"),
            new CollegeOverview("综合信息矿产预测研究所", null, null, "151"),
            new CollegeOverview("汽车动态模拟国家重点实", null, null, "152"),
            new CollegeOverview("塑性与超塑性研究所", null, null, "153"),
            new CollegeOverview("辊锻工艺研究所", null, null, "154"),
            new CollegeOverview("链传动研究所", null, null, "155"),
            new CollegeOverview("测试中心", null, null, "156"),
            new CollegeOverview("军事理论教研室", null, null, "173"),
            new CollegeOverview("理论化学研究所", null, null, "157"),
            new CollegeOverview("分子酶工程教育部重点实验室", null, null, "158"),
            new CollegeOverview("原子与分子物理研究所", null, null, "159"),
            new CollegeOverview("超分子结构与谱学教育部", null, null, "160"),
            new CollegeOverview("农学部实验动物中心", null, null, "161"),
            new CollegeOverview("古籍研究所", null, null, "162"),
            new CollegeOverview("东北亚研究院", null, null, "163"),
            new CollegeOverview("高等教育研究所", null, null, "164"),
            new CollegeOverview("经济信息学院", null, null, "165"),
            new CollegeOverview("工商管理学院", null, null, "166"),
            new CollegeOverview("软件学院(珠海)", null, null, "167"),
            new CollegeOverview("外事服务中心", null, null, "169"),
            new CollegeOverview("网络中心", null, null, "170"),
            new CollegeOverview("中心校区", "1401", null, "201"),
            new CollegeOverview("东区教务办", "1402", null, "202"),
            new CollegeOverview("北区教务办", "1404", null, "204"),
            new CollegeOverview("西区教务办", "1406", null, "206"),
            new CollegeOverview("待定", null, null, "140"),
            new CollegeOverview("公选课", null, null, "-3"),
            new CollegeOverview("所有学院", null, null, "-1"),
            new CollegeOverview("未分配", null, null, "-2"),
            new CollegeOverview("管理部门", null, null, "-4"),
            new CollegeOverview("再生医学研究所", null, null, "171"),
            new CollegeOverview("实验动物中心", null, null, "172"),
            new CollegeOverview("学生心理健康指导中心", null, null, "184"),
            new CollegeOverview("人兽共患病研究所", "1401", null, "209"),
            new CollegeOverview("创新创业教育学院", null, null, "191"),
            new CollegeOverview("就业指导中心", null, null, "210"),
            new CollegeOverview("数学研究所", null, null, "180"),
            new CollegeOverview("注册与考试中心", null, null, "211"),
            new CollegeOverview("莱姆顿学院", null, null, "179"),
            new CollegeOverview("超硬材料国家重点实验室", "1401", null, "208")
        };

        public struct CollegeOverview
        {
            public string Name;
            public string Campus;
            public string Division;
            public string Id;

            public CollegeOverview(string name, string campus, string division, string id)
            {
                Name = name;
                Campus = campus;
                Division = division;
                Id = id;
            }

            public string ToString(string type)
            {
                if (type == "option")
                {
                    string ret = $"<option value=\"{Id}\"";
                    if (Campus != null) ret += $" data-campus=\"{Campus}\"";
                    if (Division != null) ret += $" data-part=\"{Division}\"";
                    ret += $">{Name}</option>";
                    return ret;
                }
                return Name;
            }
        }
    }
}

#pragma warning restore
