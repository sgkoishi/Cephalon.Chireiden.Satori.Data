﻿using System;
using System.Collections.Generic;

namespace Cephalon.Chireiden.Satori.Warframe
{
    public partial class GameData
    {
        public static Dictionary<string, string> Acolyst;
        public static Dictionary<string, (string Title, string Detail)> Conclave;
        public static Dictionary<Faction, string> Faction;
        public static Dictionary<string, string> Item;
        public static Dictionary<string, string> JobDesc;
        public static Dictionary<string, string> JobName;
        public static Dictionary<MissionType, string> Mission;
        public static Dictionary<string, Node> Nodes;
        public static Dictionary<string, string> Planet;
        public static List<Riven.RivenAttribute> RivenAttributes;
        public static Dictionary<string, string> RivenRedirection;
        public static Dictionary<string, string> Sortie;
        public static Dictionary<string, string> Syndicate;
        public static Dictionary<string, string> Tileset;
        public static Dictionary<VoidModifier, string> VoidModifier;
        public static Dictionary<string, List<string>> WeaponAlias;
        public static Dictionary<WeaponType, List<string>> WeaponTypes;
        public static Dictionary<string, Reward> BountyRewards;

        public static void Init()
        {
            Instance = new GameData();
            InitPlanets();
            InitItems();
            InitNodes();
            InitEnums();
            InitSorties();
            InitAcolysts();
            InitConclaves();
            InitWeaponAlias();
            InitTilesets();
            InitRivens();
            InitStndicates();
            InitBounty();
            Instance.Load();
            foreach (var item in Instance.GameNodes)
            {
                var name = Planet[item.SystemName] + item.Name;
                if (Nodes.ContainsKey(item.UniqueName))
                {
                    var k = Nodes[item.UniqueName];
                    if (name != k.ToString())
                    {
                        Console.WriteLine($"Name conflict: {item.UniqueName} ({name} - {k})");
                    }
                }
                else
                {
                    Console.WriteLine($"Node missing: {item.UniqueName} ({name})");
                }
            }
        }

        private static void InitBounty()
        {
            InitJobs();
            BountyRewards = new Dictionary<string, Reward>
            {
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/GhoulBountyTableARewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("内融核心", 100),
                            ("古纪H2遗物", 1),
                            ("猎人肾上腺素", 1),
                            ("加密的日记碎片", 1),
                            ("猎人战备", 1),
                            ("史度巴蓝图", 1),
                            ("希图斯幽魂", 1),
                            ("夜灵之息", 5),
                            ("古纪T2遗物", 1),
                            ("猎人追踪", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/GhoulBountyTableBRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("内融核心", 300),
                            ("中纪B4遗物", 1),
                            ("猎人复元", 1),
                            ("加密的日记碎片", 1),
                            ("猎人协力", 1),
                            ("夸塔克蓝图", 1),
                            ("希图斯幽魂", 1),
                            ("夜灵之息", 5),
                            ("中纪V7遗物", 1),
                            ("猎人命令", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierATableARewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("蓄能重划", 1),
                            ("奥席金属", 100),
                            ("现金匣", 1500),
                            ("内融核心", 50),
                            ("伊莱体", 15),
                            ("Gara机体蓝图", 1),
                            ("抵近射击", 1),
                            ("简化", 1),
                            ("非晶态合金", 2)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierATableBRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("压迫点", 1),
                            ("永冻晶矿", 100),
                            ("现金匣", 1500),
                            ("内融核心", 50),
                            ("葛克度", 15),
                            ("Gara机体蓝图", 1),
                            ("黄蜂蛰刺", 1),
                            ("延伸", 1),
                            ("非晶态合金", 2)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierATableCRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("生命力", 1),
                            ("生物质", 200),
                            ("现金匣", 1500),
                            ("内融核心", 50),
                            ("尼蒐荚", 15),
                            ("Gara机体蓝图", 1),
                            ("抵近射击", 1),
                            ("聚精会神", 1),
                            ("镓", 2)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierBTableARewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("钢铁纤维", 1),
                            ("奥席金属", 200),
                            ("现金匣", 2500),
                            ("内融核心", 100),
                            ("古纪B3遗物", 1),
                            ("Gara系统蓝图", 1),
                            ("蓄力装填", 1),
                            ("炙热黄蜂", 1),
                            ("控制模块", 2)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierBTableBRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("能量转化", 1),
                            ("永冻晶矿", 200),
                            ("现金匣", 2500),
                            ("内融核心", 100),
                            ("古纪V5遗物", 1),
                            ("Gara系统蓝图", 1),
                            ("灵敏扳机", 1),
                            ("收割螺旋", 1),
                            ("神经传感器", 2)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierBTableCRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("致命一击", 1),
                            ("电路", 300),
                            ("现金匣", 2500),
                            ("内融核心", 100),
                            ("古纪T2遗物", 1),
                            ("Gara系统蓝图", 1),
                            ("耐久强化", 1),
                            ("冷面狂怒", 1),
                            ("Orokin电池", 2)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierCTableARewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("角斗士圣盾", 1),
                            ("MADIRAI晶体", 1),
                            ("希图斯幽魂", 1),
                            ("内融核心", 200),
                            ("前纪D2遗物", 1),
                            ("Gara头部神经光元蓝图", 1),
                            ("预言协约", 1),
                            ("飞光荒疫", 1),
                            ("私法补给", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierCTableBRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("私法军备", 1),
                            ("VAZARIN晶体", 1),
                            ("UNAIRU晶体", 1),
                            ("内融核心", 200),
                            ("前纪Z1遗物", 1),
                            ("Gara头部神经光元蓝图", 1),
                            ("角斗士威猛", 1),
                            ("破碎之风", 1),
                            ("预言探求", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierCTableCRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("预言契约", 1),
                            ("NARAMON晶体", 1),
                            ("ZENURIK晶体", 1),
                            ("内融核心", 200),
                            ("前纪B2遗物", 1),
                            ("Gara头部神经光元蓝图", 1),
                            ("私法热诚", 1),
                            ("旋风虎击", 1),
                            ("角斗士钳制", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierDTableARewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("角斗士猛突", 1),
                            ("UNAIRU晶体", 1),
                            ("MADIRAI晶体", 1),
                            ("内融核心", 300),
                            ("中纪L1遗物", 1),
                            ("希图斯幽魂", 1),
                            ("预言通灵", 1),
                            ("终焉风暴", 1),
                            ("私法侵犯", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierDTableBRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("私法活力", 1),
                            ("ZENURIK晶体", 1),
                            ("VAZARIN晶体", 1),
                            ("内融核心", 300),
                            ("中纪N8遗物", 1),
                            ("希图斯幽魂", 1),
                            ("角斗士决心", 1),
                            ("纵横双子", 1),
                            ("预言神密", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierDTableCRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("预言启示", 1),
                            ("赤毒", 100),
                            ("NARAMON晶体", 1),
                            ("内融核心", 300),
                            ("中纪V7遗物", 1),
                            ("希图斯幽魂", 1),
                            ("私法追踪", 1),
                            ("沉没之爪", 1),
                            ("角斗士灵巧", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierETableARewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("夜灵之息", 5),
                            ("后纪K3遗物", 1),
                            ("希图斯幽魂", 2),
                            ("赤毒", 300),
                            ("弗拉克斯亡魂左拳套", 1),
                            ("雕斩螳螂", 1),
                            ("夜灵晶体蓝图", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierETableBRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("夜灵之息", 5),
                            ("后纪O3遗物", 1),
                            ("希图斯幽魂", 2),
                            ("赤毒", 300),
                            ("弗拉克斯亡魂右拳套", 1),
                            ("猎鹰俯击", 1),
                            ("夜灵晶体蓝图", 1)
                        }
                    }
                },
                {
                    "/Lotus/Types/Game/MissionDecks/EidolonJobMissionRewards/TierETableCRewards",
                    new Reward
                    {
                        Rewards = new List<(string Name, int Count)>
                        {
                            ("夜灵之息", 5),
                            ("后纪L2遗物", 1),
                            ("希图斯幽魂", 2),
                            ("赤毒", 300),
                            ("弗拉克斯亡魂蓝图", 1),
                            ("回转尖峰", 1),
                            ("夜灵晶体蓝图", 1)
                        }
                    }
                }
            };
        }

        private static void InitAcolysts()
        {
            Acolyst = new Dictionary<string, string>
            {
                {"/Lotus/Types/Enemies/Acolytes/ControlAcolyteAgent", "折磨"},
                {"/Lotus/Types/Enemies/Acolytes/DuellistAcolyteAgent", "暴力"},
                {"/Lotus/Types/Enemies/Acolytes/HeavyAcolyteAgent", "怨恨"},
                {"/Lotus/Types/Enemies/Acolytes/RogueAcolyteAgent", "躁狂"},
                {"/Lotus/Types/Enemies/Acolytes/StrikerAcolyteAgent", "焦虑"}
            };
        }

        private static void InitConclaves()
        {
            Conclave = new Dictionary<string, (string Title, string Detail)>
            {
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPowerEASY", ("虚空绘师", "以Warframe的能力击杀敌人[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPowerMEDIUM", ("虚空绘师", "以Warframe的能力击杀敌人[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPowerHARD", ("专注的堡垒绘师", "以Warframe的能力击杀敌人[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeFlagCaptureEASY", ("恶棍", "夺取了[num]个中枢")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeFlagCaptureMEDIUM", ("恶棍", "夺取了[num]个中枢")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeFlagReturnEASY", ("救星", "将队上的中枢归还了[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeFlagReturnMEDIUM", ("救星", "将队上的中枢归还了[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsComboEASY", ("技巧熟练", "使用近战武器、枪炮或能力任意两种组合击杀了[num]名对手")},
                {
                    "/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsComboMEDIUM",
                    ("技巧熟练", "使用近战武器、枪炮或能力任意两种组合击杀了[num]名对手")
                },
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsMeleeEASY", ("角斗士", "以近战击杀敌人[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsMeleeMEDIUM", ("角斗士", "以近战击杀敌人[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsMeleeHARD", ("专注的角斗士", "以近战击杀敌人[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPaybackEASY", ("复仇", "击杀[num]名曾经杀掉你的敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPaybackMEDIUM", ("复仇", "击杀[num]名曾经杀掉你的敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPrimaryEASY", ("首要目标", "以主武器击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPrimaryHARD", ("专注首要目标", "以主武器击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsPrimaryMEDIUM", ("首要目标", "以主武器击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsSecondaryEASY", ("次要目标", "于一场竞赛中, 以副武器击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsSecondaryHARD", ("专注次要目标", "于一场竞赛中, 以副武器击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsSecondaryMEDIUM", ("次要目标", "于一场竞赛中, 以副武器击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsStreakDominationEASY", ("支配", "击杀[num]名敌人, 并且不被他们击杀")},
                {
                    "/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsStreakDominationMEDIUM",
                    ("支配", "击杀[num]名敌人, 并且不被他们击杀")
                },
                {
                    "/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsStreakDomination_EASY",
                    ("支配", "击杀[num]名敌人, 并且不被他们击杀")
                },
                {
                    "/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsStreakDomination_MEDIUM",
                    ("支配", "击杀[num]名敌人, 并且不被他们击杀")
                },
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsWhileInAirEasy", ("空袭", "滞留空中时击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsWhileInAirMEDIUM", ("空袭", "滞留空中时击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsWhileInAirHARD", ("专注空袭", "滞留空中时击杀[num]个敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsTargetInAirEASY", ("反空袭", "击杀[num]个空中的敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsTargetInAirHARD", ("专注反空袭", "击杀[num]个空中的敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsTargetInAirMEDIUM", ("反空袭", "击杀[num]个空中的敌人")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsWhileSlidingEASY", ("滑行突击", "于一场竞赛中, 滑行时击杀[num]个敌人")},
                {
                    "/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsWhileSlidingHARD",
                    ("专注滑行突击", "于一场竞赛中, 滑行时击杀[num]个敌人")
                },
                {
                    "/Lotus/PVPChallengeTypes/PVPTimedChallengeKillsWhileSlidingMEDIUM",
                    ("滑行突击", "于一场竞赛中, 滑行时击杀[num]个敌人")
                },
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeMatchCompleteEASY", ("紧盯目标", "完成[num]场竞赛")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeMatchCompleteMEDIUM", ("紧盯目标", "完成[num]场竞赛")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballCatchesEASY", ("注意！", "传球给队友[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballCatchesHARD", ("集中注意！", "传球给队友[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballCatchesMEDIUM", ("注意！", "传球给队友[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballChecksEASY", ("门都没有", "殴打带着球的对手[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballChecksMEDIUM", ("门都没有", "殴打带着球的对手[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballChecksHARD", ("让你门都没有", "殴打带着球的对手[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballGoalsEASY", ("得分！", "获得[num]分")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballGoalsMEDIUM", ("得分！", "获得[num]分")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballGoalsHARD", ("集中得分！", "获得[num]分")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballPassesEASY", ("使命必达！", "成功传球给队友[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballPassesMEDIUM", ("使命必达！", "成功传球给队友[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballStealsEASY", ("抢与夺", "成功偷球[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballStealsMEDIUM", ("抢与夺", "成功偷球[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballInterceptionsEASY", ("拦截！", "拦截敌人的球[num]次")},
                {"/Lotus/PVPChallengeTypes/PVPTimedChallengeSpeedballInterceptionsMEDIUM", ("拦截！", "拦截敌人的球[num]次")}
            };
        }

        private static void InitEnums()
        {
            VoidModifier = new Dictionary<VoidModifier, string>
            {
                {Warframe.VoidModifier.VoidT1, "古纪"},
                {Warframe.VoidModifier.VoidT2, "前纪"},
                {Warframe.VoidModifier.VoidT3, "中纪"},
                {Warframe.VoidModifier.VoidT4, "后纪"}
            };
            Faction = new Dictionary<Faction, string>
            {
                {Warframe.Faction.FC_CORPUS, "Corpus"},
                {Warframe.Faction.FC_CORRUPTED, "堕落者"},
                {Warframe.Faction.FC_GRINEER, "Grineer"},
                {Warframe.Faction.FC_INFESTATION, "Infested"},
                {Warframe.Faction.FC_OROKIN, "Orokin"}
            };
            Mission = new Dictionary<MissionType, string>
            {
                {MissionType.MT_UNKNOWN, "数据删除"},
                {MissionType.MT_ARENA, "竞技场"},
                {MissionType.MT_ASSASSINATION, "刺杀"},
                {MissionType.MT_ASSAULT, "强袭"},
                {MissionType.MT_CAPTURE, "捕获"},
                {MissionType.MT_DEFENSE, "防御"},
                {MissionType.MT_EVACUATION, "叛逃"},
                {MissionType.MT_EXCAVATE, "挖掘"},
                {MissionType.MT_EXTERMINATION, "歼灭"},
                {MissionType.MT_HIVE, "清巢"},
                {MissionType.MT_INTEL, "间谍"},
                {MissionType.MT_LANDSCAPE, "自由漫步"},
                {MissionType.MT_MOBILE_DEFENSE, "移动防御"},
                {MissionType.MT_PVP, "武型秘仪"},
                {MissionType.MT_RESCUE, "救援"},
                {MissionType.MT_RETRIEVAL, "劫持"},
                {MissionType.MT_SABOTAGE, "破坏"},
                {MissionType.MT_SECTOR, "黑暗地带"},
                {MissionType.MT_SURVIVAL, "生存"},
                {MissionType.MT_TERRITORY, "拦截"},
                {MissionType.MT_PURSUIT, "追击"},
                {MissionType.MT_INFESTEDSALVAGE, "Infested资源回收"},
                {MissionType.MT_RELAY, "中继站"},
                {MissionType.MT_RUSH, "突袭"}
            };
            WeaponTypes = new Dictionary<WeaponType, List<string>>
            {
                {
                    WeaponType.Melee,
                    new List<string>
                    {
                        "ACK & BRUNT",
                        "AMPHIS",
                        "ANKU",
                        "ANKYROS PRIME",
                        "ANKYROS",
                        "ARCA TITRON",
                        "ATTERAX",
                        "BALLA",
                        "BO PRIME",
                        "BO",
                        "BOLTACE",
                        "BROKEN SCEPTER",
                        "BROKEN WAR",
                        "CADUS",
                        "CASSOWAR",
                        "CAUSTACYST",
                        "CERAMIC DAGGER",
                        "CERATA",
                        "CRONUS",
                        "CYATH",
                        "DAKRA PRIME",
                        "DARK DAGGER",
                        "DARK SPLIT-SWORD",
                        "DARK SWORD",
                        "DECONSTRUCTOR PRIME",
                        "DECONSTRUCTOR",
                        "DEHTAT",
                        "DESTREZA PRIME",
                        "DESTREZA",
                        "DEX DAKRA",
                        "DRAGON NIKANA",
                        "DUAL CLEAVERS",
                        "DUAL ETHER",
                        "DUAL HEAT SWORDS",
                        "DUAL ICHOR",
                        "DUAL KAMAS PRIME",
                        "DUAL KAMAS",
                        "DUAL KERES",
                        "DUAL RAZA",
                        "DUAL SKANA",
                        "DUAL ZOREN",
                        "ENDURA",
                        "ETHER DAGGERS",
                        "ETHER REAPER",
                        "ETHER SWORD",
                        "FANG PRIME",
                        "FANG",
                        "FRAGOR PRIME",
                        "FRAGOR",
                        "FURAX WRAITH",
                        "FURAX",
                        "GALATINE PRIME",
                        "GALATINE",
                        "GAZAL MACHETE",
                        "GLAIVE PRIME",
                        "GLAIVE",
                        "GRAM",
                        "GUANDAO",
                        "GUNSEN",
                        "HALIKAR",
                        "HATE",
                        "HEAT DAGGER",
                        "HEAT SWORD",
                        "HELIOCOR",
                        "HIRUDO",
                        "JAT KITTAG",
                        "JAT KUSAR",
                        "JAW SWORD",
                        "KAMA",
                        "KARYST",
                        "KESHEG",
                        "KESTREL",
                        "KOGAKE PRIME",
                        "KOGAKE",
                        "KROHKUR",
                        "KRONEN PRIME",
                        "KRONEN",
                        "KRONSH",
                        "LACERA",
                        "LECTA",
                        "LESION",
                        "MACHETE WRAITH",
                        "MACHETE",
                        "MAGISTAR",
                        "MEWAN",
                        "MIOS",
                        "MIRE",
                        "MK1-BO",
                        "MK1-FURAX",
                        "NAMI SKYLA PRIME",
                        "NAMI SKYLA",
                        "NAMI SOLO",
                        "NIKANA PRIME",
                        "NIKANA",
                        "NINKONDI",
                        "OBEX",
                        "OHMA",
                        "OKINA",
                        "OOLTHA",
                        "ORTHOS PRIME",
                        "ORTHOS",
                        "ORVIUS",
                        "PANGOLIN SWORD",
                        "PLAGUE KEEWAR",
                        "PLAGUE KRIPATH",
                        "PLASMA SWORD",
                        "PRISMA DUAL CLEAVERS",
                        "PRISMA MACHETE",
                        "PRISMA OBEX",
                        "PRISMA SKANA",
                        "PROVA VANDAL",
                        "PROVA",
                        "RAKTA DARK DAGGER",
                        "REAPER PRIME",
                        "REDEEMER",
                        "RIPKAS",
                        "SANCTI MAGISTAR",
                        "SARPA",
                        "SCINDO PRIME",
                        "SCINDO",
                        "SCOLIAC",
                        "SECURA LECTA",
                        "SERRO",
                        "SHAKU",
                        "SHEEV",
                        "SIBEAR",
                        "SIGMA & OCTANTIS",
                        "SILVA & AEGIS PRIME",
                        "SILVA & AEGIS",
                        "SKANA PRIME",
                        "SKANA",
                        "SKIAJATI",
                        "SYDON",
                        "SYNOID HELIOCOR",
                        "TEKKO",
                        "TELOS BOLTACE",
                        "TIPEDO",
                        "TONBO",
                        "TWIN BASOLK",
                        "TWIN KROHKUR",
                        "VAYKOR SYDON",
                        "VENKA PRIME",
                        "VENKA",
                        "VOLNUS",
                        "WAR",
                        "ZAW",
                        "ZENISTAR"
                    }
                },
                {
                    WeaponType.Shotgun,
                    new List<string>
                    {
                        "ARCA PLASMOR",
                        "ASTILLA",
                        "BOAR PRIME",
                        "BOAR",
                        "CONVECTRIX",
                        "CORINTH",
                        "DRAKGOON",
                        "HEK",
                        "KOHM",
                        "MK1-STRUN",
                        "PHAGE",
                        "PHANTASMA",
                        "SANCTI TIGRIS",
                        "SOBEK",
                        "STRUN WRAITH",
                        "STRUN",
                        "SWEEPER PRIME",
                        "SWEEPER",
                        "TIGRIS PRIME",
                        "TIGRIS",
                        "VAYKOR HEK"
                    }
                },
                {
                    WeaponType.Pistol,
                    new List<string>
                    {
                        "ACRID",
                        "AFURIS",
                        "AKBOLTO PRIME",
                        "AKBOLTO",
                        "AKBRONCO PRIME",
                        "AKBRONCO",
                        "AKJAGARA",
                        "AKLATO",
                        "AKLEX PRIME",
                        "AKLEX",
                        "AKMAGNUS",
                        "AKSOMATI",
                        "AKSTILETTO PRIME",
                        "AKSTILETTO",
                        "AKVASTO",
                        "AKZANI",
                        "ANGSTRUM",
                        "ARCA SCISCO",
                        "ATOMOS",
                        "AZIMA",
                        "BALLISTICA PRIME",
                        "BALLISTICA",
                        "BOLTO",
                        "BRAKK",
                        "BRONCO PRIME",
                        "BRONCO",
                        "BURST LASER PRIME",
                        "BURST LASER",
                        "CASTANAS",
                        "CESTRA",
                        "CYCRON",
                        "DESPAIR",
                        "DETRON",
                        "DEX FURIS",
                        "DUAL CESTRA",
                        "DUAL TOXOCYST",
                        "EMBOLIST",
                        "EUPHONA PRIME",
                        "FURIS",
                        "FUSILAI",
                        "GAMMACOR",
                        "HIKOU PRIME",
                        "HIKOU",
                        "HYSTRIX",
                        "KNELL",
                        "KOHMAK",
                        "KRAKEN",
                        "KULSTAR",
                        "KUNAI",
                        "LATO PRIME",
                        "LATO VANDAL",
                        "LATO",
                        "LEX PRIME",
                        "LEX",
                        "MAGNUS",
                        "MARA DETRON",
                        "MARELOK",
                        "MK1-FURIS",
                        "MK1-KUNAI",
                        "NUKOR",
                        "PANDERO",
                        "POX",
                        "PRISMA ANGSTRUM",
                        "PRISMA BURST LASER",
                        "PRISMA TWIN GREMLINS",
                        "PYRANA PRIME",
                        "PYRANA",
                        "RAKTA BALLISTICA",
                        "SANCTI CASTANAS",
                        "SECURA DUAL CESTRA",
                        "SEER",
                        "SICARUS PRIME",
                        "SICARUS",
                        "SONICOR",
                        "SPECTRA",
                        "SPIRA PRIME",
                        "SPIRA",
                        "STATICOR",
                        "STUBBA",
                        "STUG",
                        "SYNOID GAMMACOR",
                        "TALONS",
                        "TELOS AKBOLTO",
                        "TWIN GRAKATAS",
                        "TWIN GREMLINS",
                        "TWIN KOHMAK",
                        "TWIN ROGGA",
                        "TWIN VIPERS WRAITH",
                        "TWIN VIPERS",
                        "TYSIS",
                        "VASTO PRIME",
                        "VASTO",
                        "VAYKOR MARELOK",
                        "VIPER WRAITH",
                        "VIPER",
                        "ZAKTI",
                        "ZYLOK"
                    }
                },
                {
                    WeaponType.Primary,
                    new List<string>
                    {
                        "AMPREX",
                        "ARGONAK",
                        "ARTAX",
                        "ATTICA",
                        "BAZA",
                        "BOLTOR PRIME",
                        "BOLTOR",
                        "BRATON PRIME",
                        "BRATON VANDAL",
                        "BRATON",
                        "BURSTON PRIME",
                        "BURSTON",
                        "BUZLOK",
                        "CARMINE PENTA",
                        "CERNOS PRIME",
                        "CERNOS",
                        "DAIKYU",
                        "DERA VANDAL",
                        "DERA",
                        "DETH MACHINE RIFLE PRIME",
                        "DETH MACHINE RIFLE",
                        "DEX SYBARIS",
                        "DREAD",
                        "FERROX",
                        "FLUX RIFLE",
                        "GLAXION",
                        "GORGON WRAITH",
                        "GORGON",
                        "GRAKATA",
                        "GRINLOK",
                        "HARPAK",
                        "HEMA",
                        "HIND",
                        "IGNIS WRAITH",
                        "IGNIS",
                        "JAVLOK",
                        "KARAK WRAITH",
                        "KARAK",
                        "LANKA",
                        "LASER RIFLE",
                        "LATRON PRIME",
                        "LATRON WRAITH",
                        "LATRON",
                        "LENZ",
                        "MITER",
                        "MK1-BRATON",
                        "MK1-PARIS",
                        "MUTALIST CERNOS",
                        "MUTALIST QUANTA",
                        "OGRIS",
                        "OPTICOR",
                        "PANTHERA",
                        "PARACYST",
                        "PARIS PRIME",
                        "PARIS",
                        "PENTA",
                        "PRIME LASER RIFLE",
                        "PRISMA GORGON",
                        "PRISMA GRAKATA",
                        "PRISMA TETRA",
                        "QUANTA VANDAL",
                        "QUANTA",
                        "QUARTAKK",
                        "RAKTA CERNOS",
                        "RUBICO",
                        "SCOURGE",
                        "SECURA PENTA",
                        "SIMULOR",
                        "SNIPETRON VANDAL",
                        "SNIPETRON",
                        "SOMA PRIME",
                        "SOMA",
                        "STINGER PRIME",
                        "STINGER",
                        "STRADAVAR",
                        "SUPRA VANDAL",
                        "SUPRA",
                        "SYBARIS PRIME",
                        "SYBARIS",
                        "SYNAPSE",
                        "SYNOID SIMULOR",
                        "TELOS BOLTOR",
                        "TENORA",
                        "TETRA",
                        "TIBERON PRIME",
                        "TIBERON",
                        "TONKOR",
                        "TORID",
                        "VECTIS PRIME",
                        "VECTIS",
                        "VELDT",
                        "VULKAR WRAITH",
                        "VULKAR",
                        "VULKLOK PRIME",
                        "VULKLOK",
                        "ZARR",
                        "ZENITH",
                        "ZHUGE"
                    }
                }
            };
        }

        private static void InitItems()
        {
            Item = new Dictionary<string, string>
            {
                {"/Lotus/StoreItems/Types/Game/KubrowPet/Eggs/KubrowEgg", "库狛蛋"},
                {"/Lotus/StoreItems/Types/Items/MiscItems/OrokinCatalyst", "Orokin催化剂"},
                {"/Lotus/StoreItems/Types/Items/MiscItems/OrokinReactor", "Orokin反应堆"},
                {"/Lotus/StoreItems/Types/Recipes/Components/FormaBlueprint", "Forma蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Components/OrokinCatalystBlueprint", "Orokin催化剂 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Components/OrokinReactorBlueprint", "Orokin反应堆 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/DarkSwordBlueprint", "暗黑长剑 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/AnimaAltHelmetBlueprint", "Equinox 至点头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/BardAltHelmetBlueprint", "Octavia 华彩乐章头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/BrawlerAltHelmetBlueprint", "Atlas 炼狱头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/BrawlerAltTwoHelmetBlueprint", "Atlas 兜围头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/ChromaAltBHelmetBlueprint", "Chroma 羽蛇神头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/CowgirlAltHelmetBlueprint", "Mesa 长角头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/DragonAltHelmetBlueprint", "Chroma 龙蛇头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/ExcaliburMordredHelmetBlueprint", "Excalibur 莫德雷头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/FairyAltHelmetBlueprint", "Titania 风之妖精头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/GlassAltHelmetBlueprint", "Gara 悍妇头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/HarlequinAltHelmetBlueprint", "Mirage 丑角头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/LimboAltBHelmetBlueprint", "Limbo 画家头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/LimboAristeasHelmetBlueprint", "Limbo 诗人头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/LokiEnigmaHelmetBlueprint", "Loki 谜样头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/MesaAltBHelmetBlueprint", "Mesa 角羊头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/MirageAltBHelmetBlueprint", "Mirage 丑仆头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/MonkeyKingAltBHelmetBlueprint", "Wukong 猕猴头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/NekrosAraknidHelmetBlueprint", "Nekros 古墓头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/NekrosShroudHelmetBlueprint", "Nekros 裹尸布头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/NezhaAltHelmetBlueprint", "Nezha 奇尔卡头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/NidusAltHelmetBlueprint", "Nidus 阮毒头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/NovaQuantumHelmetBlueprint", "Nova 量子头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/NovaSlipstreamHelmetBlueprint", "Nova 气流头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/OberonAltBHelmetBlueprint", "Oberon 捻角山羊头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/OberonAltHelmetBlueprint", "Oberon 羚羊头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/PirateAltBHelmetBlueprint", "Hydroid 海怪头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/PirateAltHelmetBlueprint", "Hydroid 海之信使头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/PriestAltHelmetBlueprint", "Harrow 副主教头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/RangerAltBHelmetBlueprint", "Ivara 头罩头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/RangerAltHelmetBlueprint", "Ivara 洛克斯利头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/SandmanAltBHelmetBlueprint", "Inaros 卡诺匹斯头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/SandmanAltHelmetBlueprint", "Inaros 阿努比斯头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessAshAltHelmetBlueprint", "Ash 毒蝎头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessBansheeAltHelmetBlueprint", "Banshee 返响头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessEmberAltHelmetBlueprint", "Ember 凤凰头盔 蓝图(外观)"},
                {
                    "/Lotus/StoreItems/Types/Recipes/Helmets/StatlessExcaliburAltHelmetBlueprint",
                    "Excalibur 阿瓦隆头盔 蓝图(外观)"
                },
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessFrostAltHelmetBlueprint", "Frost 极光头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessLokiAltHelmetBlueprint", "Loki 本质头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessMagAltHelmetBlueprint", "Mag 线圈头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessNovaAltHelmetBlueprint", "Nova 通量头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessNyxAltHelmetBlueprint", "Nyx 灭神头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessRhinoAltHelmetBlueprint", "Rhino 震击头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessSarynAltHelmetBlueprint", "Saryn 铁杉头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessTrinityAltHelmetBlueprint", "Trinity 预言头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2AshAltHelmetBlueprint", "Ash 飞蝗头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2BansheeAltHelmetBlueprint", "Banshee 合音头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2EmberAltHelmetBlueprint", "Ember 复燃头盔 蓝图(外观)"},
                {
                    "/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2ExcaliburAltHelmetBlueprint",
                    "Excalibur 潘德拉冈头盔 蓝图(外观)"
                },
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2FrostAltHelmetBlueprint", "Frost 飓风头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2LokiAltHelmetBlueprint", "Loki 诈欺头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2MagAltHelmetBlueprint", "Mag 高斯头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2NyxAltHelmetBlueprint", "Nyx 黄蜂头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2RhinoAltHelmetBlueprint", "Rhino 先锋头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2TrinityAltHelmetBlueprint", "Trinity 经络头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessV2VaubanAltHelmetBlueprint", "Vauban 策略头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessVaubanAltHelmetBlueprint", "Vauban 机敏头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/StatlessVoltAltHelmetBlueprint", "Volt 风暴头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/ValkyrAltBHelmetBlueprint", "Valkyr 狂者头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/ValkyrBastetHelmetBlueprint", "Valkyr 芭丝特头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/VaubanHelmetSoldierBlueprint", "Vauban 休战头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/WukongAltHelmetBlueprint", "Wukong 大圣头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/ZephyrCierzoHelmetBlueprint", "Zephyr 西熟风头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/Helmets/ZephyrTenguHelmetBlueprint", "Zephyr 天狗头盔 蓝图(外观)"},
                {"/Lotus/StoreItems/Types/Recipes/WarframeRecipes/TrapperChassisBlueprint", "Vauban机体 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/WarframeRecipes/TrapperHelmetBlueprint", "Vauban头部神经光元 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/WarframeRecipes/TrapperSystemsBlueprint", "Vauban系统 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/CeramicDaggerBlueprint", "陶瓷匕首 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/DarkDaggerBlueprint", "暗黑匕首 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/GlaiveBlueprint", "战刃 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/HeatDaggerBlueprint", "烈焰短剑 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/HeatSwordBlueprint", "烈焰长剑 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/JawBlueprint", "蛇颚刀 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/PangolinSwordBlueprint", "鲮鲤剑 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/PlasmaSwordBlueprint", "等离子长剑 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/Skins/DaggerAxeBlueprint", "某斧头外观蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/Skins/DualDaggerAxeBlueprint", "某斧头外观蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/Skins/GrnAxeBlueprint", "某斧头外观 蓝图"},
                {"/Lotus/StoreItems/Types/Recipes/Weapons/Skins/GrnHammerBlueprint", "某锤子外观 蓝图"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/EnemyArmorReductionAuraMod", "腐蚀投射(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/EnemyShieldReductionAuraMod", "护盾瓦解(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/InfestationSpeedReductionAuraMod", "感染者阻抗(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerEnemyRadarAuraMod", "侦敌雷达(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerEnergyRegenAuraMod", "能量虹吸(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerHealthAuraMod", "体魄(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerHealthRegenAuraMod", "返老还童(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerHolsterSpeedAuraMod", "快速切换(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerLootRadarAuraMod", "战利品探测器(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerMeleeAuraMod", "钢铁充能(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerPistolAmmoAuraMod", "手枪弹药搜集者(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerRifleAmmoAuraMod", "步枪弹药搜集者(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerRifleDamageAuraMod", "步枪增幅(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerShellAmmoAuraMod", "霰弹枪弹药搜集者(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerSniperAmmoAuraMod", "狙击枪弹药搜集者(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerSniperDamageAuraMod", "死亡之眼(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/PlayerSprintAuraMod", "冲刺提升(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Aura/RobotPoorAimAuraMod", "电磁脉冲场(光环)"},
                {"/Lotus/StoreItems/Upgrades/Mods/FusionBundles/AlertFusionBundleLarge", "150内融核心"},
                {"/Lotus/StoreItems/Upgrades/Mods/FusionBundles/AlertFusionBundleMedium", "100内融核心"},
                {"/Lotus/StoreItems/Upgrades/Mods/FusionBundles/AlertFusionBundleSmall", "80内融核心"},
                {"/Lotus/StoreItems/Upgrades/Mods/Melee/DualStat/FocusEnergyMod", "聚焦能量(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Melee/DualStat/RendingStrikeMod", "撕裂打击(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Pistol/DualStat/GrinderMod", "致命洪流(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Pistol/DualStat/IceStormMod", "冰风暴(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Pistol/DualStat/StunningSpeedMod", "慑人神速(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Rifle/DualStat/HammerShotMod", "重锤射击(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Rifle/DualStat/ShredMod", "撕裂(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Rifle/DualStat/WildfireMod", "野火(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Sentinel/SentinelLootRadarEnemyRadarMod", "动物本能(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Shotgun/DualStat/AcceleratedBlastMod", "加速冲击(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Shotgun/DualStat/BlazeMod", "烈焰(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Shotgun/DualStat/ReloadSpeedPunchThroughMod", "狂暴追猎(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Warframe/DualStat/ConstitutionMod", "百折不挠(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Warframe/DualStat/FortitudeMod", "不屈不挠(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Warframe/DualStat/RunSpeedArmorMod", "灵活装甲(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Mods/Warframe/DualStat/VigorMod", "活力(噩梦Mod)"},
                {"/Lotus/StoreItems/Upgrades/Skins/Scarves/DexScarf", "DEX 延药睡莲披饰"},
                {"/Lotus/StoreItems/Weapons/Tenno/LongGuns/DexTheThird/DexTheThird", "DEX 达克拉双剑"},
                {"/Lotus/StoreItems/Weapons/Tenno/Melee/Swords/DexTheSecond/DexTheSecond", "DEX 席芭莉丝"},
                {"/Lotus/StoreItems/Weapons/Tenno/Pistols/DexFuris/DexFuris", "DEX 盗贼双枪"},
                {"/Lotus/Types/Game/CatbrowPet/CatbrowGeneticSignature", "库娃遗传密码"},
                {"/Lotus/Types/Items/MiscItems/Alertium", "泥炭萃取物"},
                {"/Lotus/Types/Items/MiscItems/AlloyPlate", "合金板"},
                {"/Lotus/Types/Items/MiscItems/ArgonCrystal", "氩结晶"},
                {"/Lotus/Types/Items/MiscItems/Circuits", "电路"},
                {"/Lotus/Types/Items/MiscItems/ControlModule", "控制模块"},
                {"/Lotus/Types/Items/MiscItems/Eventium", "合成刺激质"},
                {"/Lotus/Types/Items/MiscItems/Ferrite", "铁氧体"},
                {"/Lotus/Types/Items/MiscItems/Gallium", "镓"},
                {"/Lotus/Types/Items/MiscItems/InfestedAladCoordinate", "异融Alad V导航坐标"},
                {"/Lotus/Types/Items/MiscItems/Morphic", "非晶态合金"},
                {"/Lotus/Types/Items/MiscItems/Nanospores", "纳米孢子"},
                {"/Lotus/Types/Items/MiscItems/NeuralSensor", "神经传感器"},
                {"/Lotus/Types/Items/MiscItems/Neurode", "神经元"},
                {"/Lotus/Types/Items/MiscItems/OrokinCell", "Orokin电池"},
                {"/Lotus/Types/Items/MiscItems/OxiumAlloy", "奥席金属"},
                {"/Lotus/Types/Items/MiscItems/Plastids", "生物质"},
                {"/Lotus/Types/Items/MiscItems/PolymerBundle", "聚合物束"},
                {"/Lotus/Types/Items/MiscItems/Rubedo", "红化结晶"},
                {"/Lotus/Types/Items/MiscItems/Salvage", "回收金属"},
                {"/Lotus/Types/Items/MiscItems/Tellurium", "碲"},
                {"/Lotus/Types/Items/MiscItems/VoidTearDrop", "虚空光体"},
                {"/Lotus/Types/Items/Research/BioComponent", "突变原聚合物"},
                {"/Lotus/Types/Items/Research/ChemComponent", "燃爆喷射器"},
                {"/Lotus/Types/Items/Research/EnergyComponent", "电磁力场装置"},
                {"/Lotus/Types/Recipes/Components/FormaBlueprint", "Forma蓝图"},
                {"/Lotus/Types/Recipes/Components/OrokinCatalystBlueprint", "Orokin催化剂 蓝图"},
                {"/Lotus/Types/Recipes/Components/OrokinReactorBlueprint", "Orokin反应堆 蓝图"},
                {"/Lotus/Types/Recipes/Components/UtilityUnlockerBlueprint", "特殊功能槽连接器 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/DeraVandalBlueprint", "德拉破坏者 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/GrineerCombatKnifeSortieBlueprint", "希芙 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/KarakWraithBlueprint", "卡拉克亡魂 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/LatronWraithBlueprint", "拉特昂亡魂 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/SnipetronVandalBlueprint", "狙击特昂破坏者 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/StrunWraithBlueprint", "斯特朗亡魂 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/TwinVipersWraithBlueprint", "双子蝰蛇亡魂 蓝图"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/DeraVandalBarrel", "德拉破坏者 枪管"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/DeraVandalReceiver", "德拉破坏者 枪机"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/DeraVandalStock", "德拉破坏者 枪托"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/GrineerCombatKnifeBlade", "希芙 刀刃"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/GrineerCombatKnifeHeatsink", "希芙 散热槽"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/GrineerCombatKnifeHilt", "希芙 握柄"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/KarakWraithBarrel", "卡拉克亡魂 枪管"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/KarakWraithReceiver", "卡拉克亡魂 枪机"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/KarakWraithStock", "卡拉克亡魂 枪托"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/LatronWraithBarrel", "拉特昂亡魂 枪管"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/LatronWraithReceiver", "拉特昂亡魂 枪机"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/LatronWraithStock", "拉特昂亡魂 枪托"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/SnipetronVandalBarrel", "狙击特昂破坏者 枪管"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/SnipetronVandalReceiver", "狙击特昂破坏者 枪机"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/SnipetronVandalStock", "狙击特昂破坏者 枪托"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/StrunWraithBarrel", "斯特朗亡魂 枪管"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/StrunWraithReceiver", "斯特朗亡魂 枪机"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/StrunWraithStock", "斯特朗亡魂 枪托"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/TwinVipersWraithBarrel", "双子蝰蛇亡魂 枪管"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/TwinVipersWraithLink", "双子蝰蛇亡魂 连接器"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/TwinVipersWraithReceiver", "双子蝰蛇亡魂 枪机"},
                {"/Lotus/Types/Recipes/Weapons/WeaponParts/TwinVipersWraithStock", "双子蝰蛇亡魂 枪托"}
            };
        }

        private static void InitJobs()
        {
            JobName = new Dictionary<string, string>
            {
                {"/Lotus/Language/G1Quests/FomorianRevengeBattleName", "巴罗尔巨人战舰"},
                {"/Lotus/Language/Menu/InfestedInvasionGeneric", "Infested爆发"},
                {"/Lotus/Language/Menu/InfestedInvasionBoss", "Phorid现形"},
                {"/Lotus/Language/Menu/CorpusInvasionGeneric", "Corpus围攻"},
                {"/Lotus/Language/Menu/GrineerInvasionGeneric", "Grineer进攻"},
                {"/Lotus/Language/GameModes/RecurringGhoulAlert", "尸鬼净化"},
                {"/Lotus/Language/InfestedPlainsEvent/InfestedPlainsBountyName", "瘟疫之星"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/InfestedPlainsBounty", "瘟疫之星"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AssassinateBountyAss", "刺杀指挥官"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AssassinateBountyCap", "捕获新任Grineer指挥官"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountyCap", "捕获他们的领袖"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountyExt", "宰杀敌人"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountyLib", "削弱Grineer的据点"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountySab", "破坏Grineer的补给线"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/CaptureBountyCapOne", "捕获Grineer指挥官"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/CaptureBountyCapTwo", "间谍捕手"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/ReclamationBountyCache", "找出遗失的器物"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/ReclamationBountyCap", "捕获Grineer特工"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/ReclamationBountyTheft", "取回被偷的器物"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/RescueBountyResc", "搜索并救援"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/SabotageBountySab", "破坏原型机"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyAss", "消灭一个尸鬼头领"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyHunt", "净化一个巨型尸鬼埋藏地"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyRes", "营救尸鬼叛逃者"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyExt", "清扫尸鬼埋养地"}
            };
            JobDesc = new Dictionary<string, string>
            {
                {
                    "/Lotus/Language/InfestedPlainsEvent/InfestedPlainsBountyDesc",
                    "偷取Vay Hek的Thrax毒素, 混合, 并将毒素送去在平野中部生长的Infested疖瘤。"
                },
                {
                    "/Lotus/Types/Gameplay/Eidolon/Jobs/Events/InfestedPlainsBounty",
                    "偷取Vay Hek的Thrax毒素, 混合, 并将毒素送去在平野中部生长的Infested疖瘤。"
                },
                {"/Lotus/Language/GameModes/RecurringGhoulAlertDesc", "帮助Konzu消灭平野上的Grineer尸鬼"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountyLib", "将Grineer从他们在平野上的外哨赶出去"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AssassinateBountyAss", "一名Grineer领导者只会在我们干扰其多处前线行动的时候现身。"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AssassinateBountyCap", "一名新任的Grineer指挥官已经不断在制造麻烦。捉住指挥官。"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountyCap", "捉住他们的指挥官能对Grineer的分遣队造成士气上的打击。"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountyExt", "Grineer的数量已经太多了。削弱他们。"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/AttritionBountySab", "重创Grineer的补给链。"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/CaptureBountyCapOne", "一名高阶的Grineer已经登陆到平野上。将他们带给Lotus。"},
                {
                    "/Lotus/Types/Gameplay/Eidolon/Jobs/CaptureBountyCapTwo",
                    "发现一名Grineer的间谍潜藏在希图斯村中。对Grineer施加压力将那位间谍逼出来。"
                },
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/ReclamationBountyCache", "Grineer夺走了一件Orokin器物。找出他们已埋藏的器物。"},
                {
                    "/Lotus/Types/Gameplay/Eidolon/Jobs/ReclamationBountyCap",
                    "一件对夜羽的重要道具已经被Grineer夺取。找出夺走器物的特工并捉住他。"
                },
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/ReclamationBountyTheft", "夜羽表示Grineer偷走了一件珍贵的Orokin器物。把偷它回来。"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/RescueBountyResc", "一名Ostron人在平野上失踪了, 找到他们并带他们回家。"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/SabotageBountySab", "原型科技正要运送给Grineer。扫遍整个平野直到你找到为止！"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyAss", "猎杀一个尸鬼头领, 并削弱他们在平野上的规模"},
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyHunt", "在尸鬼觉醒前, 找到并消灭尸鬼埋藏地"},
                {
                    "/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyRes",
                    "钢铁防线已经辨识出一个可能的尸鬼叛逃者, 进行营救, 避免其注定的死亡。"
                },
                {"/Lotus/Types/Gameplay/Eidolon/Jobs/Events/GhoulAlertBountyExt", "对Grineer的埋养地发起进攻, 向Vay Hek表明立场。"}
            };
        }

        private static void InitNodes()
        {
            Nodes = new Dictionary<string, Node>
            {
                {"ClanNode0", new Node("ClanNode0", "金星", "金星Romula", "Corpus哨站", MissionType.MT_DEFENSE)},
                {"ClanNode1", new Node("ClanNode1", "金星", "金星Malva", "Corpus飞船", MissionType.MT_SURVIVAL)},
                {"ClanNode2", new Node("ClanNode2", "地球", "地球Coba", "Grineer丛林", MissionType.MT_DEFENSE)},
                {"ClanNode3", new Node("ClanNode3", "地球", "地球Tikal", "Grineer丛林", MissionType.MT_EXCAVATE)},
                {"ClanNode4", new Node("ClanNode4", "木星", "木星Sinai", "Corpus燃气城市", MissionType.MT_DEFENSE)},
                {"ClanNode5", new Node("ClanNode5", "木星", "木星Cameria", "Corpus燃气城市", MissionType.MT_SURVIVAL)},
                {"ClanNode6", new Node("ClanNode6", "欧罗巴", "欧罗巴Larzac", "Corpus冰原星球", MissionType.MT_DEFENSE)},
                {"ClanNode7", new Node("ClanNode7", "欧罗巴", "欧罗巴Cholistan", "Corpus冰原星球", MissionType.MT_EXCAVATE)},
                {"ClanNode8", new Node("ClanNode8", "火星", "火星Kadesh", "Grineer营地", MissionType.MT_DEFENSE)},
                {"ClanNode9", new Node("ClanNode9", "火星", "火星Wahiba", "Corpus飞船", MissionType.MT_SURVIVAL)},
                {"ClanNode10", new Node("ClanNode10", "火卫一", "火卫一Memphis", "Grineer小行星", MissionType.MT_EVACUATION)},
                {"ClanNode11", new Node("ClanNode11", "火卫一", "火卫一Zeugma", "Grineer小行星", MissionType.MT_SURVIVAL)},
                {"ClanNode12", new Node("ClanNode12", "土星", "土星Caracol", "Grineer小行星", MissionType.MT_EVACUATION)},
                {"ClanNode13", new Node("ClanNode13", "土星", "土星Piscinas", "Grineer小行星", MissionType.MT_SURVIVAL)},
                {"ClanNode14", new Node("ClanNode14", "赛德娜", "赛德娜Amarna", "Grineer小行星", MissionType.MT_SURVIVAL)},
                {"ClanNode15", new Node("ClanNode15", "赛德娜", "赛德娜Sangeru", "Grineer小行星", MissionType.MT_DEFENSE)},
                {"ClanNode16", new Node("ClanNode16", "天王星", "天王星Ur", "Grineer小行星", MissionType.MT_DEFENSE)},
                {"ClanNode17", new Node("ClanNode17", "天王星", "天王星Assur", "Grineer巨舰", MissionType.MT_SURVIVAL)},
                {"ClanNode18", new Node("ClanNode18", "阋神星", "阋神星Akkad", "Infested飞船", MissionType.MT_DEFENSE)},
                {"ClanNode19", new Node("ClanNode19", "阋神星", "阋神星Zabala", "Infested飞船", MissionType.MT_SURVIVAL)},
                {"ClanNode20", new Node("ClanNode20", "海王星", "海王星Yursa", "Infested飞船", MissionType.MT_EVACUATION)},
                {"ClanNode21", new Node("ClanNode21", "海王星", "海王星Kelashin", "Infested飞船", MissionType.MT_SURVIVAL)},
                {"ClanNode22", new Node("ClanNode22", "谷神星", "谷神星Seimeni", "Grineer船坞", MissionType.MT_DEFENSE)},
                {"ClanNode23", new Node("ClanNode23", "谷神星", "谷神星Gabii", "Grineer巨舰", MissionType.MT_SURVIVAL)},
                {"ClanNode24", new Node("ClanNode24", "冥王星", "冥王星Sechura", "Corpus哨站", MissionType.MT_DEFENSE)},
                {"ClanNode25", new Node("ClanNode25", "冥王星", "冥王星Hieracon", "Corpus哨站", MissionType.MT_EXCAVATE)},
                {"EarthHUB", new Node("EarthHUB", "地球", "地球中继站Strata", "中继站", MissionType.MT_RELAY)},
                {"ErisHUB", new Node("ErisHUB", "阋神星", "阋神星中继站Kuiper", "中继站", MissionType.MT_RELAY)},
                {"EuropaHUB", new Node("EuropaHUB", "欧罗巴", "欧罗巴中继站Leonov", "中继站", MissionType.MT_RELAY)},
                {"MercuryHUB", new Node("MercuryHUB", "水星", "水星中继站Larunda", "中继站", MissionType.MT_RELAY)},
                {"PlutoHUB", new Node("PlutoHUB", "冥王星", "冥王星中继站Orcus", "中继站", MissionType.MT_RELAY)},
                {"SaturnHUB", new Node("SaturnHUB", "土星", "土星中继站Kronia", "中继站", MissionType.MT_RELAY)},
                {"VenusHUB", new Node("VenusHUB", "金星", "金星中继站Vesper", "中继站", MissionType.MT_RELAY)},
                {
                    "SettlementNode1",
                    new Node("SettlementNode1", "火卫一", "火卫一Roche", "Corpus飞船", MissionType.MT_EXTERMINATION)
                },
                {
                    "SettlementNode2",
                    new Node("SettlementNode2", "火卫一", "火卫一Skyresh", "Corpus飞船", MissionType.MT_CAPTURE)
                },
                {
                    "SettlementNode3",
                    new Node("SettlementNode3", "火卫一", "火卫一Stickney", "Corpus飞船", MissionType.MT_SURVIVAL)
                },
                {"SettlementNode4", new Node("SettlementNode4", "火卫一", "火卫一Drunlo", "[数据删除]", MissionType.MT_UNKNOWN)},
                {
                    "SettlementNode5",
                    new Node("SettlementNode5", "火卫一", "火卫一Grildrig", "[数据删除]", MissionType.MT_UNKNOWN)
                },
                {"SettlementNode6", new Node("SettlementNode6", "火卫一", "火卫一Limtoc", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SettlementNode7", new Node("SettlementNode7", "火卫一", "火卫一Hall", "[数据删除]", MissionType.MT_UNKNOWN)},
                {
                    "SettlementNode8",
                    new Node("SettlementNode8", "火卫一", "火卫一Reldresal", "[数据删除]", MissionType.MT_UNKNOWN)
                },
                {
                    "SettlementNode9",
                    new Node("SettlementNode9", "火卫一", "火卫一Clustril", "[数据删除]", MissionType.MT_UNKNOWN)
                },
                {"SettlementNode10", new Node("SettlementNode10", "火卫一", "火卫一Kepler", "Corpus飞船", MissionType.MT_RUSH)},
                {
                    "SettlementNode11",
                    new Node("SettlementNode11", "火卫一", "火卫一Gulliver", "Corpus飞船", MissionType.MT_DEFENSE)
                },
                {
                    "SettlementNode12",
                    new Node("SettlementNode12", "火卫一", "火卫一Monolith", "Corpus飞船", MissionType.MT_RESCUE)
                },
                {
                    "SettlementNode13",
                    new Node("SettlementNode13", "火卫一D'", "火卫一D'Arrest", "[数据删除]", MissionType.MT_UNKNOWN)
                },
                {
                    "SettlementNode14",
                    new Node("SettlementNode14", "火卫一", "火卫一Shklovsky", "Corpus飞船", MissionType.MT_INTEL)
                },
                {
                    "SettlementNode15",
                    new Node("SettlementNode15", "火卫一", "火卫一Sharpless", "Corpus飞船", MissionType.MT_MOBILE_DEFENSE)
                },
                {
                    "SettlementNode16",
                    new Node("SettlementNode16", "火卫一", "火卫一Wendell", "[数据删除]", MissionType.MT_UNKNOWN)
                },
                {
                    "SettlementNode17",
                    new Node("SettlementNode17", "火卫一", "火卫一Flimnap", "[数据删除]", MissionType.MT_UNKNOWN)
                },
                {"SettlementNode18", new Node("SettlementNode18", "火卫一", "火卫一Opik", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SettlementNode19", new Node("SettlementNode19", "火卫一", "火卫一Todd", "[数据删除]", MissionType.MT_UNKNOWN)},
                {
                    "SettlementNode20",
                    new Node("SettlementNode20", "火卫一", "火卫一Iliad", "Corpus飞船", MissionType.MT_ASSASSINATION)
                },
                {"SolNode1", new Node("SolNode1", "海王星", "海王星Galatea", "Corpus燃气城市", MissionType.MT_CAPTURE)},
                {"SolNode2", new Node("SolNode2", "金星", "金星Aphrodite", "Corpus哨站", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode3", new Node("SolNode3", "天王星", "天王星Cordelia", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode4", new Node("SolNode4", "冥王星", "冥王星Acheron", "Corpus飞船", MissionType.MT_EXTERMINATION)},
                {"SolNode5", new Node("SolNode5", "天王星", "天王星Perdita", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode6", new Node("SolNode6", "海王星", "海王星Despina", "Corpus哨站", MissionType.MT_EXCAVATE)},
                {"SolNode7", new Node("SolNode7", "土星", "土星Epimetheus", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode8", new Node("SolNode8", "冥王星", "冥王星Nix", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode9", new Node("SolNode9", "天王星", "天王星Rosalind", "Grineer深海研究所", MissionType.MT_INTEL)},
                {"SolNode10", new Node("SolNode10", "木星", "木星Thebe", "Corpus燃气城市", MissionType.MT_SABOTAGE)},
                {"SolNode11", new Node("SolNode11", "火星", "火星Tharsis", "Corpus冰原星球", MissionType.MT_RETRIEVAL)},
                {"SolNode12", new Node("SolNode12", "水星", "水星Elion", "Grineer小行星", MissionType.MT_CAPTURE)},
                {"SolNode13", new Node("SolNode13", "天王星", "天王星Bianca", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode14", new Node("SolNode14", "火星", "火星Ultor", "Corpus冰原星球", MissionType.MT_EXTERMINATION)},
                {"SolNode15", new Node("SolNode15", "地球", "地球Pacific", "Grineer巨舰", MissionType.MT_RESCUE)},
                {"SolNode16", new Node("SolNode16", "火星", "火星Augustus", "Grineer营地", MissionType.MT_EXCAVATE)},
                {"SolNode17", new Node("SolNode17", "海王星", "海王星Proteus", "Corpus飞船", MissionType.MT_DEFENSE)},
                {"SolNode18", new Node("SolNode18", "土星", "土星Rhea", "Grineer小行星", MissionType.MT_TERRITORY)},
                {"SolNode19", new Node("SolNode19", "土星", "土星Enceladus", "Grineer小行星", MissionType.MT_SABOTAGE)},
                {"SolNode20", new Node("SolNode20", "土星", "土星Telesto", "Grineer巨舰", MissionType.MT_EXTERMINATION)},
                {"SolNode21", new Node("SolNode21", "冥王星", "冥王星Narcissus", "Corpus哨站", MissionType.MT_EXTERMINATION)},
                {"SolNode22", new Node("SolNode22", "金星", "金星Tessera", "Corpus哨站", MissionType.MT_DEFENSE)},
                {"SolNode23", new Node("SolNode23", "金星", "金星Cytherean", "Corpus飞船", MissionType.MT_TERRITORY)},
                {"SolNode24", new Node("SolNode24", "地球", "地球Oro", "Grineer丛林", MissionType.MT_ASSASSINATION)},
                {"SolNode25", new Node("SolNode25", "木星", "木星Callisto", "Corpus燃气城市", MissionType.MT_TERRITORY)},
                {"SolNode26", new Node("SolNode26", "地球", "地球Lith", "Grineer丛林", MissionType.MT_DEFENSE)},
                {"SolNode27", new Node("SolNode27", "地球", "地球E Prime", "Grineer丛林", MissionType.MT_EXTERMINATION)},
                {"SolNode28", new Node("SolNode28", "水星", "水星Terminus", "Grineer巨舰", MissionType.MT_SABOTAGE)},
                {"SolNode29", new Node("SolNode29", "天王星", "天王星Oberon", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode30", new Node("SolNode30", "火星", "火星Olympus", "Grineer营地", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode31", new Node("SolNode31", "土星", "土星Anthe", "Grineer巨舰", MissionType.MT_RESCUE)},
                {"SolNode32", new Node("SolNode32", "土星", "土星Tethys", "Grineer巨舰", MissionType.MT_ASSASSINATION)},
                {"SolNode33", new Node("SolNode33", "天王星", "天王星Ariel", "Grineer深海研究所", MissionType.MT_CAPTURE)},
                {"SolNode34", new Node("SolNode34", "天王星", "天王星Sycorax", "Grineer深海研究所", MissionType.MT_EXTERMINATION)},
                {"SolNode35", new Node("SolNode35", "火星", "火星Arcadia", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode36", new Node("SolNode36", "火星", "火星Martialis", "Grineer营地", MissionType.MT_RESCUE)},
                {"SolNode37", new Node("SolNode37", "土星", "土星Pallene", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode38", new Node("SolNode38", "冥王星", "冥王星Minthe", "Corpus哨站", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode39", new Node("SolNode39", "地球", "地球Everest", "Grineer丛林", MissionType.MT_EXCAVATE)},
                {"SolNode40", new Node("SolNode40", "天王星", "天王星Prospero", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode41", new Node("SolNode41", "火星", "火星Arval", "Grineer营地", MissionType.MT_INTEL)},
                {"SolNode42", new Node("SolNode42", "土星", "土星Helene", "Grineer巨舰", MissionType.MT_DEFENSE)},
                {"SolNode43", new Node("SolNode43", "冥王星", "冥王星Cerberus", "Corpus哨站", MissionType.MT_TERRITORY)},
                {"SolNode44", new Node("SolNode44", "土星", "土星Mimas", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode45", new Node("SolNode45", "火星", "火星Ara", "Grineer营地", MissionType.MT_CAPTURE)},
                {"SolNode46", new Node("SolNode46", "火星", "火星Spear", "Grineer营地", MissionType.MT_DEFENSE)},
                {"SolNode47", new Node("SolNode47", "土星", "土星Janus", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode48", new Node("SolNode48", "冥王星", "冥王星Regna", "Corpus哨站", MissionType.MT_RESCUE)},
                {"SolNode49", new Node("SolNode49", "海王星", "海王星Larissa", "Corpus飞船", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode50", new Node("SolNode50", "土星", "土星Numa", "Grineer小行星", MissionType.MT_RESCUE)},
                {"SolNode51", new Node("SolNode51", "冥王星", "冥王星Hades", "Corpus哨站", MissionType.MT_ASSASSINATION)},
                {"SolNode52", new Node("SolNode52", "天王星", "天王星Portia", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode53", new Node("SolNode53", "木星", "木星Themisto", "Corpus燃气城市", MissionType.MT_ASSASSINATION)},
                {"SolNode54", new Node("SolNode54", "火星", "火星Silvanus", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode55", new Node("SolNode55", "土星", "土星Methone", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode56", new Node("SolNode56", "冥王星", "冥王星Cypress", "Corpus飞船", MissionType.MT_SABOTAGE)},
                {"SolNode57", new Node("SolNode57", "海王星", "海王星Sao", "Corpus哨站", MissionType.MT_SABOTAGE)},
                {"SolNode58", new Node("SolNode58", "火星", "火星Hellas", "Grineer营地", MissionType.MT_EXTERMINATION)},
                {"SolNode59", new Node("SolNode59", "地球", "地球Eurasia", "Grineer丛林", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode60", new Node("SolNode60", "天王星", "天王星Caliban", "Grineer深海研究所", MissionType.MT_RESCUE)},
                {"SolNode61", new Node("SolNode61", "金星", "金星Ishtar", "Corpus飞船", MissionType.MT_SABOTAGE)},
                {"SolNode62", new Node("SolNode62", "海王星", "海王星Neso", "Corpus冰原星球", MissionType.MT_EXTERMINATION)},
                {"SolNode63", new Node("SolNode63", "地球", "地球Mantle", "Grineer丛林", MissionType.MT_CAPTURE)},
                {"SolNode64", new Node("SolNode64", "天王星", "天王星Umbriel", "Grineer深海研究所", MissionType.MT_TERRITORY)},
                {"SolNode65", new Node("SolNode65", "火星", "火星Gradivus", "Corpus飞船", MissionType.MT_SABOTAGE)},
                {"SolNode66", new Node("SolNode66", "金星", "金星Unda", "Corpus哨站", MissionType.MT_INTEL)},
                {"SolNode67", new Node("SolNode67", "土星", "土星Dione", "Grineer小行星", MissionType.MT_INTEL)},
                {"SolNode68", new Node("SolNode68", "火星", "火星Vallis", "Grineer巨舰", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode69", new Node("SolNode69", "天王星", "天王星Ophelia", "Grineer深海研究所", MissionType.MT_SURVIVAL)},
                {"SolNode70", new Node("SolNode70", "土星", "土星Cassini", "Grineer巨舰", MissionType.MT_CAPTURE)},
                {"SolNode71", new Node("SolNode71", "[数据删除]", "[数据删除]", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode72", new Node("SolNode72", "冥王星", "冥王星Outer Terminus", "Corpus哨站", MissionType.MT_DEFENSE)},
                {"SolNode73", new Node("SolNode73", "木星", "木星Ananke", "Corpus燃气城市", MissionType.MT_CAPTURE)},
                {"SolNode74", new Node("SolNode74", "木星", "木星Carme", "Corpus燃气城市", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode75", new Node("SolNode75", "地球", "地球Cervantes", "Grineer丛林", MissionType.MT_SABOTAGE)},
                {"SolNode76", new Node("SolNode76", "冥王星", "冥王星Hydra", "Corpus飞船", MissionType.MT_CAPTURE)},
                {"SolNode77", new Node("SolNode77", "天王星", "天王星Cupid", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode78", new Node("SolNode78", "海王星", "海王星Triton", "Corpus飞船", MissionType.MT_RESCUE)},
                {"SolNode79", new Node("SolNode79", "地球", "地球Cambria", "Grineer丛林", MissionType.MT_INTEL)},
                {"SolNode80", new Node("SolNode80", "土星", "土星Phoebe", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode81", new Node("SolNode81", "冥王星", "冥王星Palus", "Corpus飞船", MissionType.MT_SURVIVAL)},
                {"SolNode82", new Node("SolNode82", "土星", "土星Calypso", "Grineer巨舰", MissionType.MT_SABOTAGE)},
                {
                    "SolNode83",
                    new Node("SolNode83", "天王星", "天王星Cressida", "Grineer深海研究所", MissionType.MT_MOBILE_DEFENSE)
                },
                {"SolNode84", new Node("SolNode84", "海王星", "海王星Nereid", "Corpus冰原星球", MissionType.MT_RETRIEVAL)},
                {"SolNode85", new Node("SolNode85", "地球", "地球Gaia", "Grineer丛林", MissionType.MT_TERRITORY)},
                {"SolNode86", new Node("SolNode86", "土星", "土星Aegaeon", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode87", new Node("SolNode87", "木星", "木星Ganymede", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode88", new Node("SolNode88", "木星", "木星Adrastea", "Corpus燃气城市", MissionType.MT_SABOTAGE)},
                {"SolNode89", new Node("SolNode89", "地球", "地球Mariana", "Grineer深海研究所", MissionType.MT_EXTERMINATION)},
                {"SolNode90", new Node("SolNode90", "", "Miranda", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode91", new Node("SolNode91", "土星", "土星Iapetus", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode92", new Node("SolNode92", "冥王星", "冥王星Charon", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode93", new Node("SolNode93", "土星", "土星Keeler", "Grineer小行星", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode94", new Node("SolNode94", "水星", "水星Apollodorus", "Grineer巨舰", MissionType.MT_SURVIVAL)},
                {"SolNode95", new Node("SolNode95", "海王星", "海王星Thalassa", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode96", new Node("SolNode96", "土星", "土星Titan", "Grineer巨舰", MissionType.MT_SURVIVAL)},
                {"SolNode97", new Node("SolNode97", "木星", "木星Amalthea", "Corpus燃气城市", MissionType.MT_INTEL)},
                {"SolNode98", new Node("SolNode98", "天王星", "天王星Desdemona", "Grineer深海研究所", MissionType.MT_SABOTAGE)},
                {"SolNode99", new Node("SolNode99", "火星", "火星War", "Grineer营地", MissionType.MT_ASSASSINATION)},
                {"SolNode100", new Node("SolNode100", "木星", "木星Elara", "Corpus燃气城市", MissionType.MT_SURVIVAL)},
                {"SolNode101", new Node("SolNode101", "金星", "金星Kiliken", "Corpus哨站", MissionType.MT_EXCAVATE)},
                {"SolNode102", new Node("SolNode102", "冥王星", "冥王星Oceanum", "Corpus哨站", MissionType.MT_INTEL)},
                {"SolNode103", new Node("SolNode103", "水星", "水星M Prime", "Grineer小行星", MissionType.MT_EXTERMINATION)},
                {"SolNode104", new Node("SolNode104", "金星", "金星Fossa", "Corpus飞船", MissionType.MT_ASSASSINATION)},
                {
                    "SolNode105",
                    new Node("SolNode105", "天王星", "天王星Titania", "Grineer深海研究所", MissionType.MT_ASSASSINATION)
                },
                {"SolNode106", new Node("SolNode106", "火星", "火星Alator", "Grineer营地", MissionType.MT_TERRITORY)},
                {"SolNode107", new Node("SolNode107", "金星", "金星Venera", "Corpus哨站", MissionType.MT_CAPTURE)},
                {"SolNode108", new Node("SolNode108", "水星", "水星Tolstoj", "Grineer小行星", MissionType.MT_ASSASSINATION)},
                {"SolNode109", new Node("SolNode109", "金星", "金星Linea", "Corpus哨站", MissionType.MT_RESCUE)},
                {"SolNode110", new Node("SolNode110", "土星", "土星Hyperion", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode111", new Node("SolNode111", "天王星", "天王星Juliet", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode112", new Node("SolNode112", "天王星", "天王星Setebos", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode113", new Node("SolNode113", "火星", "火星Ares", "Grineer营地", MissionType.MT_SABOTAGE)},
                {"SolNode114", new Node("SolNode114", "天王星", "天王星Puck", "Grineer深海研究所", MissionType.MT_EXTERMINATION)},
                {"SolNode115", new Node("SolNode115", "火星", "火星Quirinus", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode116", new Node("SolNode116", "天王星", "天王星Mab", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode117", new Node("SolNode117", "海王星", "海王星Naiad", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode118", new Node("SolNode118", "海王星", "海王星Laomedeia", "Corpus冰原星球", MissionType.MT_INTEL)},
                {"SolNode119", new Node("SolNode119", "水星", "水星Caloris", "Grineer小行星", MissionType.MT_RESCUE)},
                {"SolNode120", new Node("SolNode120", "海王星", "海王星Halimede", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode121", new Node("SolNode121", "木星", "木星Carpo", "Corpus燃气城市", MissionType.MT_EXTERMINATION)},
                {"SolNode122", new Node("SolNode122", "天王星", "天王星Stephano", "Grineer深海研究所", MissionType.MT_DEFENSE)},
                {"SolNode123", new Node("SolNode123", "金星", "金星V Prime", "Corpus飞船", MissionType.MT_SURVIVAL)},
                {"SolNode124", new Node("SolNode124", "天王星", "天王星Trinculo", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode125", new Node("SolNode125", "木星", "木星Io", "Corpus燃气城市", MissionType.MT_DEFENSE)},
                {"SolNode126", new Node("SolNode126", "木星", "木星Metis", "Corpus燃气城市", MissionType.MT_RESCUE)},
                {"SolNode127", new Node("SolNode127", "海王星", "海王星Psamathe", "Corpus飞船", MissionType.MT_ASSASSINATION)},
                {"SolNode128", new Node("SolNode128", "金星", "金星E Gate", "Corpus哨站", MissionType.MT_EXTERMINATION)},
                {"SolNode129", new Node("SolNode129", "数据删除", "数据删除", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode130", new Node("SolNode130", "水星", "水星Lares", "Grineer小行星", MissionType.MT_DEFENSE)},
                {"SolNode131", new Node("SolNode131", "谷神星", "谷神星Pallas", "Grineer船坞", MissionType.MT_EXTERMINATION)},
                {"SolNode132", new Node("SolNode132", "谷神星", "谷神星Bode", "Grineer船坞", MissionType.MT_INTEL)},
                {"SolNode133", new Node("SolNode133", "谷神星", "谷神星Vedic", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode134", new Node("SolNode134", "谷神星", "谷神星Varro", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode135", new Node("SolNode135", "谷神星", "谷神星Thon", "Grineer巨舰", MissionType.MT_SABOTAGE)},
                {"SolNode136", new Node("SolNode136", "谷神星", "谷神星Olla", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode137", new Node("SolNode137", "谷神星", "谷神星Nuovo", "Grineer船坞", MissionType.MT_RESCUE)},
                {"SolNode138", new Node("SolNode138", "谷神星", "谷神星Ludi", "Grineer船坞", MissionType.MT_RETRIEVAL)},
                {"SolNode139", new Node("SolNode139", "谷神星", "谷神星Lex", "Grineer船坞", MissionType.MT_CAPTURE)},
                {"SolNode140", new Node("SolNode140", "谷神星", "谷神星Kiste", "Grineer船坞", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode141", new Node("SolNode141", "谷神星", "谷神星Ker", "Grineer船坞", MissionType.MT_SABOTAGE)},
                {"SolNode142", new Node("SolNode142", "谷神星", "谷神星Hapke", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode143", new Node("SolNode143", "谷神星", "谷神星Gefion", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode144", new Node("SolNode144", "谷神星", "谷神星Exta", "Grineer船坞", MissionType.MT_ASSASSINATION)},
                {"SolNode145", new Node("SolNode145", "谷神星", "谷神星Egeria", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode146", new Node("SolNode146", "谷神星", "谷神星Draco", "Grineer小行星", MissionType.MT_SURVIVAL)},
                {"SolNode147", new Node("SolNode147", "谷神星", "谷神星Cinxia", "Grineer船坞", MissionType.MT_TERRITORY)},
                {"SolNode148", new Node("SolNode148", "谷神星", "谷神星Cerium", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode149", new Node("SolNode149", "谷神星", "谷神星Casta", "Grineer船坞", MissionType.MT_DEFENSE)},
                {"SolNode150", new Node("SolNode150", "谷神星", "谷神星Albedo", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode151", new Node("SolNode151", "阋神星", "阋神星Acanth", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode152", new Node("SolNode152", "阋神星", "阋神星Ascar", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode153", new Node("SolNode153", "阋神星", "阋神星Brugia", "Infested飞船", MissionType.MT_RESCUE)},
                {"SolNode154", new Node("SolNode154", "阋神星", "阋神星Candiru", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode155", new Node("SolNode155", "阋神星", "阋神星Cosis", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode156", new Node("SolNode156", "阋神星", "阋神星Cyath", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode157", new Node("SolNode157", "阋神星", "阋神星Giardia", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode158", new Node("SolNode158", "阋神星", "阋神星Gnathos", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode159", new Node("SolNode159", "阋神星", "阋神星Lepis", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode160", new Node("SolNode160", "阋神星", "阋神星Histo", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode161", new Node("SolNode161", "阋神星", "阋神星Hymeno", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode162", new Node("SolNode162", "阋神星", "阋神星Isos", "Infested飞船", MissionType.MT_CAPTURE)},
                {"SolNode163", new Node("SolNode163", "阋神星", "阋神星Ixodes", "[数据删除]", MissionType.MT_UNKNOWN)},
                {
                    "SolNode164",
                    new Node("SolNode164", "阋神星Kala-", "阋神星Kala-azar", "Infested飞船", MissionType.MT_DEFENSE)
                },
                {"SolNode165", new Node("SolNode165", "阋神星", "阋神星Sporid", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode166", new Node("SolNode166", "阋神星", "阋神星Nimus", "Infested飞船", MissionType.MT_SURVIVAL)},
                {
                    "SolNode167",
                    new Node("SolNode167", "阋神星", "阋神星Oestrus", "Infested飞船", MissionType.MT_INFESTEDSALVAGE)
                },
                {"SolNode168", new Node("SolNode168", "阋神星", "阋神星Phalan", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode169", new Node("SolNode169", "阋神星", "阋神星Psoro", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode170", new Node("SolNode170", "阋神星", "阋神星Ranova", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode171", new Node("SolNode171", "阋神星", "阋神星Saxis", "Infested飞船", MissionType.MT_EXTERMINATION)},
                {"SolNode172", new Node("SolNode172", "阋神星", "阋神星Xini", "Corpus飞船", MissionType.MT_TERRITORY)},
                {"SolNode173", new Node("SolNode173", "阋神星", "阋神星Solium", "Infested飞船", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode174", new Node("SolNode174", "阋神星", "阋神星Sparga", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode175", new Node("SolNode175", "阋神星", "阋神星Naeglar", "Infested飞船", MissionType.MT_HIVE)},
                {"SolNode176", new Node("SolNode176", "阋神星", "阋神星Viver", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode177", new Node("SolNode177", "赛德娜", "赛德娜Kappa", "Grineer巨舰", MissionType.MT_INTEL)},
                {"SolNode178", new Node("SolNode178", "赛德娜", "赛德娜Hyosube", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode179", new Node("SolNode179", "赛德娜", "赛德娜Jengu", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode180", new Node("SolNode180", "赛德娜", "赛德娜Undine", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode181", new Node("SolNode181", "赛德娜", "赛德娜Adaro", "Grineer小行星", MissionType.MT_EXTERMINATION)},
                {"SolNode182", new Node("SolNode182", "赛德娜", "赛德娜Camenae", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode183", new Node("SolNode183", "赛德娜", "赛德娜Vodyanoi", "Grineer深海研究所", MissionType.MT_ARENA)},
                {"SolNode184", new Node("SolNode184", "赛德娜", "赛德娜Rusalka", "Grineer巨舰", MissionType.MT_CAPTURE)},
                {"SolNode185", new Node("SolNode185", "赛德娜", "赛德娜Berehynia", "Grineer船坞", MissionType.MT_TERRITORY)},
                {"SolNode186", new Node("SolNode186", "赛德娜", "赛德娜Phithale", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode187", new Node("SolNode187", "赛德娜", "赛德娜Selkie", "Grineer小行星", MissionType.MT_SURVIVAL)},
                {"SolNode188", new Node("SolNode188", "赛德娜", "赛德娜Kelpie", "Grineer巨舰", MissionType.MT_SABOTAGE)},
                {"SolNode189", new Node("SolNode189", "赛德娜", "赛德娜Naga", "Grineer巨舰", MissionType.MT_RESCUE)},
                {"SolNode190", new Node("SolNode190", "赛德娜", "赛德娜Nakki", "Grineer船坞", MissionType.MT_ARENA)},
                {"SolNode191", new Node("SolNode191", "赛德娜", "赛德娜Marid", "Grineer船坞", MissionType.MT_RETRIEVAL)},
                {"SolNode192", new Node("SolNode192", "赛德娜", "赛德娜Tikoloshe", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode193", new Node("SolNode193", "赛德娜", "赛德娜Merrow", "Grineer小行星", MissionType.MT_ASSASSINATION)},
                {"SolNode194", new Node("SolNode194", "赛德娜", "赛德娜Ponaturi", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode195", new Node("SolNode195", "赛德娜", "赛德娜Hydron", "Grineer巨舰", MissionType.MT_DEFENSE)},
                {
                    "SolNode196",
                    new Node("SolNode196", "赛德娜", "赛德娜Charybdis", "Grineer巨舰", MissionType.MT_MOBILE_DEFENSE)
                },
                {"SolNode197", new Node("SolNode197", "赛德娜", "赛德娜Graeae", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode198", new Node("SolNode198", "赛德娜", "赛德娜Scylla", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode199", new Node("SolNode199", "赛德娜", "赛德娜Yam", "Grineer深海研究所", MissionType.MT_ARENA)},
                {"SolNode200", new Node("SolNode200", "赛德娜", "赛德娜Veles", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode201", new Node("SolNode201", "赛德娜", "赛德娜Tiamat", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode202", new Node("SolNode202", "赛德娜", "赛德娜Yemaja", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode203", new Node("SolNode203", "欧罗巴", "欧罗巴Abaddon", "Corpus冰原星球", MissionType.MT_CAPTURE)},
                {"SolNode204", new Node("SolNode204", "欧罗巴", "欧罗巴Armaros", "Infested飞船", MissionType.MT_EXTERMINATION)},
                {"SolNode205", new Node("SolNode205", "欧罗巴", "欧罗巴Baal", "Corpus冰原星球", MissionType.MT_EXTERMINATION)},
                {"SolNode206", new Node("SolNode206", "欧罗巴", "欧罗巴Eligor", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode207", new Node("SolNode207", "欧罗巴", "欧罗巴Gamygyn", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode208", new Node("SolNode208", "欧罗巴", "欧罗巴Lillith", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode209", new Node("SolNode209", "欧罗巴", "欧罗巴Morax", "Corpus冰原星球", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode210", new Node("SolNode210", "欧罗巴", "欧罗巴Naamah", "Corpus冰原星球", MissionType.MT_ASSASSINATION)},
                {"SolNode211", new Node("SolNode211", "欧罗巴", "欧罗巴Ose", "Corpus冰原星球", MissionType.MT_TERRITORY)},
                {"SolNode212", new Node("SolNode212", "欧罗巴", "欧罗巴Paimon", "Corpus冰原星球", MissionType.MT_DEFENSE)},
                {"SolNode213", new Node("SolNode213", "欧罗巴", "欧罗巴Shax", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode214", new Node("SolNode214", "欧罗巴", "欧罗巴Sorath", "Corpus冰原星球", MissionType.MT_RETRIEVAL)},
                {"SolNode215", new Node("SolNode215", "欧罗巴", "欧罗巴Valac", "Corpus飞船", MissionType.MT_INTEL)},
                {"SolNode216", new Node("SolNode216", "欧罗巴", "欧罗巴Valefor", "Corpus冰原星球", MissionType.MT_EXCAVATE)},
                {"SolNode217", new Node("SolNode217", "欧罗巴", "欧罗巴Orias", "Corpus冰原星球", MissionType.MT_RESCUE)},
                {"SolNode218", new Node("SolNode218", "欧罗巴", "欧罗巴Zagan", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode219", new Node("SolNode219", "欧罗巴", "欧罗巴Beleth", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode220", new Node("SolNode220", "欧罗巴", "欧罗巴Kokabiel", "Corpus冰原星球", MissionType.MT_SABOTAGE)},
                {"SolNode221", new Node("SolNode221", "水星", "水星Neruda", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode222", new Node("SolNode222", "水星", "水星Eminescu", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode223", new Node("SolNode223", "水星", "水星Boethius", "Grineer小行星", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode224", new Node("SolNode224", "水星", "水星Odin", "Grineer巨舰", MissionType.MT_TERRITORY)},
                {"SolNode225", new Node("SolNode225", "水星", "水星Suisei", "Grineer巨舰", MissionType.MT_INTEL)},
                {"SolNode226", new Node("SolNode226", "水星", "水星Pantheon", "Grineer巨舰", MissionType.MT_EXTERMINATION)},
                {"SolNode227", new Node("SolNode227", "水星", "水星Verdi", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode228", new Node("SolNode228", "地球", "地球夜灵平野", "夜灵平野", MissionType.MT_LANDSCAPE)},
                {"SolNode300", new Node("SolNode300", "月球", "月球Plato", "Orokin之月", MissionType.MT_EXTERMINATION)},
                {"SolNode301", new Node("SolNode301", "月球", "月球Grimaldi", "Orokin之月", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode302", new Node("SolNode302", "月球", "月球Tycho", "Orokin之月", MissionType.MT_SURVIVAL)},
                {"SolNode304", new Node("SolNode304", "月球", "月球Copernicus", "Orokin之月", MissionType.MT_CAPTURE)},
                {"SolNode305", new Node("SolNode305", "月球", "月球Stofler", "Orokin之月", MissionType.MT_DEFENSE)},
                {"SolNode306", new Node("SolNode306", "月球", "月球Pavlov", "Orokin之月", MissionType.MT_INTEL)},
                {"SolNode307", new Node("SolNode307", "月球", "月球Zeipel", "Orokin之月", MissionType.MT_RESCUE)},
                {"SolNode400", new Node("SolNode400", "虚空", "虚空Teshub", "Orokin堡垒", MissionType.MT_EXTERMINATION)},
                {"SolNode401", new Node("SolNode401", "虚空", "虚空Hepit", "Orokin堡垒", MissionType.MT_CAPTURE)},
                {"SolNode402", new Node("SolNode402", "虚空", "虚空Taranis", "Orokin堡垒", MissionType.MT_DEFENSE)},
                {"SolNode403", new Node("SolNode403", "虚空", "虚空Tiwaz", "Orokin堡垒", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode404", new Node("SolNode404", "虚空", "虚空Stribog", "Orokin堡垒", MissionType.MT_SABOTAGE)},
                {"SolNode405", new Node("SolNode405", "虚空", "虚空Ani", "Orokin堡垒", MissionType.MT_SURVIVAL)},
                {"SolNode406", new Node("SolNode406", "虚空", "虚空Ukko", "Orokin堡垒", MissionType.MT_CAPTURE)},
                {"SolNode407", new Node("SolNode407", "虚空", "虚空Oxomoco", "Orokin堡垒", MissionType.MT_EXTERMINATION)},
                {"SolNode408", new Node("SolNode408", "虚空", "虚空Belenus", "Orokin堡垒", MissionType.MT_DEFENSE)},
                {"SolNode409", new Node("SolNode409", "虚空", "虚空Mot", "Orokin堡垒", MissionType.MT_SURVIVAL)},
                {"SolNode410", new Node("SolNode410", "虚空", "虚空Aten", "Orokin堡垒", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode411", new Node("SolNode411", "虚空", "虚空Marduk", "Orokin堡垒", MissionType.MT_SABOTAGE)},
                {"SolNode412", new Node("SolNode412", "虚空", "虚空Mithra", "Orokin堡垒", MissionType.MT_TERRITORY)},
                {
                    "SolNode706",
                    new Node("SolNode706", "被遗弃的Orokin船只", "被遗弃的Orokin船只 捕获", "被遗弃的Orokin船只", MissionType.MT_CAPTURE)
                },
                {
                    "SolNode707",
                    new Node("SolNode707", "被遗弃的Orokin船只", "被遗弃的Orokin船只 防御", "被遗弃的Orokin船只", MissionType.MT_DEFENSE)
                },
                {
                    "SolNode708",
                    new Node("SolNode708", "被遗弃的Orokin船只", "被遗弃的Orokin船只 歼灭", "被遗弃的Orokin船只",
                        MissionType.MT_EXTERMINATION)
                },
                {
                    "SolNode709",
                    new Node("SolNode709", "被遗弃的Orokin船只", "被遗弃的Orokin船只 移动防御", "被遗弃的Orokin船只",
                        MissionType.MT_MOBILE_DEFENSE)
                },
                {
                    "SolNode710",
                    new Node("SolNode710", "被遗弃的Orokin船只", "被遗弃的Orokin船只 破坏", "被遗弃的Orokin船只", MissionType.MT_SABOTAGE)
                },
                {
                    "SolNode711",
                    new Node("SolNode711", "被遗弃的Orokin船只", "被遗弃的Orokin船只 生存", "被遗弃的Orokin船只", MissionType.MT_SURVIVAL)
                },
                {
                    "SolNode712",
                    new Node("SolNode712", "被遗弃的Orokin船只", "被遗弃的Orokin船只 刺杀", "被遗弃的Orokin船只",
                        MissionType.MT_ASSASSINATION)
                },
                {"SolNode741", new Node("SolNode741", "赤毒要塞", "赤毒要塞Koro", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode742", new Node("SolNode742", "赤毒要塞", "赤毒要塞Nabuk", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode743", new Node("SolNode743", "赤毒要塞", "赤毒要塞Rotuma", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode744", new Node("SolNode744", "赤毒要塞", "赤毒要塞Taveuni", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode745", new Node("SolNode745", "赤毒要塞", "赤毒要塞Tamu", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode746", new Node("SolNode746", "赤毒要塞", "赤毒要塞Dakata", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode747", new Node("SolNode747", "赤毒要塞", "赤毒要塞Pago", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode748", new Node("SolNode748", "赤毒要塞", "赤毒要塞Garus", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode802", new Node("SolNode802", "[数据删除]", "[数据删除]", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode901", new Node("SolNode901", "", "Caduceus", "[数据删除]", MissionType.MT_UNKNOWN)},
                {"SolNode902", new Node("SolNode902", "金星", "金星Montes", "Corpus飞船", MissionType.MT_EXTERMINATION)},
                {"SolNode903", new Node("SolNode903", "地球", "地球Erpo", "外太空", MissionType.MT_MOBILE_DEFENSE)},
                {"SolNode904", new Node("SolNode904", "火星", "火星Syrtis", "外太空", MissionType.MT_EXTERMINATION)},
                {"SolNode905", new Node("SolNode905", "木星", "木星Galilea", "Corpus飞船", MissionType.MT_SABOTAGE)},
                {"SolNode906", new Node("SolNode906", "土星", "土星Pandora", "外太空", MissionType.MT_PURSUIT)},
                {"SolNode907", new Node("SolNode907", "天王星", "天王星Caelus", "外太空", MissionType.MT_TERRITORY)},
                {"SolNode908", new Node("SolNode908", "海王星", "海王星Salacia", "Corpus飞船", MissionType.MT_MOBILE_DEFENSE)}
            };
        }

        private static void InitPlanets()
        {
            Planet = new Dictionary<string, string>
            {
                {"Ceres", "谷神星"},
                {"Earth", "地球"},
                {"Eris", "阋神星"},
                {"Europa", "欧罗巴"},
                {"Jupiter", "木星"},
                {"Lua", "月球"},
                {"Mars", "火星"},
                {"Mercury", "水星"},
                {"Neptune", "海王星"},
                {"Phobos", "火卫一"},
                {"Pluto", "冥王星"},
                {"Saturn", "土星"},
                {"Sedna", "赛德娜"},
                {"Uranus", "天王星"},
                {"Venus", "金星"},
                {"Void", "虚空"},
                {"Kuva Fortress", "赤毒要塞"},
                {"Derelict", "被遗弃的Orokin船只"}
            };
        }

        private static void InitRivens()
        {
            RivenAttributes = new List<Riven.RivenAttribute>
            {
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "visi",
                    Suffix = "ata",
                    Text = "[{0:P2}到{1:P2}]近战伤害",
                    Alias = new List<string> {"伤害", "攻击", "基伤", "伤", "da"},
                    Scale = 165
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "magna",
                    Suffix = "ton",
                    Text = "[{0:P2}到{1:P2}]冲击伤害",
                    Alias = new List<string> {"冲击伤害", "冲击", "冲", "im"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "insi",
                    Suffix = "cak",
                    Text = "[{0:P2}到{1:P2}]穿刺伤害",
                    Alias = new List<string> {"穿刺伤害", "穿刺", "pu"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "sci",
                    Suffix = "sus",
                    Text = "[{0:P2}到{1:P2}]切割伤害",
                    Alias = new List<string> {"切割伤害", "切割", "切", "sl"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "crita",
                    Suffix = "cron",
                    Text = "[{0:P2}到{1:P2}]暴击率",
                    Alias = new List<string> {"暴率", "暴击率", "爆率", "暴击", "爆击", "crch", "cc"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "acri",
                    Suffix = "tis",
                    Text = "[{0:P2}到{1:P2}]暴击伤害",
                    Alias = new List<string> {"爆伤", "暴伤", "暴击伤害", "crda", "cd"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "geli",
                    Suffix = "do",
                    Text = "[{0:P2}到{1:P2}]冰冻伤害",
                    Alias = new List<string> {"冰冻伤害", "冰伤", "冰冻", "冰", "co"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "vexi",
                    Suffix = "tio",
                    Text = "[{0:P2}到{1:P2}]电击伤害",
                    Alias = new List<string> {"电击伤害", "电伤", "电击", "电", "el"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "igni",
                    Suffix = "pha",
                    Text = "[{0:P2}到{1:P2}]火焰伤害",
                    Alias = new List<string> {"火焰伤害", "火焰", "火伤", "火", "he"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "toxi",
                    Suffix = "tox",
                    Text = "[{0:P2}到{1:P2}]毒素伤害",
                    Alias = new List<string> {"毒素伤害", "毒素", "毒伤", "毒", "to"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "hexa",
                    Suffix = "dex",
                    Text = "[{0:P2}到{1:P2}]触发几率",
                    Alias = new List<string> {"触发几率", "触发", "触发率", "stch"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "deci",
                    Suffix = "des",
                    Text = "[{0:P2}到{1:P2}]触发时间",
                    Alias = new List<string> {"触发时间", "时间", "stdu"},
                    CanCurse = true,
                    Scale = 100
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "manti",
                    Suffix = "tron",
                    Text = "[{0:P2}到{1:P2}]对Corpus伤害",
                    Alias = new List<string> {"对corpus伤害", "c佬", "c系", "c", "datoco", "corpus"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "argi",
                    Suffix = "con",
                    Text = "[{0:P2}到{1:P2}]对Grineer伤害",
                    Alias = new List<string> {"对grineer伤害", "g佬", "g系", "g", "datogr", "grineer"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "pura",
                    Suffix = "ada",
                    Text = "[{0:P2}到{1:P2}]对Infested伤害",
                    Alias = new List<string> {"对infested伤害", "i佬", "i系", "i", "datoin", "infested"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "croni",
                    Suffix = "dra",
                    Text = "[{0:P2}到{1:P2}]攻击速度",
                    Alias = new List<string> {"攻速", "攻击速度", "fira", "atsp"},
                    CanCurse = true,
                    Scale = 53
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "uti",
                    Suffix = "tia",
                    Text = "[{0:P2}到{1:P2}]导引效率",
                    Alias = new List<string> {"引导效率", "导引效率", "充能效率", "效率", "chef"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "tori",
                    Suffix = "bo",
                    Text = "[{0:P2}到{1:P2}]导引伤害",
                    Alias = new List<string> {"引导伤害", "导引伤害", "充能伤害", "充能", "chda"},
                    Scale = 150
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "exi",
                    Suffix = "cta",
                    Text = "[{0:P2}到{1:P2}]处决伤害",
                    Alias = new List<string> {"处决伤害", "终结", "处决", "fida"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "locti",
                    Suffix = "tor",
                    Text = "[{0:P2}到{1:P2}]攻击范围",
                    Alias = new List<string> {"攻击范围", "范围", "ra"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "pleci",
                    Suffix = "nent",
                    Text = "滑行攻击有[{0:P2}到{1:P2}]的几率造成暴击",
                    Alias = new List<string>
                    {
                        "滑暴",
                        "滑爆",
                        "划爆",
                        "划暴",
                        "滑砍",
                        "划砍",
                        "sl",
                        "slat",
                        "slatha"
                    },
                    CanCurse = true,
                    Scale = 90.0
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Melee,
                    Prefix = "tempi",
                    Suffix = "nem",
                    Text = "连击时间[{0:F2}到{1:F2}]秒",
                    Alias = new List<string> {"连击时间", "连击", "codu"},
                    CanCurse = true,
                    Scale = 8.1
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "sati",
                    Suffix = "can",
                    Text = "[{0:P2}到{1:P2}]多重射击",
                    Alias = new List<string> {"多重射击", "多重", "mu"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "visi",
                    Suffix = "ata",
                    Text = "[{0:P2}到{1:P2}]伤害",
                    Alias = new List<string> {"伤害", "攻击", "基伤", "伤", "da"},
                    CanCurse = true,
                    Scale = 165
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "magna",
                    Suffix = "ton",
                    Text = "[{0:P2}到{1:P2}]冲击伤害",
                    Alias = new List<string> {"冲击伤害", "冲击", "冲", "im"},
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "insi",
                    Suffix = "cak",
                    Text = "[{0:P2}到{1:P2}]穿刺伤害",
                    Alias = new List<string> {"穿刺伤害", "穿刺", "pu"},
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "sci",
                    Suffix = "sus",
                    Text = "[{0:P2}到{1:P2}]切割伤害",
                    Alias = new List<string> {"切割伤害", "切割", "切", "sl"},
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "crita",
                    Suffix = "cron",
                    Text = "[{0:P2}到{1:P2}]暴击率",
                    Alias = new List<string> {"暴率", "暴击率", "爆率", "暴击", "爆击", "crch", "cc"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "acri",
                    Suffix = "tis",
                    Text = "[{0:P2}到{1:P2}]暴击伤害",
                    Alias = new List<string> {"爆伤", "暴伤", "暴击伤害", "crda", "cd"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "geli",
                    Suffix = "do",
                    Text = "[{0:P2}到{1:P2}]冰冻伤害",
                    Alias = new List<string> {"冰冻伤害", "冰伤", "冰冻", "冰", "co"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "vexi",
                    Suffix = "tio",
                    Text = "[{0:P2}到{1:P2}]电击伤害",
                    Alias = new List<string> {"电击伤害", "电伤", "电击", "电", "el"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "igni",
                    Suffix = "pha",
                    Text = "[{0:P2}到{1:P2}]火焰伤害",
                    Alias = new List<string> {"火焰伤害", "火焰", "火伤", "火", "he"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "toxi",
                    Suffix = "tox",
                    Text = "[{0:P2}到{1:P2}]毒素伤害",
                    Alias = new List<string> {"毒素伤害", "毒素", "毒伤", "毒", "to"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "hexa",
                    Suffix = "dex",
                    Text = "[{0:P2}到{1:P2}]触发几率",
                    Alias = new List<string> {"触发几率", "触发", "触发率", "stch"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "deci",
                    Suffix = "des",
                    Text = "[{0:P2}到{1:P2}]触发时间",
                    Alias = new List<string> {"触发时间", "时间", "stdu"},
                    CanCurse = true,
                    Scale = 100
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "manti",
                    Suffix = "tron",
                    Text = "[{0:P2}到{1:P2}]对Corpus伤害",
                    Alias = new List<string> {"对corpus伤害", "c佬", "c系", "c", "datoco", "corpus"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "argi",
                    Suffix = "con",
                    Text = "[{0:P2}到{1:P2}]对Grineer伤害",
                    Alias = new List<string> {"对grineer伤害", "g佬", "g系", "g", "datogr", "grineer"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "pura",
                    Suffix = "ada",
                    Text = "[{0:P2}到{1:P2}]对Infested伤害",
                    Alias = new List<string> {"对infested伤害", "i佬", "i系", "i", "datoin", "infested"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "croni",
                    Suffix = "dra",
                    Text = "[{0:P2}到{1:P2}]射速（弓类武器效果加倍）",
                    Alias = new List<string> {"射速", "攻速", "攻击速度", "fira", "atsp"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "arma",
                    Suffix = "tin",
                    Text = "[{0:P2}到{1:P2}]弹匣容量",
                    Alias = new List<string> {"弹匣容量", "弹匣", "弹夹", "弹夹容量", "maca", "masi", "ma"},
                    CanCurse = true,
                    Scale = 50
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "ampi",
                    Suffix = "bin",
                    Text = "[{0:P2}到{1:P2}]弹药最大值",
                    Alias = new List<string> {"弹药", "amma"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "conci",
                    Suffix = "nak",
                    Text = "[{0:P2}到{1:P2}]弹道飞行速度",
                    Alias = new List<string> {"弹道", "飞行速度", "飞行", "prflsp"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "feva",
                    Suffix = "tak",
                    Text = "[{0:P2}到{1:P2}]装填速度",
                    Alias = new List<string> {"装填速度", "换弹", "装弹", "装填", "resp"},
                    CanCurse = true,
                    Scale = 50
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "zeti",
                    Suffix = "mag",
                    Text = "[{0:P2}到{1:P2}]武器后坐力",
                    Alias = new List<string> {"后座", "后座力", "后坐", "后坐力", "were"},
                    CanCurse = true,
                    Scale = -90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Shotgun,
                    Prefix = "lexi",
                    Suffix = "nok",
                    Text = "[{0:F2}到{1:F2}]穿透",
                    Alias = new List<string> {"穿透", "穿", "puth"},
                    Scale = 2.7
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "sati",
                    Suffix = "can",
                    Text = "[{0:P2}到{1:P2}]多重射击",
                    Alias = new List<string> {"多重射击", "多重", "mu"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "visi",
                    Suffix = "ata",
                    Text = "[{0:P2}到{1:P2}]伤害",
                    Alias = new List<string> {"伤害", "攻击", "基伤", "伤", "da"},
                    CanCurse = true,
                    Scale = 220
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "magna",
                    Suffix = "ton",
                    Text = "[{0:P2}到{1:P2}]冲击伤害",
                    Alias = new List<string> {"冲击伤害", "冲击", "冲", "im"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "insi",
                    Suffix = "cak",
                    Text = "[{0:P2}到{1:P2}]穿刺伤害",
                    Alias = new List<string> {"穿刺伤害", "穿刺", "pu"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "sci",
                    Suffix = "sus",
                    Text = "[{0:P2}到{1:P2}]切割伤害",
                    Alias = new List<string> {"切割伤害", "切割", "切", "sl"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "crita",
                    Suffix = "cron",
                    Text = "[{0:P2}到{1:P2}]暴击率",
                    Alias = new List<string> {"暴率", "暴击率", "爆率", "暴击", "爆击", "crch", "cc"},
                    CanCurse = true,
                    Scale = 150
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "acri",
                    Suffix = "tis",
                    Text = "[{0:P2}到{1:P2}]暴击伤害",
                    Alias = new List<string> {"爆伤", "暴伤", "暴击伤害", "crda", "cd"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "geli",
                    Suffix = "do",
                    Text = "[{0:P2}到{1:P2}]冰冻伤害",
                    Alias = new List<string> {"冰冻伤害", "冰伤", "冰冻", "冰", "co"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "vexi",
                    Suffix = "tio",
                    Text = "[{0:P2}到{1:P2}]电击伤害",
                    Alias = new List<string> {"电击伤害", "电伤", "电击", "电", "el"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "igni",
                    Suffix = "pha",
                    Text = "[{0:P2}到{1:P2}]火焰伤害",
                    Alias = new List<string> {"火焰伤害", "火焰", "火伤", "火", "he"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "toxi",
                    Suffix = "tox",
                    Text = "[{0:P2}到{1:P2}]毒素伤害",
                    Alias = new List<string> {"毒素伤害", "毒素", "毒伤", "毒", "to"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "hexa",
                    Suffix = "dex",
                    Text = "[{0:P2}到{1:P2}]触发几率",
                    Alias = new List<string> {"触发几率", "触发", "触发率", "stch"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "deci",
                    Suffix = "des",
                    Text = "[{0:P2}到{1:P2}]触发时间",
                    Alias = new List<string> {"触发时间", "时间", "stdu"},
                    CanCurse = true,
                    Scale = 100
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "manti",
                    Suffix = "tron",
                    Text = "[{0:P2}到{1:P2}]对Corpus伤害",
                    Alias = new List<string> {"对corpus伤害", "c佬", "c系", "c", "datoco", "corpus"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "argi",
                    Suffix = "con",
                    Text = "[{0:P2}到{1:P2}]对Grineer伤害",
                    Alias = new List<string> {"对grineer伤害", "g佬", "g系", "g", "datogr", "grineer"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "pura",
                    Suffix = "ada",
                    Text = "[{0:P2}到{1:P2}]对Infested伤害",
                    Alias = new List<string> {"对infested伤害", "i佬", "i系", "i", "datoin", "infested"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "croni",
                    Suffix = "dra",
                    Text = "[{0:P2}到{1:P2}]射速",
                    Alias = new List<string> {"射速", "攻速", "攻击速度", "fira", "atsp"},
                    CanCurse = true,
                    Scale = 75
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "arma",
                    Suffix = "tin",
                    Text = "[{0:P2}到{1:P2}]弹匣容量",
                    Alias = new List<string> {"弹匣容量", "弹匣", "弹夹", "弹夹容量", "maca", "masi", "ma"},
                    CanCurse = true,
                    Scale = 50
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "ampi",
                    Suffix = "bin",
                    Text = "[{0:P2}到{1:P2}]弹药最大值",
                    Alias = new List<string> {"弹药", "amma"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "conci",
                    Suffix = "nak",
                    Text = "[{0:P2}到{1:P2}]弹道飞行速度",
                    Alias = new List<string> {"弹道", "飞行速度", "飞行", "prflsp"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "feva",
                    Suffix = "tak",
                    Text = "[{0:P2}到{1:P2}]装填速度",
                    Alias = new List<string> {"装填速度", "换弹", "装弹", "装填", "resp"},
                    CanCurse = true,
                    Scale = 50
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "zeti",
                    Suffix = "mag",
                    Text = "[{0:P2}到{1:P2}]武器后坐力",
                    Alias = new List<string> {"后座", "后座力", "后坐", "后坐力", "were"},
                    CanCurse = true,
                    Scale = -90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "hera",
                    Suffix = "lis",
                    Text = "[{0:P2}到{1:P2}]变焦",
                    Alias = new List<string> {"瞄准", "变焦", "zo"},
                    CanCurse = true,
                    Scale = 80
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Pistol,
                    Prefix = "lexi",
                    Suffix = "nok",
                    Text = "[{0:F2}到{1:F2}]穿透",
                    Alias = new List<string> {"穿透", "穿", "puth"},
                    Scale = 2.7
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "sati",
                    Suffix = "can",
                    Text = "[{0:P2}到{1:P2}]多重射击",
                    Alias = new List<string> {"多重射击", "多重", "mu"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "visi",
                    Suffix = "ata",
                    Text = "[{0:P2}到{1:P2}]伤害",
                    Alias = new List<string> {"伤害", "攻击", "基伤", "伤", "da"},
                    CanCurse = true,
                    Scale = 165
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "magna",
                    Suffix = "ton",
                    Text = "[{0:P2}到{1:P2}]冲击伤害",
                    Alias = new List<string> {"冲击伤害", "冲击", "冲", "im"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "insi",
                    Suffix = "cak",
                    Text = "[{0:P2}到{1:P2}]穿刺伤害",
                    Alias = new List<string> {"穿刺伤害", "穿刺", "pu"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "sci",
                    Suffix = "sus",
                    Text = "[{0:P2}到{1:P2}]切割伤害",
                    Alias = new List<string> {"切割伤害", "切割", "切", "sl"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "crita",
                    Suffix = "cron",
                    Text = "[{0:P2}到{1:P2}]暴击率",
                    Alias = new List<string> {"暴率", "暴击率", "爆率", "暴击", "爆击", "crch", "cc"},
                    CanCurse = true,
                    Scale = 150
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "acri",
                    Suffix = "tis",
                    Text = "[{0:P2}到{1:P2}]暴击伤害",
                    Alias = new List<string> {"爆伤", "暴伤", "暴击伤害", "crda", "cd"},
                    CanCurse = true,
                    Scale = 120
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "geli",
                    Suffix = "do",
                    Text = "[{0:P2}到{1:P2}]冰冻伤害",
                    Alias = new List<string> {"冰冻伤害", "冰伤", "冰冻", "冰", "co"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "vexi",
                    Suffix = "tio",
                    Text = "[{0:P2}到{1:P2}]电击伤害",
                    Alias = new List<string> {"电击伤害", "电伤", "电击", "电", "el"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "igni",
                    Suffix = "pha",
                    Text = "[{0:P2}到{1:P2}]火焰伤害",
                    Alias = new List<string> {"火焰伤害", "火焰", "火伤", "火", "he"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "toxi",
                    Suffix = "tox",
                    Text = "[{0:P2}到{1:P2}]毒素伤害",
                    Alias = new List<string> {"毒素伤害", "毒素", "毒伤", "毒", "to"},
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "hexa",
                    Suffix = "dex",
                    Text = "[{0:P2}到{1:P2}]触发几率",
                    Alias = new List<string> {"触发几率", "触发", "触发率", "stch"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "deci",
                    Suffix = "des",
                    Text = "[{0:P2}到{1:P2}]触发时间",
                    Alias = new List<string> {"触发时间", "时间", "stdu"},
                    CanCurse = true,
                    Scale = 100
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "manti",
                    Suffix = "tron",
                    Text = "[{0:P2}到{1:P2}]对Corpus伤害",
                    Alias = new List<string> {"对corpus伤害", "c佬", "c系", "c", "datoco", "corpus"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "argi",
                    Suffix = "con",
                    Text = "[{0:P2}到{1:P2}]对Grineer伤害",
                    Alias = new List<string> {"对grineer伤害", "g佬", "g系", "g", "datogr", "grineer"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "pura",
                    Suffix = "ada",
                    Text = "[{0:P2}到{1:P2}]对Infested伤害",
                    Alias = new List<string> {"对infested伤害", "i佬", "i系", "i", "datoin", "infested"},
                    CanCurse = true,
                    Scale = 45
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "croni",
                    Suffix = "dra",
                    Text = "[{0:P2}到{1:P2}]射速（弓类武器效果加倍）",
                    Alias = new List<string> {"射速", "攻速", "攻击速度", "fira", "atsp"},
                    CanCurse = true,
                    Scale = 60
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "arma",
                    Suffix = "tin",
                    Text = "[{0:P2}到{1:P2}]弹匣容量",
                    Alias = new List<string> {"弹匣容量", "弹匣", "弹夹", "弹夹容量", "maca", "masi", "ma"},
                    CanCurse = true,
                    Scale = 50
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "ampi",
                    Suffix = "bin",
                    Text = "[{0:P2}到{1:P2}]弹药最大值",
                    Alias = new List<string> {"弹药", "amma"},
                    CanCurse = true,
                    Scale = 50
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "conci",
                    Suffix = "nak",
                    Text = "[{0:P2}到{1:P2}]弹道飞行速度",
                    Alias = new List<string> {"弹道", "飞行速度", "飞行", "prflsp"},
                    CanCurse = true,
                    Scale = 90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "feva",
                    Suffix = "tak",
                    Text = "[{0:P2}到{1:P2}]装填速度",
                    Alias = new List<string> {"装填速度", "换弹", "装弹", "装填", "resp"},
                    CanCurse = true,
                    Scale = 50
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "zeti",
                    Suffix = "mag",
                    Text = "[{0:P2}到{1:P2}]武器后坐力",
                    Alias = new List<string> {"后座", "后座力", "后坐", "后坐力", "were"},
                    CanCurse = true,
                    Scale = -90
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "hera",
                    Suffix = "lis",
                    Text = "[{0:P2}到{1:P2}]变焦",
                    Alias = new List<string> {"瞄准", "变焦", "zo"},
                    CanCurse = true,
                    Scale = 60
                },
                new Riven.RivenAttribute
                {
                    Weapon = WeaponType.Primary,
                    Prefix = "lexi",
                    Suffix = "nok",
                    Text = "[{0:F2}到{1:F2}]穿透",
                    Alias = new List<string> {"穿透", "穿", "puth"},
                    Scale = 2.7
                }
            };
            RivenRedirection = new Dictionary<string, string>
            {
                {"AKBOLTO PRIME", "AKBOLTO"},
                {"AKBRONCO PRIME", "AKBRONCO"},
                {"AKLEX PRIME", "AKLEX"},
                {"AKSTILETTO PRIME", "AKSTILETTO"},
                {"ANKYROS PRIME", "ANKYROS"},
                {"BALLISTICA PRIME", "BALLISTICA"},
                {"BO PRIME", "BO"},
                {"BOAR PRIME", "BOAR"},
                {"BOLTOR PRIME", "BOLTOR"},
                {"BRATON PRIME", "BRATON"},
                {"BRATON VANDAL", "BRATON"},
                {"BRONCO PRIME", "BRONCO"},
                {"BURST LASER PRIME", "BURST LASER"},
                {"BURSTON PRIME", "BURSTON"},
                {"CARMINE PENTA", "PENTA"},
                {"CERNOS PRIME", "CERNOS"},
                {"DECONSTRUCTOR PRIME", "DECONSTRUCTOR"},
                {"DERA VANDAL", "DERA"},
                {"DESTREZA PRIME", "DESTREZA"},
                {"DETH MACHINE RIFLE PRIME", "DETH MACHINE RIFLE"},
                {"DEX FURIS", "AFURIS"},
                {"DEX SYBARIS", "SYBARIS"},
                {"DUAL KAMAS PRIME", "DUAL KAMAS"},
                {"FANG PRIME", "FANG"},
                {"FRAGOR PRIME", "FRAGOR"},
                {"FURAX WRAITH", "FURAX"},
                {"GALATINE PRIME", "GALATINE"},
                {"GLAIVE PRIME", "GLAIVE"},
                {"GORGON WRAITH", "GORGON"},
                {"HIKOU PRIME", "HIKOU"},
                {"IGNIS WRAITH", "IGNIS"},
                {"KARAK WRAITH", "KARAK"},
                {"KOGAKE PRIME", "KOGAKE"},
                {"LATO PRIME", "LATO"},
                {"LATO VANDAL", "LATO"},
                {"LATRON PRIME", "LATRON"},
                {"LATRON WRAITH", "LATRON"},
                {"LEX PRIME", "LEX"},
                {"MACHETE WRAITH", "MACHETE"},
                {"MARA DETRON", "DETRON"},
                {"MK1-BO", "BO"},
                {"MK1-BRATON", "BRATON"},
                {"MK1-FURAX", "FURAX"},
                {"MK1-FURIS", "FURIS"},
                {"MK1-KUNAI", "KUNAI"},
                {"MK1-PARIS", "PARIS"},
                {"MK1-STRUN", "STRUN"},
                {"NIKANA PRIME", "NIKANA"},
                {"ORTHOS PRIME", "ORTHOS"},
                {"PARIS PRIME", "PARIS"},
                {"PRIME LASER RIFLE", "LASER RIFLE"},
                {"PRISMA ANGSTRUM", "ANGSTRUM"},
                {"PRISMA BURST LASER", "BURST LASER"},
                {"PRISMA DUAL CLEAVERS", "DUAL CLEAVERS"},
                {"PRISMA GORGON", "GORGON"},
                {"PRISMA GRAKATA", "GRAKATA"},
                {"PRISMA MACHETE", "MACHETE"},
                {"PRISMA OBEX", "OBEX"},
                {"PRISMA SKANA", "SKANA"},
                {"PRISMA TETRA", "TETRA"},
                {"PRISMA TWIN GREMLINS", "TWIN GREMLINS"},
                {"PROVA VANDAL", "PROVA"},
                {"PYRANA PRIME", "PYRANA"},
                {"QUANTA VANDAL", "QUANTA"},
                {"RAKTA BALLISTICA", "BALLISTICA"},
                {"RAKTA CERNOS", "CERNOS"},
                {"RAKTA DARK DAGGER", "DARK DAGGER"},
                {"REAPER PRIME", "REAPER"},
                {"SANCTI CASTANAS", "CASTANAS"},
                {"SANCTI MAGISTAR", "MAGISTAR"},
                {"SANCTI TIGRIS", "TIGRIS"},
                {"SCINDO PRIME", "SCINDO"},
                {"SECURA DUAL CESTRA", "DUAL CESTRA"},
                {"SECURA LECTA", "LECTA"},
                {"SECURA PENTA", "PENTA"},
                {"SICARUS PRIME", "SICARUS"},
                {"SKANA PRIME", "SKANA"},
                {"SNIPETRON VANDAL", "SNIPETRON"},
                {"SOMA PRIME", "SOMA"},
                {"SPIRA PRIME", "SPIRA"},
                {"STINGER PRIME", "STINGER"},
                {"STRUN WRAITH", "STRUN"},
                {"SUPRA VANDAL", "SUPRA"},
                {"SWEEPER PRIME", "SWEEPER"},
                {"SYBARIS PRIME", "SYBARIS"},
                {"SYNOID GAMMACOR", "GAMMACOR"},
                {"SYNOID HELIOCOR", "HELIOCOR"},
                {"SYNOID SIMULOR", "SIMULOR"},
                {"TELOS AKBOLTO", "AKBOLTO"},
                {"TELOS BOLTACE", "BOLTACE"},
                {"TELOS BOLTOR", "BOLTOR"},
                {"TIGRIS PRIME", "TIGRIS"},
                {"TWIN VIPERS WRAITH", "TWIN VIPERS"},
                {"VASTO PRIME", "VASTO"},
                {"VAYKOR HEK", "HEK"},
                {"VAYKOR MARELOK", "MARELOK"},
                {"VAYKOR SYDON", "SYDON"},
                {"VECTIS PRIME", "VECTIS"},
                {"VENKA PRIME", "VENKA"},
                {"VIPER WRAITH", "VIPER"},
                {"VULKAR WRAITH", "VULKAR"}
            };
        }

        private static void InitSorties()
        {
            Sortie = new Dictionary<string, string>
            {
                {"SORTIE_BOSS_ALAD", "击败Alad V的部队"},
                {"SORTIE_BOSS_AMBULAS", "击败Ambulas的部队"},
                {"SORTIE_BOSS_CORRUPTED_VOR", "击败堕落的Vor的部队"},
                {"SORTIE_BOSS_HEK", "击败Vay Hek委员的部队"},
                {"SORTIE_BOSS_HYENA", "击败鬣狗群的部队"},
                {"SORTIE_BOSS_INFALAD", "击败异融者Alad V的部队"},
                {"SORTIE_BOSS_JACKAL", "击败豺狼的部队"},
                {"SORTIE_BOSS_KELA", "击败Kela De Thaym的部队"},
                {"SORTIE_BOSS_KRIL", "击败Lech Kril中尉的部队"},
                {"SORTIE_BOSS_LEPHANTIS", "击败Lephantis的部队"},
                {"SORTIE_BOSS_NEF", "击败Nef Anyo的部队"},
                {"SORTIE_BOSS_PHORID", "击败Phorid的部队"},
                {"SORTIE_BOSS_RAPTOR", "击败猛禽的部队"},
                {"SORTIE_BOSS_RUK", "击败Sargas Ruk将军的部队"},
                {"SORTIE_BOSS_TYL", "击败Tyl Regor的部队"},
                {"SORTIE_BOSS_VOR", "击败Vor上尉的部队"},
                {"SORTIE_MODIFIER_ARMOR", "敌人护甲强化"},
                {"SORTIE_MODIFIER_BOW_ONLY", "弓箭 限定"},
                {"SORTIE_MODIFIER_CORROSIVE", "敌人元素强化(腐蚀)"},
                {"SORTIE_MODIFIER_ELECTRICITY", "敌人元素强化(电击)"},
                {"SORTIE_MODIFIER_EXIMUS", "卓越者大本营"},
                {"SORTIE_MODIFIER_EXPLOSION", "敌人元素强化(爆炸)"},
                {"SORTIE_MODIFIER_FIRE", "敌人元素强化(火焰)"},
                {"SORTIE_MODIFIER_FREEZE", "敌人元素强化(冰冻)"},
                {"SORTIE_MODIFIER_GAS", "敌人元素强化(毒气)"},
                {"SORTIE_MODIFIER_HAZARD_COLD", "极度寒冷(移动减速)"},
                {"SORTIE_MODIFIER_HAZARD_FIRE", "火灾(损害生命)"},
                {"SORTIE_MODIFIER_HAZARD_FOG", "浓雾(可视减少)"},
                {"SORTIE_MODIFIER_HAZARD_ICE", "低温外泄(护盾减少)"},
                {"SORTIE_MODIFIER_HAZARD_MAGNETIC", "电磁异常(能量干扰)"},
                {"SORTIE_MODIFIER_HAZARD_RADIATION", "辐射灾害(队友伤害)"},
                {"SORTIE_MODIFIER_IMPACT", "敌人物理强化(冲击)"},
                {"SORTIE_MODIFIER_LOW_ENERGY", "能量上限减少"},
                {"SORTIE_MODIFIER_MAGNETIC", "敌人元素强化(磁力)"},
                {"SORTIE_MODIFIER_MELEE_ONLY", "近战 限定"},
                {"SORTIE_MODIFIER_POISON", "敌人元素强化(毒素)"},
                {"SORTIE_MODIFIER_PUNCTURE", "敌人物理强化(穿刺)"},
                {"SORTIE_MODIFIER_RADIATION", "敌人元素强化(辐射)"},
                {"SORTIE_MODIFIER_RIFLE_ONLY", "突击步枪 限定"},
                {"SORTIE_MODIFIER_SECONDARY_ONLY", "次要 限定"},
                {"SORTIE_MODIFIER_SHIELDS", "敌人护盾强化"},
                {"SORTIE_MODIFIER_SHOTGUN_ONLY", "霰弹枪 限定"},
                {"SORTIE_MODIFIER_SLASH", "敌人物理强化(切割)"},
                {"SORTIE_MODIFIER_SNIPER_ONLY", "狙击枪 限定"},
                {"SORTIE_MODIFIER_VIRAL", "敌人元素强化(病毒)"}
            };
        }

        private static void InitStndicates()
        {
            Syndicate = new Dictionary<string, string>
            {
                {"ArbitersSyndicate", "均衡仲裁者"},
                {"CephalonSudaSyndicate", "中枢苏达"},
                {"NewLokaSyndicate", "新世间"},
                {"PerrinSyndicate", "佩兰数列"},
                {"AssassinsSyndicate", "某神秘集团"},
                {"RedVeilSyndicate", "血色面纱"},
                {"SteelMeridianSyndicate", "钢铁防线"},
                {"CetusSyndicate", "Ostron"},
                {"EventSyndicate", "行动补给"},
                {"QuillsSyndicate", "夜羽"}
            };
        }

        private static void InitTilesets()
        {
            Tileset = new Dictionary<string, string>
            {
                {"GrineerAsteroidTileset", "Grineer小行星"},
                {"GrineerGalleonTileset", "Grineer巨舰"},
                {"CorpusIcePlanetTilesetCaves", "Corpus冰原星球(洞穴)"},
                {"CorpusGasCityTileset", "Corpus燃气城市"},
                {"CorpusShipTileset", "Corpus飞船"},
                {"OrokinMoonTilesetCorpus", "Orokin之月(Corpus)"},
                {"OrokinVoidTileset", "Orokin虚空"}
            };
        }

        private static void InitWeaponAlias()
        {
            WeaponAlias = new Dictionary<string, List<string>>
            {
                {"ACK & BRUNT", new List<string> {"Ack & Brunt", "认知&冲击", "认知&冲击", "认知冲击"}},
                {"ACRID", new List<string> {"Acrid", "阿克里德", "刻薄毒镖"}},
                {"AFURIS", new List<string> {"Afuris", "盗贼双枪", "双持弗里斯手枪"}},
                {"AKBOLTO PRIME", new List<string> {"Akbolto Prime", "螺钉双枪Prime", "圣装双持角犀", "螺钉双枪P", "螺双"}},
                {"AKBOLTO", new List<string> {"Akbolto", "螺钉双枪", "双持角犀"}},
                {"AKBRONCO PRIME", new List<string> {"Akbronco Prime", "野马双枪Prime", "圣装双持布隆克烈驹", "野马双枪P"}},
                {"AKBRONCO", new List<string> {"Akbronco", "野马双枪", "双持布隆克烈驹"}},
                {"AKJAGARA", new List<string> {"Akjagara", "觉醒双枪", "觉醒双枪"}},
                {"AKLATO", new List<string> {"Aklato", "拉托双枪", "双持拉托"}},
                {"AKLEX PRIME", new List<string> {"Aklex Prime", "雷克斯双枪Prime", "圣装双持秩序之握", "雷克斯双枪P", "雷双"}},
                {"AKLEX", new List<string> {"Aklex", "雷克斯双枪", "双持秩序之握"}},
                {"AKMAGNUS", new List<string> {"Akmagnus", "麦格努斯双枪", "猛犸双枪"}},
                {"AKSOMATI", new List<string> {"Aksomati", "轻灵月神双枪", "轻灵索玛双枪"}},
                {
                    "AKSTILETTO PRIME",
                    new List<string> {"Akstiletto Prime", "史提托双枪Prime", "圣装双持西提列托", "史提托双枪P", "史提托", "尸体拖"}
                },
                {"AKSTILETTO", new List<string> {"Akstiletto", "史提托双枪", "双持西提列托"}},
                {"AKVASTO", new List<string> {"Akvasto", "瓦斯托双枪", "瓦斯托双枪"}},
                {"AKZANI", new List<string> {"Akzani", "荒谬双枪", "双持欢喜丸"}},
                {"AMPHIS", new List<string> {"Amphis", "双头蛇", "安菲斯"}},
                {"AMPREX", new List<string> {"Amprex", "安培克斯", "安普斯雷电", "电枪"}},
                {"ANGSTRUM", new List<string> {"Angstrum", "安格斯壮", "将军手持短炮"}},
                {"ANKU", new List<string> {"Anku", "夺魂死神", "噬魂镰"}},
                {"ANKYROS PRIME", new List<string> {"Ankyros Prime", "甲龙双拳Prime", "圣装安奇洛斯拳套", "甲龙双拳P"}},
                {"ANKYROS", new List<string> {"Ankyros", "甲龙双拳", "安奇洛斯拳套"}},
                {"ARCA PLASMOR", new List<string> {"Arca Plasmor", "弧电离子枪", "弧电离子枪", "弧电喷"}},
                {"ARCA SCISCO", new List<string> {"Arca Scisco", "弧电探知者", "弧电探知者"}},
                {"ARCA TITRON", new List<string> {"Arca Titron", "弧电振子锤", "弧电振子锤"}},
                {"ARGONAK", new List<string> {"Argonak", "氩格纳克", "氩格纳克"}},
                {"ARTAX", new List<string> {"Artax", "阿塔克斯", "阿塔克斯"}},
                {"ASTILLA", new List<string> {"Astilla", "碎裂者", "碎裂者", "玻璃炮"}},
                {"ATOMOS", new List<string> {"Atomos", "原子矿融炮", "原子矿融炮"}},
                {"ATTERAX", new List<string> {"Atterax", "阿特拉克斯", "刑罚绞索", "G鞭"}},
                {"ATTICA", new List<string> {"Attica", "阿提卡", "阿提卡重弩"}},
                {"AZIMA", new List<string> {"Azima", "方位角", "日冕"}},
                {"BALLA", new List<string> {"Balla", "宝拉", "轻短刃"}},
                {"BALLISTICA PRIME", new List<string> {"Ballistica Prime", "布里斯提卡Prime", "圣装惊惧手弩", "布里斯提卡P"}},
                {"BALLISTICA", new List<string> {"Ballistica", "布里斯提卡", "惊惧手弩"}},
                {"BAZA", new List<string> {"Baza", "苍鹰", "苍鹰"}},
                {"BO PRIME", new List<string> {"Bo Prime", "珀之武杖Prime", "圣装破禅武杖", "珀之武杖P"}},
                {"BO", new List<string> {"Bo", "珀之武杖", "破禅武杖", "珀", "武杖"}},
                {"BOAR PRIME", new List<string> {"Boar Prime", "野猪Prime", "圣装雄猪霰弹枪", "野猪P"}},
                {"BOAR", new List<string> {"Boar", "野猪", "雄猪霰弹枪"}},
                {"BOLTACE", new List<string> {"Boltace", "螺钉拐刃", "螺钉弧月刀", "螺钉拐"}},
                {"BOLTO", new List<string> {"Bolto", "螺钉手枪", "角犀"}},
                {"BOLTOR PRIME", new List<string> {"Boltor Prime", "螺钉步枪Prime", "圣装波尔托骨刺", "螺钉步枪P", "螺钉P", "鱼骨P"}},
                {"BOLTOR", new List<string> {"Boltor", "螺钉步枪", "波尔托骨刺", "鱼骨"}},
                {"BRAKK", new List<string> {"Brakk", "布拉克", "布拉克"}},
                {"BRATON PRIME", new List<string> {"Braton Prime", "布莱顿Prime", "圣装制式步枪", "布莱顿P"}},
                {"BRATON VANDAL", new List<string> {"Braton Vandal", "布莱顿破坏者", "镇暴制式步枪"}},
                {"BRATON", new List<string> {"Braton", "布莱顿", "制式步枪"}},
                {"BROKEN SCEPTER", new List<string> {"Broken Scepter", "破损珽杖", "破碎权杖"}},
                {"BROKEN WAR", new List<string> {"Broken War", "破碎的战争之剑", "破碎战争", "破剑"}},
                {"BRONCO PRIME", new List<string> {"Bronco Prime", "野马Prime", "圣装布隆克烈驹", "野马P"}},
                {"BRONCO", new List<string> {"Bronco", "野马", "布隆克烈驹"}},
                {"BURST LASER PRIME", new List<string> {"Burst Laser Prime", "棱晶激光点发", "棱晶激光发射器"}},
                {"BURST LASER", new List<string> {"Burst Laser", "激光点发", "激光发射器"}},
                {"BURSTON PRIME", new List<string> {"Burston Prime", "伯斯顿Prime", "圣装伯斯顿步枪", "伯斯顿P"}},
                {"BURSTON", new List<string> {"Burston", "伯斯顿", "伯斯顿步枪"}},
                {"BUZLOK", new List<string> {"Buzlok", "巴兹火枪", "复仇黄鼬"}},
                {"CADUS", new List<string> {"Cadus", "卡度斯", "卡度斯"}},
                {"CARMINE PENTA", new List<string> {"Carmine Penta", "绯红五芒星", "绯红五芒星"}},
                {"CASSOWAR", new List<string> {"Cassowar", "鹤鸵长戟", "鹤鸵长戟"}},
                {"CASTANAS", new List<string> {"Castanas", "雷爆信镖", "分体式处理信标", "雷爆信标", "雷暴信镖", "雷暴信标"}},
                {"CAUSTACYST", new List<string> {"Caustacyst", "灼蚀变体镰", "腐蚀寄生者"}},
                {"CERAMIC DAGGER", new List<string> {"Ceramic Dagger", "陶瓷匕首", "精瓷匕首"}},
                {"CERATA", new List<string> {"Cerata", "裸鳃刃", "蛟鳃刃"}},
                {"CERNOS PRIME", new List<string> {"Cernos Prime", "西诺斯Prime", "圣装瑟诺斯长弓", "西诺斯P"}},
                {"CERNOS", new List<string> {"Cernos", "西诺斯", "瑟诺斯长弓"}},
                {"CESTRA", new List<string> {"Cestra", "锡斯特", "逆转聚能炮"}},
                {"CONVECTRIX", new List<string> {"Convectrix", "导热聚焦枪", "导热聚焦枪"}},
                {"CORINTH", new List<string> {"Corinth", "科林斯", "科林斯"}},
                {"CRONUS", new List<string> {"Cronus", "克洛诺斯", "克洛诺斯"}},
                {"CYATH", new List<string> {"Cyath", "西亚什", "弯刃"}},
                {"CYCRON", new List<string> {"Cycron", "循环离子枪", "循环式电浆手枪"}},
                {"DAIKYU", new List<string> {"Daikyu", "大久和弓", "大久和弓", "大久"}},
                {"DAKRA PRIME", new List<string> {"Dakra Prime", "达克拉Prime", "圣装达克拉", "达克拉P"}},
                {"DARK DAGGER", new List<string> {"Dark Dagger", "暗黑匕首", "暗影匕首"}},
                {"DARK SPLIT-SWORD", new List<string> {"Dark Split-Sword", "暗黑分合剑", "暗影子母剑", "暗黑分和剑"}},
                {"DARK SWORD", new List<string> {"Dark Sword", "暗黑长剑", "暗影长剑"}},
                {"DECONSTRUCTOR PRIME", new List<string> {"Deconstructor Prime", "分离Prime", "圣装爆能分解", "分离P"}},
                {"DECONSTRUCTOR", new List<string> {"Deconstructor", "分离", "爆能分解"}},
                {"DEHTAT", new List<string> {"Dehtat", "德塔特", "轻刺刃"}},
                {"DERA VANDAL", new List<string> {"Dera Vandal", "德拉破坏者", "镇暴德拉"}},
                {"DERA", new List<string> {"Dera", "德拉", "德拉"}},
                {"DESPAIR", new List<string> {"Despair", "绝望", "绝望"}},
                {"DESTREZA", new List<string> {"Destreza", "技巧之剑", "护手刺剑"}},
                {"DESTREZA PRIME", new List<string> {"Destreza Prime", "技巧之剑Prime", "圣装护手刺剑"}},
                {
                    "DETH MACHINE RIFLE PRIME",
                    new List<string> {"Deth Machine Rifle Prime", "死亡机枪Prime", "圣装致死机枪", "死亡机枪P"}
                },
                {"DETH MACHINE RIFLE", new List<string> {"Deth Machine Rifle", "死亡机枪", "致死机枪"}},
                {"DETRON", new List<string> {"Detron", "德特昂", "迪特隆"}},
                {"DEX DAKRA", new List<string> {"Dex Dakra", "Dex达克拉双剑", "灵敏达克拉"}},
                {"DEX FURIS", new List<string> {"Dex Furis", "Dex盗贼双枪", "灵敏弗里斯双枪"}},
                {"DEX SYBARIS", new List<string> {"Dex Sybaris", "Dex席巴莉丝", "灵敏远古丧钟"}},
                {"DRAGON NIKANA", new List<string> {"Dragon Nikana", "龙之侍刃", "龙之侍刃", "龙刀"}},
                {"DRAKGOON", new List<string> {"Drakgoon", "龙骑兵", "龙息匣炮"}},
                {"DREAD", new List<string> {"Dread", "恐惧", "恐惧"}},
                {"DUAL CESTRA", new List<string> {"Dual Cestra", "锡斯特双枪", "双持逆转聚能炮"}},
                {"DUAL CLEAVERS", new List<string> {"Dual Cleavers", "斩肉双刀", "起义者"}},
                {"DUAL ETHER", new List<string> {"Dual Ether", "苍穹双剑", "苍穹双剑"}},
                {"DUAL HEAT SWORDS", new List<string> {"Dual Heat Swords", "烈焰双剑", "烈焰双剑"}},
                {"DUAL ICHOR", new List<string> {"Dual Ichor", "恶脓双斧", "恶脓双斧"}},
                {"DUAL KAMAS PRIME", new List<string> {"Dual Kamas Prime", "双短柄战镰Prime", "圣装迦摩双镰", "双短柄战镰P"}},
                {"DUAL KAMAS", new List<string> {"Dual Kamas", "双短柄战镰", "迦摩双镰"}},
                {"DUAL KERES", new List<string> {"Dual Keres", "双持凯瑞斯", "双持凯瑞斯"}},
                {"DUAL RAZA", new List<string> {"Dual Raza", "锋月双斧", "锋月双斧"}},
                {"DUAL SKANA", new List<string> {"Dual Skana", "空刃双刀", "空灵双刃"}},
                {"DUAL TOXOCYST", new List<string> {"Dual Toxocyst", "毒囊双枪", "毒刺双枪"}},
                {"DUAL ZOREN", new List<string> {"Dual Zoren", "佐伦双斧", "索伦双斧"}},
                {"EMBOLIST", new List<string> {"Embolist", "安伯勒斯", "蛇颅"}},
                {"ENDURA", new List<string> {"Endura", "三叶坚韧", "苦行刺剑"}},
                {"ETHER DAGGERS", new List<string> {"Ether Daggers", "苍穹匕首", "苍穹匕首"}},
                {"ETHER REAPER", new List<string> {"Ether Reaper", "苍穹死神", "苍穹死神"}},
                {"ETHER SWORD", new List<string> {"Ether Sword", "苍穹之剑", "苍穹之剑"}},
                {"EUPHONA PRIME", new List<string> {"Euphona Prime", "悦音Prime", "圣装仙乐奏鸣", "悦音P"}},
                {"FANG PRIME", new List<string> {"Fang Prime", "狼牙Prime", "圣装狼牙双刃", "狼牙P"}},
                {"FANG", new List<string> {"Fang", "狼牙", "狼牙双刃"}},
                {"FERROX", new List<string> {"Ferrox", "铁晶磁轨炮", "铁磁式激光矛枪", "C矛"}},
                {"FLUX RIFLE", new List<string> {"Flux Rifle", "通量射线步枪", "热能步枪"}},
                {"FRAGOR PRIME", new List<string> {"Fragor Prime", "重击巨锤Prime", "圣装悲悯", "重击巨锤P", "大锤P"}},
                {"FRAGOR", new List<string> {"Fragor", "重击巨锤", "悲悯", "大锤"}},
                {"FURAX WRAITH", new List<string> {"Furax Wraith", "弗拉克斯亡魂", "亡魂寄居蟹手刺"}},
                {"FURAX", new List<string> {"Furax", "弗拉克斯", "寄居蟹手刺"}},
                {"FURIS", new List<string> {"Furis", "盗贼", "盗贼"}},
                {"FUSILAI", new List<string> {"Fusilai", "齐射玻刃", "齐射玻刃", "玻璃飞刀"}},
                {"GALATINE PRIME", new List<string> {"Galatine Prime", "迦伦提恩Prime", "圣装加拉丁暗影", "迦伦提恩P", "大剑P"}},
                {"GALATINE", new List<string> {"Galatine", "迦伦提恩", "加拉丁暗影", "大剑"}},
                {"GAMMACOR", new List<string> {"Gammacor", "伽马腕甲枪", "射线发生仪"}},
                {"GAZAL MACHETE", new List<string> {"Gazal Machete", "加扎勒反曲刀", "加扎尔精英阔刀"}},
                {"GLAIVE PRIME", new List<string> {"Glaive Prime", "战刃Prime", "圣装回旋刃", "战刃P"}},
                {"GLAIVE", new List<string> {"Glaive", "战刃", "回旋刃"}},
                {"GLAXION", new List<string> {"Glaxion", "冷冻光束步枪", "急冻冰枪", "冷冻射线步枪", "冰冻射线步枪", "冰冻光束步枪"}},
                {"GORGON WRAITH", new List<string> {"Gorgon Wraith", "蛇发女妖亡魂", "亡魂蛇发女妖"}},
                {"GORGON", new List<string> {"Gorgon", "蛇发女妖", "蛇发女妖"}},
                {"GRAKATA", new List<string> {"Grakata", "葛拉卡达", "格拉达火舌"}},
                {"GRAM", new List<string> {"Gram", "格拉姆", "格拉姆"}},
                {"GRINLOK", new List<string> {"Grinlok", "葛恩火枪", "尖叫小丑"}},
                {"GUANDAO", new List<string> {"Guandao", "关刀", "偃月刀"}},
                {"GUNSEN", new List<string> {"Gunsen", "军扇", "军扇"}},
                {"HALIKAR", new List<string> {"Halikar", "哈利卡", "喷射飞锤"}},
                {"HARPAK", new List<string> {"Harpak", "哈帕克", "哈帕克"}},
                {"HATE", new List<string> {"Hate", "憎恨", "憎恨"}},
                {"HEAT DAGGER", new List<string> {"Heat Dagger", "烈焰匕首", "烈焰匕首"}},
                {"HEAT SWORD", new List<string> {"Heat Sword", "烈焰长剑", "烈焰长剑"}},
                {"HEK", new List<string> {"Hek", "海克", "恶婴"}},
                {"HELIOCOR", new List<string> {"Heliocor", "赫利俄光锤", "太阳神锤", "扫描锤"}},
                {"HEMA", new List<string> {"Hema", "血肢", "希玛嗜血体"}},
                {"HIKOU PRIME", new List<string> {"Hikou Prime", "飞扬Prime", "圣装星镖", "飞扬P"}},
                {"HIKOU", new List<string> {"Hikou", "飞扬", "星镖"}},
                {"HIND", new List<string> {"Hind", "雌鹿", "雌鹿半自动步枪"}},
                {"HIRUDO", new List<string> {"Hirudo", "蚂蝗", "血蛭"}},
                {"HYSTRIX", new List<string> {"Hystrix", "猬刺", "猬刺"}},
                {"IGNIS WRAITH", new List<string> {"Ignis Wraith", "伊格尼斯亡魂", "亡魂爆燃喷射器", "喷火器P"}},
                {"IGNIS", new List<string> {"Ignis", "伊格尼斯", "爆燃喷射器", "喷火器"}},
                {"JAT KITTAG", new List<string> {"Jat Kittag", "喷射战锤", "氪金狼牙棒"}},
                {"JAT KUSAR", new List<string> {"Jat Kusar", "喷射锁镰", "喷射锁镰"}},
                {"JAVLOK", new List<string> {"Javlok", "燃焰标枪", "爆燃矛枪", "G矛"}},
                {"JAW SWORD", new List<string> {"Jaw Sword", "蛇颚刀", "蛇颚刀"}},
                {"KAMA", new List<string> {"Kama", "短柄战镰", "迦摩天战镰"}},
                {"KARAK WRAITH", new List<string> {"Karak Wraith", "卡拉克亡魂", "亡魂超体步枪"}},
                {"KARAK", new List<string> {"Karak", "卡拉克", "超体步枪"}},
                {"KARYST", new List<string> {"Karyst", "凯洛斯特", "困惑之刃"}},
                {"KESHEG", new List<string> {"Kesheg", "怯薛", "禁卫长戟"}},
                {"KESTREL", new List<string> {"Kestrel", "红隼", "红隼"}},
                {"KNELL", new List<string> {"Knell", "丧钟", "噩兆"}},
                {"KOGAKE PRIME", new List<string> {"Kogake Prime", "科加基Prime", "圣装牢笼拳套", "科加基P"}},
                {"KOGAKE", new List<string> {"Kogake", "科加基", "牢笼拳套"}},
                {"KOHM", new List<string> {"Kohm", "寇恩热能枪", "聚能瓦斯炮", "吹风机"}},
                {"KOHMAK", new List<string> {"Kohmak", "寇恩霰机枪", "寇恩热能炮"}},
                {"KRAKEN", new List<string> {"Kraken", "北海巨妖", "北海巨妖"}},
                {"KROHKUR", new List<string> {"Krohkur", "克鲁古尔", "克鲁古尔"}},
                {"KRONEN", new List<string> {"Kronen", "皇家拐刃", "弧月刀", "皇家拐"}},
                {"KRONEN PRIME", new List<string> {"Kronen Prime", "皇家拐刃Prime", "圣装弧月刀", "拐p"}},
                {"KRONSH", new List<string> {"Kronsh", "客隆什", "重弯刀"}},
                {"KULSTAR", new List<string> {"Kulstar", "杀星", "集束鱼雷发射器"}},
                {"KUNAI", new List<string> {"Kunai", "苦无", "苦无"}},
                {"LACERA", new List<string> {"Lacera", "悲痛之刃", "绝情双剪", "悲痛"}},
                {"LANKA", new List<string> {"Lanka", "兰卡", "兰卡原能加速枪"}},
                {"LASER RIFLE", new List<string> {"Laser Rifle", "激光步枪", "激光步枪"}},
                {"LATO PRIME", new List<string> {"Lato Prime", "拉托Prime", "圣装拉托", "拉托P"}},
                {"LATO VANDAL", new List<string> {"Lato Vandal", "拉托破坏者", "镇暴拉托"}},
                {"LATO", new List<string> {"Lato", "拉托", "拉托"}},
                {"LATRON PRIME", new List<string> {"Latron Prime", "拉特昂Prime", "圣装拉特龙半自动步枪", "拉特昂P"}},
                {"LATRON WRAITH", new List<string> {"Latron Wraith", "拉特昂亡魂", "亡魂拉特龙半自动步枪"}},
                {"LATRON", new List<string> {"Latron", "拉特昂", "拉特龙半自动步枪"}},
                {"LECTA", new List<string> {"Lecta", "勒克塔", "僵直电鞭", "电鞭"}},
                {"LENZ", new List<string> {"Lenz", "楞次弓", "楞次弓", "楞次"}},
                {"LESION", new List<string> {"Lesion", "病变", "病变"}},
                {"LEX PRIME", new List<string> {"Lex Prime", "雷克斯Prime", "圣装秩序之握", "雷克斯P"}},
                {"LEX", new List<string> {"Lex", "雷克斯", "秩序之握"}},
                {"MACHETE WRAITH", new List<string> {"Machete Wraith", "马谢特砍刀亡魂", "亡魂精英阔刀"}},
                {"MACHETE", new List<string> {"Machete", "马谢特砍刀", "精英阔刀"}},
                {"MAGISTAR", new List<string> {"Magistar", "执法者", "真理权杖"}},
                {"MAGNUS", new List<string> {"Magnus", "麦格努斯", "猛犸手枪"}},
                {"MARA DETRON", new List<string> {"Mara Detron", "苦痛德特昂", "苦痛德特昂"}},
                {"MARELOK", new List<string> {"Marelok", "玛瑞火枪", "马洛克"}},
                {"MEWAN", new List<string> {"Mewan", "密丸", "重长刃", "蜜丸"}},
                {"MIOS", new List<string> {"Mios", "牝狮神", "米奥斯鞭刃", "狮神"}},
                {"MIRE", new List<string> {"Mire", "米尔", "米雷泥沼"}},
                {"MITER", new List<string> {"Miter", "米特尔", "米特锯刃发射器"}},
                {"MK1-BO", new List<string> {"MK1-Bo", "MK1-珀之武杖", "MK1-破禅武杖"}},
                {"MK1-BRATON", new List<string> {"MK1-Braton", "MK1-布莱顿", "MK1-制式步枪"}},
                {"MK1-FURAX", new List<string> {"MK1-Furax", "MK1-弗拉克斯", "MK1-寄居蟹手刺"}},
                {"MK1-FURIS", new List<string> {"MK1-Furis", "MK1-盗贼", "MK1-弗里斯手枪"}},
                {"MK1-KUNAI", new List<string> {"MK1-Kunai", "MK1-苦无", "MK1-苦无"}},
                {"MK1-PARIS", new List<string> {"MK1-Paris", "MK1-帕里斯", "MK1-帕里斯长弓"}},
                {"MK1-STRUN", new List<string> {"MK1-Strun", "MK1-斯特昂", "MK1-斯特朗炮"}},
                {"MUTALIST CERNOS", new List<string> {"Mutalist Cernos", "异融西诺斯", "异融瑟诺斯长弓"}},
                {"MUTALIST QUANTA", new List<string> {"Mutalist Quanta", "异融量子枪", "异融光能量子"}},
                {
                    "NAMI SKYLA PRIME",
                    new List<string> {"Nami Skyla Prime", "海波斯库拉对剑Prime", "圣装纳米斯凯拉", "海波斯库拉对剑P", "海波对剑P", "海波双剑P"}
                },
                {"NAMI SKYLA", new List<string> {"Nami Skyla", "海波斯库拉对剑", "纳米斯凯拉", "海波对剑", "海波双剑"}},
                {"NAMI SOLO", new List<string> {"Nami Solo", "海波单剑", "纳米索隆"}},
                {"NIKANA PRIME", new List<string> {"Nikana Prime", "侍刃Prime", "圣装侍刃", "侍刃P", "装逼刀P"}},
                {"NIKANA", new List<string> {"Nikana", "侍刃", "虎之侍刃", "装逼刀"}},
                {"NINKONDI", new List<string> {"Ninkondi", "降灵追猎者", "降灵追猎者", "降灵"}},
                {"NUKOR", new List<string> {"Nukor", "努寇微波枪", "努寇微波"}},
                {"OBEX", new List<string> {"Obex", "奥比克斯", "惩戒手刺"}},
                {"OGRIS", new List<string> {"Ogris", "食人女魔", "奥基手持火箭炮"}},
                {"OHMA", new List<string> {"Ohma", "欧玛", "欧玛电击棍", "欧码"}},
                {"OKINA", new List<string> {"Okina", "翁", "三叉刺"}},
                {"OOLTHA", new List<string> {"Ooltha", "乌尔萨", "长刃"}},
                {"OPTICOR", new List<string> {"Opticor", "奥堤克光子枪", "热熔镭射炮", "O炮"}},
                {"ORTHOS PRIME", new List<string> {"Orthos Prime", "欧特鲁斯Prime", "圣装双尾鲨", "欧特鲁斯P", "OP"}},
                {"ORTHOS", new List<string> {"Orthos", "欧特鲁斯", "双尾鲨"}},
                {"ORVIUS", new List<string> {"Orvius", "灵枢", "灵枢"}},
                {"PANDERO", new List<string> {"Pandero", "手鼓", "潘德罗"}},
                {"PANGOLIN SWORD", new List<string> {"Pangolin Sword", "鲮鲤剑", "鲮鲤剑"}},
                {"PANTHERA", new List<string> {"Panthera", "猎豹", "猎豹"}},
                {"PARACYST", new List<string> {"Paracyst", "附肢寄生者", "附肢寄生者"}},
                {"PARIS PRIME", new List<string> {"Paris Prime", "帕里斯Prime", "圣装帕里斯长弓", "帕里斯P", "PP"}},
                {"PARIS", new List<string> {"Paris", "帕里斯", "帕里斯长弓"}},
                {"PENTA", new List<string> {"Penta", "潘塔", "五芒星榴弹炮"}},
                {"PHAGE", new List<string> {"Phage", "噬菌者", "菲姬噬菌体"}},
                {"PHANTASMA", new List<string> {"Phantasma", "幻离子", "幻离子"}},
                {"PLAGUE KEEWAR", new List<string> {"Plague Keewar", "瘟疫奇沃", "瘟疫奇沃", "奇沃"}},
                {"PLAGUE KRIPATH", new List<string> {"Plague Kripath", "瘟疫克里帕丝", "瘟疫克里帕丝", "瘟疫克里帕斯", "克里帕斯", "克里帕丝"}},
                {"PLASMA SWORD", new List<string> {"Plasma Sword", "等离子长剑", "等离子长剑"}},
                {"POX", new List<string> {"Pox", "脓痘", "脓痘"}},
                {"PRIME LASER RIFLE", new List<string> {"Prime Laser RIFLE", "激光步枪Prime", "圣装激光步枪", "激光步枪P"}},
                {"PRISMA ANGSTRUM", new List<string> {"Prisma Angstrum", "棱晶安格斯壮", "棱晶将军手持短炮"}},
                {"PRISMA BURST LASER", new List<string> {"Prisma Burst Laser", "棱晶激光点发", "棱晶激光发射器"}},
                {"PRISMA DUAL CLEAVERS", new List<string> {"Prisma Dual Cleavers", "棱晶斩肉双刀", "棱晶起义者"}},
                {"PRISMA GORGON", new List<string> {"Prisma Gorgon", "棱晶蛇发女妖", "棱晶蛇发女妖"}},
                {"PRISMA GRAKATA", new List<string> {"Prisma Grakata", "棱晶葛拉卡达", "棱晶格拉达火舌"}},
                {"PRISMA MACHETE", new List<string> {"Prisma Machete", "棱晶马谢特砍刀", "棱晶精英阔刀"}},
                {"PRISMA OBEX", new List<string> {"Prisma Obex", "棱晶奥比克斯", "棱晶惩戒手刺"}},
                {"PRISMA SKANA", new List<string> {"Prisma Skana", "棱晶空刃", "棱晶空灵刃"}},
                {"PRISMA TETRA", new List<string> {"Prisma Tetra", "棱晶特拉", "棱晶泰特拉"}},
                {"PRISMA TWIN GREMLINS", new List<string> {"Prisma Twin Gremlins", "棱晶双子小精灵", "棱晶双子小精灵"}},
                {"PROVA VANDAL", new List<string> {"Prova Vandal", "普罗沃破坏者", "镇暴高压电棒"}},
                {"PROVA", new List<string> {"Prova", "普罗沃", "高压电棒"}},
                {"PYRANA", new List<string> {"Pyrana", "食人鱼", "派亚脊刺"}},
                {"PYRANA PRIME", new List<string> {"Pyrana Prime", "食人鱼Prime", "圣装派亚脊刺"}},
                {"QUANTA VANDAL", new List<string> {"Quanta Vandal", "量子切割器破坏者", "镇暴光能量子", "莲花矿枪"}},
                {"QUANTA", new List<string> {"Quanta", "量子切割器", "光能量子", "矿枪"}},
                {"QUARTAKK", new List<string> {"Quartakk", "夸塔克", "夸塔克"}},
                {"RAKTA BALLISTICA", new List<string> {"Rakta Ballistica", "绯红布里斯提卡", "拉克塔惊惧手弩", "集团弩"}},
                {"RAKTA CERNOS", new List<string> {"Rakta Cernos", "绯红西诺斯", "拉克塔瑟诺斯长弓", "集团弓", "血色弓"}},
                {"RAKTA DARK DAGGER", new List<string> {"Rakta Dark Dagger", "绯红暗黑匕首", "拉克塔暗影匕首", "集团匕"}},
                {"REAPER PRIME", new List<string> {"Reaper Prime", "收割者Prime", "圣装收割者", "收割者P"}},
                {"REDEEMER", new List<string> {"Redeemer", "救赎者", "救赎者"}},
                {"RIPKAS", new List<string> {"Ripkas", "锐卡斯", "覆海蛟"}},
                {"RUBICO", new List<string> {"Rubico", "绝路", "绿陶狙击枪"}},
                {
                    "SANCTI CASTANAS", new List<string>
                    {
                        "Sancti Castanas",
                        "圣洁雷爆信镖",
                        "圣洁分体式处理信标",
                        "圣洁雷爆信标",
                        "圣洁雷暴信镖",
                        "圣洁雷暴信标",
                        "圣洁信镖",
                        "圣洁信标",
                        "集团镖"
                    }
                },
                {"SANCTI MAGISTAR", new List<string> {"Sancti Magistar", "圣洁执法者", "圣洁真理权杖", "奶锤"}},
                {"SANCTI TIGRIS", new List<string> {"Sancti Tigris", "圣洁猛虎", "圣洁泰格里斯", "集团猛虎"}},
                {"SARPA", new List<string> {"Sarpa", "蛇刃", "蛇刃"}},
                {"SCINDO PRIME", new List<string> {"Scindo Prime", "分裂斩斧Prime", "圣装神罚巨斧", "分裂斩斧P"}},
                {"SCINDO", new List<string> {"Scindo", "分裂斩斧", "神罚巨斧"}},
                {"SCOLIAC", new List<string> {"Scoliac", "嵴椎节鞭", "腐尾蛟", "嵴椎", "I鞭"}},
                {"SCOURGE", new List<string> {"Scourge", "祸根", "天罚"}},
                {"SECURA DUAL CESTRA", new List<string> {"Secura Dual Cestra", "保障锡斯特双枪", "瑟古拉双持逆转聚能炮"}},
                {"SECURA LECTA", new List<string> {"Secura Lecta", "保障勒克塔", "瑟古拉僵直电鞭", "钱鞭", "集团鞭"}},
                {"SECURA PENTA", new List<string> {"Secura Penta", "保障潘塔", "瑟古拉五芒星榴弹炮"}},
                {"SEER", new List<string> {"Seer", "预言者", "希尔先知"}},
                {"SERRO", new List<string> {"Serro", "电能斩锯", "电能斩锯"}},
                {"SHAKU", new List<string> {"Shaku", "双节尺棍", "双节尺棍"}},
                {"SHEEV", new List<string> {"Sheev", "希芙", "西弗"}},
                {"SIBEAR", new List<string> {"Sibear", "西伯利亚冰锤", "冰原重锤", "冰锤"}},
                {"SICARUS PRIME", new List<string> {"Sicarus Prime", "暗杀者Prime", "圣装赛卡洛斯", "暗杀者P"}},
                {"SICARUS", new List<string> {"Sicarus", "暗杀者", "赛卡洛斯"}},
                {"SIGMA & OCTANTIS", new List<string> {"Sigma & Octantis", "西格玛&南极座", "西格玛&南极座", "西格玛南极座"}},
                {
                    "SILVA & AEGIS PRIME",
                    new List<string>
                    {
                        "Silva & Aegis Prime",
                        "席瓦&神盾Prime",
                        "圣装席瓦&神盾",
                        "圣装希瓦·艾奎斯剑盾",
                        "剑盾P",
                        "席瓦&神盾P",
                        "席瓦神盾P",
                        "希瓦神盾"
                    }
                },
                {"SILVA & AEGIS", new List<string> {"Silva & Aegis", "席瓦&神盾", "希瓦·艾奎斯剑盾", "剑盾", "席瓦神盾"}},
                {"SIMULOR", new List<string> {"Simulor", "重力奇点拟成枪", "重力奇点拟成枪", "重力枪"}},
                {"SKANA PRIME", new List<string> {"Skana Prime", "空刃Prime", "圣装空灵刃", "空刃P"}},
                {"SKANA", new List<string> {"Skana", "空刃", "空灵刃"}},
                {"SKIAJATI", new List<string> {"Skiajati", "影生", "影生"}},
                {"SNIPETRON VANDAL", new List<string> {"Snipetron Vandal", "狙击特昂破坏者", "镇暴特洛恩阳极磁轨枪", "莲花狙"}},
                {"SNIPETRON", new List<string> {"Snipetron", "狙击特昂", "特洛恩阳极磁轨枪"}},
                {"SOBEK", new List<string> {"Sobek", "鳄神", "鳄牙"}},
                {"SOMA PRIME", new List<string> {"Soma Prime", "月神Prime", "圣装索玛", "月神P"}},
                {"SOMA", new List<string> {"Soma", "月神", "索玛"}},
                {"SONICOR", new List<string> {"Sonicor", "超音波冲击枪", "超音冲击枪"}},
                {"SPECTRA", new List<string> {"Spectra", "光谱切割器", "光谱手枪"}},
                {"SPIRA PRIME", new List<string> {"Spira Prime", "旋刃飞刀Prime", "圣装螺旋飞刃", "旋刃飞刀P"}},
                {"SPIRA", new List<string> {"Spira", "旋刃飞刀", "小李飞刀"}},
                {"STATICOR", new List<string> {"Staticor", "静电能量导引枪", "静电势能发射器"}},
                {"STINGER PRIME", new List<string> {"Stinger Prime", "毒刺Prime", "圣装史丁格毒刺", "毒刺P"}},
                {"STINGER", new List<string> {"Stinger", "毒刺", "史丁格毒刺"}},
                {"STRADAVAR", new List<string> {"Stradavar", "斯特拉迪瓦", "斯特拉迪瓦"}},
                {"STRUN WRAITH", new List<string> {"Strun Wraith", "斯特朗亡魂", "亡魂斯特朗炮"}},
                {"STRUN", new List<string> {"Strun", "斯特朗", "斯特朗炮"}},
                {"STUBBA", new List<string> {"Stubba", "史度巴", "史度巴"}},
                {"STUG", new List<string> {"Stug", "史特克", "斯塔客"}},
                {"SUPRA VANDAL", new List<string> {"Supra Vandal", "苏普拉破坏者", "镇暴量子苏普拉"}},
                {"SUPRA", new List<string> {"Supra", "苏普拉", "量子苏普拉", "烟花"}},
                {"SWEEPER PRIME", new List<string> {"Sweeper Prime", "扫除者Prime", "圣装清道夫", "扫除者P"}},
                {"SWEEPER", new List<string> {"Sweeper", "扫除者", "清道夫"}},
                {"SYBARIS PRIME", new List<string> {"Sybaris Prime", "席芭莉丝Prime", "圣装远古丧钟", "席芭莉丝P"}},
                {"SYBARIS", new List<string> {"Sybaris", "席芭莉丝", "远古丧钟", "席八"}},
                {"SYDON", new List<string> {"Sydon", "恶龙", "恶龙三叉戟"}},
                {"SYNAPSE", new List<string> {"Synapse", "突触生化枪", "焦灼之须"}},
                {"SYNOID GAMMACOR", new List<string> {"Synoid Gammacor", "枢议咖玛腕甲枪", "辛诺德射线发生仪"}},
                {"SYNOID HELIOCOR", new List<string> {"Synoid Heliocor", "枢议赫利俄光锤", "辛诺德太阳神锤", "扫描锤"}},
                {"SYNOID SIMULOR", new List<string> {"Synoid Simulor", "枢议重力奇点拟成枪", "辛诺德重力奇点拟成枪", "黑洞枪"}},
                {"TALONS", new List<string> {"talons", "鹰爪", "鹰爪"}},
                {"TEKKO", new List<string> {"Tekko", "铁钩手甲", "刺蛇"}},
                {"TELOS AKBOLTO", new List<string> {"Telos Akbolto", "终极螺钉双枪", "终极双持角犀"}},
                {"TELOS BOLTACE", new List<string> {"Telos Boltace", "终极螺钉拐刃", "终极螺钉弧月刀", "集团拐"}},
                {"TELOS BOLTOR", new List<string> {"Telos Boltor", "终极螺钉步枪", "终极波尔托骨刺"}},
                {"TENORA", new List<string> {"Tenora", "双簧管", "泰诺拉"}},
                {"TETRA", new List<string> {"Tetra", "特拉", "泰特拉"}},
                {"TIBERON", new List<string> {"Tiberon", "狂鲨", "狂鲨"}},
                {"TIBERON PRIME", new List<string> {"Tiberon Prime", "狂鲨p", "圣装狂鲨"}},
                {"TIGRIS PRIME", new List<string> {"Tigris Prime", "猛虎Prime", "圣装泰格里斯", "猛虎P"}},
                {"TIGRIS", new List<string> {"Tigris", "猛虎", "泰格里斯", "萌虎"}},
                {"TIPEDO", new List<string> {"Tipedo", "提佩多", "提佩多军铲"}},
                {"TONBO", new List<string> {"Tonbo", "蜻蛉薙", "龙诞棍", "蜻蜓切", "蜻蜓薙", "蜻蜓"}},
                {"TONKOR", new List<string> {"Tonkor", "征服榴炮", "征服榴炮", "征服"}},
                {"TORID", new List<string> {"Torid", "托里德", "爆裂生化炮", "毒榴弹"}},
                {"TWIN BASOLK", new List<string> {"Twin Basolk", "双子巴萨克", "双子巴萨克"}},
                {"TWIN GRAKATAS", new List<string> {"Twin Grakatas", "双子葛拉卡达", "双持格拉达火舌"}},
                {"TWIN GREMLINS", new List<string> {"Twin Gremlins", "双子小精灵", "双子小精灵"}},
                {"TWIN KOHMAK", new List<string> {"Twin Kohmak", "双子宼恩霰机枪", "双子寇玛热能炮"}},
                {"TWIN KROHKUR", new List<string> {"Twin Krohkur", "双子克鲁古尔", "双子克鲁古尔"}},
                {"TWIN ROGGA", new List<string> {"Twin Rogga", "双子罗格", "双子罗迦霰弹枪"}},
                {"TWIN VIPERS WRAITH", new List<string> {"Twin Vipers Wraith", "双子蝰蛇亡魂", "亡魂双子蝰蛇"}},
                {"TWIN VIPERS", new List<string> {"Twin Vipers", "双子蝰蛇", "双子蝰蛇"}},
                {"TYSIS", new List<string> {"Tysis", "啐沫者", "啐沫者"}},
                {"VASTO PRIME", new List<string> {"Vasto Prime", "瓦斯托Prime", "圣装瓦斯托", "瓦斯托P"}},
                {"VASTO", new List<string> {"Vasto", "瓦斯托", "瓦斯托"}},
                {"VAYKOR HEK", new List<string> {"Vaykor Hek", "勇气海克", "维寇恶婴"}},
                {"VAYKOR MARELOK", new List<string> {"Vaykor Marelok", "勇气玛瑞火枪", "维寇马洛克"}},
                {"VAYKOR SYDON", new List<string> {"Vaykor Sydon", "勇气恶龙", "维寇恶龙三叉戟"}},
                {"VECTIS PRIME", new List<string> {"Vectis Prime", "守望者Prime", "圣装守望者", "守望者P"}},
                {"VECTIS", new List<string> {"Vectis", "守望者", "守望者", "守望"}},
                {"VENKA PRIME", new List<string> {"Venka Prime", "凯旋之爪Prime", "圣装钨钢合金爪", "凯旋之爪P"}},
                {"VENKA", new List<string> {"Venka", "凯旋之爪", "钨钢合金爪"}},
                {"VELDT", new List<string> {"Veldt", "草原猎手", "草原猎手"}},
                {"VIPER", new List<string> {"Viper", "蝰蛇", "蝰蛇"}},
                {"VIPER WRAITH", new List<string> {"Viper Wraith", "蝰蛇亡魂", "亡魂蝰蛇"}},
                {"VOLNUS", new List<string> {"Volnus", "创伤", "创伤"}},
                {"VULKAR WRAITH", new List<string> {"Vulkar Wraith", "金工火神亡魂", "伏卡尔狙击枪"}},
                {"VULKAR", new List<string> {"Vulkar", "金工火神", "伏卡尔狙击枪", "钓鱼竿"}},
                {"VULKLOK", new List<string> {"Vulklok", "金工火枪", "电弧步枪"}},
                {"WAR", new List<string> {"War", "战争之剑", "战争"}},
                {"ZAKTI", new List<string> {"Zakti", "毒芽", "毒芽"}},
                {"ZARR", new List<string> {"Zarr", "沙皇", "煞皇"}},
                {"ZAW", new List<string> {"Zaw", "Zaw", "天工"}},
                {"ZENISTAR", new List<string> {"Zenistar", "天顶之星", "天顶之星"}},
                {"ZENITH", new List<string> {"Zenith", "天穹之顶", "天穹之顶"}},
                {"ZHUGE", new List<string> {"Zhuge", "诸葛连弩", "诸葛连弩", "诸葛"}},
                {"ZYLOK", new List<string> {"Zylok", "Zylok", "Zylok"}}
            };
        }
    }
}