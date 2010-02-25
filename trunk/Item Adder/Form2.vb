﻿Option Explicit On
Imports System.Net
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Xml
Imports System.Threading


Public Class Form2
    Dim info As Integer
    Dim itemtype As Boolean = False
    Dim fileinfo As String
    Private arrRealmlist As New ArrayList()
    Dim thequery As String
    Private arcQuery As String
    Dim aspquery As String
    Dim trinquery As String
    Dim mangoquery As String
    Dim entry = 0
    Dim classs = 0
    Dim subclass = 0
    Dim field4 = 0
    Dim name1 As String = 0
    Dim name2 = 0
    Dim name3 = 0
    Dim name4 = 0
    Dim displayid = 0
    Dim quality = 0
    Dim buycount = 1
    Dim flags = 0
    Dim faction = 0
    Dim buyprice = 0
    Dim sellprice = 0
    Dim inventorytype = 0
    Dim allowableclass = 0
    Dim allowablerace = 0
    Dim itemlevel = 0
    Dim requiredlevel = 0
    Dim RequiredSkill = 0
    Dim RequiredSkillRank = 0
    Dim RequiredSpell = 0
    Dim RequiredPlayerRank1 = 0
    Dim RequiredPlayerRank2 = 0
    Dim RequiredFaction = 0
    Dim RequiredFactionStanding = 0
    Dim RequiredReputationRank = 0
    Dim Unique = 0
    Dim rangedmodrange = 0
    Dim maxcount = 0
    Dim ContainerSlots = 0
    Dim itemstatscount = 0
    Dim stat_type1 = 0
    Dim stat_value1 = 0
    Dim stat_type2 = 0
    Dim stat_value2 = 0
    Dim stat_type3 = 0
    Dim stat_value3 = 0
    Dim stat_type4 = 0
    Dim stat_value4 = 0
    Dim stat_type5 = 0
    Dim stat_value5 = 0
    Dim stat_type6 = 0
    Dim stat_value6 = 0
    Dim stat_type7 = 0
    Dim stat_value7 = 0
    Dim stat_type8 = 0
    Dim stat_value8 = 0
    Dim stat_type9 = 0
    Dim stat_value9 = 0
    Dim stat_type10 = 0
    Dim stat_value10 = 0
    Dim ScalingStatsEntry = 0
    Dim ScalingStatsFlags = 0
    Dim dmg_min1 = 0
    Dim dmg_max1 = 0
    Dim dmg_type1 = 0
    Dim dmg_min2 = 0
    Dim dmg_max2 = 0
    Dim dmg_type2 = 0
    Dim dmg_min3 = 0
    Dim dmg_max3 = 0
    Dim dmg_type3 = 0
    Dim dmg_min4 = 0
    Dim dmg_max4 = 0
    Dim dmg_type4 = 0
    Dim dmg_min5 = 0
    Dim dmg_max5 = 0
    Dim dmg_type5 = 0
    Dim armor = 0
    Dim holy_res = 0
    Dim fire_res = 0
    Dim nature_res = 0
    Dim frost_res = 0
    Dim shadow_res = 0
    Dim arcane_resist = 0
    Dim delay = 0
    Dim ammo_type = 0
    Dim spellid_1 = 0
    Dim spelltrigger_1 = 0
    Dim spellcharges_1 = 0
    Dim spellcooldown_1 = 0
    Dim spellcategory_1 = 0
    Dim spellcategorycooldown_1 = 0
    Dim spellid_2 = 0
    Dim spelltrigger_2 = 0
    Dim spellcharges_2 = 0
    Dim spellcooldown_2 = 0
    Dim spellcategory_2 = 0
    Dim spellcategorycooldown_2 = 0
    Dim spellid_3 = 0
    Dim spelltrigger_3 = 0
    Dim spellcharges_3 = 0
    Dim spellcooldown_3 = 0
    Dim spellcategory_3 = 0
    Dim spellcategorycooldown_3 = 0
    Dim spellid_4 = 0
    Dim spelltrigger_4 = 0
    Dim spellcharges_4 = 0
    Dim spellcooldown_4 = 0
    Dim spellcategory_4 = 0
    Dim spellcategorycooldown_4 = 0
    Dim spellid_6 = 0
    Dim spelltrigger_6 = 0
    Dim spellcharges_6 = 0
    Dim spellcooldown_6 = 0
    Dim spellcategory_6 = 0
    Dim spellcategorycooldown_6 = 0
    Dim bonding = 0
    Dim description = 0
    Dim pageid = 0
    Dim page_language = 0
    Dim page_material = 0
    Dim quest_id = 0
    Dim lock_id = 0
    Dim lock_material = 0
    Dim sheathid = 0
    Dim randomprop = 0
    Dim randomsuffix = 0
    Dim block = 0
    Dim itemset = 0
    Dim MaxDurability = 0
    Dim ZoneNameID = 0
    Dim mapid = 0
    Dim bagfamily = 0
    Dim TotemCategory = 0
    Dim socket_color_1 = 0
    Dim unk201_3 = 0
    Dim socket_color_2 = 0
    Dim unk201_5 = 0
    Dim socket_color_3 = 0
    Dim unk201_7 = 0
    Dim socket_bonus = 0
    Dim GemProperties = 0
    Dim ReqDisenchantSkill = 0
    Dim ArmorDamageModifier = 0
    Dim duration
    Dim ItemLimitCategoryID
    Dim itemid As String
    Dim itemxml As String = ("http://wow.allakhazam.com/cluster/item-xml.pl?witem=" + itemid)
    Dim itemicon As String
    Dim multi As Boolean = False
    Dim x As Integer
    Dim y As Integer
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Dim banstatus As Boolean = False

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub nodelist()
        Dim m_xmld As XmlDocument
        Dim m_node As XmlNode
        Dim m_nodelist As XmlNodeList
        Sleep(NumericUpDown1.Value)

        m_xmld = New XmlDocument()
        m_xmld.Load("http://wow.allakhazam.com/cluster/item-xml.pl?witem=" & itemid)
        m_nodelist = m_xmld.SelectNodes("/wowitem")

        For Each m_node In m_nodelist
            arcane_resist = m_node.ChildNodes.Item(0).InnerText
            armor = m_node.ChildNodes.Item(1).InnerText
            bonding = m_node.ChildNodes.Item(2).InnerText
            block = m_node.ChildNodes.Item(3).InnerText
            buyprice = m_node.ChildNodes.Item(4).InnerText
            spellcharges_1 = m_node.ChildNodes.Item(5).InnerText
            spellcharges_2 = m_node.ChildNodes.Item(6).InnerText
            spellcharges_3 = m_node.ChildNodes.Item(7).InnerText
            allowableclass = m_node.ChildNodes.Item(8).InnerText
            description = m_node.ChildNodes.Item(12).InnerText
            displayid = m_node.ChildNodes.Item(20).InnerText
            dmg_max1 = m_node.ChildNodes.Item(21).InnerText
            dmg_max2 = m_node.ChildNodes.Item(22).InnerText
            dmg_max3 = m_node.ChildNodes.Item(23).InnerText
            dmg_min1 = m_node.ChildNodes.Item(24).InnerText
            dmg_min2 = m_node.ChildNodes.Item(25).InnerText
            dmg_min3 = m_node.ChildNodes.Item(26).InnerText
            dmg_type1 = m_node.ChildNodes.Item(27).InnerText
            dmg_type2 = m_node.ChildNodes.Item(28).InnerText
            dmg_type3 = m_node.ChildNodes.Item(29).InnerText
            fire_res = m_node.ChildNodes.Item(31).InnerText
            flags = m_node.ChildNodes.Item(33).InnerText
            frost_res = m_node.ChildNodes.Item(34).InnerText
            GemProperties = m_node.ChildNodes.Item(35).InnerText
            holy_res = m_node.ChildNodes.Item(36).InnerText
            itemicon = m_node.ChildNodes.Item(37).InnerText
            entry = m_node.ChildNodes.Item(38).InnerText
            classs = m_node.ChildNodes.Item(48).InnerText
            subclass = m_node.ChildNodes.Item(50).InnerText
            itemlevel = m_node.ChildNodes.Item(51).InnerText
            requiredlevel = m_node.ChildNodes.Item(53).InnerText
            name1 = m_node.ChildNodes.Item(54).InnerText
            name2 = m_node.ChildNodes.Item(55).InnerText
            name3 = m_node.ChildNodes.Item(56).InnerText
            name4 = m_node.ChildNodes.Item(57).InnerText
            nature_res = m_node.ChildNodes.Item(58).InnerText
            quality = m_node.ChildNodes.Item(62).InnerText
            allowablerace = m_node.ChildNodes.Item(63).InnerText
            randomprop = m_node.ChildNodes.Item(65).InnerText
            randomsuffix = m_node.ChildNodes.Item(64).InnerText
            RequiredSkill = m_node.ChildNodes.Item(67).InnerText
            RequiredSkillRank = m_node.ChildNodes.Item(66).InnerText
            RequiredSpell = m_node.ChildNodes.Item(68).InnerText
            RequiredFaction = m_node.ChildNodes.Item(69).InnerText
            RequiredFactionStanding = m_node.ChildNodes.Item(70).InnerText
            RequiredPlayerRank1 = m_node.ChildNodes.Item(71).InnerText
            sellprice = m_node.ChildNodes.Item(72).InnerText
            itemset = m_node.ChildNodes.Item(73).InnerText
            shadow_res = m_node.ChildNodes.Item(74).InnerText
            inventorytype = m_node.ChildNodes.Item(75).InnerText
            ContainerSlots = m_node.ChildNodes.Item(76).InnerText
            socket_color_1 = m_node.ChildNodes.Item(77).InnerText
            unk201_3 = 0
            socket_color_2 = m_node.ChildNodes.Item(78).InnerText
            unk201_5 = 0
            socket_color_3 = m_node.ChildNodes.Item(79).InnerText
            unk201_7 = 0
            socket_bonus = m_node.ChildNodes.Item(80).InnerText
            field4 = -1
            RequiredPlayerRank2 = 0
            delay = m_node.ChildNodes.Item(82).InnerText
            spelltrigger_1 = m_node.ChildNodes.Item(83).InnerText
            spelltrigger_2 = m_node.ChildNodes.Item(84).InnerText
            spelltrigger_3 = m_node.ChildNodes.Item(85).InnerText
            spellcooldown_1 = m_node.ChildNodes.Item(86).InnerText
            spellcooldown_2 = m_node.ChildNodes.Item(87).InnerText
            spellcooldown_3 = m_node.ChildNodes.Item(88).InnerText
            spellcategory_1 = m_node.ChildNodes.Item(89).InnerText
            spellcategory_2 = m_node.ChildNodes.Item(90).InnerText
            spellcategory_3 = m_node.ChildNodes.Item(91).InnerText
            spellcategorycooldown_1 = m_node.ChildNodes.Item(92).InnerText
            spellcategorycooldown_2 = m_node.ChildNodes.Item(93).InnerText
            spellcategorycooldown_3 = m_node.ChildNodes.Item(94).InnerText
            spellid_1 = m_node.ChildNodes.Item(95).InnerText
            spellid_2 = m_node.ChildNodes.Item(96).InnerText
            spellid_3 = m_node.ChildNodes.Item(97).InnerText
            maxcount = m_node.ChildNodes.Item(98).InnerText
            quest_id = m_node.ChildNodes.Item(99).InnerText
            stat_type10 = m_node.ChildNodes.Item(100).InnerText
            stat_value10 = m_node.ChildNodes.Item(101).InnerText
            stat_type1 = m_node.ChildNodes.Item(102).InnerText
            stat_value1 = m_node.ChildNodes.Item(103).InnerText
            stat_type2 = m_node.ChildNodes.Item(104).InnerText
            stat_value2 = m_node.ChildNodes.Item(105).InnerText
            stat_type3 = m_node.ChildNodes.Item(106).InnerText
            stat_value3 = m_node.ChildNodes.Item(107).InnerText
            stat_type4 = m_node.ChildNodes.Item(108).InnerText
            stat_value4 = m_node.ChildNodes.Item(109).InnerText
            stat_type5 = m_node.ChildNodes.Item(110).InnerText
            stat_value5 = m_node.ChildNodes.Item(111).InnerText
            stat_type6 = m_node.ChildNodes.Item(112).InnerText
            stat_value6 = m_node.ChildNodes.Item(113).InnerText
            stat_type7 = m_node.ChildNodes.Item(114).InnerText
            stat_value7 = m_node.ChildNodes.Item(115).InnerText
            stat_type8 = m_node.ChildNodes.Item(116).InnerText
            stat_value8 = m_node.ChildNodes.Item(117).InnerText
            stat_type9 = m_node.ChildNodes.Item(118).InnerText
            stat_value9 = m_node.ChildNodes.Item(119).InnerText
            itemstatscount = m_node.ChildNodes.Item(120).InnerText
            TotemCategory = m_node.ChildNodes.Item(122).InnerText
            Unique = m_node.ChildNodes.Item(125).InnerText
            rangedmodrange = 100
            ScalingStatsEntry = 0
            ScalingStatsFlags = 0
            dmg_min4 = 0
            dmg_max4 = 0
            dmg_type4 = 0
            dmg_min5 = 0
            dmg_max5 = 0
            dmg_type5 = 0
            ammo_type = m_node.ChildNodes.Item(159).InnerText
            spellid_4 = 0
            spelltrigger_4 = 0
            spellcharges_4 = 0
            spellcooldown_4 = 0
            spellcategory_4 = 0
            spellcategorycooldown_4 = 0
            spellid_6 = 0
            spelltrigger_6 = 0
            spellcharges_6 = 0
            spellcooldown_6 = 0
            spellcategory_6 = 0
            spellcategorycooldown_6 = 0
            pageid = m_node.ChildNodes.Item(172).InnerText
            page_language = m_node.ChildNodes.Item(173).InnerText
            page_material = m_node.ChildNodes.Item(174).InnerText
            lock_id = m_node.ChildNodes.Item(126).InnerText
            lock_material = m_node.ChildNodes.Item(127).InnerText
            sheathid = m_node.ChildNodes.Item(128).InnerText
            MaxDurability = m_node.ChildNodes.Item(130).InnerText
            ZoneNameID = m_node.ChildNodes.Item(132).InnerText
            mapid = m_node.ChildNodes.Item(133).InnerText
            bagfamily = m_node.ChildNodes.Item(134).InnerText
            ReqDisenchantSkill = m_node.ChildNodes.Item(138).InnerText
            ArmorDamageModifier = m_node.ChildNodes.Item(139).InnerText
            duration = m_node.ChildNodes.Item(142).InnerText
            ItemLimitCategoryID = 0
        Next
    End Sub

    Public Sub writesql()
        If My.Settings.type = "Arcemu" Then
            arcQuery = "INSERT INTO `items` VALUES ('" & entry & "', '" & classs & "', '" & subclass & "', '" & field4 & "', '" & name1 & "', '" & displayid & "', '" & quality & "', '" & flags & "', '" & faction & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredPlayerRank2 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & Unique & "', '" & maxcount & "', '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', '" & TotemCategory & "', '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '0', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "', '" & duration & "', '" & 0 & "', '" & 0 & "');"
            thequery = arcQuery
        End If
        If My.Settings.type = "Trinity" Then
            trinquery = "INSERT INTO `item_template` VALUES ('" & entry & "', '" & classs & "', '" & subclass & "', '" & -1 & "', '" & name1 & "', '" & displayid & "', '" & quality & "', '" & flags & "', '" & faction & "', '" & buycount & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredPlayerRank2 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & maxcount & "', '" & 1 & "',  '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', '" & rangedmodrange & "', '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & 0 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & 0 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & 0 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & 0 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '" & TotemCategory & "', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "' , '" & duration & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "', '" & 0 & "');"
            thequery = trinquery
        End If
        If My.Settings.type = "Mangos" Then
            mangoquery = "INSERT INTO `item_template` VALUES ('" & entry & "', '" & classs & "', '" & subclass & "', '" & -1 & "', '" & name1 & "', '" & displayid & "', '" & quality & "', '" & flags & "', '" & faction & "', '" & buycount & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & RequiredReputationRank & "', '" & maxcount & "', '" & Unique & "',  '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', " & rangedmodrange & ", '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & 0 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & 0 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & 0 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & 0 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '" & TotemCategory & "', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "' , '" & duration & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "');"
            thequery = mangoquery
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        itemid = TextBox1.Text
        If checkitem() = True Then
            nodelist()
            If entry = 0 Then
                If banstatus = False Then
                    MsgBox("You have been banned by allakhazam.com for a while.")
                    ToolStripStatusLabel1.Text = "Web connect status: Banned."
                    banstatus = True
                End If
            Else
                TextBox5.Text = name1
                WebBrowser4.Navigate("http://wow.allakhazam.com/" & itemicon)
                ToolStripStatusLabel1.Text = "Web connect status: Connected."
            End If
        End If
        WebBrowser1.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
    End Sub

    Public Function checkitem() As Boolean
        Dim url As String = ("http://wow.allakhazam.com/ihtml?" + itemid)
        Dim webResponse3 As HttpWebResponse = Nothing
        Dim webRequest3 As HttpWebRequest = HttpWebRequest.Create(url)

        Try
            webResponse3 = DirectCast(webRequest3.GetResponse(), System.Net.HttpWebResponse)
            Dim srResp As StreamReader
            srResp = New StreamReader(webResponse3.GetResponseStream())
            Dim strIn As String
            strIn = srResp.ReadToEnd
            If strIn.Length < 470 Then
                Return False
            Else
                Return True
            End If
            ToolStripStatusLabel1.Text = "Web connect status: Connected."
        Catch ex As Exception
        End Try

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(WebBrowser1.Url.ToString)
    End Sub

    Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        itemid = TextBox1.Text
        parsexml()
        If entry = 0 Then
            If banstatus = False Then
                MsgBox("You have been banned by allakhazam.com for a while. Please set 'Multi Item Add min. Speed' >= 2000 ms.")
                ToolStripStatusLabel1.Text = "Web connect status: Banned."
                banstatus = True
            Else
                MsgBox("You are still banned.")
            End If
        End If
        If entry <> 0 Then
            checktext()
            writesql()

            Dim Connection As MySqlConnection
            Dim Query As MySqlCommand
            Dim Execute As MySqlCommand
            Dim Reader As MySqlDataReader = Nothing
            Dim Reader2 As MySqlDataReader = Nothing

            Connection = New MySqlConnection("server=" & My.Settings.host & ";user id=" & My.Settings.username & "; password=" & My.Settings.password & "; port=" & My.Settings.port & "; database=" & My.Settings.db & "; pooling=false")
            Connection.Open()
            If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
                Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
            Else
                Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
            End If
            Reader = Query.ExecuteReader()
            If Reader.HasRows And itemid <> "" Then
                Reader.Close()
                MsgBox(itemid & " already in database.")
            Else
                Reader.Close()
                Execute = New MySqlCommand(thequery, Connection)
                Reader2 = Execute.ExecuteReader
                name1 = name1.Replace("\", "")
                MsgBox(itemid & " " & name1 & " added successfuly.")
                Reader2.Close()
            End If
        End If
    End Sub

    Public Sub parsexml()
        Try
            nodelist()
        Catch errorVariable As Exception
            Console.Write(errorVariable.ToString())
        End Try
    End Sub

    Public Sub checktext()
        name1 = name1.Replace("'", "\'")
        description = description.Replace("'", "\'")
    End Sub

    Public Sub reset()
        Button1.Enabled = True
        itemid = ""
        WebBrowser1.Navigate("")
        TextBox1.Text = ""
    End Sub

    Public Sub checkstuff()
        x = ListBox5.Items.Count
        y = 0

        Do Until y = x
            If itemid = ListBox5.Items.Item(y) Then
                MsgBox(itemid & " already in list.")
                Exit Sub
            End If
            y = y + 1
        Loop

        x = ListBox3.Items.Count
        y = 0
        Do Until y = x
            If itemid = ListBox3.Items.Item(y) Then
                MsgBox(itemid & " already in database.")
                Exit Sub
            End If
            y = y + 1
        Loop

        If dbcheck() = True Then
            MsgBox(itemid & " already in database.")
            TextBox4.Text = TextBox4.Text & itemid & " | "
            ListBox3.Items.Add(itemid)
            Exit Sub
        End If

        x = ListBox4.Items.Count
        y = 0
        Do Until y = x
            If itemid = ListBox4.Items.Item(y) Then
                MsgBox(itemid & " not found on web.")
                Exit Sub
            End If
            y = y + 1
        Loop

        If checkitem() = True Then
            ListBox5.Items.Add(itemid)
            MsgBox(itemid & " added into list.")
        Else
            MsgBox(itemid & " not found on web.")
            TextBox7.Text = TextBox7.Text & itemid & " | "
            ListBox4.Items.Add(itemid)
        End If
    End Sub

    Public Function dbcheck() As Boolean
        Dim Connection As MySqlConnection
        Dim Query As MySqlCommand
        Dim Reader As MySqlDataReader = Nothing

        Connection = New MySqlConnection("server=" & My.Settings.host & ";user id=" & My.Settings.username & "; password=" & My.Settings.password & "; port=" & My.Settings.port & "; database=" & My.Settings.db & "; pooling=false")
        Connection.Open()
        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If
        Reader = Query.ExecuteReader()
        If Reader.HasRows And itemid <> "" Then
            Reader.Close()
            Return True
        Else
            Reader.Close()
            Return False
        End If

    End Function

    Private Sub removeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeToolStripMenuItem.Click
        ListBox5.Items.Remove(ListBox5.SelectedItem)
    End Sub

    Private Sub LoadRealms()

        Dim realm_name() As String

        Try
            realm_name = fileinfo.Split(";")
            Dim objRealm As New realms

            For i = 0 To UBound(realm_name)
                objRealm = realms.createrealm(realm_name(i), i.ToString)
                arrRealmlist.Add(objRealm)
            Next
        Catch

        End Try
    End Sub
    Private Sub UpdateDisplay()

        ListBox5.Items.Clear()
        For Each objRealm As realms In arrRealmlist
            If objRealm.realmname <> "" Then
                ListBox5.Items.Add(objRealm.realmname)
            End If
        Next
    End Sub

    Public Sub cleantext()
        Dim illegalChars As Char() = "'".ToCharArray()
        Dim sb As New System.Text.StringBuilder
        For Each ch As Char In name1
            If Array.IndexOf(illegalChars, ch) = -1 Then
                sb.Append(ch)
            End If
        Next
        name1 = sb.ToString
        Dim illegalChars2 As Char() = "'".ToCharArray()
        Dim sb2 As New System.Text.StringBuilder
        For Each ch As Char In description
            If Array.IndexOf(illegalChars, ch) = -1 Then
                sb.Append(ch)
            End If
        Next
        description = sb2.ToString
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        addtodb()
    End Sub

    Public Sub addtodb()
        Dim Connection As MySqlConnection
        Dim execute As MySqlCommand
        Dim Reader2 As MySqlDataReader = Nothing

        x = ListBox5.Items.Count
        y = 0
        ProgressBar1.Maximum = x
        ProgressBar1.Value = y
        Connection = New MySqlConnection("server=" & My.Settings.host & ";user id=" & My.Settings.username & "; password=" & My.Settings.password & "; port=" & My.Settings.port & "; database=" & My.Settings.db & "; pooling=false")
        Connection.Open()
        Do Until y = x
            itemid = ListBox5.Items.Item(y)
            Label11.Text = "Adding to database:" & itemid & ". " & ListBox2.Items.Count & " item(s) added."
            Label11.Refresh()
            nodelist()

            checktext()
            writesql()
            execute = New MySqlCommand(thequery, Connection)
            Reader2 = execute.ExecuteReader
            Reader2.Close()
            ListBox5.Items.RemoveAt(y)
            ListBox2.Items.Add(itemid)
            banstatus = False

            x = ListBox5.Items.Count
            ProgressBar1.Value = ProgressBar1.Value + 1
        Loop
        Label11.Text = ListBox2.Items.Count & " new item(s) added."
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If TextBox2.Text = "" And TextBox3.Text = "" Then
            MsgBox("You didn't fill in any information")
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            MsgBox("You need to fill in a starting value")
        End If
        If TextBox3.Text = "" Then
            MsgBox("You need to fill in an ending value")
        End If
        x = TextBox2.Text
        y = TextBox3.Text
        If x > y Then
            MsgBox("Starting value can't be more then ending value.")
            Exit Sub
        End If

        Do Until x = y
            If ListBox1.Items.Contains(x) Then
            Else
                ListBox5.Items.Add(x)
            End If
            x = x + 1
        Loop
        checkdb()
    End Sub

    Public Function Listbox3Check() As Boolean
        Dim q As Integer
        Dim z As Integer
        q = 0
        z = ListBox3.Items.Count

        Do Until q = z
            If itemid = ListBox3.Items.Item(y) Then
                Return True
            End If
            q = q + 1
        Loop
    End Function

    Public Function Listbox4Check() As Boolean
        Dim q As Integer
        Dim z As Integer
        q = 0
        z = ListBox4.Items.Count

        Do Until q = z
            If itemid = ListBox4.Items.Item(y) Then
                Return True
            End If
            q = q + 1
        Loop
    End Function

    Public Sub checkdb()
        y = 0
        x = ListBox5.Items.Count
        ProgressBar1.Maximum = x
        ProgressBar1.Value = y

        Do Until y = x
            itemid = ListBox5.Items.Item(y)
            Label11.Text = "Check database and web: " & itemid
            Label11.Refresh()

            If Listbox3Check() = True Then
                ListBox5.Items.RemoveAt(y)
            Else
                Dim Connection As MySqlConnection
                Dim Query As MySqlCommand
                Dim Reader As MySqlDataReader = Nothing

                Connection = New MySqlConnection("server=" & My.Settings.host & ";user id=" & My.Settings.username & "; password=" & My.Settings.password & "; port=" & My.Settings.port & "; database=" & My.Settings.db & "; pooling=false")
                Connection.Open()

                If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
                    Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
                Else
                    Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
                End If

                Reader = Query.ExecuteReader()
                If Reader.HasRows And itemid <> "" Then
                    Reader.Close()
                    TextBox4.Text = TextBox4.Text & itemid & " | "
                    ListBox3.Items.Add(itemid)
                    ListBox5.Items.RemoveAt(y)
                Else
                    Reader.Close()
                    If Listbox4Check() = True Then
                        ListBox5.Items.RemoveAt(y)
                    Else
                        Dim url As String = ("http://wow.allakhazam.com/ihtml?" & itemid)
                        Dim webResponse3 As HttpWebResponse = Nothing
                        Dim webRequest3 As HttpWebRequest = HttpWebRequest.Create(url)
                        Dim srResp As StreamReader
                        Dim strIn As String
                        webResponse3 = DirectCast(webRequest3.GetResponse(), System.Net.HttpWebResponse)
                        srResp = New StreamReader(webResponse3.GetResponseStream())
                        strIn = srResp.ReadToEnd

                        If strIn.Length < 470 Then
                            TextBox7.Text = TextBox7.Text & itemid & " | "
                            ListBox4.Items.Add(itemid)
                            ListBox5.Items.RemoveAt(y)
                        Else
                            ListBox1.Items.Add(itemid)
                            ListBox5.Items.RemoveAt(y)
                            If CheckBox1.Checked = True Then
                                parsexml()
                                checktext()
                                writesql()
                                If banstatus = False Then
                                    Dim Execute As MySqlCommand
                                    Dim Reader2 As MySqlDataReader = Nothing
                                    Execute = New MySqlCommand(thequery, Connection)
                                    Reader2 = Execute.ExecuteReader
                                    Reader2.Close()
                                    ListBox2.Items.Add(itemid)
                                    ListBox1.Items.RemoveAt(y)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            x = ListBox5.Items.Count
            ProgressBar1.Value = ProgressBar1.Value + 1
        Loop
        If CheckBox1.Checked = True Then
            Label11.Text = ListBox2.Items.Count & " new item(s) added."
        Else
            Label11.Text = ListBox1.Items.Count & " new item(s) found."
        End If
        ToolStripStatusLabel1.Text = "Web connect status: Connected."
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        clearrange()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        itemid = TextBox1.Text
        If dbcheck() = True Then
            itemdelete()
            MsgBox(itemid & " deleted successfuly.")
        Else
            MsgBox(itemid & " not found in " & My.Settings.db & " .")
        End If
    End Sub

    Public Sub itemdelete()
        Dim Connection As MySqlConnection
        Dim Reader As MySqlDataReader = Nothing
        Dim Query As MySqlCommand

        Connection = New MySqlConnection("server=" & My.Settings.host & ";user id=" & My.Settings.username & "; password=" & My.Settings.password & "; port=" & My.Settings.port & "; database=" & My.Settings.db & "; pooling=false")
        Connection.Open()
        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("DELETE FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("DELETE FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If
        Reader = Query.ExecuteReader()
        Reader.Close()
    End Sub

    Public Sub additems()
        x = ListBox5.Items.Item(0)
        y = ListBox5.Items.Count

        Do While x = y
            writesql()
            x = x + 1
        Loop

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListBox5.Items.Clear()
    End Sub

    Private Sub ListBox5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox5.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim pt As Point
            pt.X = e.X
            pt.Y = e.Y
            Try
                ListBox5.SelectedIndex = ListBox5.IndexFromPoint(pt)
            Catch
            End Try
            If ListBox5.SelectedIndex >= 0 Then
                ContextMenuStrip1.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub ListBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim pt As Point
            pt.X = e.X
            pt.Y = e.Y
            Try
                ListBox2.SelectedIndex = ListBox2.IndexFromPoint(pt)
            Catch
            End Try
            If ListBox2.SelectedIndex >= 0 Then
                ContextMenuStrip2.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub ListBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox3.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim pt As Point
            pt.X = e.X
            pt.Y = e.Y
            Try
                ListBox3.SelectedIndex = ListBox3.IndexFromPoint(pt)
            Catch
            End Try
            If ListBox3.SelectedIndex >= 0 Then
                ContextMenuStrip3.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        itemid = ListBox1.SelectedItem
        nodelist()
        If entry = 0 Then
            If banstatus = False Then
                MsgBox("You have been banned by allakhazam.com for a while. Please set 'Multi Item Add min. Speed' >= 2000 ms.")
                ToolStripStatusLabel1.Text = "Web connect status: Banned."
                banstatus = True
            End If
        End If
        If entry <> 0 Then
            TextBox6.Text = name1
            TextBox8.Text = entry
            ToolStripStatusLabel1.Text = "Web connect status: Connected."
            WebBrowser5.Navigate("http://wow.allakhazam.com/" & itemicon)
        End If
        WebBrowser2.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        itemid = ListBox2.SelectedItem
        nodelist()
        If entry = 0 Then
            If banstatus = False Then
                MsgBox("You have been banned by allakhazam.com for a while. Please set 'Multi Item Add min. Speed' >= 2000 ms.")
                ToolStripStatusLabel1.Text = "Web connect status: Banned."
                banstatus = True
            End If
        End If
        If entry <> 0 Then
            TextBox6.Text = name1
            TextBox8.Text = entry
            ToolStripStatusLabel1.Text = "Web connect status: Connected."
            WebBrowser5.Navigate("http://wow.allakhazam.com/" & itemicon)
        End If
        WebBrowser2.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
    End Sub
    Private Sub ListBox3_SelectedIndex(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        itemid = ListBox3.SelectedItem
        nodelist()
        If entry = 0 Then
            If banstatus = False Then
                MsgBox("You have been banned by allakhazam.com for a while. Please set 'Multi Item Add min. Speed' >= 2000 ms.")
                ToolStripStatusLabel1.Text = "Web connect status: Banned."
                banstatus = True
            End If
        End If
        If entry <> 0 Then
            TextBox6.Text = name1
            TextBox8.Text = entry
            ToolStripStatusLabel1.Text = "Web connect status: Connected."
            WebBrowser5.Navigate("http://wow.allakhazam.com/" & itemicon)
        End If
        WebBrowser2.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
    End Sub

    Public Sub clearrange()
        TextBox2.Text = ""
        TextBox3.Text = ""
        CheckBox1.Checked = False
        ListBox5.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        TextBox4.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub RemoveAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem.Click
        ListBox5.Items.Clear()
    End Sub

    Private Sub AddToDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToDatabaseToolStripMenuItem.Click
        itemid = ListBox5.SelectedItem
        parsexml()
        checktext()
        writesql()

        Dim Connection As MySqlConnection
        Dim Query As MySqlCommand
        Dim Execute As MySqlCommand
        Dim Reader As MySqlDataReader = Nothing

        Connection = New MySqlConnection("server=" & My.Settings.host & ";user id=" & My.Settings.username & "; password=" & My.Settings.password & "; port=" & My.Settings.port & "; database=" & My.Settings.db & "; pooling=false")
        Connection.Open()

        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If

        Execute = New MySqlCommand(thequery, Connection)
        Reader = Execute.ExecuteReader
        Reader.Close()
        name1 = name1.Replace("\", "")
        MsgBox(itemid & " " & name1 & " added successfuly.")
        ListBox2.Items.Add(itemid)
        ListBox5.Items.Remove(ListBox5.SelectedItem)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.phanonic.smfnew.com")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("mailto:ctnyvz@gmail.com")
    End Sub

    Private Sub RemoveAllToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem2.Click
        ListBox2.Items.Remove(ListBox2.SelectedItem)
    End Sub

    Private Sub RemoveAllToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem1.Click
        ListBox3.Items.Remove(ListBox3.SelectedItem)
    End Sub

    Private Sub RemoveAllToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem3.Click
        ListBox2.Items.Clear()
    End Sub

    Private Sub RemoveAllToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem4.Click
        ListBox3.Items.Clear()
    End Sub

    Private Sub Listbox2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listbox2ToolStripMenuItem.Click
        itemid = ListBox2.SelectedItem
        itemdelete()
        MsgBox(itemid & " deleted successfuly.")
        ListBox2.Items.Remove(ListBox2.SelectedItem)
    End Sub

    Private Sub Lİstbox3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lİstbox3ToolStripMenuItem.Click
        itemid = ListBox3.SelectedItem
        itemdelete()
        MsgBox(itemid & " deleted successfuly.")
        ListBox3.Items.Remove(ListBox3.SelectedItem)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox3.Text = TextBox2.Text
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            itemid = TextBox1.Text
            If checkitem() = True Then
                nodelist()
                If entry = 0 Then
                    If banstatus = False Then
                        MsgBox("You have been banned by allakhazam.com for a while.")
                        ToolStripStatusLabel1.Text = "Web connect status: Banned."
                        banstatus = True
                    End If
                Else
                    TextBox5.Text = name1
                    WebBrowser4.Navigate("http://wow.allakhazam.com/" & itemicon)
                    ToolStripStatusLabel1.Text = "Web connect status: Connected."
                End If
            End If
            WebBrowser1.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
        End If
    End Sub

End Class