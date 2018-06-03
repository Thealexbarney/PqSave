// ReSharper disable InconsistentNaming ClassNeverInstantiated.Global UnusedAutoPropertyAccessor.Global UnusedMember.Global
using System.Collections.Generic;
using ZeroFormatter;

namespace PqSave
{
    [ZeroFormattable]
    public class CheckData
    {
        [Index(0)] public virtual IList<byte> hashBytes { get; set; }
        [Index(1)] public virtual int version { get; set; }
    }

    [ZeroFormattable]
    public class SerializeData
    {
        [Index(0)] public virtual CharacterStorage characterStorage { get; set; }
        [Index(1)] public virtual BattleData battleData { get; set; }
        [Index(2)] public virtual PotentialStorage potentialStorage { get; set; }
        [Index(3)] public virtual ConfigData configData { get; set; }
        [Index(4)] public virtual FlagWork flagWork { get; set; }
        [Index(5)] public virtual ItemStorage itemStorage { get; set; }
        [Index(6)] public virtual VisitCharacter visitCharacter { get; set; }
        [Index(7)] public virtual PokemonMemory pokemonMemory { get; set; }
        [Index(8)] public virtual Misc misc { get; set; }
        [Index(9)] public virtual PlayerData playerData { get; set; }
        [Index(10)] public virtual Time time { get; set; }
        [Index(11)] public virtual Goods goods { get; set; }
        [Index(12)] public virtual Cook cook { get; set; }
    }

    [ZeroFormattable]
    public class CharacterStorage
    {
        [Index(0)] public virtual ILazyDictionary<int, ManageData> characterDataDictionary { get; set; }
        [Index(1)] public virtual int dataCapacity { get; set; }

        [ZeroFormattable]
        public class ManageData
        {
            [Index(0)] public virtual SaveCharacterData data { get; set; }
            [Index(1)] public virtual bool isNew { get; set; }
            [Index(2)] public virtual long timeTicks { get; set; }
        }
    }

    [ZeroFormattable]
    public class SaveCharacterData
    {
        [Index(0)] public virtual uint exp { get; set; }
        [Index(1)] public virtual ushort monsterNo { get; set; }
        [Index(2)] public virtual byte formNo { get; set; }
        [Index(3)] public virtual ushort level { get; set; }
        [Index(4)] public virtual int hp { get; set; }
        [Index(5)] public virtual int attack { get; set; }
        [Index(6)] public virtual IList<char> name { get; set; }
        [Index(7)] public virtual byte seikaku { get; set; }
        [Index(8)] public virtual uint id { get; set; }
        [Index(9)] public virtual uint rareRandom { get; set; }
        [Index(10)] public virtual SaveCharacterPoteintialData potential { get; set; }
        [Index(11)] public virtual int trainingSkillCount { get; set; }
        [Index(12)] public virtual bool isEvolve { get; set; }
    }

    [ZeroFormattable]
    public class SaveCharacterPoteintialData
    {
        [Index(0)] public virtual ushort activeSlots { get; set; }
        [Index(1)] public virtual IList<short> attachStoneStorageID { get; set; }
        [Index(2)] public virtual IList<short> attachSkillStoneStorageID { get; set; }
        [Index(3)] public virtual sbyte nextActivateSlotIndex { get; set; }
        [Index(4)] public virtual float nextSlotProgress { get; set; }
        [Index(5)] public virtual uint bingoPropertyIndices { get; set; }
        [Index(6)] public virtual IList<sbyte> slotPropertyTypes { get; set; }
        [Index(7)] public virtual IList<SavePotentialSkillData> potentialSkill { get; set; }
    }

    [ZeroFormattable]
    public class SavePotentialSkillData
    {
        [Index(0)] public virtual sbyte slotIndex { get; set; }
        [Index(1)] public virtual ushort skillID { get; set; }
    }

    [ZeroFormattable]
    public class BattleData
    {
        [Index(0)] public virtual IList<FormationData> formationDatas { get; set; }
        [Index(1)] public virtual int selectIndex { get; set; }
        [Index(2)] public virtual int openIndex { get; set; }
        [Index(3)] public virtual ILazyDictionary<int, DungeonHighScore> stageHighScoreDictionary { get; set; }
        [Index(4)] public virtual ChallengeDungeon challengeDungeon { get; set; }
        [Index(5)] public virtual int aroundCount { get; set; }
        [Index(6)] public virtual BattleBreakData battleBreakData { get; set; }
    }

    [ZeroFormattable]
    public class FormationData
    {
        [Index(0)] public virtual IList<MemberData> memberDatas { get; set; }

        [ZeroFormattable]
        public class MemberData
        {
            [Index(0)] public virtual int storageIndex { get; set; }
        }
    }

    [ZeroFormattable]
    public class DungeonHighScore
    {
        [Index(0)] public virtual IList<SaveCharacterData> teamMembers { get; set; }
        [Index(1)] public virtual int teamPower { get; set; }
        [Index(2)] public virtual int stageLevel { get; set; }
        [Index(3)] public virtual float clearSecond { get; set; }
    }

    [ZeroFormattable]
    public class ChallengeDungeon
    {
        [Index(0)] public virtual DungeonID dungeonID { get; set; }
        [Index(1)] public virtual int stageNum { get; set; }
        [Index(2)] public virtual Work dungeonProgressWork { get; set; }
        [Index(3)] public virtual int beforeDungeonProgress { get; set; }
        [Index(4)] public virtual int stageMax { get; set; }
        [Index(5)] public virtual int localID { get; set; }
        [Index(6)] public virtual int dungeonHighScoreKey { get; set; }
    }

    public enum DungeonID
    {
        grass1,
        forest1,
        water1,
        mountain1,
        cave1,
        grass2,
        forest2,
        mountain2,
        cave2,
        water2,
        special1,
        extra1,
        special2,
        tutorial1
    }

    [ZeroFormattable]
    public class BattleBreakData
    {
        [Index(0)] public virtual bool isExist { get; set; }
        [Index(1)] public virtual int waveIndex { get; set; }
        [Index(2)] public virtual IList<int> dropItemNum { get; set; }
        [Index(3)] public virtual IList<byte[]> dropStoneData { get; set; }
        [Index(4)] public virtual int dropPassiveStoneNum { get; set; }
        [Index(5)] public virtual int dropSkillStoneNum { get; set; }
        [Index(6)] public virtual float timer { get; set; }
        [Index(7)] public virtual FinishState finishState { get; set; }
        [Index(8)] public virtual IList<int> initSeeds { get; set; }
        [Index(9)] public virtual IList<int> dropSeeds { get; set; }
        [Index(10)] public virtual IList<Member> members { get; set; }
        [Index(11)] public virtual EndMode endMode { get; set; }


        [ZeroFormattable]
        public class Member
        {
            [Index(0)] public virtual int hp { get; set; }
            [Index(1)] public virtual float revivalSecondCount { get; set; }
        }
    }

    public enum FinishState
    {
        None = 0,
        Clear = 1,
        Gameover = 2,
        Break = 3,
        Max = 4
    }

    public enum EndMode
    {
        Continue = 0,
        Retire = 1,
        Collect = 2
    }

    [ZeroFormattable]
    public class PotentialStorage
    {
        [Index(0)] public virtual ILazyDictionary<int, StoneData> potentialDatas { get; set; }
        [Index(1)] public virtual int dataCapacity { get; set; }
    }

    [ZeroFormattable]
    public class StoneData
    {
        [Index(0)] public virtual IList<byte> stoneData { get; set; }
        [Index(1)] public virtual int characterStorageIndex { get; set; }
        [Index(2)] public virtual bool isNew { get; set; }
        [Index(3)] public virtual long timeTicks { get; set; }
    }

    [ZeroFormattable]
    public class ConfigData
    {
        [Index(0)] public virtual Sex playerSex { get; set; }
        [Index(1)] public virtual Language language { get; set; }
        [Index(2)] public virtual bool bgmMute { get; set; }
        [Index(3)] public virtual bool seMute { get; set; }
        [Index(4)] public virtual bool PushNotice { get; set; }
    }

    public enum Sex
    {
        Male = 0,
        Female = 1,
        Neutral = 2
    }

    public enum Language
    {
        Null = 0,
        Japanese = 1,
        English = 2,
        France = 3,
        Italy = 4,
        Germany = 5,
        Spain = 6,
        Korea = 7,
        ChineseSimplified = 8,
        ChineseTraditional = 9
    }

    [ZeroFormattable]
    public class FlagWork
    {
        [Index(0)] public virtual IList<byte> flags { get; set; }
        [Index(1)] public virtual IList<int> works { get; set; }
    }

    [ZeroFormattable]
    public class ItemStorage
    {
        [Index(0)] public virtual IList<Core> datas { get; set; }

        [ZeroFormattable]
        public class Core
        {
            [Index(0)] public virtual Item id { get; set; }
            [Index(1)] public virtual short num { get; set; }
            [Index(2)] public virtual bool isNew { get; set; }
        }
    }

    public enum Item
    {
        Invalid = 0,
        RedCommon = 1,
        RedUnCommon = 2,
        BlueCommon = 3,
        BlueUnCommon = 4,
        YellowCommon = 5,
        YellowUnCommon = 6,
        GreyCommon = 7,
        GreyUnCommon = 8,
        Rare = 9,
        Legend = 10,
        Max = 11,
        SaveMax = 129
    }

    [ZeroFormattable]
    public class VisitCharacter
    {
        public const int TimeVisitMax = 1;
        public const int CookingVisitMax = 3;
        public const int TutorialVisitMax = 2;
        public const int DLCVisitMax = 5;
        public const int TimeGroupMax = 1;
        public const int CookingGroupMax = 4;
        public const int TutorialGroupMax = 1;
        public const int DLCGroupMax = 1;
        public const int VisitTotal = 20;

        [Index(0)] public virtual IList<SaveCookingPot> cookingPotList { get; set; }
        [Index(1)] public virtual ILazyDictionary<int, SaveCharacterData> timeVisitCharacters_1 { get; set; }
        [Index(2)] public virtual ILazyDictionary<int, SaveCharacterData> cookVisitCharacters_1 { get; set; }
        [Index(3)] public virtual ILazyDictionary<int, SaveCharacterData> cookVisitCharacters_2 { get; set; }
        [Index(4)] public virtual ILazyDictionary<int, SaveCharacterData> cookVisitCharacters_3 { get; set; }
        [Index(5)] public virtual ILazyDictionary<int, SaveCharacterData> cookVisitCharacters_4 { get; set; }
        [Index(6)] public virtual ILazyDictionary<int, SaveCharacterData> tutorialVisitCharacters_1 { get; set; }
        [Index(7)] public virtual ILazyDictionary<int, SaveCharacterData> dlcVisitCharacters_1 { get; set; }
    }

    [ZeroFormattable]
    public class PokemonMemory
    {
        [Index(0)] public virtual IList<byte> winFlags { get; set; }
        [Index(1)] public virtual IList<ushort> scoutCounts { get; set; }
        [Index(2)] public virtual IList<byte> scoutRareFlags { get; set; }
    }

    [ZeroFormattable]
    public class Misc
    {
        [Index(0)] public virtual bool isFormated { get; set; }
        [Index(1)] public virtual int fsGiftTicketNum { get; set; }
        [Index(2)] public virtual int battery { get; set; }
        [Index(3)] public virtual IList<int> useSkillIDFlags { get; set; }
        [Index(4)] public virtual IList<int> battlePokeSeikakuFlags { get; set; }
    }

    [ZeroFormattable]
    public class PlayerData
    {
        [Index(0)] public virtual string name { get; set; }
        [Index(1)] public virtual int termsVersion { get; set; }
        [Index(2)] public virtual string playerKey { get; set; }
        [Index(3)] public virtual string deviceUUID { get; set; }
        [Index(4)] public virtual string supportID { get; set; }
        [Index(5)] public virtual bool coppaLimit { get; set; }
        [Index(6)] public virtual bool purchaseCheck { get; set; }
        [Index(7)] public virtual IList<PurchaseWork> purchaseWorks { get; set; }
        [Index(8)] public virtual string migrationBackupId { get; set; }
        [Index(9)] public virtual string migrationBackupKey { get; set; }
        [Index(10)] public virtual long backupDatetime { get; set; }
        [Index(11)] public virtual CompensationWork compensationWork { get; set; }
        [Index(12)] public virtual IList<ID> timeoveredDLC { get; set; }
    }

    public enum ID
    {
        Invalid = 0,
        DLC_01 = 1,
        DLC_02 = 2,
        DLC_03 = 3,
        DLC_04 = 4,
        DLC_05 = 5,
        DLC_06 = 6,
        DLC_07 = 7,
        DLC_08 = 8,
        DLC_09 = 9,
        DLC_10 = 10,
        DLC_11 = 11
    }

    [ZeroFormattable]
    public class PurchaseWork
    {
        [Index(0)] public virtual string commonProductId { get; set; }
        [Index(1)] public virtual string platformTransactionId { get; set; }
        [Index(2)] public virtual long appTransactionId { get; set; }
        [Index(3)] public virtual bool validated { get; set; }
        [Index(4)] public virtual string purchaseLocation { get; set; }
    }

    [ZeroFormattable]
    public class CompensationWork
    {
        [Index(0)] public virtual State state { get; set; }
        [Index(1)] public virtual long applyId { get; set; }
        [Index(2)] public virtual long dataId { get; set; }
    }

    public enum State
    {
        None,
        Begin,
        Applied
    }

    [ZeroFormattable]
    public class Time
    {
        [Index(0)] public virtual TimeParameter time { get; set; }
        [Index(1)] public virtual TimeParameter fsGiftTicketTime { get; set; }
        [Index(2)] public virtual TimeParameter batteryTime { get; set; }
        [Index(3)] public virtual TimeParameter visitTime { get; set; }
        [Index(4)] public virtual IList<byte> timePoint { get; set; }
        [Index(5)] public virtual long lastFsGiftTicketServerTime { get; set; }
    }

    [ZeroFormattable]
    public class TimeParameter
    {
        [Index(0)] public virtual long ticks { get; set; }
    }

    [ZeroFormattable]
    public class Goods
    {
        [Index(0)] public virtual IList<ManageData> hasDatas { get; set; }
        [Index(1)] public virtual IList<PlacementData> placementDatas { get; set; }

        [ZeroFormattable]
        public class ManageData
        {
            [Index(0)] public virtual int id { get; set; }
            [Index(1)] public virtual bool isNew { get; set; }
        }

        [ZeroFormattable]
        public class PlacementData
        {
            [Index(0)] public virtual int id { get; set; }
            [Index(1)] public virtual int goodsID { get; set; }
            [Index(2)] public virtual byte direction { get; set; }
        }
    }

    [ZeroFormattable]
    public class Cook
    {
        [Index(0)] public virtual int recipeOpen { get; set; }
        [Index(1)] public virtual int volumeOpen { get; set; }
        [Index(2)] public virtual int lastRecipeID { get; set; }
        [Index(3)] public virtual int potOpen { get; set; }
    }

    [ZeroFormattable]
    public class SaveCookingPot
    {
        [Index(0)] public virtual CookingPotState state { get; set; }
        [Index(1)] public virtual int cookingProgress { get; set; }
        [Index(2)] public virtual int cookingOldProgress { get; set; }
        [Index(3)] public virtual int recipeID { get; set; }
        [Index(4)] public virtual int rarityID { get; set; }
        [Index(5)] public virtual int rankID { get; set; }
        [Index(6)] public virtual int cookTime { get; set; }
    }

    public enum CookingPotState
    {
        None,
        Cooking,
        Finish,
        Idle
    }

    public enum Work
    {
        Invalid = 0,
        Dungeon00_00 = 1,
        Dungeon00_01 = 2,
        Dungeon00_02 = 3,
        Dungeon00_03 = 4,
        Dungeon00_04 = 5,
        Dungeon00_05 = 6,
        Dungeon00_06 = 7,
        Dungeon00_07 = 8,
        Dungeon00_08 = 9,
        Dungeon00_09 = 10,
        Dungeon00_10 = 11,
        Dungeon00_11 = 12,
        Dungeon00_12 = 13,
        Dungeon00_13 = 14,
        Dungeon00_14 = 15,
        Dungeon00_15 = 16,
        Dungeon00_16 = 17,
        Dungeon00_17 = 18,
        Dungeon00_18 = 19,
        Dungeon00_19 = 20,
        Dungeon00_20 = 21,
        Dungeon00_21 = 22,
        Dungeon00_22 = 23,
        Dungeon00_23 = 24,
        PokemonVisitLotteryLoseCount = 50,
        StageClearRankMax = 51,
        GameStart = 210,
        TutorialSeq = 212,
        TitleAfterScene = 300,
        AchievementTotal_000 = 400,
        AchievementTotal_001 = 401,
        AchievementTotal_002 = 402,
        AchievementTotal_003 = 403,
        AchievementTotal_004 = 404,
        AchievementTotal_005 = 405,
        AchievementTotal_006 = 406,
        AchievementTotal_007 = 407,
        AchievementTotal_008 = 408,
        AchievementTotal_009 = 409,
        AchievementTotal_010 = 410,
        AchievementTotal_011 = 411,
        AchievementTotal_012 = 412,
        AchievementTotal_013 = 413,
        AchievementTotal_014 = 414,
        AchievementTotal_015 = 415,
        AchievementTotal_016 = 416,
        AchievementTotal_017 = 417,
        AchievementTotal_018 = 418,
        AchievementTotal_019 = 419,
        AchievementTotal_020 = 420,
        AchievementTotal_021 = 421,
        AchievementTotal_022 = 422,
        AchievementTotal_023 = 423,
        AchievementTotal_024 = 424,
        AchievementTotal_025 = 425,
        AchievementTotal_026 = 426,
        AchievementTotal_027 = 427,
        AchievementTotal_028 = 428,
        AchievementTotal_029 = 429,
        AchievementTotal_030 = 430,
        AchievementTotal_031 = 431,
        AchievementTotal_032 = 432,
        AchievementTotal_033 = 433,
        AchievementTotal_034 = 434,
        AchievementTotal_035 = 435,
        AchievementTotal_036 = 436,
        AchievementTotal_037 = 437,
        AchievementTotal_038 = 438,
        AchievementTotal_039 = 439,
        AchievementTotal_040 = 440,
        AchievementTotal_041 = 441,
        AchievementTotal_042 = 442,
        AchievementTotal_043 = 443,
        AchievementTotal_044 = 444,
        AchievementTotal_045 = 445,
        AchievementTotal_046 = 446,
        AchievementTotal_047 = 447,
        AchievementTotal_048 = 448,
        AchievementTotal_049 = 449,
        AchievementTotal_050 = 450,
        AchievementTotal_051 = 451,
        AchievementTotal_052 = 452,
        AchievementTotal_053 = 453,
        AchievementTotal_054 = 454,
        AchievementTotal_055 = 455,
        AchievementTotal_056 = 456,
        AchievementTotal_057 = 457,
        AchievementTotal_058 = 458,
        AchievementTotal_059 = 459,
        AchievementTotal_060 = 460,
        AchievementTotal_061 = 461,
        AchievementTotal_062 = 462,
        AchievementTotal_063 = 463,
        AchievementTotal_064 = 464,
        AchievementTotal_065 = 465,
        AchievementTotal_066 = 466,
        AchievementTotal_067 = 467,
        AchievementTotal_068 = 468,
        AchievementTotal_069 = 469,
        AchievementTotal_070 = 470,
        AchievementTotal_071 = 471,
        AchievementTotal_072 = 472,
        AchievementTotal_073 = 473,
        AchievementTotal_074 = 474,
        AchievementTotal_075 = 475,
        AchievementTotal_076 = 476,
        AchievementTotal_077 = 477,
        AchievementTotal_078 = 478,
        AchievementTotal_079 = 479,
        AchievementTotal_080 = 480,
        AchievementTotal_081 = 481,
        AchievementTotal_082 = 482,
        AchievementTotal_083 = 483,
        AchievementTotal_084 = 484,
        AchievementTotal_085 = 485,
        AchievementTotal_086 = 486,
        AchievementTotal_087 = 487,
        AchievementTotal_088 = 488,
        AchievementTotal_089 = 489,
        AchievementTotal_090 = 490,
        AchievementTotal_091 = 491,
        AchievementTotal_092 = 492,
        AchievementTotal_093 = 493,
        AchievementTotal_094 = 494,
        AchievementTotal_095 = 495,
        AchievementTotal_096 = 496,
        AchievementTotal_097 = 497,
        AchievementTotal_098 = 498,
        AchievementTotal_099 = 499,
        AchievementTotal_100 = 500,
        AchievementTotal_101 = 501,
        AchievementTotal_102 = 502,
        AchievementTotal_103 = 503,
        AchievementTotal_104 = 504,
        AchievementTotal_105 = 505,
        AchievementTotal_106 = 506,
        AchievementTotal_107 = 507,
        AchievementTotal_108 = 508,
        AchievementTotal_109 = 509,
        AchievementTotal_110 = 510,
        AchievementTotal_111 = 511,
        AchievementKeyTotal_000 = 550,
        AchievementKeyTotal_001 = 551,
        AchievementKeyTotal_002 = 552,
        AchievementKeyTotal_003 = 553,
        AchievementKeyTotal_004 = 554,
        AchievementKeyTotal_005 = 555,
        AchievementKeyTotal_006 = 556,
        AchievementKeyTotal_007 = 557,
        AchievementKeyTotal_008 = 558,
        AchievementKeyTotal_009 = 559,
        AchievementKeyTotal_010 = 560,
        AchievementKeyTotal_011 = 561,
        AchievementKeyTotal_012 = 562,
        AchievementKeyTotal_013 = 563,
        AchievementKeyTotal_014 = 564,
        AchievementKeyTotal_015 = 565,
        AchievementKeyTotal_016 = 566,
        AchievementKeyTotal_017 = 567,
        AchievementKeyTotal_018 = 568,
        AchievementKeyTotal_019 = 569,
        AchievementKeyTotal_020 = 570,
        AchievementLevel_000 = 600,
        AchievementLevel_001 = 601,
        AchievementLevel_002 = 602,
        AchievementLevel_003 = 603,
        AchievementLevel_004 = 604,
        AchievementLevel_005 = 605,
        AchievementLevel_006 = 606,
        AchievementLevel_007 = 607,
        AchievementLevel_008 = 608,
        AchievementLevel_009 = 609,
        AchievementLevel_010 = 610,
        AchievementLevel_011 = 611,
        AchievementLevel_012 = 612,
        AchievementLevel_013 = 613,
        AchievementLevel_014 = 614,
        AchievementLevel_015 = 615,
        AchievementLevel_016 = 616,
        AchievementLevel_017 = 617,
        AchievementLevel_018 = 618,
        AchievementLevel_019 = 619,
        AchievementLevel_020 = 620,
        AchievementLevel_021 = 621,
        AchievementLevel_022 = 622,
        AchievementLevel_023 = 623,
        AchievementLevel_024 = 624,
        AchievementLevel_025 = 625,
        AchievementLevel_026 = 626,
        AchievementLevel_027 = 627,
        AchievementLevel_028 = 628,
        AchievementLevel_029 = 629,
        AchievementLevel_030 = 630,
        AchievementLevel_031 = 631,
        AchievementLevel_032 = 632,
        AchievementLevel_033 = 633,
        AchievementLevel_034 = 634,
        AchievementLevel_035 = 635,
        AchievementLevel_036 = 636,
        AchievementLevel_037 = 637,
        AchievementLevel_038 = 638,
        AchievementLevel_039 = 639,
        AchievementLevel_040 = 640,
        AchievementLevel_041 = 641,
        AchievementLevel_042 = 642,
        AchievementLevel_043 = 643,
        AchievementLevel_044 = 644,
        AchievementLevel_045 = 645,
        AchievementLevel_046 = 646,
        AchievementLevel_047 = 647,
        AchievementLevel_048 = 648,
        AchievementLevel_049 = 649,
        AchievementLevel_050 = 650,
        AchievementLevel_051 = 651,
        AchievementLevel_052 = 652,
        AchievementLevel_053 = 653,
        AchievementLevel_054 = 654,
        AchievementLevel_055 = 655,
        AchievementLevel_056 = 656,
        AchievementLevel_057 = 657,
        AchievementLevel_058 = 658,
        AchievementLevel_059 = 659,
        AchievementLevel_060 = 660,
        AchievementLevel_061 = 661,
        AchievementLevel_062 = 662,
        AchievementLevel_063 = 663,
        AchievementLevel_064 = 664,
        AchievementLevel_065 = 665,
        AchievementLevel_066 = 666,
        AchievementLevel_067 = 667,
        AchievementLevel_068 = 668,
        AchievementLevel_069 = 669,
        AchievementLevel_070 = 670,
        AchievementLevel_071 = 671,
        AchievementLevel_072 = 672,
        AchievementLevel_073 = 673,
        AchievementLevel_074 = 674,
        AchievementLevel_075 = 675,
        AchievementLevel_076 = 676,
        AchievementLevel_077 = 677,
        AchievementLevel_078 = 678,
        AchievementLevel_079 = 679,
        AchievementLevel_080 = 680,
        AchievementLevel_081 = 681,
        AchievementLevel_082 = 682,
        AchievementLevel_083 = 683,
        AchievementLevel_084 = 684,
        AchievementLevel_085 = 685,
        AchievementLevel_086 = 686,
        AchievementLevel_087 = 687,
        AchievementLevel_088 = 688,
        AchievementLevel_089 = 689,
        AchievementLevel_090 = 690,
        AchievementLevel_091 = 691,
        AchievementLevel_092 = 692,
        AchievementLevel_093 = 693,
        AchievementLevel_094 = 694,
        AchievementLevel_095 = 695,
        AchievementLevel_096 = 696,
        AchievementLevel_097 = 697,
        AchievementLevel_098 = 698,
        AchievementLevel_099 = 699,
        AchievementLevel_100 = 700,
        AchievementLevel_101 = 701,
        AchievementLevel_102 = 702,
        AchievementLevel_103 = 703,
        AchievementLevel_104 = 704,
        AchievementLevel_105 = 705,
        AchievementLevel_106 = 706,
        AchievementLevel_107 = 707,
        AchievementLevel_108 = 708,
        AchievementLevel_109 = 709,
        AchievementLevel_110 = 710,
        AchievementLevel_111 = 711,
        AchievementKeyLevel_000 = 750,
        AchievementKeyLevel_001 = 751,
        AchievementKeyLevel_002 = 752,
        AchievementKeyLevel_003 = 753,
        AchievementKeyLevel_004 = 754,
        AchievementKeyLevel_005 = 755,
        AchievementKeyLevel_006 = 756,
        AchievementKeyLevel_007 = 757,
        AchievementKeyLevel_008 = 758,
        AchievementKeyLevel_009 = 759,
        AchievementKeyLevel_010 = 760,
        AchievementKeyLevel_011 = 761,
        AchievementKeyLevel_012 = 762,
        AchievementKeyLevel_013 = 763,
        AchievementKeyLevel_014 = 764,
        AchievementKeyLevel_015 = 765,
        AchievementKeyLevel_016 = 766,
        AchievementKeyLevel_017 = 767,
        AchievementKeyLevel_018 = 768,
        AchievementKeyLevel_019 = 769,
        AchievementKeyLevel_020 = 770,
        Max = 1025
    }
}
